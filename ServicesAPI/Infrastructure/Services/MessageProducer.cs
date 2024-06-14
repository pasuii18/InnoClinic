using System.Text;
using System.Text.Json;
using Application.Interfaces;
using Infrastructure.Common;
using RabbitMQ.Client;

namespace Application.Services;

public class MessageProducer(RabbitMQClient _client) : IMessageProducer
{
    public void SendMessage<T>(T message, string routingKey)
    {
        using (var channel = _client.GetModel())
        {
            var jsonString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);
        
            channel.BasicPublish("", routingKey, body: body);
        }
    }
}