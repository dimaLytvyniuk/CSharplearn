using System;
using System.IO;
using ProtoBuf;
using SerializationContext = Confluent.Kafka.SerializationContext;

namespace KafkaStudy.Api
{
    public class ProtobufSerializer<T>: IMessageSerializer<T>
    {
        public byte[] Serialize(T data, SerializationContext context)
        {
            return Serialize(data);
        }

        public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            return Deserialize(data.ToArray());
        }

        public byte[] Serialize(T data)
        {
            using (var memoryStream = new MemoryStream())
            {
                Serializer.Serialize(memoryStream, data);
                return memoryStream.ToArray();
            }
        }

        public T Deserialize(byte[] data)
        {
            using (var memoryStream = new MemoryStream(data))
            {
                return Serializer.Deserialize<T>(memoryStream);
            }
        }
    }
}
