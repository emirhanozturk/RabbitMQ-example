using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("amqps://mewlylyo:HkyxgU8xLIPrVUnhvy3GHnmv9EfgUE-x@woodpecker.rmq.cloudamqp.com/mewlylyo");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();



channel.QueueDeclare(queue: "queue-example", exclusive: false);

EventingBasicConsumer consumer = new(channel);
channel.BasicConsume("queue-example", autoAck: true, consumer);
//channel.BasicConsume("queue-example", autoAck:false, consumer); Ack mesajını otomatik olarak göndermez.

consumer.Received += (sender, ea) =>
{
    var body = ea.Body.Span;
    Console.WriteLine("Received: " + Encoding.UTF8.GetString(body));
    //channel.BasicAck(deliveryTag:ea.DeliveryTag,multiple:false); Queue'ya mesajın işlendiğine dair ack mesajı gönderir.
};


Console.Read();