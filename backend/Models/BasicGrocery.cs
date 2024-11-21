using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace digital_pantry.Models;

public class BasicGrocery
{
    [JsonPropertyName("id")]
    [BsonElement("id")]
    public string Id { get; set; } //same as FDCID

    [JsonPropertyName("description")]
    [BsonElement("description")]
    public string[] Description { get; set; } = []; // description split on ','
    
    [JsonPropertyName("scientific_name")]
    [BsonElement("scientific_name")]
    public string ScientificName { get; set; } = String.Empty;
    
    
}