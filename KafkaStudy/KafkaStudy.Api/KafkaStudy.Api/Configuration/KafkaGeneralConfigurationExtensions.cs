using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KafkaStudy.Api.Configuration
{
    public static class KafkaGeneralConfigurationExtensions
    {
        public static IServiceCollection AddKafka(
            this IServiceCollection services,
            IConfiguration configuration,
            Action<IKafkaGeneralOptionsBuilder> optionsBuilderAction)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (optionsBuilderAction == null)
                throw new ArgumentNullException(nameof(optionsBuilderAction));

            services.Configure<KafkaConfiguration>(configuration.GetSection("Kafka"));
            services.AddSingleton(typeof(IKafkaProducer<>), typeof(KafkaProducer<>));
            
            var options = new KafkaGeneralOptionsBuilder(services);
            optionsBuilderAction(options);
            
            return services;
        }
    }
}
