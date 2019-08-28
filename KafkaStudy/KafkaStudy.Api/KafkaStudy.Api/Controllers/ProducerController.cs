using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KafkaStudy.Api.Controllers
{
    public class ProducerController: Controller
    {
        private readonly IKafkaProducer<User> _kafkaProducer;
        
        public ProducerController(IKafkaProducer<User> kafkaProducer)
        {
            _kafkaProducer = kafkaProducer;
        }
        
        [HttpGet("/getInfo")]
        public async Task<ActionResult<string>> GetInfo()
        {
            for (int i = 0; i < 10; i++)
            {
                var message = new User(){ Id = Guid.NewGuid(), MessageKey = "val"};
                var result = await _kafkaProducer.Produce("my-topic", message);
                var result1 = await _kafkaProducer.Produce("my-second-topic", message);
                var result3 = await _kafkaProducer.Produce(message);
            }

            return Ok();
        }
    }
}