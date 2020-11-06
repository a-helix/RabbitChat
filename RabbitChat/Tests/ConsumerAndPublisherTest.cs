using Credentials;
using NUnit.Framework;
using System.IO;

namespace RabbitChat.Tests
{
    public class ConsumerAndPublisherTest
    {
        static string configPath = Path.Combine(Directory.GetParent(
                                   Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName,
                                   "WeatherAPI", "WeatherAPI", "Configs", "ApiConfigs.json");
        static readonly JsonFileContent config = new JsonFileContent(configPath);
<<<<<<< HEAD
        static readonly string rabbitUrl = (string)config.Value("RabbitMQ");
=======
        static readonly string rabbitUrl = (string) config.Parameter("RabbitMQ");
>>>>>>> master
        Consumer consumer = new Consumer(rabbitUrl, "test", "test");
        Publisher publisher = new Publisher(rabbitUrl, "test", "test");

        [Test]
        public void SendAndReceiveQueueMessegeTest()
        {
            var queue = "test";
            var messege = "Hello World!";
            publisher.SendQueue(queue, messege);
            var positiveFeedback = consumer.ReceiveQueue(queue);
            Assert.AreEqual(messege, positiveFeedback);
            Assert.IsNull(consumer.ReceiveQueue("not exhist"));
        }
<<<<<<< HEAD
    }
}
=======

        [Test]
        public void SendAndReceiveExchangeMessegeTest()
        {
            var exchange = "Test";
            var messege = "Hello World!";
            var routingKey = (string)config.Parameter("routingKeyFinished");
            publisher.SendExchange(exchange, routingKey, messege);
            var positiveFeedback = consumer.ReceiveExchange(exchange, routingKey);
            Assert.AreEqual(messege, positiveFeedback);
            Assert.IsNull(consumer.ReceiveExchange(exchange, routingKey));
        }
    }
}
>>>>>>> master
