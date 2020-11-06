namespace RabbitChat
{
    public class PublisherEmulator : IPublisher
    {
        private RabbitServerEmulator _rabbit;
        public PublisherEmulator(RabbitServerEmulator rabbit, string userName, string password)
        {
            _rabbit = rabbit;
            _rabbit.ValidUser(userName, password);
        }

        public void SendQueue(string queue, string data)
        {
            _rabbit.Save(queue, data);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> master
