using System.Threading.Tasks;

namespace KafkaStudy.Api
{
    internal interface IKafkaMessageConsumer
    {
        Task<KafkaConsumerResultModel> ConsumeAsync(byte[] message);
    }
}
