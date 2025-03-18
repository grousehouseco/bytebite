using CoreLib.Events.MediatR;
using CoreLib.Exceptions;
using CoreLib.Models;
using CoreLib.Services;
using CoreLib.ServiceUtils;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace UserLibrary;

public class UserService(IOptions<MongoOptions> options, IMediator mediator) : RepositoryBase<User>(options)
{
    public async Task<List<User>> GetUsersAsync()
    {
        return await GetAsync();
    }
    public async Task<User?> GetUserByIdAsync(string id)
    {
        var users = (await GetByNamedParamAsync("Id", id).ConfigureAwait(false));
        if (users is null || users.Count == 0)
        {
            throw new NotFoundException($"User with Id '{id}' does not exist");
        }
        return users.FirstOrDefault();
    }

    public async Task<List<User>?> GetUsersByHouseholdAsync(string householdId)
    {
        return (await GetByNamedParamAsync("HouseholdId", householdId).ConfigureAwait(false));
    }

    public async Task<User> AddUserAsync(string userEmail)
    {
        User? existingUser = (await GetByNamedParamAsync("Email", userEmail))?.FirstOrDefault();
        if (existingUser is not null)
        {
            throw new BadRequestException($"User with email '{userEmail}' already exists");
        }

        var user = new User()
        {
            Email = userEmail,
            Id = ObjectId.GenerateNewId().ToString(),
            Settings = new AppSettings(),
            Friends = [],
            InventoryId = ObjectId.GenerateNewId().ToString(),
        };
        await AddOrReplaceAsync(user);
        await mediator.Publish(new UserAddedNotification(user));
        return user;

    }
    public async Task<bool> UpdateUserAsync(User user)
    {
        User? existingUser = (await GetByNamedParamAsync("Id", user.Id))?.FirstOrDefault();
        if (existingUser is null)
        {
            throw new BadRequestException($"User with Id '{user.Id}' does not exist");
        }
        var res = await AddOrReplaceAsync(user);
        if (!res) return false;
        await mediator.Publish(new UserUpdatedNotification(user));
        return true;
    }

    public async Task<bool> DeleteUserByIdAsync(string id)
    {
        User? existingUser = (await GetByNamedParamAsync("Id", id))?.FirstOrDefault();
        if (existingUser is null)
        {
            throw new BadRequestException($"User with Id '{id}' does not exist");
        }
        var res = await DeleteByNamedParameterAsync("Id", id);
        if (!res) return false;
        await mediator.Publish(new UserDeletedNotification(existingUser));
        return true;
    }
}