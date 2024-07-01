using DAL.Entities;
using Microsoft.Azure.Cosmos;

namespace DAL.Common.Interfaces.RepoInterfaces;

public interface IDocumentDbRepo
{
    public Task<Document?> GetDocumentByIdLinked(Guid idLinked, CancellationToken cancellationToken);
    public Task CreateDocument(Document document, PartitionKey partition, CancellationToken cancellationToken);
    public Task UpdateDocument(Document document, PartitionKey partition, CancellationToken cancellationToken);
    public Task DeleteDocument(string idDocument, PartitionKey partition, CancellationToken cancellationToken);
}