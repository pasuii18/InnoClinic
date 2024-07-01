using BAL.Common.Dtos.PhotoDtos;
using BAL.Common.ServicesInterfaces;
using DAL.Entities;
using DAL.Events.OfficeEvents;
using MassTransit;

namespace Presentation.Consumers.AccountConsumers;

public class OfficeConsumer(IPhotoDbService _photoDbService) 
    : IConsumer<CreatedOfficeEvent>, IConsumer<UpdatedOfficeEvent>, IConsumer<DeletedOfficeEvent>
{
    public async Task Consume(ConsumeContext<CreatedOfficeEvent> context)
    {
        await _photoDbService.CreatePhoto(
            new CreatePhotoDto(context.Message.IdOffice, context.Message.Data, PhotoTypeEnum.Office),
            context.CancellationToken);
    }

    public async Task Consume(ConsumeContext<UpdatedOfficeEvent> context)
    {
        await _photoDbService.UpdatePhoto(
            new UpdatePhotoDto(context.Message.IdOffice, context.Message.Data, PhotoTypeEnum.Office),
            context.CancellationToken);
    }

    public async Task Consume(ConsumeContext<DeletedOfficeEvent> context)
    {
        await _photoDbService.DeletePhoto(
            new DeletePhotoDto(context.Message.IdOffice, PhotoTypeEnum.Office),
            context.CancellationToken);
    }
}