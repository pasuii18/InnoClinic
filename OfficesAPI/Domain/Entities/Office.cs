using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

public class Office
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid IdOffice { get; set; }
    [BsonRepresentation(BsonType.String)]
    public string Address { get; set; }
    [BsonRepresentation(BsonType.String)]
    public string RegistryPhoneNumber { get; set; }
    [BsonRepresentation(BsonType.Boolean)]
    public bool IsActive { get; set; }
    [BsonRepresentation(BsonType.String)]
    public Guid IdPhoto { get; set; }
    [BsonRepresentation(BsonType.String)]
    public string Url { get; set; } // use only after brokers have been implemented
}