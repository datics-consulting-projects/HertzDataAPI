namespace _50HertzDataAPI.Services;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


public class MongoDbService
{
    private readonly IMongoCollection<Measurement> _collection;

    public MongoDbService(IMongoClient client, IConfiguration config)
    {
        var database = client.GetDatabase(config["CosmosDb:DatabaseName"]);
        _collection = database.GetCollection<Measurement>(config["CosmosDb:CollectionName"]);
    }

    public async Task<List<Measurement>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task InsertAsync(Measurement measurement)
    {
        await _collection.InsertOneAsync(measurement);
    }
}