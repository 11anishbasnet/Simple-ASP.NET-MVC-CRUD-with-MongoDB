using Microsoft.Extensions.Configuration;
using MongoDb.Models;
using MongoDB.Driver;

public class MongoDBContext
{
    private readonly IMongoDatabase _database;

    public MongoDBContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDBConnection");
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase("MongoCrudDB");
    }

    public IMongoCollection<User> YourCollection =>
        _database.GetCollection<User>("User");
}
