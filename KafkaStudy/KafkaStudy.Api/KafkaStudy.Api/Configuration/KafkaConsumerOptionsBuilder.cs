using System;
using System.Collections.Generic;

namespace KafkaStudy.Api.Configuration
{
    internal class KafkaConsumerOptionsBuilder: IKafkaConsumerOptionsBuilder
    {
        private int _partitionCount = 1;
        private readonly Dictionary<string, Type> _topicConsumerTypes;

        public KafkaConsumerOptionsBuilder()
        {
            _topicConsumerTypes = new Dictionary<string, Type>();
        }
        
        public int PartitionCount
        {
            get => _partitionCount;
            set
            {
                if (value <= 0 )
                    throw new ArgumentException($"{nameof(PartitionCount)} should be greater than 0"); 
                
                _partitionCount = value;   
            }
        }

        public Dictionary<string, Type> TopicConsumerTypes => _topicConsumerTypes;
        
        public void AddTopic<T>()
        {
            var messageType = typeof(T);
            _topicConsumerTypes.Add(messageType.FullName, typeof(KafkaMessageConsumer<T>));
        }

        public void AddTopic<T>(string topicName)
        {
            _topicConsumerTypes.Add(topicName, typeof(KafkaMessageConsumer<T>));
        }
    }
}
