using CoreLib.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserLibrary;

namespace digital_pantry.Endpoints;

public static class UserEndpoints
{
    public static void Map(WebApplication app)
    {
        var mappings = app.MapGroup("users");
        mappings.MapGet("/", GetUsers);
        mappings.MapPut("/{email}", AddUser);
        mappings.MapPost("/", UpdateUser);
        mappings.MapDelete("/{id}", DeleteUser);
    }

    public static async Task<IResult> GetUsers([FromServices] UserService svc)
    {
        return Results.Ok(await svc.GetUsersAsync());
    }

    public static async Task<IResult> AddUser([FromServices] UserService svc, [FromServices] IMediator mediator,
        string email)
    {
        var res = await svc.AddUserAsync(email);
        return Results.Created($"users/{res.Id}", res);
    }
    public static async Task<IResult> UpdateUser([FromServices] UserService svc, [FromServices]IMediator mediator, [FromBody]User user)
    {
        var res= await svc.UpdateUserAsync(user);
        return Results.Ok(res);
    }
    public static async Task<IResult> DeleteUser([FromServices] UserService svc, [FromServices]IMediator mediator, string id)
    {
        await svc.DeleteUserByIdAsync(id);
        return Results.NoContent();
    }
}