using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoreLib.Models;

public class Inventory
{
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("id")]
    public string Id { get; init; }
    
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("owner")]
    public string Owner { get; init; } // user or household

    [BsonElement("items")] public List<InventoryItem> Items { get; set; } = [];


}

public class InventoryItem
{
    [BsonId]
    [BsonElement("code")]
    public string? UpcCode { get; init; }
    [BsonElement("quantity_in_stock")]
    public double? QuantityInStock { get; set; }
    [BsonElement("unit")]
    public string? Unit { get; set; }
    [BsonElement("last_purchase_date")]
    public DateTimeOffset LastPurchaseDate { get; set; }
}