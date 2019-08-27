namespace KafkaStudy.Api.Configuration
{
    public interface IKafkaProducersOptionsBuilder
    { 
        void AddProducer<T>();
        void AddProducer<T>(string topicName);
    }
}
