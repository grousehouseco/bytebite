using CoreLib.Events.MediatR;
using MediatR;

namespace UserLibrary.Handlers;

public class UserDeletedHandler: INotificationHandler<UserDeletedNotification>
{
    public Task Handle(UserDeletedNotification notification, CancellationToken cancellationToken)
    {
        // remove inventory
        throw new NotImplementedException();
    }
}