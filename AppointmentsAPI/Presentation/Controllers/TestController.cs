using Domain.Events;
using Domain.Events.DoctorEvents;
using Domain.Events.ServiceEvents;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.AspNetCore.Mvc;
using ServicesAPI.Common;

namespace ServicesAPI.Controllers;

[Route("api/v1/[controller]")]
public class TestController(IPublishEndpoint _publishEndpoint) : ControllerBase
{
    [HttpGet("/asdasda")]
    public async Task<IActionResult> Publish(MegaClass asdasd, CancellationToken cancellationToken)
    {
        // await _publishEndpoint.Publish(asdasd.ServiceUpdatedEvent, cancellationToken);
        await _publishEndpoint.Publish(asdasd.DoctorUpdatedEvent, cancellationToken);
        // await _publishEndpoint.Publish(asdasd.PatientUpdatedEvent, cancellationToken);
        return Ok();
    }
}

public class MegaClass()
{
    public ServiceUpdatedEvent ServiceUpdatedEvent { get; set; }
    public DoctorUpdatedEvent DoctorUpdatedEvent { get; set; }
    public PatientUpdatedEvent PatientUpdatedEvent { get; set; }
}