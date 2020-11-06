using RabbitMQ.Client;
using System.Text;

namespace RabbitChat
{
    public class Publisher : IPublisher
    {
        ConnectionFactory connectionFactory;

        public Publisher(string hostName, string userName, string password)
            {
            connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = hostName;
            connectionFactory.UserName = userName;
            connectionFactory.Password = password;
            }

        public void SendQueue(string queue, string data)
        {
            using (IConnection connection = new ConnectionFactory().CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue, false, false, false, null);
                    channel.BasicPublish(string.Empty, queue, null, Encoding.UTF8.GetBytes(data));
                }
            }
        }
    }
}
