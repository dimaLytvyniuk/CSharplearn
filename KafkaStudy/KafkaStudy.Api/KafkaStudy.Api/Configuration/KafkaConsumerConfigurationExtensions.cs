using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace KafkaStudy.Api.Configuration
{
    internal static class KafkaConsumerConfigurationExtensions
    {
        public static IServiceCollection AddKafkaConsumer(
            this IServiceCollection services,
            Action<IKafkaConsumerOptionsBuilder> optionsBuilderAction)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            
            if (optionsBuilderAction == null)
                throw new ArgumentNullException(nameof(optionsBuilderAction));

            var optionsBuilder = new KafkaConsumerOptionsBuilder(services);
            optionsBuilderAction(optionsBuilder);
            
            AddBackgroundConsumers(services, optionsBuilder);

            return services;
        }

        private static void AddBackgroundConsumers(
            IServiceCollection services,
            IKafkaConsumerOptionsBuilder optionsBuilder)
        {
            var topicsNames = optionsBuilder.TopicConsumerTypes.Keys.ToList();
            
            for (var i = 0; i < optionsBuilder.PartitionCount; i++)
            {
                services.AddSingleton<IHostedService>(sp =>
                {
                    var kafkaConfiguration = sp.GetRequiredService<IOptions<KafkaConfiguration>>().Value;
                    var consumerFactory = new KafkaMessageConsumerFactory(sp, optionsBuilder.TopicConsumerTypes);
                    var backGroundPerPartitionConsumer = new BackgroundPerPartitionConsumer(kafkaConfiguration, consumerFactory, topicsNames);
                    return backGroundPerPartitionConsumer;
                });
            }
        }
    }
}
