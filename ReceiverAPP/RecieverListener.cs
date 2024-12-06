using MassTransit;
using ReceiverAPP.Data.Models;

namespace ReceiverAPP
{
    public class RecieverListener : IConsumer<Product>
    {
        public async Task Consume(ConsumeContext<Product> context)
        {
            var product = context.Message;
        }
    }
}
