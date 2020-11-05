using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitChat
{
    public class Consumer
    {
        ConnectionFactory connectionFactory;
        IConnection connection;
        public Consumer(string hostName, string userName, string password)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = hostName;
            connectionFactory.UserName = userName;
            connectionFactory.Password = password;
            connection = connectionFactory.CreateConnection();
        }

        public string ReceiveQueue(string queue)
        {
            using (connection)
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


        public string ReceiveExchange(string exchange, string routingKey)
        {
            //This code doesn't work
            string feedback = null;
            using (connection)
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: exchange, type: ExchangeType.Fanout);

                var queueName = channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: queueName,
                                    exchange: exchange,
                                    routingKey: routingKey);

                var consumer = new EventingBasicConsumer(channel);
                channel.BasicConsume(queue: queueName,
                        autoAck: true,
                        consumer: consumer);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    feedback = message;
                };
                return feedback;
            }

        }
    }
}
