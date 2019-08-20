using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace KafkaStudy.Api.Rx
{
    public class KafkaRxConsumerStream<T>: IKafkaRxConsumerStream<T>, IDisposable
    {
        private const int RETRY_COUNT = 3;
        private const int THREAD_COUNT = 4;
        private const int RETRY_TIMEOUT = 500;
        
        private readonly Subject<T> _subject;
        private readonly IDictionary<string, IDisposable> _subscribers;
        private readonly IServiceProvider _serviceProvider;
        
        public KafkaRxConsumerStream(IEnumerable<IKafkaMessageHandler<T>> kafkaMessageHandlers, IServiceProvider serviceProvider)
        {
            _subject = new Subject<T>();
            _subscribers = new Dictionary<string, IDisposable>();
            _serviceProvider = serviceProvider;
            
            RegisterDefaultSubscribers();
        }
        
        public void Publish(T message)
        {
            _subject.OnNext(message);
        }

        public void Subscribe(string subscriberName, Func<T, Task> action)
        {
            if (_subscribers.ContainsKey(subscriberName))
                throw new ArgumentException($"Subscriber with name {subscriberName} already exist");
            
            _subscribers.Add(subscriberName, _subject.Subscribe(async (messge) => await action(messge)));
        }

        private void RegisterDefaultSubscribers()
        {
            var handlers = _serviceProvider.GetServices<IKafkaMessageHandler<T>>();

            foreach (var handler in handlers)
            {
                _subscribers.Add(
                    handler.GetType().FullName, 
                    _subject
                        .Select(message => Observable.FromAsync(async () => await DefaultAction(handler).Invoke(message)))
                        .Merge(THREAD_COUNT)
                        .Subscribe(unit => {}));
            }
        }
        
        private Func<T, Task> DefaultAction<KHandler>(KHandler handler) where KHandler: IKafkaMessageHandler<T>
        {
            return async (message) =>
            {
                for (int i = 0; i < RETRY_COUNT; i++)
                {
                    try
                    {
                        await OnMessageAsync(handler, message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"Exception {ex}");
                        await Task.Delay(RETRY_TIMEOUT);
                    }   
                }
            };
        }

        private async Task OnMessageAsync<KHandler>(KHandler handler, T message) where KHandler: IKafkaMessageHandler<T>
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var service = (IKafkaMessageHandler<T>)scope.ServiceProvider.GetRequiredService(handler.GetType());
                await service.OnMessageAsync(message);
            }
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
