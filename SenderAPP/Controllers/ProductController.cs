using Common;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenderAPP.Data.Models;

namespace SenderAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IBus _bus;
        public ProductController(IBus bus)
        {
            _bus = bus;
        }

        //private readonly IPublishEndpoint _publishEndpoint;

        //public ProductController(IPublishEndpoint publishEndpoint)
        //{
        //    _publishEndpoint = publishEndpoint;
        //}

        [HttpPost("send-tutorial")]
        //[Route("Product")]
        public async Task<IActionResult> PostProduct()
        {
            var product = new Product()
            {
                Id = 1,
                Name = "Test",
                ProductId = new Guid(),
                Quantity = 1,
                Price = 1
            };

            var url = new Uri("rabbitmq://localhost/send-tutorial");
            var endpoint = await _bus.GetSendEndpoint(url);
            await endpoint.Send(product);

            //await _publishEndpoint.Publish(product);
            return Ok("Posting publisher Message Via RabbitMQ");
        }

        [HttpPost("publush-user")]
        //[Route("Product")]
        public async Task<IActionResult> PostUseer()
        {
            var user = new User()
            {
                Id = 1,
                Name = "Samuel Offiah",
                Email = "samueltochi1@gmail.com",
            };

            await _bus.Publish(user);

            return Ok("publishing User Details Via RabbitMQ");
        }
    }
}
