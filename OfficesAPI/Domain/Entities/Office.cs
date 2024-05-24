using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

public class Office
{
    // [BsonId]
    // [BsonRepresentation(BsonType.ObjectId)]
    // public string Id { get; set; }
    
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid IdOffice { get; set; }
    public string Address { get; set; }
    public string RegistryPhoneNumber { get; set; }
    public bool IsActive { get; set; }
    public Guid IdPhoto { get; set; }
    public string Url { get; set; } // use only after brokers have been implemented
}