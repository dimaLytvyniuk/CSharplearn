using System.Threading.Tasks;

namespace KafkaStudy.Api
{
    public interface IKafkaMessageHandler<T>
    {
        Task OnMessageAsync(T message);
    }
}