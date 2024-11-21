using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace digital_pantry.Models;

public class Recipe
{
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("id")]
    public string Id { get; set; }
    public string Name { get; set; }
    public uint Yield { get; set; }
    public List<string> Tags { get; set; } = [];
    public TimeSpan TotalTime { get; set; }
    public TimeSpan ActiveTime { get; set; }
    public int? PreHeatTemperature { get; set; }
    public List<string> Directions { get; set; } = [];
    public List<RecipeIngredient> Ingredients { get; set; } = [];
}

public class RecipeIngredient
{
    public string Ingredient { get; set; } // butter
    public List<string> IngredientModifiers { get; set; } = []; // salted
    public double Quantity { get; set; } // 2
    public string Unit { get; set; } // Tbsp
}