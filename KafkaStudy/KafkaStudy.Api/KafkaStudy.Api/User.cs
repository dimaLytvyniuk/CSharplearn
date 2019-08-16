using System;
using ProtoBuf;

namespace KafkaStudy.Api
{
    [ProtoContract]
    public class User
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ProtoMember(2)]
        public string MessageKey { get; set; }
    }
}