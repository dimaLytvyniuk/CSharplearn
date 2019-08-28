using Confluent.Kafka;

namespace KafkaStudy.Api
{
    public interface IMessageSerializer<T>: ISerializer<T>, IDeserializer<T>
    {
        byte[] Serialize(T data);
        T Deserialize(byte[] data);
    }
}