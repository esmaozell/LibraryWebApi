﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LibraryWebApi.Data
{
    public class MongoDbContext : IMongoDbContext
    {
        private IMongoDatabase _database;
        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
           return _database.GetCollection<T>(name);
        }
    }
}
