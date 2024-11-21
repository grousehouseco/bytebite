using digital_pantry.Models;
using MediatR;

namespace digital_pantry.MediatR;

public class AddInventoryItemRequest(InventoryItem item) : INotification
{
    public InventoryItem Item { get; init; } = item;
}

public class UpdateInventoryItemRequest(InventoryItem item) : INotification
{
    public InventoryItem Item { get; init; } = item;
}