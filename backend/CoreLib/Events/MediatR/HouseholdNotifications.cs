using CoreLib.Models;
using MediatR;

namespace CoreLib.Events.MediatR;
public class HouseholdAddedNotification(Household household) : INotification
{
    public Household Household { get; init; } = household;
}
public class HouseholdUpdatedNotification(Household household) : INotification
{
    public Household Household { get; init; }= household;
}
public class HouseholdDeletedNotification(Household household) : INotification
{
    public Household Household { get; init; } = household;
}