using System;

namespace Subscriber.Client
{
    using Messenger.Lib.Broker;
    using RabbitMQ.Client;

    class Program
    {
        static void Main(string[] args)
        {
            var sub = new Subscriber(new ConnectionFactory { HostName = "localhost" }.CreateConnection());

            sub.Subscribe();

            Console.WriteLine(" Press [enter] to exit.");

            Console.ReadLine();
        }
    }
}
