using Common;
using MassTransit;

namespace ReceiverAPP
{
    public class UserSubscriber : IConsumer<User>
    {
        public async Task Consume(ConsumeContext<User> context)
        {
            var user = context.Message;
        }
    }
}
