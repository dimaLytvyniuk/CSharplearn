using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using KafkaStudy.Api.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace KafkaStudy.Api
{
    internal class BackgroundPerPartitionConsumer: BackgroundService
    {
        private readonly KafkaConfiguration _configuration;
        private readonly IKafkaMessageConsumerFactory _consumerFactory;
        private readonly IReadOnlyList<string> _subscribedTopics;
        
        private static int ConsumerCount = 0;
        private int ConumerId;
        
        public BackgroundPerPartitionConsumer(
            KafkaConfiguration configuration,
            IKafkaMessageConsumerFactory consumerFactory, 
            IReadOnlyList<string> subscribedTopics)
        {
            _configuration = configuration;
            _consumerFactory = consumerFactory;
            _subscribedTopics = subscribedTopics;
            ConsumerCount++;
            ConumerId = ConsumerCount;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var conf = new ConsumerConfig
            { 
                GroupId = _configuration.GroupId,
                BootstrapServers = _configuration.ConnectionString,
                // Note: The AutoOffsetReset property determines the start offset in the event
                // there are not yet any committed offsets for the consumer group for the
                // topic/partitions of interest. By default, offsets are committed
                // automatically, so in this example, consumption will only start from the
                // earliest message in the topic 'my-topic' the first time you run the program.
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            
            using (var c = new ConsumerBuilder<Ignore, byte[]>(conf)
                //.SetValueDeserializer(new ProtobufSerializer<T>())
                .Build())
            {
                c.Subscribe(_subscribedTopics);
                CancellationTokenSource cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true; // prevent the process from terminating.
                    cts.Cancel();
                };

                try
                {
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        try
                        {
                            var cr = c.Consume(cts.Token);
                            
                            Log.Error($"First topic {ConumerId} {cr.Topic}");
                            var consumer = _consumerFactory.GetMessageConsumer(cr.Topic);
                            await consumer.ConsumeAsync(cr.Value);
                            Log.Error($"End First topic {ConumerId} {cr.Value.Length}");
                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine($"Error occured: {e.Error.Reason}");
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Ensure the consumer leaves the group cleanly and final offsets are committed.
                    c.Close();
                }
            }
        }
    }
}
