using System.Threading.Tasks;

namespace KafkaStudy.Api
{
    public interface IKafkaMessageConsumer
    {
        Task ConsumeAsync(byte[] message);
    }
}
