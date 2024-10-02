using System.Text.Json;
using System.Text.Json.Serialization;
using digital_pantry.Models;
using digital_pantry.Repository;
using Microsoft.AspNetCore.Mvc;

namespace digital_pantry.Endpoints;

public static class GroceryEndpoints
{
    public static void Map(WebApplication app)
    {
        var mappings = app.MapGroup("groceries");
        mappings.MapGet("/", GetGroceryItem);
    }

    public static IResult GetGroceryItem([FromServices]GroceryRepository repo, [FromServices]HttpClient client, [FromQuery]string code)
    {
        var res = repo.GetByNamedParamAsync("UpcCode", code).Result;
        if (!(res?.Count < 1) && res?[0] is not null) return Results.Ok(res![0]);
        // call openApi to get the entry, the add it to db
        var link = $"https://world.openfoodfacts.org/api/v2/search?code={code}";
        var offResult = client.GetAsync(link).Result;
        if(!offResult.IsSuccessStatusCode) return Results.StatusCode(500);
        var str = offResult.Content.ReadAsStringAsync().Result;
        var resp = JsonSerializer.Deserialize<OpenFoodResponse>(str);
        if(resp?.Count < 1) return Results.NotFound();
        var addRes = repo.PostAsync(resp!.Products[0]).Result;
        return addRes ? Results.Created($"/groceries/{code}", resp!.Products[0]) : Results.NotFound();
    }
}

public class OpenFoodResponse
{
    [JsonPropertyName("count")]
    public int Count { get; set; }
    [JsonPropertyName("products")]
    public List<Grocery> Products { get; set; }
}