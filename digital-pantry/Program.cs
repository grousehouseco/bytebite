using digital_pantry.Endpoints;
using digital_pantry.Models;
using digital_pantry.Repository;
using MongoDB.Bson.Serialization;
using Sieve.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();
if(builder.Environment.IsDevelopment()) builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddScoped<SieveProcessor>();
BsonClassMap.RegisterClassMap<User>();
BsonClassMap.RegisterClassMap<Inventory>();
BsonClassMap.RegisterClassMap<Household>();
BsonClassMap.RegisterClassMap<Grocery>();
builder.Services.Configure<MongoOptions>(builder.Configuration.GetSection("Mongo"));
builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<InventoryRepository>();
builder.Services.AddSingleton<HouseholdRepository>();
builder.Services.AddSingleton<GroceryRepository>();


var app = builder.Build();

//app.UseAuthorization();

//app.MapControllers();
UserEndpoints.Map(app);
HouseholdEndpoints.Map(app);

app.Run();