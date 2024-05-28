using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Common.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Persistence;

public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _database;
    
    public MongoDbContext(CustomMongoDbClient client)
    {
        _database = client.GetDatabase(MongoDbOptions.MongoDbName);
        Offices = _database.GetCollection<Office>("Offices");
    }

    public IMongoCollection<Office> Offices { get; }
}
