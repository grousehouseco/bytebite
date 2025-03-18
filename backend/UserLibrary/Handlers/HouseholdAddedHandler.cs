using CoreLib.Events.MediatR;
using MediatR;

namespace UserLibrary.Handlers;

public class HouseholdAddedHandler: INotificationHandler<HouseholdAddedNotification>
{
    public Task Handle(HouseholdAddedNotification notification, CancellationToken cancellationToken)
    {
        // add inventory for household
        throw new NotImplementedException();
    }
}