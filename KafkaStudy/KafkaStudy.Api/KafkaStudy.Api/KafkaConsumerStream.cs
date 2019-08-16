using System;
using System.Collections.Generic;
using System.Reactive.Subjects;

namespace KafkaStudy.Api
{
    public class KafkaConsumerStream<T>: IKafkaConsumerStream<T>, IDisposable
    {
        private readonly Subject<T> _subject;
        private readonly IDictionary<string, IDisposable> _subscribers;

        public KafkaConsumerStream(IEnumerable<IKafkaMessageHandler<T>> kafkaMessageHandlers)
        {
            _subject = new Subject<T>();
            _subscribers = new Dictionary<string, IDisposable>();
            
            foreach (var handler in kafkaMessageHandlers)
            {
                Subscribe(handler.GetType().FullName, handler.OnMessage);
            }
        }
        
        public void Publish(T message)
        {
            _subject.OnNext(message);
        }

        public void Subscribe(string subscriberName, Action<T> action)
        {
            if (_subscribers.ContainsKey(subscriberName))
                throw new ArgumentException($"Subscriber with name {subscriberName} already exist");
            
            _subscribers.Add(subscriberName, _subject.Subscribe(action));
        }

        public void Dispose()
        {
            if(_subject != null)
            {
                _subject.Dispose();
            }
        }
    }
}