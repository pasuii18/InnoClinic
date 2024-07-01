using BAL.Common.Dtos.PhotoDtos;
using BAL.Common.ServicesInterfaces;
using DAL.Entities;
using DAL.Events.ResultEvents;
using MassTransit;

namespace Presentation.Consumers;

public class ResultConsumer(IDocumentDbService _documentDbService) 
    : IConsumer<CreatedResultEvent>, IConsumer<UpdatedResultEvent>, IConsumer<DeletedResultEvent>
{
    public async Task Consume(ConsumeContext<CreatedResultEvent> context)
    {
        await _documentDbService.CreateDocument(
            new CreateDocumentDto(context.Message.IdResult, context.Message.Data, DocumentTypeEnum.Result),
            context.CancellationToken);
    }

    public async Task Consume(ConsumeContext<UpdatedResultEvent> context)
    {
        await _documentDbService.UpdateDocument(
            new UpdateDocumentDto(context.Message.IdResult, context.Message.Data, DocumentTypeEnum.Result),
            context.CancellationToken);
    }

    public async Task Consume(ConsumeContext<DeletedResultEvent> context)
    {
        await _documentDbService.DeleteDocument(
            new DeleteDocumentDto(context.Message.IdResult, DocumentTypeEnum.Result),
            context.CancellationToken);
    }
}