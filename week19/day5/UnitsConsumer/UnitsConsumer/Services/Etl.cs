using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitsConsumer.Models;
using static Confluent.Kafka.ConfigPropertyNames;

namespace UnitsConsumer.Services
{
    public class Etl
    {
        private readonly MyConsumer _consumer;
        private readonly Proccessor _proccessor;
        private readonly ConfigurationStrings _conStrings;
        
        public Etl(MyConsumer myConsumer, Proccessor proccessor, ConfigurationStrings configurationStrings)
        {
            _consumer = myConsumer;
            _proccessor = proccessor;
            _conStrings = configurationStrings;
        }
        public async Task LoopOverTopic(string topic)
        {
            _consumer.Unsubscribe();
            _consumer.Subscribe(topic);
            while (true)
            {
                var consumeResult = _consumer.Consumer.Consume(TimeSpan.FromSeconds(5));
                if (consumeResult == null || consumeResult.Message!.Value == null)
                {
                    break;
                }
                if (consumeResult.Topic == _conStrings.uavTopic)
                {
                    await _proccessor.ProccessModel(consumeResult.Message.Value);
                }
                if (consumeResult.Topic == _conStrings.hostileTopic)
                {
                    await _proccessor.ProccessHostileUnit(consumeResult.Message.Value);
                }
                if (consumeResult.Topic == _conStrings.trackTopic)
                {
                    await _proccessor.ProccessTrack(consumeResult.Message.Value);
                }
            }
        }
    }
}
