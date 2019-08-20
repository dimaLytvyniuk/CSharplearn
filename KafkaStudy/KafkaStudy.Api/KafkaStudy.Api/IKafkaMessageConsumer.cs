using System.Threading.Tasks;

namespace KafkaStudy.Api
{
    public interface IKafkaMessageConsumer<T>
    {
        Task ConsumeAsync(T message);
    }
}
