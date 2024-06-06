using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Domain.Entities;

public class Office
{
    [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId IdOffice { get; set; }
    [BsonRepresentation(BsonType.String)]
    public string Address { get; set; }
    [BsonRepresentation(BsonType.String)]
    public string RegistryPhoneNumber { get; set; }
    [BsonRepresentation(BsonType.Boolean)]
    public bool IsActive { get; set; }
    [BsonRepresentation(BsonType.String)]
    public Guid IdPhoto { get; set; }
}