namespace Messenger.Lib.Broker
{
    using System.Text;
    using Extentions;
    using Interfaces;
    using RabbitMQ.Client;

    public class Sender : ISender
    {
        private readonly IConnection _connection;

        public Sender(IConnection connection)
        {
            _connection = connection;
        }

        public void Execute(string name)
        {
            using (_connection)
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.QueueDeclare();

                    channel.BasicPublish(GetBody(name));
                }
            }
        }

        private byte[] GetBody(string name)
        {
            string message = $"Hello my name is, {name}";

            var body = Encoding.UTF8.GetBytes(message);

            return body;
        }
    }
}
