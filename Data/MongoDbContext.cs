using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StudentManagement.Models;
using StudentManagement.Setting;

namespace StudentManagement.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IMongoClient mongoClient, IOptions<MongoDbSettings> options)
    {
        _database = mongoClient.GetDatabase(options.Value.DatabaseName);
    }
    public IMongoCollection<Department> Departments => _database.GetCollection<Department>(nameof(Departments));
}