using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KafkaStudy.Api.Configuration
{
    internal class KafkaProducersOptionsBuilder: IKafkaProducersOptionsBuilder
    {
        private readonly IServiceCollection _services;
        
        public KafkaProducersOptionsBuilder(IServiceCollection services)
        {
            _services = services;
        }
        
        public void AddProducer<T>()
        {
            _services.AddSingleton<IKafkaProducer<T>>(sp =>
            {
                var kafkaProducer = new KafkaProducer<T>(sp.GetRequiredService<IConfiguration>());
                return kafkaProducer;
            });
        }

        public void AddProducer<T>(string topicName)
        {
            _services.AddSingleton<IKafkaProducer<T>>(sp =>
            {
                var kafkaProducer = new KafkaProducer<T>(sp.GetRequiredService<IConfiguration>(), topicName);
                return kafkaProducer;
            });
        }
    }
}
