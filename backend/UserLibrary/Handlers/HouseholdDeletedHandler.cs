using CoreLib.Events.MediatR;
using MediatR;

namespace UserLibrary.Handlers;

public class HouseholdDeletedHandler: INotificationHandler<HouseholdDeletedNotification>
{
    //remove inventory
    public Task Handle(HouseholdDeletedNotification notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}