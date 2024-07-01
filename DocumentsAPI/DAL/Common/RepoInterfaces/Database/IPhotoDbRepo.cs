using DAL.Entities;
using Microsoft.Azure.Cosmos;

namespace DAL.Common.Interfaces.RepoInterfaces;

public interface IPhotoDbRepo
{
    public Task<Photo?> GetPhotoByIdLinked(string idLinked, PartitionKey partition, CancellationToken cancellationToken);
    public Task CreatePhoto(Photo photo, PartitionKey partition, CancellationToken cancellationToken);
    public Task UpdatePhoto(Photo photo, PartitionKey partition, CancellationToken cancellationToken);
    public Task DeletePhoto(string idPhoto, PartitionKey partition, CancellationToken cancellationToken);
}