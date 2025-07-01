using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LibraryWebApi.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("username")]
        public string UserName { get; set; }
    }
}
