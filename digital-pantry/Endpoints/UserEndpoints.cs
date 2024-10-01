using digital_pantry.MediatR;
using digital_pantry.Models;
using digital_pantry.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace digital_pantry.Endpoints;

public static class UserEndpoints
{
    public static void Map(WebApplication app)
    {
        var mappings = app.MapGroup("users");
        mappings.MapGet("/", GetUsers);
        mappings.MapPost("/", UpsertUser);
        mappings.MapDelete("/{email}", DeleteUser);
    }

    public static IResult GetUsers([FromServices] UserRepository repo, string pageCount = "2", string pageSize = "10", string propertyName = "", string? propertyValue = "")
    {
        return string.IsNullOrEmpty(propertyName) || string.IsNullOrEmpty(propertyValue)
            ? Results.Ok(repo.GetAsync().Result)
            : Results.Ok(repo.GetByNamedParamAsync(propertyName, propertyValue, pageSize:pageSize, pageCount:pageCount).Result);
    }

    public static IResult UpsertUser([FromServices] UserRepository repo, [FromServices]IMediator mediator, [FromBody]User user)
    {
        var existingUsers = repo.GetByNamedParamAsync("Email", user.Email).Result;
        if (existingUsers?.Count < 1 || existingUsers?[0] is null)
        {
            User newUser = new()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Email = user.Email, 
                Settings = new AppSettings(),
                Friends = [],
                InventoryId = ObjectId.GenerateNewId().ToString(),
            };
            var result = repo.PostAsync(newUser).Result;
            if (!result) return Results.BadRequest();
            mediator.Publish(new AddUserRequest(newUser));
            return Results.Created($"users/{newUser.Email}", newUser);
        }
        var existingUser = existingUsers[0];
        if(existingUser.Id != user.Id) return Results.BadRequest();
        if(user.Email is not null) existingUser.Email = user.Email;
        if(user.Friends is not null) existingUser.Friends = user.Friends;
        if(user.Settings is not null) existingUser.Settings = user.Settings;
        var updateResult = repo.PostAsync(existingUser).Result;
        if(!updateResult) return Results.NotFound();
        mediator.Publish(new UpdateUserRequest(existingUser));
        return Results.Ok(existingUser);
    }
    private static IResult DeleteUser([FromServices] UserRepository repo, [FromServices]IMediator mediator, string email)
    {
        var user = repo.GetByNamedParamAsync("Email", email).Result;
        if(user is null || user.Count != 1) return Results.NotFound();
        var result = repo.DeleteByNamedParameterAsync("Email", email).Result;
        if(result == 0) return Results.NotFound();
        mediator.Publish(new DeleteUserRequest(user[0]));
        return Results.NoContent();
    }
}