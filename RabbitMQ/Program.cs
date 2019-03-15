namespace Sender.Client
{
    using System;
    using Messenger.Lib.Broker;
    using RabbitMQ.Client;

    class Program
    {
        static void Main(string[] args)
        {
            var sender = new Sender(new ConnectionFactory { HostName = "localhost" }.CreateConnection());

            Console.WriteLine("please enter your name and press [enter] to proceed:");

            var name = Console.ReadLine();

            sender.Execute(name);

            Console.WriteLine(" Press [enter] to exit.");

            Console.ReadLine();
        }
    }
}
