namespace RabbitChat
{
    public interface IConsumer
    {
        public string ReceiveQueue(string queue);
    }
}
