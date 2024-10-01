using digital_pantry.Models;
using digital_pantry.Repository;
using Microsoft.AspNetCore.Mvc;

namespace digital_pantry.Endpoints;

public static class GroceryEndpoints
{
    public static void Map(WebApplication app)
    {
        var mappings = app.MapGroup("groceries");
        mappings.MapGet("/{code}", GetByCode);
        mappings.MapPut("/", AddItem);
    }

    public static IResult GetByCode([FromServices]GroceryRepository repo, string code)
    {
        return Results.Ok(repo.GetByNamedParamAsync("UpcCode", code).Result);
    }
    public static IResult AddItem([FromServices]GroceryRepository repo, [FromBody]Grocery item)
    {
        var existingItem = repo.GetByNamedParamAsync("UpcCode", item.UpcCode).Result;
        if (existingItem is not { Count: < 1 }) return Results.Conflict();
        var result = repo.PostAsync(item).Result;
        if (!result) return Results.BadRequest();
        return Results.Created($"groceries/{item.UpcCode}", item);
    }
}