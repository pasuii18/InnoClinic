using Infrastructure.Common.Options;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Infrastructure.Common;

public class RabbitMQClient(IOptions<RabbitMQOptions> _options)
{
    // channel.QueueDeclare("Appointments", durable: true, exclusive: true);
    public IConnection GetConnection()
    {
        var factory = new ConnectionFactory()
        {
            HostName = _options.Value.HostName,
            UserName = _options.Value.UserName,
            Password = _options.Value.Password,
            VirtualHost = _options.Value.VirtualHost
        };
        return factory.CreateConnection();
    }
    public IModel GetModel()
    {
        var connection = GetConnection();
        return connection.CreateModel();
    }
}