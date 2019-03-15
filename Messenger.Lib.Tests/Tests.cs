using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Messenger.Lib.Tests
{
    using Broker;
    using FluentAssertions;
    using NSubstitute;
    using RabbitMQ.Client;

    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Sender_Constructor_With_Valid_Param_Creates_Instance()
        {
            var conn = Substitute.For<IConnection>();

            var sender = new Sender(conn);

            sender.Should().NotBe(null);
        }

        [TestMethod]
        public void Subscriber_Constructor_With_Valid_Param_Creates_Instance()
        {
            var conn = Substitute.For<IConnection>();

            var subscriber = new Subscriber(conn);

            subscriber.Should().NotBe(null);
        }

        [TestMethod]
        public void Sender_Execute_With_Valid_Param_Creates_Channel()
        {
            var conn = Substitute.For<IConnection>();

            var sender = new Sender(conn);

            sender.Execute("vumani");

            conn.Received(1).CreateModel();
        }
    }
}
