using DAL.Common.Contexts;
using DAL.Common.Interfaces.RepoInterfaces;
using DAL.Entities;
using Microsoft.Azure.Cosmos;

namespace DAL.Repos.Database;

public class DocumentDbRepo(CosmosDbContext _context) : IDocumentDbRepo
{
    public async Task<Document?> GetDocumentByIdLinked(Guid idLinked, PartitionKey partition, CancellationToken cancellationToken)
    {
        var query = new QueryDefinition("SELECT * FROM c WHERE c.IdLinked = @IdLinked")
            .WithParameter("@IdLinked", idLinked);

        var iterator = _context.DocumentsContainer.GetItemQueryIterator<Document>(
            query,
            requestOptions: new QueryRequestOptions { PartitionKey = partition });

        if (iterator.HasMoreResults)
        {
            var response = await iterator.ReadNextAsync(cancellationToken);
            return response.FirstOrDefault();
        }

        return null;
    }
    public async Task CreateDocument(Document document, PartitionKey partition, CancellationToken cancellationToken)
    {
        await _context.PhotosContainer
            .CreateItemAsync(document, partition, cancellationToken: cancellationToken);
    }
    public async Task UpdateDocument(Document document, PartitionKey partition, CancellationToken cancellationToken)
    {
        await _context.DocumentsContainer
            .ReplaceItemAsync(document, document.IdDocument.ToString(), partition, cancellationToken: cancellationToken);
    }
    public async Task DeleteDocument(string idDocument, PartitionKey partition, CancellationToken cancellationToken)
    {
        await _context.DocumentsContainer
            .DeleteItemAsync<Document>(idDocument, partition, cancellationToken: cancellationToken);
    }
}