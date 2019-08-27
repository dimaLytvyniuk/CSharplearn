using System;

namespace KafkaStudy.Api.Configuration
{
    public interface IKafkaOptionsBuilder
    {
        IKafkaOptionsBuilder AddConsumer(Action<IKafkaConsumerOptionsBuilder> options);
        IKafkaOptionsBuilder AddProduces(Action<IKafkaProducersOptionsBuilder> options);
    }
}
