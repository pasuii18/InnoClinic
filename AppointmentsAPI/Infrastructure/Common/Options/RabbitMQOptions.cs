﻿namespace Infrastructure.Common.Options;

public class RabbitMQOptions
{
    public string HostName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string VirtualHost { get; set; }
}