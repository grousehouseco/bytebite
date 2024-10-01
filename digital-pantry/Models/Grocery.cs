using System.Text.Json.Serialization;
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
    [BsonId]
    [JsonPropertyName("code")]
    public string? UpcCode { get; set; }
    [JsonPropertyName("brands")]
    public string? Brands { get; set; }
    [JsonPropertyName("product_name")]
    public string? Name { get; set; }
    [JsonPropertyName("product_quantity")]
    public double? ProductQuantity { get; set; }
    [JsonPropertyName("product_quantity_unit")]
    public string? ProductQuantityUnit { get; set; }
    [JsonPropertyName("categories_hierarchy")]
    public List<string> Categories { get; set; } = [];
    [JsonPropertyName("image_thumb_url")]
    public string? ThumbnailUrl { get; set; }
    [JsonPropertyName("allergens_hierarchy")]
    public List<string> Allergens { get; set; } = [];
    [JsonPropertyName("serving_quantity")]
    public double? ServingQuantity { get; set; }
    [JsonPropertyName("serving_quantity_unit")]
    public string? ServingQuantityUnit { get; set; }
    [JsonPropertyName("serving_size")]
    public string? ServingSize { get; set; } // ServingQuantity + Unit as string
    [JsonPropertyName("links")]
    public List<string> Links { get; set; } = [];

}