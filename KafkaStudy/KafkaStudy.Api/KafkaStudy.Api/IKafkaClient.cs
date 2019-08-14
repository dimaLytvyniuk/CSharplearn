using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace KafkaStudy.Api
{
    public interface IKafkaClient: IDisposable
    {
        Task<DeliveryResult<Null, string>> Produce(string key, string val);
    }
}