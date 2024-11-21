using digital_pantry.MediatR;
using digital_pantry.Models;
using digital_pantry.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YamlDotNet.Core.Events;

namespace digital_pantry.Endpoints;

public static class InventoryEndpoints
{
    public static void Map(WebApplication app)
    {
        var mappings = app.MapGroup("inventory");
        mappings.MapGet("/{id}", GetInventoryById);
        mappings.MapGet("/{id}/items", GetItemByCode);
        mappings.MapPost("/{id}/items", UpsertItem);
    }

    public static IResult GetInventoryById([FromServices]InventoryRepository repo, [FromServices]IMediator mediator, string id)
    {
        var res = GetInventory(repo, id);
        if(res is null) return Results.NotFound();
        return Results.Ok(res);
    }

    private static Inventory? GetInventory(InventoryRepository repo, string id)
    {
        var res = repo.GetByNamedParamAsync("Id", id).Result;
        if(res?.Count is < 1) return null;
        return res![0];
    }
    public static IResult GetItemByCode([FromServices]InventoryRepository repo, [FromServices]IMediator mediator, string id, [FromQuery]string code)
    {
        var inv = GetInventory(repo, id);
        if(inv?.Items is null) return Results.NotFound();
        var res = inv.Items.Find(item => item.UpcCode == code);
        if(res is null) return Results.NotFound(); // make another call to grocery API
        return Results.Ok(res);
    }
    public static IResult UpsertItem([FromServices]InventoryRepository repo, [FromServices]IMediator mediator, string id, [FromBody]InventoryItem item)
    {
        var inv = GetInventory(repo, id);
        if(inv is null) return Results.NotFound();
        inv.Items ??= new List<InventoryItem>();
        var existingItem = inv.Items.Find(i => i.UpcCode == item.UpcCode);
        if (existingItem is null)
        {
            inv.Items.Add(item);
            var res = repo.PostAsync(inv).Result;
            if(!res) return Results.BadRequest();
            mediator.Publish(new AddInventoryItemRequest(item));
            return Results.Created($"inventory/{id}/items/{item.UpcCode}", item);
        }
        var index = inv.Items.FindIndex(i => i.UpcCode == item.UpcCode);
        inv.Items[index].QuantityInStock = item.QuantityInStock;
        inv.Items[index].LastPurchaseDate = item.LastPurchaseDate;
        var updateRes = repo.PostAsync(inv).Result;
        if(!updateRes) return Results.BadRequest();
        mediator.Publish(new UpdateInventoryItemRequest(item));
        return Results.Ok(inv);
    }
}