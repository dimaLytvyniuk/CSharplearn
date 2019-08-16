namespace KafkaStudy.Api
{
    public interface IKafkaMessageHandler<T>
    {
        void OnMessage(T message);
    }
}