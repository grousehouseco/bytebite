using CoreLib.Events.MediatR;
using MediatR;

namespace UserLibrary;

public class UserAddedHandler: INotificationHandler<UserAddedNotification>
{
    public Task Handle(UserAddedNotification notification, CancellationToken cancellationToken)
    {
        // create inventory object
        throw new NotImplementedException();
    }
}