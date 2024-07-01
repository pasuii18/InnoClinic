using BAL.Common.Dtos;
using BAL.Common.Dtos.PhotoDtos;
using BAL.Common.Interfaces;
using DAL.Events.ResultEvents;

namespace BAL.Common.ServicesInterfaces;

public interface IDocumentDbService
{
    public Task<ICustomResult<string>> GetDocumentUrlByResultId(Guid idResult, CancellationToken cancellationToken);
    public Task CreateDocument(CreateDocumentDto createDocumentDto, CancellationToken cancellationToken);
    public Task UpdateDocument(UpdateDocumentDto updateDocumentDto, CancellationToken cancellationToken);
    public Task DeleteDocument(DeleteDocumentDto deleteDocumentDto, CancellationToken cancellationToken);
}