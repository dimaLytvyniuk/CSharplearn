using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

namespace KafkaStudy.Api
{
    public class KafkaProducer<T>: IKafkaProducer<T>
    {
        private IProducer<Null, T> _producer;
        private string _topicName;
        
        public KafkaProducer(IConfiguration configuration, string topicName): this(configuration)
        {
            _topicName = topicName;
        }

        public KafkaProducer(IConfiguration globalconf)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

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
