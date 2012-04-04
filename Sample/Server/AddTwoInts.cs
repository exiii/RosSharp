﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RosSharp.Message;
using RosSharp.Service;
namespace RosSharp
{
    public class AddTwoInts : ServiceBase<AddTwoInts.Request, AddTwoInts.Response>
    {
        public AddTwoInts()
        {
        }
        public AddTwoInts(Func<Request, Response> action)
            : base(action)
        {
        }
        public override string ServiceType
        {
            get { return "AddTwoInts"; }
        }
        public override string Md5Sum
        {
            get { return "6a2e34150c00229791cc89ff309fff21"; }
        }
        public override string ServiceDefinition
        {
            get { return "int64 a\nint64 b---\nint64 sum"; }
        }
        public class Request : IMessage
        {
            public Request()
            {
            }
            public Request(BinaryReader br)
            {
                Deserialize(br);
            }
            public long a { get; set; }
            public long b { get; set; }
            public string MessageType
            {
                get { return "AddTwoIntsRequest"; }
            }
            public string Md5Sum
            {
                get { return "36d09b846be0b371c5f190354dd3153e"; }
            }
            public string MessageDefinition
            {
                get { return "int64 a\nint64 b"; }
            }
            public void Serialize(BinaryWriter bw)
            {
                bw.Write(a);
                bw.Write(b);
            }
            public void Deserialize(BinaryReader br)
            {
                a = br.ReadInt64();
                b = br.ReadInt64();
            }
            public int SerializeLength
            {
                get { return 8 + 8; }
            }
            public bool Equals(Request other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return other.a.Equals(a) && other.b.Equals(b);
            }
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != typeof(Request)) return false;
                return Equals((Request)obj);
            }
            public override int GetHashCode()
            {
                unchecked
                {
                    int result = 0;
                    result = (result * 397) ^ a.GetHashCode();
                    result = (result * 397) ^ b.GetHashCode();
                    return result;
                }
            }
        }
        public class Response : IMessage
        {
            public Response()
            {
            }
            public Response(BinaryReader br)
            {
                Deserialize(br);
            }
            public long sum { get; set; }
            public string MessageType
            {
                get { return "AddTwoIntsResponse"; }
            }
            public string Md5Sum
            {
                get { return "b88405221c77b1878a3cbbfff53428d7"; }
            }
            public string MessageDefinition
            {
                get { return "int64 sum"; }
            }
            public void Serialize(BinaryWriter bw)
            {
                bw.Write(sum);
            }
            public void Deserialize(BinaryReader br)
            {
                sum = br.ReadInt64();
            }
            public int SerializeLength
            {
                get { return 8; }
            }
            public bool Equals(Response other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return other.sum.Equals(sum);
            }
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != typeof(Response)) return false;
                return Equals((Response)obj);
            }
            public override int GetHashCode()
            {
                unchecked
                {
                    int result = 0;
                    result = (result * 397) ^ sum.GetHashCode();
                    return result;
                }
            }
        }
    }
}
