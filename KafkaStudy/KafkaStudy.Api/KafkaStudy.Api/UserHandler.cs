using Serilog;

namespace KafkaStudy.Api
{
    public class UserHandler: IKafkaMessageHandler<User>
    {
        public void OnMessage(User user)
        {
            Log.Error($"Consume message {user.Id}");
        }
    }
}