using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KafkaStudy.Api.Controllers
{
    public class ProducerController: Controller
    {
        private readonly IKafkaClient _kafkaClient;
        
        public ProducerController(IKafkaClient kafkaClient)
        {
            _kafkaClient = kafkaClient;
        }
        
        [HttpGet("/getInfo")]
        public async Task<ActionResult<string>> GetInfo()
        {
            for (int i = 0; i < 100; i++)
            {
                var result = await _kafkaClient.Produce("my-topic", "key", "val");
                var result1 = await _kafkaClient.Produce("my-second-topic", "key", "val2");
            }

            return Ok();
        }
    }
}