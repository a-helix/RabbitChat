namespace RabbitChat
{

    public interface IPublisher
    {
        void SendQueue(string queue, string data);
    }
}