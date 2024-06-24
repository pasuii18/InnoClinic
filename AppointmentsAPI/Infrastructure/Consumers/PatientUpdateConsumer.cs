using Application.Interfaces;
using Domain.Events;
using Mapster;
using MassTransit;

namespace Infrastructure.Consumers;

public class PatientUpdateConsumer(IProcessesService _processesService) : IConsumer<PatientUpdatedEvent>
{
    public async Task Consume(ConsumeContext<PatientUpdatedEvent> context)
    {
        var patientUpdateEvent = context.Message.Adapt<PatientUpdatedEvent>();
        await _processesService.ProcessPatientUpdate(patientUpdateEvent, context.CancellationToken);
    }
}