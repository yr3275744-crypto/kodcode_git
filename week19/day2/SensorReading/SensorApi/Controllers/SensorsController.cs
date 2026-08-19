using Microsoft.AspNetCore.Mvc;
using SensorApi.Models;
using SensorApi.Services;

namespace SensorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorsController : ControllerBase
    {
        private readonly KafkaConsumerService _kafkaConsumer;
        
        public SensorsController(KafkaConsumerService kafkaConsumer)
        {
            _kafkaConsumer = kafkaConsumer;
        }
        [HttpGet]
        public ActionResult<SensorReading> GetNextSensor()
        {
            var result = _kafkaConsumer.ConsumeNextSensor(TimeSpan.FromSeconds(5));
            if (result == null)
            {
                return NotFound("message not found");
            }
            return Ok(result);
        }
    }
}
