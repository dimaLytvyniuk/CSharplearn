using System;
using Microsoft.Extensions.DependencyInjection;

namespace KafkaStudy.Api.Configuration
{
    public static class KafkaGeneralConfigurationExtensions
    {
        public static IServiceCollection AddKafka(
            this IServiceCollection services,
            Action<IKafkaGeneralOptionsBuilder> optionsBuilderAction)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (optionsBuilderAction == null)
                throw new ArgumentNullException(nameof(optionsBuilderAction));

            var options = new KafkaGeneralOptionsBuilder(services);
            optionsBuilderAction(options);
            
            return services;
        }
    }
}
