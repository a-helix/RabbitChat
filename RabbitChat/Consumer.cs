using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitChat
{
    public class Consumer : IConsumer
    {
        ConnectionFactory connectionFactory;
        public Consumer(string hostName, string userName, string password)
        {
            connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = hostName;
            connectionFactory.UserName = userName;
            connectionFactory.Password = password;
        }

        public string ReceiveQueue(string queue)
        {
            using (IConnection connection = new ConnectionFactory().CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue, false, false, false, null);
                    var consumer = new EventingBasicConsumer(channel);
                    BasicGetResult result = channel.BasicGet(queue, true);
                    if (result != null)
                    {
                        var body = result.Body.ToArray();
                        string data = Encoding.UTF8.GetString(body);
                        return data;
                    }
                    return null;
                }
            }
        }
    }
}
