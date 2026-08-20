using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UnitsProducer.Models;

namespace UnitsProducer.Services
{
    public class MyProducer : IDisposable
    {
        private readonly string _bootstrapServers;
        public IProducer<string, string> Producer { get; private set; }
        public MyProducer(string bootstrapServers)
        {
            _bootstrapServers = bootstrapServers;
            var config = new ProducerConfig
            {
                BootstrapServers = _bootstrapServers
            };
            Producer = new ProducerBuilder<string, string>(config).Build();
        }
        public async Task SendUavAsync(uav_models_reading obj, string topic)
        {
            string val = JsonSerializer.Serialize(obj);
            Producer.Produce(topic, new Message<string, string>
            {
                Key = Convert.ToString(obj.model_id),
                Value = val
            });
        }
        public async Task SendHostileAsync(hostile_units_reading obj, string topic)
        {
            string val = JsonSerializer.Serialize(obj);
            Producer.Produce(topic, new Message<string, string>
            {
                Key = Convert.ToString(obj.unit_id),
                Value = val
            });
        }
        public async Task SendTrackAsync(tracks_reading obj, string topic)
        {
            string val = JsonSerializer.Serialize(obj);
            Producer.Produce(topic, new Message<string, string>
            {
                Key = Convert.ToString(obj.track_id),
                Value = val
            });
        }
        public void Dispose()
        {
            Producer.Flush();
            Producer.Dispose();
        }
    }
}
