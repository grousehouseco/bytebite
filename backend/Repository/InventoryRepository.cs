using digital_pantry.MediatR;
using digital_pantry.Models;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace digital_pantry.Repository;

public class InventoryRepository(IOptions<MongoOptions> options)
    : RepositoryBase<Inventory>(options), INotificationHandler<AddUserRequest>, INotificationHandler<DeleteUserRequest>, INotificationHandler<AddHouseholdRequest>
{
    public Task Handle(AddUserRequest notification, CancellationToken cancellationToken)
    {
        // Add new inventory
        var collection = GetCollection();
        var id = notification.User.InventoryId;
        if (string.IsNullOrEmpty(id))
            return Task.FromException(new ArgumentNullException());

        var inventory = new Inventory()
        {
            Id = id,
            Owner = notification.User.Id,
            Items = []
        };
        var bsonDoc = inventory.ToBsonDocument();
        var filter = Builders<Inventory>.Filter.Eq("_id", bsonDoc["_id"]);
        return collection.ReplaceOneAsync(
            filter, 
            inventory, 
            new ReplaceOptions {IsUpsert = true}, cancellationToken);
    }

    public Task Handle(DeleteUserRequest notification, CancellationToken cancellationToken)
    {
        var collection = GetCollection();
        return collection.DeleteOneAsync(Builders<Inventory>.Filter.Eq("_id", notification.User.InventoryId), cancellationToken);
    }

    public Task Handle(AddHouseholdRequest notification, CancellationToken cancellationToken)
    {
        // create a new inventory for the household
        var collection = GetCollection();
        var inv = new Inventory()
        {
            Id = notification.Household.InventoryId,
            Owner = notification.Household.Id,
            Items = []
        };
        return collection.InsertOneAsync(inv, new InsertOneOptions(), cancellationToken);
    }
}