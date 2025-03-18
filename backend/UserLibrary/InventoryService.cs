using CoreLib.Exceptions;
using CoreLib.Models;
using CoreLib.Services;
using CoreLib.ServiceUtils;
using MediatR;
using Microsoft.Extensions.Options;

namespace UserLibrary;

public class InventoryService(IOptions<MongoOptions> options, IMediator mediator) : RepositoryBase<Inventory>(options)
{
    // once an inventory exists, it will not be removed unless its owner is removed
    // items are not deleted, just updated with quantity = 0
    public async Task<Inventory> GetInventoryAsync(string id)
    {
        var res = (await GetByNamedParamAsync("Id", id))?.FirstOrDefault();
        if (res is null)
        {
            throw new NotFoundException($"Inventory with Id '{id}' not found");
        }

        return res!;
    }
    public async Task<Inventory> GetInventoryByOwnerAsync(string owner)
    {
        var res = (await GetByNamedParamAsync("Owner", owner))?.FirstOrDefault();
        if (res is null)
        {
            throw new NotFoundException($"Inventory for owner '{owner}' not found");
        }

        return res!;
    }

    public async Task<InventoryItem> GetItemAsync(string id, string upcCode)
    {
        var inventory = await GetInventoryAsync(id);
        var res = inventory.Items.FirstOrDefault(x => x.UpcCode == upcCode);
        if (res is null)
        {
            throw new NotFoundException($"Item with upc code '{upcCode}' not found in inventory '{inventory.Id}'");
        }

        return res!;
    }

    public async Task<Inventory> AddInventoryAsync(string owner, string id)
    {
        var inventory = new Inventory()
        {
            Owner = owner,
            Id = id,
            Items = new List<InventoryItem>()
        };
        await AddOrReplaceAsync(inventory);
        return inventory;
    }

    public async Task<InventoryItem> AddItemAsync(string id, InventoryItem item)
    {
        var inventory = await GetInventoryAsync(id);
        if (inventory.Items.Exists(i => i.UpcCode == item.UpcCode))
        {
            throw new BadRequestException($"Item with upc code '{item.UpcCode}' already exists");
        }
        inventory.Items.Add(item);
        return item;
    }

    public async Task<InventoryItem> UpdateItemAsync(string owner, InventoryItem item)
    {
        var inventory = await GetInventoryAsync(owner);
        var existingItem = inventory.Items.FirstOrDefault(i => i.UpcCode == item.UpcCode);
        if (existingItem is null)
        {
            throw new NotFoundException($"Item with upc code '{item.UpcCode}' does not exist");
        }
        var itemIndex = inventory.Items.IndexOf(existingItem);
        inventory.Items[itemIndex].QuantityInStock = item.QuantityInStock;
        inventory.Items[itemIndex].LastPurchaseDate = item.LastPurchaseDate;
        inventory.Items[itemIndex].Unit = item.Unit;
        await AddOrReplaceAsync(inventory);
        return item;
    }
}