using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace KafkaStudy.Api
{
    public class KafkaMessageConsumerFactory: IKafkaMessageConsumerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly Dictionary<string, Type> _topicTypes = new Dictionary<string, Type>()
        {
            {"my-topic", typeof(KafkaMessageConsumer<User>)},
            {"my-second-topic", typeof(KafkaMessageConsumer<User>)}
        };

        private readonly Dictionary<string, IKafkaMessageConsumer> _consumerCache; 
        
        public KafkaMessageConsumerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _consumerCache = new Dictionary<string, IKafkaMessageConsumer>();
            FillConsumerCache();
        }

        public IKafkaMessageConsumer GetMessageConsumer(string topic)
        {
            return _consumerCache[topic];
        }

        private void FillConsumerCache()
        {
            foreach (var topic in _topicTypes.Keys)
            {
                _consumerCache[topic] = (IKafkaMessageConsumer) _serviceProvider.GetRequiredService(_topicTypes[topic]);
            }
        }
    }
}
