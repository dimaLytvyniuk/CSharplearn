using System.Threading.Tasks;
using Confluent.Kafka;

namespace KafkaStudy.Api.ErrorHandling
{
    public interface IDeadLetterMessagesProducer
    {
        Task<DeliveryResult<Null, string>> Produce(string topicName, KafkaErrorMessage message);
    }
}