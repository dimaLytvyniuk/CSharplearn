using System;
using System.IO;
using Confluent.Kafka;
using ProtoBuf;
using SerializationContext = Confluent.Kafka.SerializationContext;

namespace KafkaStudy.Api
{
    public class ProtobufSerializer<T>: ISerializer<T>, IDeserializer<T>
    {
        public byte[] Serialize(T data, SerializationContext context)
        {
            using (var memoryStream = new MemoryStream())
            {
                Serializer.Serialize(memoryStream, data);
                return memoryStream.ToArray();
            }
            
        }

        public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            using (var memoryStream = new MemoryStream(data.ToArray()))
            {
                return Serializer.Deserialize<T>(memoryStream);
            }
        }
    }
}