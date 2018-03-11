// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: gameboy.event.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Retro.Net.Api.RealTime.Messages.Event {

  /// <summary>Holder for reflection information generated from gameboy.event.proto</summary>
  public static partial class GameboyEventReflection {

    #region Descriptor
    /// <summary>File descriptor for gameboy.event.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static GameboyEventReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChNnYW1lYm95LmV2ZW50LnByb3RvGhxnYW1lYm95LmV2ZW50Lm1lc3NhZ2Vz",
            "LnByb3RvIrwBCgxHYW1lQm95RXZlbnQSIQoFZnJhbWUYASABKAsyEC5HYW1l",
            "Qm95R3B1RnJhbWVIABI0ChBwdWJsaXNoZWRNZXNzYWdlGAIgASgLMhguR2Ft",
            "ZUJveVB1Ymxpc2hlZE1lc3NhZ2VIABIkCgVlcnJvchgDIAEoCzITLkdhbWVC",
            "b3lTZXJ2ZXJFcnJvckgAEiQKBXN0YXRlGAQgASgLMhMuR2FtZUJveUNsaWVu",
            "dFN0YXRlSABCBwoFdmFsdWVCKKoCJVJldHJvLk5ldC5BcGkuUmVhbFRpbWUu",
            "TWVzc2FnZXMuRXZlbnRiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Retro.Net.Api.RealTime.Messages.Event.GameboyEventMessagesReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Retro.Net.Api.RealTime.Messages.Event.GameBoyEvent), global::Retro.Net.Api.RealTime.Messages.Event.GameBoyEvent.Parser, new[]{ "Frame", "PublishedMessage", "Error", "State" }, new[]{ "Value" }, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// An event specific to GameBoy clients published by Retro.Net.Api.
  /// </summary>
  public sealed partial class GameBoyEvent : pb::IMessage<GameBoyEvent> {
    private static readonly pb::MessageParser<GameBoyEvent> _parser = new pb::MessageParser<GameBoyEvent>(() => new GameBoyEvent());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GameBoyEvent> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Retro.Net.Api.RealTime.Messages.Event.GameboyEventReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameBoyEvent() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameBoyEvent(GameBoyEvent other) : this() {
      switch (other.ValueCase) {
        case ValueOneofCase.Frame:
          Frame = other.Frame.Clone();
          break;
        case ValueOneofCase.PublishedMessage:
          PublishedMessage = other.PublishedMessage.Clone();
          break;
        case ValueOneofCase.Error:
          Error = other.Error.Clone();
          break;
        case ValueOneofCase.State:
          State = other.State.Clone();
          break;
      }

      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GameBoyEvent Clone() {
      return new GameBoyEvent(this);
    }

    /// <summary>Field number for the "frame" field.</summary>
    public const int FrameFieldNumber = 1;
    /// <summary>
    /// A single GameBoy GPU frame.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Retro.Net.Api.RealTime.Messages.Event.GameBoyGpuFrame Frame {
      get { return valueCase_ == ValueOneofCase.Frame ? (global::Retro.Net.Api.RealTime.Messages.Event.GameBoyGpuFrame) value_ : null; }
      set {
        value_ = value;
        valueCase_ = value == null ? ValueOneofCase.None : ValueOneofCase.Frame;
      }
    }

    /// <summary>Field number for the "publishedMessage" field.</summary>
    public const int PublishedMessageFieldNumber = 2;
    /// <summary>
    /// A text message published to all connected GameBoy clients by Retro.Net.Api.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Retro.Net.Api.RealTime.Messages.Event.GameBoyPublishedMessage PublishedMessage {
      get { return valueCase_ == ValueOneofCase.PublishedMessage ? (global::Retro.Net.Api.RealTime.Messages.Event.GameBoyPublishedMessage) value_ : null; }
      set {
        value_ = value;
        valueCase_ = value == null ? ValueOneofCase.None : ValueOneofCase.PublishedMessage;
      }
    }

    /// <summary>Field number for the "error" field.</summary>
    public const int ErrorFieldNumber = 3;
    /// <summary>
    /// An error message published to all connected GameBoy clients by Retro.Net.Api.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Retro.Net.Api.RealTime.Messages.Event.GameBoyServerError Error {
      get { return valueCase_ == ValueOneofCase.Error ? (global::Retro.Net.Api.RealTime.Messages.Event.GameBoyServerError) value_ : null; }
      set {
        value_ = value;
        valueCase_ = value == null ? ValueOneofCase.None : ValueOneofCase.Error;
      }
    }

    /// <summary>Field number for the "state" field.</summary>
    public const int StateFieldNumber = 4;
    /// <summary>
    /// The state of a GameBoy websocket connection.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Retro.Net.Api.RealTime.Messages.Event.GameBoyClientState State {
      get { return valueCase_ == ValueOneofCase.State ? (global::Retro.Net.Api.RealTime.Messages.Event.GameBoyClientState) value_ : null; }
      set {
        value_ = value;
        valueCase_ = value == null ? ValueOneofCase.None : ValueOneofCase.State;
      }
    }

    private object value_;
    /// <summary>Enum of possible cases for the "value" oneof.</summary>
    public enum ValueOneofCase {
      None = 0,
      Frame = 1,
      PublishedMessage = 2,
      Error = 3,
      State = 4,
    }
    private ValueOneofCase valueCase_ = ValueOneofCase.None;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ValueOneofCase ValueCase {
      get { return valueCase_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearValue() {
      valueCase_ = ValueOneofCase.None;
      value_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GameBoyEvent);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GameBoyEvent other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Frame, other.Frame)) return false;
      if (!object.Equals(PublishedMessage, other.PublishedMessage)) return false;
      if (!object.Equals(Error, other.Error)) return false;
      if (!object.Equals(State, other.State)) return false;
      if (ValueCase != other.ValueCase) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (valueCase_ == ValueOneofCase.Frame) hash ^= Frame.GetHashCode();
      if (valueCase_ == ValueOneofCase.PublishedMessage) hash ^= PublishedMessage.GetHashCode();
      if (valueCase_ == ValueOneofCase.Error) hash ^= Error.GetHashCode();
      if (valueCase_ == ValueOneofCase.State) hash ^= State.GetHashCode();
      hash ^= (int) valueCase_;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (valueCase_ == ValueOneofCase.Frame) {
        output.WriteRawTag(10);
        output.WriteMessage(Frame);
      }
      if (valueCase_ == ValueOneofCase.PublishedMessage) {
        output.WriteRawTag(18);
        output.WriteMessage(PublishedMessage);
      }
      if (valueCase_ == ValueOneofCase.Error) {
        output.WriteRawTag(26);
        output.WriteMessage(Error);
      }
      if (valueCase_ == ValueOneofCase.State) {
        output.WriteRawTag(34);
        output.WriteMessage(State);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (valueCase_ == ValueOneofCase.Frame) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Frame);
      }
      if (valueCase_ == ValueOneofCase.PublishedMessage) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(PublishedMessage);
      }
      if (valueCase_ == ValueOneofCase.Error) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Error);
      }
      if (valueCase_ == ValueOneofCase.State) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(State);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GameBoyEvent other) {
      if (other == null) {
        return;
      }
      switch (other.ValueCase) {
        case ValueOneofCase.Frame:
          if (Frame == null) {
            Frame = new global::Retro.Net.Api.RealTime.Messages.Event.GameBoyGpuFrame();
          }
          Frame.MergeFrom(other.Frame);
          break;
        case ValueOneofCase.PublishedMessage:
          if (PublishedMessage == null) {
            PublishedMessage = new global::Retro.Net.Api.RealTime.Messages.Event.GameBoyPublishedMessage();
          }
          PublishedMessage.MergeFrom(other.PublishedMessage);
          break;
        case ValueOneofCase.Error:
          if (Error == null) {
            Error = new global::Retro.Net.Api.RealTime.Messages.Event.GameBoyServerError();
          }
          Error.MergeFrom(other.Error);
          break;
        case ValueOneofCase.State:
          if (State == null) {
            State = new global::Retro.Net.Api.RealTime.Messages.Event.GameBoyClientState();
          }
          State.MergeFrom(other.State);
          break;
      }

      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            global::Retro.Net.Api.RealTime.Messages.Event.GameBoyGpuFrame subBuilder = new global::Retro.Net.Api.RealTime.Messages.Event.GameBoyGpuFrame();
            if (valueCase_ == ValueOneofCase.Frame) {
              subBuilder.MergeFrom(Frame);
            }
            input.ReadMessage(subBuilder);
            Frame = subBuilder;
            break;
          }
          case 18: {
            global::Retro.Net.Api.RealTime.Messages.Event.GameBoyPublishedMessage subBuilder = new global::Retro.Net.Api.RealTime.Messages.Event.GameBoyPublishedMessage();
            if (valueCase_ == ValueOneofCase.PublishedMessage) {
              subBuilder.MergeFrom(PublishedMessage);
            }
            input.ReadMessage(subBuilder);
            PublishedMessage = subBuilder;
            break;
          }
          case 26: {
            global::Retro.Net.Api.RealTime.Messages.Event.GameBoyServerError subBuilder = new global::Retro.Net.Api.RealTime.Messages.Event.GameBoyServerError();
            if (valueCase_ == ValueOneofCase.Error) {
              subBuilder.MergeFrom(Error);
            }
            input.ReadMessage(subBuilder);
            Error = subBuilder;
            break;
          }
          case 34: {
            global::Retro.Net.Api.RealTime.Messages.Event.GameBoyClientState subBuilder = new global::Retro.Net.Api.RealTime.Messages.Event.GameBoyClientState();
            if (valueCase_ == ValueOneofCase.State) {
              subBuilder.MergeFrom(State);
            }
            input.ReadMessage(subBuilder);
            State = subBuilder;
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
