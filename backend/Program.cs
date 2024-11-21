using System.Net;
using digital_pantry.Endpoints;
using digital_pantry.Models;
using digital_pantry.Repository;
using MongoDB.Bson.Serialization;
using Sieve.Services;
using NSwag.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://*:5000");
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", b => b
        .AllowAnyMethod()
        .AllowCredentials()
        .SetIsOriginAllowed((host) => true)
        .AllowAnyHeader());
});
builder.Configuration.AddEnvironmentVariables();
builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddScoped<SieveProcessor>();
builder.Services.AddHttpClient();
BsonClassMap.RegisterClassMap<User>();
BsonClassMap.RegisterClassMap<Inventory>();
BsonClassMap.RegisterClassMap<Household>();
BsonClassMap.RegisterClassMap<Grocery>();
BsonClassMap.RegisterClassMap<BasicGrocery>();
builder.Services.Configure<MongoOptions>(builder.Configuration.GetSection("Mongo"));
builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<InventoryRepository>();
builder.Services.AddSingleton<HouseholdRepository>();
builder.Services.AddSingleton<GroceryRepository>();
builder.Services.AddSingleton<BasicGroceryRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "DigitalPantryAPI";
    config.Title = "Digital Pantry API";
    config.Version = "v1";
});

var app = builder.Build();
app.UseOpenApi();
app.UseSwaggerUi(config =>
{
    config.DocumentTitle = "DigitalPantryAPI";
    config.Path = "/swagger";
    config.DocumentPath = "/swagger/{documentName}/swagger.json";
    config.DocExpansion = "list";
});

//app.UseAuthorization();

//app.MapControllers();
UserEndpoints.Map(app);
HouseholdEndpoints.Map(app);
GroceryEndpoints.Map(app);
app.UseCors("CorsPolicy");

app.Run();