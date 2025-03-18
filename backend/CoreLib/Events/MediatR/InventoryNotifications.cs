using CoreLib.Models;
using MediatR;

namespace CoreLib.Events.MediatR;

public class ItemAdded(InventoryItem item) : INotification
{
    public InventoryItem Item { get; init; } = item;
}

public class ItemUpdated(List<InventoryItem> updatedItems) : INotification
{
    public List<InventoryItem> UpdatedItems { get; init; } = updatedItems;
}