using System;
using System.Collections.Generic;

namespace KafkaStudy.Api.Configuration
{
    public interface IKafkaConsumerOptionsBuilder
    {
        int PartitionCount { get; set; }
        Dictionary<string, Type> TopicConsumerTypes { get; }
        
        void AddTopic<T>();
        void AddTopic<T>(string topicName);
    }
}
