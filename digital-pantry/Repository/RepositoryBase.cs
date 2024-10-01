using System.Runtime.CompilerServices;
using System.Text.Json;
using digital_pantry.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace digital_pantry.Repository;

public class RepositoryBase<T> where T : class
{
    private const string DbName = "digital_pantry";
    protected readonly MongoClient Client;

    public RepositoryBase(IOptions<MongoOptions> options)
    {
        var settings = MongoClientSettings.FromConnectionString(options.Value.Connection);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        Client = new MongoClient(settings);
    }
    public async Task<List<T>> GetAsync()
    {
        var collection = GetCollection();
        List<T> list = [];
        foreach (var entity in await collection.AsQueryable().ToListAsync())
        {
            list.Add(entity);
        }
        return list;
    }

    public async Task<List<T>?> GetByNamedParamAsync(string param, string? value, bool doSort = false, string? sortParam = null, string sortMethod = "ascending", string pageCount = "2", string pageSize = "10")
    {
        var collection = GetCollection();
        if (string.IsNullOrEmpty(param) || typeof(T).GetProperty(param) is null) return null;
        if (!int.TryParse(pageCount, out var count) || !int.TryParse(pageSize, out var size)) return null;
        var filter = Builders<T>.Filter.Eq(param, value);
        if (!doSort || string.IsNullOrEmpty(sortParam))
            return await collection.Find(filter).ToListAsync();
        if (sortMethod.Contains("desc", StringComparison.CurrentCultureIgnoreCase))
        {
            return await collection.Find(filter).Skip((count-1)*size).Limit(size).SortByDescending(item => sortParam).ToListAsync();
        }
        return await collection.Find(filter).Skip((count-1)*size).Limit(size).SortBy(item => sortParam).ToListAsync();
    }

    public async Task<bool> PostAsync(T entity)
    {
        var collection = GetCollection();
        var bsonDoc = entity.ToBsonDocument();
        if (bsonDoc == null) return false;
        var filter = Builders<T>.Filter.Eq("_id", bsonDoc["_id"]);
        var replaceOneResult = await collection.ReplaceOneAsync(
            filter, 
            entity, 
            new ReplaceOptions {IsUpsert = true});
        return replaceOneResult.IsAcknowledged;
    }

    public async Task<int> DeleteByNamedParameterAsync(string param, object? value)
    {
        if (string.IsNullOrEmpty(param) || typeof(T).GetProperty(param) is null) return 0;
        var collection = GetCollection();
        var res = await collection.DeleteOneAsync(Builders<T>.Filter.Eq(param, value));
        return res.IsAcknowledged ? 0 : 1;
    }

    protected IMongoCollection<T> GetCollection()
    {
        return Client.GetDatabase(DbName).GetCollection<T>(typeof(T).Name);
    }
}