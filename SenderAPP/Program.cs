
using MassTransit;

namespace SenderAPP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMassTransit(x => x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
            {
                config.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            })));

            //builder.Services.AddMassTransitHostedService();

            //// Configure MassTransit with RabbitMQ
            //builder.Services.AddMassTransit(x =>
            //{
            //    x.UsingRabbitMq((context, cfg) =>
            //    {
            //        cfg.Host("localhost", "/", h =>
            //        {
            //            h.Username("guest");
            //            h.Password("guest");
            //        });
            //    });
            //});

            // Add MassTransit to the service collection
            builder.Services.AddMassTransitHostedService();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
