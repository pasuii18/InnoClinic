namespace Application.Interfaces;

public interface IMessageProducer
{
    public void SendMessage<T>(T message, string routingKey);
}