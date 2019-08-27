using System;
using Microsoft.Extensions.DependencyInjection;

namespace KafkaStudy.Api.Configuration
{
    public static class KafkaProducerConfigurationExtensions
    {
        public static IServiceCollection AddKafkaProducers(
            this IServiceCollection services,
            Action<IKafkaProducersOptionsBuilder> optionsBuilderAction)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            
            if (optionsBuilderAction == null)
                throw new ArgumentNullException(nameof(optionsBuilderAction));

            var producersOptionsBuilder = new KafkaProducersOptionsBuilder(services);
            optionsBuilderAction(producersOptionsBuilder);
            
            return services;
        }
    }
}