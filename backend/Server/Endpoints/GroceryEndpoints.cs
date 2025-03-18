using GroceryLibrary;
using Microsoft.AspNetCore.Mvc;

namespace digital_pantry.Endpoints;

public static class GroceryEndpoints
{
    public static void Map(WebApplication app)
    {
        var mappings = app.MapGroup("groceries");
        mappings.MapGet("/branded", GetGroceryItem);
        mappings.MapGet("/basic", GetBasicGroceryItem);
    }

    public static async Task<IResult> GetGroceryItem([FromServices]GroceryService svc, [FromServices]HttpClient client, [FromQuery]string code)
    {
        var res = await svc.GetGroceryByUpc(upc: code);
        return Results.Ok(res);
    }

    public static async Task<IResult> GetBasicGroceryItem([FromServices] GroceryService svc,
        [FromQuery] string keywords)
    {
        var filteredResults = await svc.GetBasicGroceryByKeyword(keywords);
        return Results.Ok(filteredResults);
    }
}