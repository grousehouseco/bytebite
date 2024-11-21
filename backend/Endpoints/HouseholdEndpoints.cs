using digital_pantry.MediatR;
using digital_pantry.Models;
using digital_pantry.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace digital_pantry.Endpoints;

public static class HouseholdEndpoints
{
    public static void Map(WebApplication app)
    {
        var mappings = app.MapGroup("households");
        mappings.MapGet("/", GetHouseholds);
        mappings.MapGet("/{id}", GetHousehold);
        mappings.MapGet("/{id}/members", GetMembers);
        mappings.MapPost("/{id}", UpdateName);
        mappings.MapPost("/", AddHousehold);
        mappings.MapPost("/{id}/members", AddMember);
        mappings.MapDelete("/{id}", DeleteHousehold);
        mappings.MapDelete("/{id}/members", DeleteMember);
    }

    public static IResult GetHousehold([FromServices] HouseholdRepository repository, [FromRoute] string id)
    {
        if(string.IsNullOrEmpty(id)) return Results.BadRequest();
        var res = repository.GetByNamedParamAsync("Id", id).Result;
        return (res?.Count is > 0) ? Results.Ok(res) : Results.NotFound();
    }
    public static IResult GetHouseholds([FromServices] HouseholdRepository repository)
    {
        var allResult = repository.GetAsync().Result;
        return allResult.Count is > 0 ? Results.Ok(allResult) : Results.Ok(new List<Household>());
    }
    public static IResult GetMembers([FromServices] HouseholdRepository repository, string id)
    {
        var res = repository.GetByNamedParamAsync("Id", id).Result;
        if (res == null) return Results.BadRequest();
        if (res.Count == 0) return Results.NotFound();
        return Results.Ok(res[0].Members);
    }
    public static IResult UpdateName([FromServices] HouseholdRepository repository,
        [FromServices] IMediator mediator, string id, [FromQuery] string? name = null)
    {
        if(string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name)) return Results.BadRequest();
        var res = repository.GetByNamedParamAsync("Id", id).Result;
        if (res == null) return Results.NotFound();
        var household = res[0];
        household.Name = name;
        var postResult = repository.PostAsync(household).Result;
        if(!postResult) return Results.BadRequest();
        mediator.Publish(new UpdateHouseholdRequest([new FieldValue(){Field="Name", Value=household.Name}]));
        return Results.Ok(postResult);
    }

    public static IResult AddHousehold([FromServices] HouseholdRepository repository, [FromServices] IMediator mediator, [FromQuery] string name)
    {
        if(string.IsNullOrEmpty(name)) return Results.BadRequest();
        var res = repository.GetByNamedParamAsync("Name", name).Result;
        if (res?.Count is > 0) return Results.Conflict();
        var household = new Household()
        {
            Id = ObjectId.GenerateNewId().ToString(),
            Name = name,
            Members = [],
            InventoryId = ObjectId.GenerateNewId().ToString()
        };
        var postResult = repository.PostAsync(household).Result;
        if(!postResult) return Results.BadRequest();
        mediator.Publish(new AddHouseholdRequest(household));
        return Results.Created($"households/{name}", household);
    }
    public static IResult AddMember([FromServices] HouseholdRepository repository,
        [FromServices] IMediator mediator, string id, [FromQuery] string? memberId = null)
    {
        if(string.IsNullOrEmpty(id) || string.IsNullOrEmpty(memberId)) return Results.BadRequest();
        var res = repository.GetByNamedParamAsync("Id", id).Result;
        if (res == null) return Results.NotFound();
        var household = res[0];
        household.Members ??= [];
        household.Members.Add(memberId);
        var postResult = repository.PostAsync(household).Result;
        if(!postResult) return Results.BadRequest();
        mediator.Publish(new UpdateHouseholdRequest(
            [
                new FieldValue(){Field="Id", Value=household.Id},
                new FieldValue(){Field="Members", Value=household.Members}
            ]));
        return Results.Ok(postResult);
    }

    public static IResult DeleteHousehold([FromServices] HouseholdRepository repository,
        [FromServices] IMediator mediator, string id)
    {
        if(string.IsNullOrEmpty(id)) return Results.BadRequest();
        var res = repository.GetByNamedParamAsync("Id", id).Result;
        if (res == null) return Results.NotFound();
        
        var deleteRes = repository.DeleteByNamedParameterAsync("Id", id).Result;
        if (deleteRes == 0) return Results.NotFound();
        mediator.Publish(new DeleteHouseholdRequest(res[0]));
        return Results.Ok();
    }

    public static IResult DeleteMember([FromServices] HouseholdRepository repository, string id, [FromQuery] string userId)
    {
        if(string.IsNullOrEmpty(id) || string.IsNullOrEmpty(userId)) return Results.BadRequest();
        var res = repository.DeleteMember(id, userId);
        return res is > 0 ? Results.NoContent() : Results.NotFound();
    }
}