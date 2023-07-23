using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("amqps://mewlylyo:HkyxgU8xLIPrVUnhvy3GHnmv9EfgUE-x@woodpecker.rmq.cloudamqp.com/mewlylyo");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.QueueDeclare(queue: "queue-example", exclusive: false);

byte[] message = Encoding.UTF8.GetBytes("message sended by Publisher");
channel.BasicPublish(exchange: "", routingKey: "queue-example", body: message);

Console.Read();
