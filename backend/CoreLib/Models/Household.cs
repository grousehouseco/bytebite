using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoreLib.Models;

public class Household
{
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("id")]
    public string Id { get; init; }
    
    [BsonElement("name")]
    public string? Name { get; set; }

    [BsonElement("members")] public List<string> Members { get; set; } = [];
    
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("inventory_id")]
    public string InventoryId { get; init; }
}