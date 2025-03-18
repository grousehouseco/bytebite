using CoreLib.Events.MediatR;
using CoreLib.Exceptions;
using MediatR;

namespace UserLibrary;

public class HouseholdUpdatedHandler(UserService service): INotificationHandler<HouseholdUpdatedNotification>
{
    public async Task Handle(HouseholdUpdatedNotification notification, CancellationToken cancellationToken)
    {
        var householdId = notification.Household.Id;
        var members = notification.Household.Members;
        foreach (var member in members)
        { 
            // TODO refactor to call update many
            var user = await service.GetUserByIdAsync(member);
            if (user == null) return;
            user.HouseholdId = householdId;
            await service.UpdateUserAsync(user);
        }
    }
}