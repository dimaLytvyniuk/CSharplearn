using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KafkaStudy.Api.Configuration
{
    public static class KafkaConsumerConfigurationExtensions
    {
        public static IServiceCollection AddKafkaConsumer(
            this IServiceCollection services,
            Action<IKafkaConsumerOptionsBuilder> optionsBuilderAction)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            
            if (optionsBuilderAction == null)
                throw new ArgumentNullException(nameof(optionsBuilderAction));

            var optionsBuilder = new KafkaConsumerOptionsBuilder();
            optionsBuilderAction(optionsBuilder);

            AddConsumerFactory(services, optionsBuilder);
            AddBackgroundConsumers(services, optionsBuilder);

            return services;
        }

        private static void AddConsumerFactory(
            IServiceCollection services,
            IKafkaConsumerOptionsBuilder optionsBuilder)
        {
            services.AddTransient<IKafkaMessageConsumerFactory>(sp =>
            {
                var consumerFactory = sp.GetService<IKafkaMessageConsumerFactory>();

                if (consumerFactory == null)
                {
                    consumerFactory = new KafkaMessageConsumerFactory(sp, optionsBuilder.TopicConsumerTypes);
                }
                else
                {
                    consumerFactory.AddTopicConsumerTypes(optionsBuilder.TopicConsumerTypes);
                }

                return consumerFactory;
            });
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
                    var consumerFactory = sp.GetRequiredService<IKafkaMessageConsumerFactory>();
                    var backGroundPerPartitionConsumer = new BackgroundPerPartitionConsumer(consumerFactory, topicsNames);
                    return backGroundPerPartitionConsumer;
                });
            }
        }
    }
}
