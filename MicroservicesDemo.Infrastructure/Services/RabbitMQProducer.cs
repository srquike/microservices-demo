using MicroservicesDemo.Application.Contracts.Infrastructure;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace MicroservicesDemo.Infrastructure.Services
{
    public class RabbitMQProducer : IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "18.206.155.167",
                Port = 5672,                
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();
            channel.QueueDeclare("user", exclusive: false);

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "user", body: body);
        }
    }
}
