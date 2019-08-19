using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace KafkaStudy.Api
{
    public class UserHandler: IKafkaMessageHandler<User>
    {
        public async Task OnMessageAsync(User user)
        {
            var id = Guid.NewGuid();
            Log.Error($"Start {id}");
            var httpClient = new HttpClient();
            var result = await httpClient.GetAsync("http://localhost:7000");
            Log.Error($"End {id}");
        }
    }
}