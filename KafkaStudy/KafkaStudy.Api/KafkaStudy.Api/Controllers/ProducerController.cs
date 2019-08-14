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
            var result = await _kafkaClient.Produce("key", "val");
            return Ok(result.Message.Value);
        }
    }
}