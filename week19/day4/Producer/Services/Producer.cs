using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer.Services
{
    public class MyProducer
    {
        private readonly string _bootstrapServers;
        private readonly IProducer<string, string> _producer;
        public MyProducer(string bootstrapServers)
        {
            _bootstrapServers = bootstrapServers;
            var config = new ProducerConfig
            {
                BootstrapServers = _bootstrapServers
            };
             _producer = new ProducerBuilder<string, string>(config).Build();
        }
        public async Task<DeliveryResult<string, string>> SendAsync(string topicName,string key, string value)
        {
            var message = new Message<string, string>
            {
                Key = key,
                Value = value
            };
            var result = await _producer.ProduceAsync(topicName, message);
            return result;

        }
        public void Dispose()
        {
            _producer.Flush();
            _producer.Dispose();
        }
    }
}
