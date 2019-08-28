using System;
using Microsoft.Extensions.DependencyInjection;

namespace KafkaStudy.Api.Configuration
{
    internal class KafkaGeneralOptionsBuilder: IKafkaGeneralOptionsBuilder
    {
        private readonly IServiceCollection _services;

        public KafkaGeneralOptionsBuilder(IServiceCollection services)
        {
            _services = services;
        }

        public void AddConsumer(Action<IKafkaConsumerOptionsBuilder> optionsBuilderAction)
        {
            if (optionsBuilderAction == null)
                throw new ArgumentNullException(nameof(optionsBuilderAction));

            _services.AddKafkaConsumer(optionsBuilderAction);
        }

        public void AddProducers(Action<IKafkaProducersOptionsBuilder> optionsBuilderAction)
        {
            if (optionsBuilderAction == null)
                throw new ArgumentNullException(nameof(optionsBuilderAction));

            _services.AddKafkaProducers(optionsBuilderAction);
        }

        public void UseProtoBufSerializer()
        {
            _services.AddSingleton(typeof(IMessageSerializer<>), typeof(ProtobufSerializer<>));
        }
    }
}
