namespace KafkaStudy.Api
{
    public interface IKafkaMessageConsumerFactory
    {
        IKafkaMessageConsumer GetMessageConsumer(string topic);
    }
}
