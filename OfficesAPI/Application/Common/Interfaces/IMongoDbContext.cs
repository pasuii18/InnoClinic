using Domain.Entities;
using MongoDB.Driver;

namespace Application.Common.Interfaces;

public interface IMongoDbContext
{
    public IMongoCollection<Office> Offices { get; }
}