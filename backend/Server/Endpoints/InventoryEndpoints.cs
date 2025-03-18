using CoreLib.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserLibrary;

namespace digital_pantry.Endpoints;

public static class InventoryEndpoints
{
    public static void Map(WebApplication app)
    {
        var mappings = app.MapGroup("inventory");
        mappings.MapGet("/{id}", GetInventoryById);
        mappings.MapGet("/{id}/items/{code}", GetItemByCode);
        mappings.MapPut("/{id}/items", AddItem);
        mappings.MapPost("/{id}/items", UpdateItem);
    }

    public static async Task<IResult> GetInventoryById([FromServices] InventoryService svc, string id)
    {
        return Results.Ok(await svc.GetInventoryAsync(id));
    }

    public static async Task<IResult> GetItemByCode([FromServices] InventoryService svc, string id, string code)
    {
        return Results.Ok(await svc.GetItemAsync(id, code));
    }

    public static async Task<IResult> AddItem([FromServices] InventoryService svc, string id,
        [FromBody] InventoryItem item)
    {
        var createdItem = await svc.AddItemAsync(id, item);
        return Results.Created($"inventory/{item.UpcCode}/items/{item.UpcCode}", createdItem);
    }

    public static async Task<IResult> UpdateItem([FromServices] InventoryService svc, string id, InventoryItem item)
    {
        return Results.Ok(await svc.UpdateItemAsync(id, item));
    }
}