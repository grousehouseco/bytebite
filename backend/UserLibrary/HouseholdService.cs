using CoreLib.Events.MediatR;
using CoreLib.Exceptions;
using CoreLib.Models;
using CoreLib.Services;
using CoreLib.ServiceUtils;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace UserLibrary;

public class HouseholdService(IOptions<MongoOptions> options, IMediator mediator) : RepositoryBase<Household>(options)
{
    public async Task<List<Household>> GetHouseholdsAsync()
    {
        return await GetAsync();
    }

    public async Task<Household> GetHouseholdAsync(string id)
    {
        var res = (await GetByNamedParamAsync("Id", id))?.FirstOrDefault();
        if (res is null)
        {
            throw new NotFoundException($"Household with id '{id}' does not exist");
        }
        return res;
    }

    public async Task<Household> AddHouseholdAsync(string householdName, string creatorId)
    {
        if (string.IsNullOrEmpty(householdName))
        {
            throw new BadRequestException("Household name cannot be empty");
        }

        if (string.IsNullOrEmpty(creatorId))
        {
            throw new BadRequestException("Household must have at least one member");
        }
        var household = new Household()
        {
            Id = ObjectId.GenerateNewId().ToString(),
            Name = householdName,
            Members = [creatorId],
            InventoryId = ObjectId.GenerateNewId().ToString()
        };
        await AddOrReplaceAsync(household);
        await mediator.Publish(new HouseholdAddedNotification(household));
        return household;
    }

    public async Task<Household> UpdateHouseholdAsync(Household household)
    {
        var existingHousehold = await GetHouseholdAsync(household.Id);
        if (household.Members.Count != existingHousehold.Members.Count)
        {
            existingHousehold.Members = household.Members;
        }

        if (household.Name != existingHousehold.Name)
        {
            // validate name
            existingHousehold.Name = household.Name;
        }
        await AddOrReplaceAsync(existingHousehold);
        await mediator.Publish(new HouseholdUpdatedNotification(household));
        return household;
    }

    public async Task DeleteHouseholdAsync(string id)
    {
        await DeleteByNamedParameterAsync("Id", id);
    }
}