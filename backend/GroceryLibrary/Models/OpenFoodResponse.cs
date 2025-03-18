using System.Text.Json.Serialization;
using CoreLib.Models;

namespace GroceryLibrary.Models;

public class OpenFoodResponse
{
    [JsonPropertyName("count")] 
    public int Count { get; set; } = 0;

    [JsonPropertyName("products")] 
    public List<Grocery> Products { get; set; } = [];
}