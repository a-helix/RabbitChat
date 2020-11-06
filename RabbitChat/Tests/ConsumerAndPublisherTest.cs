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
        static readonly string rabbitUrl = (string)config.Value("RabbitMQ");
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
    }
}
