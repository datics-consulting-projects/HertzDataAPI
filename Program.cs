using _50HertzDataAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;


var builder = WebApplication.CreateBuilder(args);

// Load Cosmos DB configuration
var cosmosConfig = builder.Configuration.GetSection("CosmosDb");

// Register MongoDB Client
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(cosmosConfig["ConnectionString"]));

// Register MongoDbService
builder.Services.AddSingleton<MongoDbService>();

var app = builder.Build();
app.MapControllers();
app.Run();