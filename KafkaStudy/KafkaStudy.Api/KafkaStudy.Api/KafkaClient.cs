using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace KafkaStudy.Api
{
    public class KafkaClient: IKafkaClient
    {
        private IProducer<Null, User> _producer;

        public KafkaClient(IConfiguration globalconf)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

            _producer = new ProducerBuilder<Null, User>(config)
                .SetValueSerializer(new ProtobufSerializer<User>())
                .Build();

            //Task.Run(() => CreateConsumer());
        }

        public Task<DeliveryResult<Null, User>> Produce(string topic, string key, string val)
        {
            var user = new User() {Id = Guid.NewGuid(), MessageKey = val};
            return _producer.ProduceAsync(topic, new Message<Null, User> {  Value = user});
        }

        public void CreateConsumer()
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
            
            using (var c = new ConsumerBuilder<Ignore, string>(conf).Build())
            {
                c.Subscribe("my-topic");

                CancellationTokenSource cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) => {
                    e.Cancel = true; // prevent the process from terminating.
                    cts.Cancel();
                };

                try
                {
                    while (true)
                    {
                        try
                        {
                            var cr = c.Consume(cts.Token);
                            Log.Error($"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.");
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
        
        public void Dispose()
        {
            _producer.Dispose();
        }
    }
}