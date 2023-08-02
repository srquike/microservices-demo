using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory()
{
    HostName = "18.206.155.167",
    Port = 5672
};

var connection = factory.CreateConnection();

using var channel = connection.CreateModel();
channel.QueueDeclare("user", exclusive: false);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Users microservice message received: {message}");
};

channel.BasicConsume(queue: "user", autoAck: true, consumer: consumer);

Console.ReadKey();