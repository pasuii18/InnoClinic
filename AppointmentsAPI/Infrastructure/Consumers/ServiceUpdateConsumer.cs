using Application.Interfaces;
using Domain.Events.ServiceEvents;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Mapster;
using MassTransit;

namespace Infrastructure.Consumers;

public class ServiceUpdateConsumer(IProcessesService _processesService) : IConsumer<ServiceUpdatedEvent>
{
    public async Task Consume(ConsumeContext<ServiceUpdatedEvent> context)
    {
        var serviceUpdateEvent = context.Message.Adapt<ServiceUpdatedEvent>();
        await _processesService.ProcessServiceUpdate(serviceUpdateEvent, context.CancellationToken);
    }
}