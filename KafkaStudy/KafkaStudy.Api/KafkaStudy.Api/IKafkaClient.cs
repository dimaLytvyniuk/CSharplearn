using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace KafkaStudy.Api
{
    public interface IKafkaClient: IDisposable
    {
        Task<DeliveryResult<Null, User>> Produce(string topic, string key, string val);
    }
}