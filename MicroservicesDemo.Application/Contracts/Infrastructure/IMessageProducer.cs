namespace MicroservicesDemo.Application.Contracts.Infrastructure
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
