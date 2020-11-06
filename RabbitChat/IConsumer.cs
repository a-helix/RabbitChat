namespace RabbitChat
{
    public interface IConsumer
    {
        string ReceiveQueue(string queue);
    }
}
