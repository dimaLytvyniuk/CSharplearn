using System;
using System.Threading.Tasks;

namespace KafkaStudy.Api
{
    public interface IKafkaConsumerStream<T>
    {
        void Publish(T message);
        void Subscribe(string subscriberName, Func<T, Task> action);
    }
}