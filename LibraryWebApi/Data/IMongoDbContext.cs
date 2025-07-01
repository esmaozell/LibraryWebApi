using MongoDB.Driver;

namespace LibraryWebApi.Data
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
