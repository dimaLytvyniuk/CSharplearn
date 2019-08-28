using System;
using Microsoft.Extensions.DependencyInjection;

namespace KafkaStudy.Api.Configuration
{
    public interface IKafkaGeneralOptionsBuilder
    {
        void AddConsumer(Action<IKafkaConsumerOptionsBuilder> optionsBuilderAction);
        void AddProducers(Action<IKafkaProducersOptionsBuilder> optionsBuilderAction);
        void UseProtoBufSerializer();
    }
}
