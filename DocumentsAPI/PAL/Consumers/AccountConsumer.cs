using BAL.Common.Dtos.PhotoDtos;
using BAL.Common.ServicesInterfaces;
using DAL.Entities;
using DAL.Events.AccountEvents;
using DAL.Events.OfficeEvents;
using MassTransit;

namespace Presentation.Consumers;

public class AccountConsumer(IPhotoDbService _photoDbService)
    : IConsumer<CreatedAccountEvent>, IConsumer<UpdatedAccountEvent>, IConsumer<DeletedOfficeEvent>
{
    public async Task Consume(ConsumeContext<CreatedAccountEvent> context)
    {
        await _photoDbService.CreatePhoto(
            new CreatePhotoDto(context.Message.IdAccount, context.Message.Data, PhotoTypeEnum.Account),
            context.CancellationToken);
    }

    public async Task Consume(ConsumeContext<UpdatedAccountEvent> context)
    {
        await _photoDbService.UpdatePhoto(
            new UpdatePhotoDto(context.Message.IdAccount, context.Message.Data, PhotoTypeEnum.Account),
            context.CancellationToken);
    }

    public async Task Consume(ConsumeContext<DeletedOfficeEvent> context)
    {
        await _photoDbService.DeletePhoto(
            new DeletePhotoDto(context.Message.IdOffice, PhotoTypeEnum.Account),
            context.CancellationToken);
    }
}