using System;
using System.Net.Http;
using System.Threading.Tasks;
using Serilog;

namespace KafkaStudy.Api
{
    public class UserHandler: IKafkaMessageHandler<User>
    {
        private readonly HttpClient _httpClient;

        public UserHandler(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient();
        }
        
        public async Task OnMessageAsync(User user)
        {
            var guid = Guid.NewGuid();
            Log.Error($"Start {user.Id} {guid}");
            await _httpClient.GetAsync("http://localhost:7000");
            Log.Error($"End {user.Id} {guid}");
            throw new Exception();
        }
    }
}
