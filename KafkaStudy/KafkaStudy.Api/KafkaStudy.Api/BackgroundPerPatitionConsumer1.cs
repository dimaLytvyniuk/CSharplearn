using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace KafkaStudy.Api
{
    public class BackgroundPerPartitionConsumer1<T> : BackgroundService
    {
        private readonly IKafkaMessageConsumer<T> _kafkaMessageConsumer;

        public BackgroundPerPartitionConsumer1(IKafkaMessageConsumer<T> kafkaMessageConsumer)
        {
            _kafkaMessageConsumer = kafkaMessageConsumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var conf = new ConsumerConfig
            {
                GroupId = "test-consumer-group",
                BootstrapServers = "localhost:9092",
                // Note: The AutoOffsetReset property determines the start offset in the event
                // there are not yet any committed offsets for the consumer group for the
                // topic/partitions of interest. By default, offsets are committed
                // automatically, so in this example, consumption will only start from the
                // earliest message in the topic 'my-topic' the first time you run the program.
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var c = new ConsumerBuilder<Ignore, T>(conf)
                .SetValueDeserializer(new ProtobufSerializer<T>())
                .Build())
            {
                var list = new List<string> {"my-second-topic"};
                c.Subscribe(list);
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
                            if (cr != null)
                            {
                                Log.Error($"SecondTopic {cr.Partition.Value}");
                                await _kafkaMessageConsumer.ConsumeAsync(cr.Value);
                                Log.Error($"End SecondTopic {cr.Partition.Value}");
                            }
//                            else
//                            {
//                                await Task.Delay(TimeSpan.FromMilliseconds(100));
//                            }
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
