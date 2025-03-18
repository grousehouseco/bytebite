using CoreLib.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserLibrary;

namespace digital_pantry.Endpoints;

public static class HouseholdEndpoints
{
    public static void Map(WebApplication app)
    {
        var mappings = app.MapGroup("households");
        mappings.MapGet("/", GetHouseholds);
        mappings.MapGet("/{id}", GetHousehold);
        mappings.MapGet("/{id}/members", GetMembers);
        mappings.MapPost("/{id}", UpdateHousehold);
        mappings.MapPost("/", AddHousehold);
        mappings.MapDelete("/{id}", DeleteHousehold);
    }

    public static async Task<IResult> GetHousehold([FromServices] HouseholdService svc, [FromRoute] string id)
    {
        return Results.Ok(await svc.GetHouseholdAsync(id));
    }
    public static async Task<IResult> GetHouseholds([FromServices] HouseholdService svc)
    {
        return Results.Ok(await svc.GetHouseholdsAsync());
    }
    public static async Task<IResult> GetMembers([FromServices] HouseholdService svc, string id)
    {
        return Results.Ok((await svc.GetHouseholdAsync(id)).Members);
    }
    public static async Task<IResult> UpdateHousehold([FromServices] HouseholdService svc, string id, [FromBody] Household household)
    {
        return Results.Ok(await svc.UpdateHouseholdAsync(household));
    }

    public static async Task<IResult> AddHousehold([FromServices] HouseholdService svc, [FromServices] IMediator mediator, [FromBody](string householdName, string creatorId) details)
    {
        var res = await svc.AddHouseholdAsync(details.householdName, details.creatorId);
        return Results.Created($"households/{details.householdName}", res);
    }

    public static async Task<IResult> DeleteHousehold([FromServices] HouseholdService svc, string id)
    {
        await svc.DeleteHouseholdAsync(id);
        return Results.NoContent();
    }
}