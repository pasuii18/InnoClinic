namespace Infrastructure.Common.Options;

public class MongoDbOptions
{
    public const string MongoDbName = "OfficesDb";
    public string MongoDbConnectionString { get; set; }
}