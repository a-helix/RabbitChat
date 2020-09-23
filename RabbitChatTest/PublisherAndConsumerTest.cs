using NUnit.Framework;
using RabbitChat;

namespace RabbitChatTest
{
    public class PublisherAndConsumerTest
    {
        Consumer consumer;
        Publisher publisher;

        [SetUp]
        public void Setup()
        {
            consumer = new Consumer("localhost", "consumer", "1234");
            publisher = new Publisher("localhost", "consumer", "1234");
        }

        [Test]
        public void ChatPositiveTest()
        {
            string msg = "Hello, world.";
            publisher.send("TestChat", msg);
            string answer = consumer.receive("TestChat");
            Assert.Equals(answer, msg);
        }

        [Test]
        public void ChatNullNegativeTest()
        {
            string etalon = null;
            string answer = consumer.receive("TestChat");
            Assert.Equals(answer, etalon);
        }
    }
}