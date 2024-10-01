using digital_pantry.Models;
using MediatR;

namespace digital_pantry.MediatR;

public class AddUserRequest(User user) : INotification
{
    public User User { get; } = user;
}

public class UpdateUserRequest(User user) : INotification
{
    public User User { get; } = user;
}

public class DeleteUserRequest(User user) : INotification
{
    public User User { get; } = user;
}