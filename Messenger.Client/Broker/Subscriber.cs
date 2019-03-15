namespace Messenger.Lib.Broker
{
    using System;
    using System.Linq;
    using System.Text;
    using Extentions;
    using Interfaces;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    public class Subscriber : ISubscriber
    {
        private readonly IConnection _connection;

        public Subscriber(IConnection connection)
        {
            _connection = connection;
        }

        public void Subscribe()
        {
            using (_connection)
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.QueueDeclare();

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;

                        var message = Encoding.UTF8.GetString(body);

                        var name = message.Split(' ').LastOrDefault();

                        Console.WriteLine($"Hello { name}, I am your father!");
                    };

                    channel.BasicConsume(consumer);

                    Console.ReadLine();
                }
            }
        }
    }
}
