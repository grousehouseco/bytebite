using System.Text.Json;
using System.Text.Json.Serialization;
using digital_pantry.Models;
using digital_pantry.Repository;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

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
        if (string.IsNullOrEmpty(code)) return Results.BadRequest();
        var res = repo.GetByNamedParamAsync("Id", code).Result;
        if (res?.Count > 0) return Results.Ok(res[0]);
        // call openApi to get the entry, the add it to db
        var link = $"https://world.openfoodfacts.org/api/v2/search?code={code}";
        var offResult = client.GetAsync(link).Result;
        if(!offResult.IsSuccessStatusCode) return Results.StatusCode(500);
        var str = offResult.Content.ReadAsStringAsync().Result;
        var resp = JsonSerializer.Deserialize<OpenFoodResponse>(str);
        if(resp?.Count < 1) return Results.NotFound();
        var item = resp!.Products[0];
        var addRes = repo.PostAsync(item).Result;
        return addRes ? Results.Created($"/groceries/{code}", item) : Results.NotFound();
    }
}

public class OpenFoodResponse
{
    [JsonPropertyName("count")]
    public int Count { get; set; }
    [JsonPropertyName("products")]
    public List<Grocery> Products { get; set; }
}