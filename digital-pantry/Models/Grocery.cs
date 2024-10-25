using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace digital_pantry.Models;

public class Grocery
{
    /*
     * code: string = '';
       brands: string = '';
       product_name: string = '';
       product_quantity: number = 0;
       product_quantity_unit: string = 'g';
       categories_hierarchy: string[] = [];
       image_thumb_url: string = '';
       allergens_hierarchy: string[] = [];
       serving_quantity: string = '';
       serving_quantity_unit: string = '';
       serving_size: string = '';
       links: string[] = []; //holds a reference to the original search call
     */
    [JsonPropertyName("id")]
    [BsonElement("id")]
    public string? Id { get; set; } // UpcCode
    [JsonPropertyName("brands")]
    [BsonElement("brands")]
    public string? Brands { get; set; }
    [JsonPropertyName("product_name")]
    [BsonElement("product_name")]
    public string? Name { get; set; }
    [JsonPropertyName("product_quantity")]
    [BsonElement("product_quantity")]
    public string? ProductQuantity { get; set; }
    [JsonPropertyName("product_quantity_unit")]
    [BsonElement("product_quantity_unit")]
    public string? ProductQuantityUnit { get; set; }
    [JsonPropertyName("categories_hierarchy")]
    [BsonElement("categories_hierarchy")]
    public List<string> Categories { get; set; } = [];
    [JsonPropertyName("image_thumb_url")]
    [BsonElement("image_thumb_url")]
    public string? ThumbnailUrl { get; set; }
    [JsonPropertyName("allergens_hierarchy")]
    [BsonElement("allergens_hierarchy")]
    public List<string> Allergens { get; set; } = [];
    [JsonPropertyName("serving_quantity")]
    [BsonElement("serving_quantity")]
    public double? ServingQuantity { get; set; }
    [JsonPropertyName("serving_quantity_unit")]
    [BsonElement("serving_quantity_unit")]
    public string? ServingQuantityUnit { get; set; }
    [JsonPropertyName("serving_size")]
    [BsonElement("serving_size")]
    public string? ServingSize { get; set; } // ServingQuantity + Unit as string
    [JsonPropertyName("links")]
    [BsonElement("links")]
    public List<string> Links { get; set; } = [];

}