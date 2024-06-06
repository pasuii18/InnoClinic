using Infrastructure.Common.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Persistence;

public class CustomMongoDbClient(IOptions<MongoDbOptions> options) 
    : MongoClient(options.Value.MongoDbConnectionString);