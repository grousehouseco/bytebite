using digital_pantry.MediatR;
using digital_pantry.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace digital_pantry.Repository;

public class HouseholdRepository(IOptions<MongoOptions> options)
    : RepositoryBase<Household>(options), INotificationHandler<DeleteUserRequest>
{
    public Task Handle(DeleteUserRequest notification, CancellationToken cancellationToken)
    {
        var res = DeleteMember(notification.User.HouseholdId, notification.User.Id);
        return res is null or < 1 ? Task.CompletedTask : Task.FromResult(res);
    }

    public int? DeleteMember(string? id, string userId)
    {
        if(string.IsNullOrEmpty(id)) return null;
        var collection = GetCollection();
        var filter = Builders<Household>.Filter.Eq("_id", id);
        var update = Builders<Household>.Update.Pull<string>(household => household.Members, userId);
        var result = collection.UpdateOne(filter, update);
        return result.IsModifiedCountAvailable ? (int?)result.ModifiedCount : 0;
    }
}