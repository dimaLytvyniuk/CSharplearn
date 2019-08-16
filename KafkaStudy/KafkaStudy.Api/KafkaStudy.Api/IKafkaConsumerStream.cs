using System;

namespace KafkaStudy.Api
{
    public interface IKafkaConsumerStream<T>
    {
        void Publish(T message);
        void Subscribe(string subscriberName, Action<T> action);
    }
}