namespace Messenger.Lib.Extentions
{
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    public static class ChannelExtentions
    {
        public static void QueueDeclare(this IModel channel)
        {
            channel.QueueDeclare(queue: "queue1", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public static void BasicConsume(this IModel channel, EventingBasicConsumer consumer)
        {
            channel.BasicConsume(queue: "queue1", autoAck: true, consumer: consumer);
        }

        public static void BasicPublish(this IModel channel, byte[] body)
        {
            channel.BasicPublish(exchange: "", routingKey: "queue1", basicProperties: null, body: body);
        }
    }
}
