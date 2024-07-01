using System.Net;
using BAL.Common;
using BAL.Common.Dtos;
using BAL.Common.Dtos.PhotoDtos;
using BAL.Common.Interfaces;
using BAL.Common.ServicesInterfaces;
using DAL.Common.Interfaces.RepoInterfaces;
using DAL.Entities;
using Microsoft.Azure.Cosmos;

namespace BAL.Services;

public class DocumentDbService(IDocumentDbRepo _documentDbRepo, IDocumentBlobService _documentBlobService)
    : IDocumentDbService
{
    public async Task<ICustomResult<string>> GetDocumentUrlByResultId(Guid idResult, DocumentTypeEnum type,
        CancellationToken cancellationToken)
    {
        var document = await _documentDbRepo.GetDocumentByIdLinked(idResult,
            new PartitionKey(type.ToString()), cancellationToken);
        if (document == null) 
            return new CustomResult<string>(false, HttpStatusCode.NotFound, messages: [Messages.DocumentNotFound]);
        
        return new CustomResult<string>(true, HttpStatusCode.OK, data: document.Url);
    }
    public async Task CreateDocument(CreateDocumentDto createDocumentDto, CancellationToken cancellationToken)
    {
        var document = new Document()
        {
            IdDocument = Guid.NewGuid(),
            Url = await _documentBlobService.UploadDocument(createDocumentDto.Data, cancellationToken),
            IdLinked = createDocumentDto.IdLinked
        };
        
        await _documentDbRepo.CreateDocument(document,
            new PartitionKey(createDocumentDto.Type.ToString()), cancellationToken);
    }
    public async Task UpdateDocument(UpdateDocumentDto updateDocumentDto, CancellationToken cancellationToken)
    {
        var document = await _documentDbRepo.GetDocumentByIdLinked(updateDocumentDto.IdLinked,
            new PartitionKey(updateDocumentDto.Type.ToString()), cancellationToken);
        if (document == null) return;
        
        await _documentBlobService.DeleteDocument(document.Url, cancellationToken);
        document.Url = await _documentBlobService.UploadDocument(updateDocumentDto.Data, cancellationToken);
        
        await _documentDbRepo.UpdateDocument(document, 
            new PartitionKey(updateDocumentDto.Type.ToString()), cancellationToken);
    }
    public async Task DeleteDocument(DeleteDocumentDto deleteDocumentDto, CancellationToken cancellationToken)
    {
        var document = await _documentDbRepo.GetDocumentByIdLinked(deleteDocumentDto.IdLinked,
            new PartitionKey(deleteDocumentDto.Type.ToString()), cancellationToken);
        if (document == null) return;
        
        await _documentDbRepo.DeleteDocument(document.IdDocument.ToString(),
            new PartitionKey(deleteDocumentDto.Type.ToString()), cancellationToken);
        await _documentBlobService.DeleteDocument(document.Url, cancellationToken);
    }
}