using System.Threading.Tasks;
using Confluent.Kafka;
using KafkaStudy.Api.Configuration;
using Microsoft.Extensions.Options;

namespace KafkaStudy.Api
{
    public class KafkaProducer<T>: IKafkaProducer<T>
    {
        private IProducer<Null, T> _producer;
        private string _topicName;
        private KafkaConfiguration _configuration;

        public KafkaProducer(IOptions<KafkaConfiguration> configuration)
        {
            _configuration = configuration.Value;

            var config = new ProducerConfig { BootstrapServers = _configuration.ConnectionString };

            _producer = new ProducerBuilder<Null, T>(config)
                .SetValueSerializer(new ProtobufSerializer<T>())
                .Build();

            _topicName = typeof(T).FullName;
        }
        
        public Task<DeliveryResult<Null, T>> Produce(string topicName, T message)
        {
            return _producer.ProduceAsync(topicName, new Message<Null, T> {  Value = message });
        }

        public Task<DeliveryResult<Null, T>> Produce(T message)
        {
            return Produce(_topicName, message);
        }
        
        public void Dispose()
        {
            _producer.Dispose();
        }
    }
}
