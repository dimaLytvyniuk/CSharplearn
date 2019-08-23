namespace KafkaStudy.Api
{
    public interface IMessageSerializer<T>
    {
        byte[] Serialize(T data);
        T Deserialize(byte[] data);
    }
}