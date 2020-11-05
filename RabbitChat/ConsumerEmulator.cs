namespace RabbitChat
{
    public class ConsumerEmulator
    {
        private RabbitServerEmulator _rabbit;
        public ConsumerEmulator(RabbitServerEmulator rabbit, string userName, string password)
        {
            _rabbit = rabbit;
            _rabbit.ValidUser(userName, password);
        }

        public string Receive(string queue)
        {
            return _rabbit.Send(queue);
        }
    }
}
