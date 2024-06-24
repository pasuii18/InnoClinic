using Application.Interfaces;
using Domain.Events.DoctorEvents;
using Mapster;
using MassTransit;

namespace Infrastructure.Consumers;

public class DoctorUpdateConsumer(IProcessesService _processesService) : IConsumer<DoctorUpdatedEvent>
{
    public async Task Consume(ConsumeContext<DoctorUpdatedEvent> context)
    {
        var doctorUpdateEvent = context.Message.Adapt<DoctorUpdatedEvent>();
        await _processesService.ProcessDoctorUpdate(doctorUpdateEvent, context.CancellationToken);
    }
}