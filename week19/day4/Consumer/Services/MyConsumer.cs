using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Services
{
    public class MyConsumer
    {
        private readonly string _bootstrapServers;
        private readonly string _groupId;
        public IConsumer<string, string> Consumer { get; private set; }
        public MyConsumer(string bootstrapServers, string groupId, string topic)
        {
            _bootstrapServers = bootstrapServers;
            _groupId = groupId;
            var config = new ConsumerConfig
            {
                BootstrapServers = _bootstrapServers,
                GroupId = _groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            Consumer = new ConsumerBuilder<string, string>(config).Build();
            Consumer.Subscribe(topic);
        }
        public void UnsubscribeAndDispose()
        {
            Consumer.Unsubscribe();
            Consumer.Dispose();
        }
    }
}
