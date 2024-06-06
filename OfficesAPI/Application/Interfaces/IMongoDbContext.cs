using Domain.Entities;
using MongoDB.Driver;

namespace Application.Interfaces;

public interface IMongoDbContext
{
    public IMongoCollection<Office> Offices { get; }
}