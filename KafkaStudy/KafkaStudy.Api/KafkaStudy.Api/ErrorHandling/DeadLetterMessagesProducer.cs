using System.Threading.Tasks;
using Confluent.Kafka;
using KafkaStudy.Api.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace KafkaStudy.Api.ErrorHandling
{
    public class DeadLetterMessagesProducer: IDeadLetterMessagesProducer
    {
        private IProducer<Null, string> _producer;
        private KafkaConfiguration _configuration;

        public DeadLetterMessagesProducer(IOptions<KafkaConfiguration> configuration)
        {
            _configuration = configuration.Value;
            var config = new ProducerConfig
            {
                BootstrapServers = _configuration.ConnectionString
            };
            
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public Task<DeliveryResult<Null, string>> Produce(string topicName, KafkaErrorMessage message)
        {
            var serializedObject = JsonConvert.SerializeObject(message);
            return _producer.ProduceAsync($"{topicName}_error", new Message<Null, string>() {Value = serializedObject});
        }

        public void Dispose()
        {
            _producer.Dispose();
        }
    }
}