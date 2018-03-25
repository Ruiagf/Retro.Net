﻿using System;
using System.IO;
using Google.Protobuf;
using LZ4;
using Retro.Net.Api.RealTime.Extensions;

namespace Retro.Net.Api.RealTime
{
    public class ProtoMessageSerializer
    {
        private byte[] _protoBuffer;
        private byte[] _lz4Buffer;

        public ArraySegment<byte> ToCompressedArraySegment(IMessage message, ref byte[] outputBuffer)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var protoLength = message.CalculateSize();
            CheckBufferSize(ref _protoBuffer, protoLength);
            
            using (var output = new CodedOutputStream(_protoBuffer))
            {
                message.WriteTo(output);

                if (output.Position != protoLength)
                {
                    throw new InvalidOperationException("Did not write as much data as expected.");
                }
            }

            var lz4Length = LZ4Codec.MaximumOutputLength(protoLength);
            CheckBufferSize(ref _lz4Buffer, lz4Length);

            lz4Length = LZ4Codec.Encode(_protoBuffer, 0, protoLength, _lz4Buffer, 0, lz4Length);
            CheckBufferSize(ref outputBuffer, lz4Length + sizeof(int) + 1); // plus the maximum length of an lsb integer.

            var outputLength = lz4Length;

            using (var stream = new MemoryStream(outputBuffer))
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write7BitEncodedInt(protoLength);
                writer.Flush();
                outputLength += (int) stream.Position;
                writer.Write(_lz4Buffer, 0, lz4Length);
            }

            return outputBuffer.Segment(outputLength);
        }

        public TMessage FromCompressedArraySegment<TMessage>(ArraySegment<byte> segment, MessageParser<TMessage> parser)
            where TMessage : IMessage<TMessage>
        {
            using (var stream = new MemoryStream(segment.Array, segment.Offset, segment.Count))
            using (var reader = new BinaryReader(stream))
            {
                var protoLength = reader.Read7BitEncodedInt();
                CheckBufferSize(ref _protoBuffer, protoLength);
                var offset = segment.Offset + (int) stream.Position;
                LZ4Codec.Decode(segment.Array, offset, segment.Count - offset, _protoBuffer, protoLength);
                return parser.ParseFrom(_protoBuffer, 0, protoLength);
            }
        }

        private static void CheckBufferSize(ref byte[] buffer, int requiredSize)
        {
            if (buffer == null || requiredSize > buffer.Length)
            {
                buffer = new byte[requiredSize];
            }
        }
    }
}
