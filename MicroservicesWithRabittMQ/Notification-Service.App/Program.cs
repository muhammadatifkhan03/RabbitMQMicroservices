using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;


var factory = new ConnectionFactory
{
    HostName = "localhost"
};
var connection = factory.CreateConnection();
using
    var channel = connection.CreateModel();
    channel.QueueDeclare("OrderQueue", exclusive: false);
    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, eventArgs) => {
        var body = eventArgs.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine($"Order Creation message received: {message}");
    };
    //Read the message
    channel.BasicConsume(queue: "OrderQueue", autoAck: true, consumer: consumer);
    Console.ReadKey();


