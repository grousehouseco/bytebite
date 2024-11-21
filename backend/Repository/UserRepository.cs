using digital_pantry.MediatR;
using digital_pantry.Models;
using MediatR;
using Microsoft.Extensions.Options;

namespace digital_pantry.Repository;

public class UserRepository(IOptions<MongoOptions> options) : RepositoryBase<User>(options), INotificationHandler<UpdateHouseholdRequest>
{
    public Task Handle(UpdateHouseholdRequest notification, CancellationToken cancellationToken)
    {
        var idValue = notification.Updates.Find(val => val.Field == "Id");
        var membersValue = notification.Updates.Find(val => val.Field == "Members");
        if(idValue?.Value is not string id || membersValue?.Value is not List<string> members) 
            return Task.FromException(new ArgumentException("Invalid id"));
        foreach (var member in members)
        {
            // TODO refactor to call update many
            var users = GetByNamedParamAsync("Id", member).Result;
            if (users?.Count is < 1) break;
            var user = users![0];
            user.HouseholdId = id;
            PostAsync(user).Wait(cancellationToken);
        }
        return Task.CompletedTask;
    }
}