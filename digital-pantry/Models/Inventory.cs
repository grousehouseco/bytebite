using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace digital_pantry.Models;

public class Inventory
{
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("id")]
    public string Id { get; set; }
    
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("owner")]
    public string Owner { get; set; } // user or household
    
    [BsonElement("items")]
    public List<InventoryItem>? Items { get; set; }
    
    
}

public class InventoryItem
{
    [BsonId]
    [BsonElement("code")]
    public string? UpcCode { get; set; }
    [BsonElement("quantity_in_stock")]
    public double? QuantityInStock { get; set; }
    [BsonElement("unit")]
    public string? Unit { get; set; }
    [BsonElement("last_purchase_date")]
    public DateTimeOffset LastPurchaseDate { get; set; }
}