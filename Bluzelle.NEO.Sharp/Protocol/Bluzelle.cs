// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: bluzelle.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from bluzelle.proto</summary>
public static partial class BluzelleReflection {

  #region Descriptor
  /// <summary>File descriptor for bluzelle.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static BluzelleReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "Cg5ibHV6ZWxsZS5wcm90bxoOZGF0YWJhc2UucHJvdG8iPQoHYnpuX21zZxIb",
          "CgJkYhgKIAEoCzINLmRhdGFiYXNlX21zZ0gAEg4KBGpzb24YCyABKAlIAEIF",
          "CgNtc2diBnByb3RvMw=="));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { global::DatabaseReflection.Descriptor, },
        new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::bzn_msg), global::bzn_msg.Parser, new[]{ "Db", "Json" }, new[]{ "Msg" }, null, null)
        }));
  }
  #endregion

}
#region Messages
public sealed partial class bzn_msg : pb::IMessage<bzn_msg> {
  private static readonly pb::MessageParser<bzn_msg> _parser = new pb::MessageParser<bzn_msg>(() => new bzn_msg());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<bzn_msg> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::BluzelleReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bzn_msg() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bzn_msg(bzn_msg other) : this() {
    switch (other.MsgCase) {
      case MsgOneofCase.Db:
        Db = other.Db.Clone();
        break;
      case MsgOneofCase.Json:
        Json = other.Json;
        break;
    }

    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bzn_msg Clone() {
    return new bzn_msg(this);
  }

  /// <summary>Field number for the "db" field.</summary>
  public const int DbFieldNumber = 10;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public global::database_msg Db {
    get { return msgCase_ == MsgOneofCase.Db ? (global::database_msg) msg_ : null; }
    set {
      msg_ = value;
      msgCase_ = value == null ? MsgOneofCase.None : MsgOneofCase.Db;
    }
  }

  /// <summary>Field number for the "json" field.</summary>
  public const int JsonFieldNumber = 11;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Json {
    get { return msgCase_ == MsgOneofCase.Json ? (string) msg_ : ""; }
    set {
      msg_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      msgCase_ = MsgOneofCase.Json;
    }
  }

  private object msg_;
  /// <summary>Enum of possible cases for the "msg" oneof.</summary>
  public enum MsgOneofCase {
    None = 0,
    Db = 10,
    Json = 11,
  }
  private MsgOneofCase msgCase_ = MsgOneofCase.None;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public MsgOneofCase MsgCase {
    get { return msgCase_; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void ClearMsg() {
    msgCase_ = MsgOneofCase.None;
    msg_ = null;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as bzn_msg);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(bzn_msg other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (!object.Equals(Db, other.Db)) return false;
    if (Json != other.Json) return false;
    if (MsgCase != other.MsgCase) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    if (msgCase_ == MsgOneofCase.Db) hash ^= Db.GetHashCode();
    if (msgCase_ == MsgOneofCase.Json) hash ^= Json.GetHashCode();
    hash ^= (int) msgCase_;
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
    if (msgCase_ == MsgOneofCase.Db) {
      output.WriteRawTag(82);
      output.WriteMessage(Db);
    }
    if (msgCase_ == MsgOneofCase.Json) {
      output.WriteRawTag(90);
      output.WriteString(Json);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    if (msgCase_ == MsgOneofCase.Db) {
      size += 1 + pb::CodedOutputStream.ComputeMessageSize(Db);
    }
    if (msgCase_ == MsgOneofCase.Json) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Json);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(bzn_msg other) {
    if (other == null) {
      return;
    }
    switch (other.MsgCase) {
      case MsgOneofCase.Db:
        if (Db == null) {
          Db = new global::database_msg();
        }
        Db.MergeFrom(other.Db);
        break;
      case MsgOneofCase.Json:
        Json = other.Json;
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
        case 82: {
          global::database_msg subBuilder = new global::database_msg();
          if (msgCase_ == MsgOneofCase.Db) {
            subBuilder.MergeFrom(Db);
          }
          input.ReadMessage(subBuilder);
          Db = subBuilder;
          break;
        }
        case 90: {
          Json = input.ReadString();
          break;
        }
      }
    }
  }

}

#endregion


#endregion Designer generated code
