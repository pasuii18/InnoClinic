using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.Persistence;

public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _database;
    
    public MongoDbContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDbConnection");
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase("OfficesDb");
    }

    public IMongoCollection<Office> Offices => _database.GetCollection<Office>("Offices");
}
