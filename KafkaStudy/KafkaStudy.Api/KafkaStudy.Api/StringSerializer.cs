using System;
using System.Text;
using Confluent.Kafka;

namespace KafkaStudy.Api
{
    public class StringSerializer: IMessageSerializer<string>
    {
        public byte[] Serialize(string data, SerializationContext context)
        {
            if (data == null)
            {
                return null;
            }

            return Encoding.UTF8.GetBytes(data);
        }

        public string Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            if (isNull)
                return null;
            
            return Encoding.UTF8.GetString(data);
        }

        public byte[] Serialize(string data)
        {
            if (data == null)
            {
                return null;
            }

            return Encoding.UTF8.GetBytes(data);
        }

        public string Deserialize(byte[] data)
        {
            if (data == null)
                return null;
            
            return Encoding.UTF8.GetString(data);
        }
    }
}
