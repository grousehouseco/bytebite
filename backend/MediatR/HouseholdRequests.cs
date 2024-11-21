using digital_pantry.Models;
using MediatR;

namespace digital_pantry.MediatR;
public class AddHouseholdRequest(Household household) : INotification
{
    public Household Household { get; init; } = household;
}
public class UpdateHouseholdRequest(List<FieldValue> updates) : INotification
{
    public List<FieldValue> Updates { get; } = updates;
}
public class DeleteHouseholdRequest(Household household) : INotification
{
    public Household Household { get; init; } = household;
}