using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace digital_pantry.Models;

public class User
{
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("id")]
    public string Id { get; set; }
    
    [BsonElement("email")]
    public string? Email { get; set; }
    
    [BsonElement("friends")]
    public List<string>? Friends { get; set; }
    
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("household_id")]
    public string? HouseholdId { get; set; }
    
    [BsonElement("settings")]
    public AppSettings? Settings { get; set; }
    
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("inventory_id")]
    public string InventoryId { get; set; }
}