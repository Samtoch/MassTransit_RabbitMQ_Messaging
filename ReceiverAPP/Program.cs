
using MassTransit;

namespace ReceiverAPP
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

            builder.Services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, config) =>
                {
                    config.Host(new Uri("rabbitmq://localhost"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    config.ReceiveEndpoint("send-tutorial", e =>
                    {
                        e.Consumer<RecieverListener>(context);
                    });

                    config.ReceiveEndpoint("publush-user", e =>
                    {
                        e.Consumer<UserSubscriber>(context);
                    });
                });

                x.AddConsumer<RecieverListener>();
                x.AddConsumer<UserSubscriber>();
            });

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
