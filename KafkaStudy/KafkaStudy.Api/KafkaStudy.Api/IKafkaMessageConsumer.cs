using System.Threading.Tasks;

namespace KafkaStudy.Api
{
    public interface IKafkaMessageConsumer
    {
        Task<KafkaConsumerResultModel> ConsumeAsync(byte[] message);
    }
}
