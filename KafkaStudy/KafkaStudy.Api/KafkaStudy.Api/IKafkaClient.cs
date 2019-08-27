using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace KafkaStudy.Api
{
    public interface IKafkaProducer<T>: IDisposable
    {
        Task<DeliveryResult<Null, T>> Produce(string topicName, T message);
        Task<DeliveryResult<Null, T>> Produce(T message);
    }
}
