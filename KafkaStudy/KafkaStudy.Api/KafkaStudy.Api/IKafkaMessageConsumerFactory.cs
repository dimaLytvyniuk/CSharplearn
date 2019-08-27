using System;
using System.Collections.Generic;

namespace KafkaStudy.Api
{
    internal interface IKafkaMessageConsumerFactory
    {
        IReadOnlyDictionary<string, Type> TopicConsumerTypes { get; }

        IKafkaMessageConsumer GetMessageConsumer(string topic);

        void AddTopicConsumerTypes(IReadOnlyDictionary<string, Type> topicConsumerTypes);
    }
}
