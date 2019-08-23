using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace KafkaStudy.Api
{
    public class KafkaMessageConsumer<T>: IKafkaMessageConsumer
    {
        private const int RETRY_COUNT = 3;
        private const int RETRY_TIMEOUT = 500;
        
        private readonly IServiceProvider _serviceProvider;
        private readonly IReadOnlyList<IKafkaMessageHandler<T>> _handlers;
        private readonly IMessageSerializer<T> _serializer;
        
        public KafkaMessageConsumer(IServiceProvider serviceProvider, IEnumerable<IKafkaMessageHandler<T>> handlers, IMessageSerializer<T> serializer)
        {
            _serviceProvider = serviceProvider;
            _handlers = handlers.ToList();
            _serializer = serializer;
        }
        
        public async Task ConsumeAsync(byte[] data)
        {
            var message = _serializer.Deserialize(data);
            
            foreach (var handler in _handlers)
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
                        //Log.Error($"Exception {ex}");
                        await Task.Delay(RETRY_TIMEOUT);
                    }   
                }
            }
        }
        
        private async Task OnMessageAsync<KHandler>(KHandler handler, T message) where KHandler: IKafkaMessageHandler<T>
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var service = (IKafkaMessageHandler<T>)scope.ServiceProvider.GetRequiredService(handler.GetType());
                await service.OnMessageAsync(message);
            }
        }
    }
}
