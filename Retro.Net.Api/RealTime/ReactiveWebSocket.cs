using System;
using System.Net.WebSockets;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Retro.Net.Api.RealTime.Extensions;
using Retro.Net.Api.RealTime.Messages.Command;
using Retro.Net.Api.RealTime.Messages.Event;

namespace Retro.Net.Api.RealTime
{
    public class ReactiveWebSocket : ISubject<GameBoyEvent, GameBoyCommand>, IDisposable
    {
        private const int InitialBufferSize = 256;
        private const int BufferSizeIncrement = 64;

        private readonly SemaphoreSlim _semaphore;
        private readonly CancellationTokenSource _disposing;
        private readonly WebSocket _socket;
        private bool _hasSubscriber;
        private bool _disposed;

        // We need 2 serializers as this impl is not thread safe.
        private readonly ProtoMessageSerializer _deSerializer;
        private readonly ProtoMessageSerializer _serializer;
        private byte[] _outputBuffer;

        public ReactiveWebSocket(WebSocket socket, CancellationToken token)
        {
            _socket = socket;
            _disposing = new CancellationTokenSource();
            _semaphore = new SemaphoreSlim(1, 1);

            _deSerializer = new ProtoMessageSerializer();
            _serializer = new ProtoMessageSerializer();

            // this is a hack... linked token sources don't seem to work here. dunno if it's because the token is from MVC?
            token.Register(_disposing.Cancel);
        }

        public void OnCompleted() => Task.Run(CloseAsync);

        public void OnError(Exception error) => Task.Run(CloseAsync);

        public void OnNext(GameBoyEvent value) => Task.Run(() => OnNextAsync(value));

        public IDisposable Subscribe(IObserver<GameBoyCommand> observer)
        {
            lock (_disposing)
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(nameof(ReactiveWebSocket));
                }

                if (_hasSubscriber)
                {
                    throw new InvalidOperationException("Only a single subscriber supported per websocket");
                }
                _hasSubscriber = true;
            }

            Task.Run(() => ReceiveAsync(observer), _disposing.Token);
            return this;
        }

        private async Task ReceiveAsync(IObserver<GameBoyCommand> observer)
        {
            var buffer = new byte[InitialBufferSize];
            while (!_disposing.IsCancellationRequested)
            {
                try
                {
                    var result = await _socket.ReceiveAsync(buffer, _disposing.Token);
                    var length = result.Count;
                    while (!result.EndOfMessage)
                    {
                        if (length >= buffer.Length)
                        {
                            Array.Resize(ref buffer, buffer.Length + BufferSizeIncrement);
                        }

                        var segment = buffer.EndSegment(length);
                        result = await _socket.ReceiveAsync(segment, _disposing.Token);
                        length += result.Count;
                    }

                    switch (result.MessageType)
                    {
                        case WebSocketMessageType.Binary:
                            var proto = _deSerializer.FromCompressedArraySegment(buffer.Segment(length), GameBoyCommand.Parser);
                            observer.OnNext(proto);
                            break;

                        case WebSocketMessageType.Text:
                            observer.OnNext(GameBoyCommand.Parser.ParseJson(Encoding.UTF8.GetString(buffer, 0, length)));
                            break;

                        case WebSocketMessageType.Close:
                            await CloseAsync();
                            observer.OnCompleted();
                            return;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                catch (OperationCanceledException)
                {
                    observer.OnCompleted();
                    break;
                }
                catch (Exception e)
                {
                    observer.OnError(e);
                    break;
                }
            }
        }
        
        private async Task CloseAsync()
        {
            if (_socket.State == WebSocketState.Closed || _socket.State == WebSocketState.CloseSent)
            {
                return;
            }

            await _semaphore.WaitAsync(_disposing.Token);
            try
            {
                await _socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task OnNextAsync(GameBoyEvent value)
        {
            if (_disposing.IsCancellationRequested)
            {
                // Do not throw.
                return;
            }

            await _semaphore.WaitAsync(_disposing.Token);
            try
            {
                if (_socket.State == WebSocketState.Open)
                {
                    var message = _serializer.ToCompressedArraySegment(value, ref _outputBuffer);
                    await _socket.SendAsync(message, WebSocketMessageType.Binary, true, _disposing.Token);
                }
                else if (_socket.State == WebSocketState.CloseReceived)
                {
                    await _socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }
        
        public void Dispose()
        {
            lock (_disposing)
            {
                if (_disposed)
                {
                    return;
                }
                _disposed = true;
            }

            _disposing.Cancel();
            _disposing.Dispose();
        }
    }
}