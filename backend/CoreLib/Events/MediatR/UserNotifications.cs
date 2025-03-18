using CoreLib.Models;
using MediatR;

namespace CoreLib.Events.MediatR;

public class UserAddedNotification(User user) : INotification
{
    public User User { get; } = user;
}

public class UserUpdatedNotification(User user) : INotification
{
    public User User { get; } = user;
}

public class UserDeletedNotification(User user) : INotification
{
    public User User { get; } = user;
}