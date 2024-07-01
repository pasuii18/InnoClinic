using DAL.Common.Contexts;
using DAL.Common.Interfaces.RepoInterfaces;
using DAL.Entities;
using Microsoft.Azure.Cosmos;

namespace DAL.Repos.Database;

public class PhotoDbRepo(CosmosDbContext _context) : IPhotoDbRepo
{
    public async Task<Photo?> GetPhotoByIdLinked(string idLinked, PartitionKey partition, CancellationToken cancellationToken)
    {
        var query = new QueryDefinition("SELECT * FROM c WHERE c.IdLinked = @IdLinked")
            .WithParameter("@IdLinked", idLinked);

        var iterator = _context.PhotosContainer.GetItemQueryIterator<Photo>(
            query,
            requestOptions: new QueryRequestOptions { PartitionKey = partition });

        if (iterator.HasMoreResults)
        {
            var response = await iterator.ReadNextAsync(cancellationToken);
            return response.FirstOrDefault();
        }

        return null;
    }
    public async Task CreatePhoto(Photo photo, PartitionKey partition, CancellationToken cancellationToken)
    {
        await _context.PhotosContainer
            .CreateItemAsync(photo, partition, cancellationToken: cancellationToken);
    }
    public async Task UpdatePhoto(Photo photo, PartitionKey partition, CancellationToken cancellationToken)
    {
        await _context.PhotosContainer
            .ReplaceItemAsync(photo, photo.IdPhoto.ToString(), partition, cancellationToken: cancellationToken);
    }
    public async Task DeletePhoto(string idPhoto, PartitionKey partition, CancellationToken cancellationToken)
    {
        await _context.PhotosContainer
            .DeleteItemAsync<Photo>(idPhoto, partition, cancellationToken: cancellationToken);
    }
}