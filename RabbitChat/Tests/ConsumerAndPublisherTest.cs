using NUnit.Framework;

namespace RabbitChat.Tests
{
    public class ConsumerAndPublisherTest
    {
        static readonly string rabbitUrl = "localhost";
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

