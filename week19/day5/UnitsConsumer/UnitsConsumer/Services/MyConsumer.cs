using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsConsumer.Services
{
    public class MyConsumer
    {
        public IConsumer<Ignore, string> Consumer { get; private set; }
        private readonly string _bootstrapServers;
        public MyConsumer(string bootstrapServers, string groupID)
        {
            _bootstrapServers = bootstrapServers;
            var config = new ConsumerConfig
            {
                BootstrapServers = bootstrapServers,
                GroupId = groupID,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            Consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        }
        public void Subscribe(string topic)
        {
            Consumer.Subscribe(topic);
        }
        public void Unsubscribe()
        {
            Consumer.Unsubscribe();
        }
    }
}
