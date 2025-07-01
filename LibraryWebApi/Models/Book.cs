using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Reflection.Metadata.Ecma335;

namespace LibraryWebApi.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("author")]
        public string Author { get; set; }

        [BsonElement("type")]
        [BsonRepresentation(BsonType.String)]
        public BookType Type { get; set; }


        [BsonElement("returndays")]
        public int ReturnDate { get; set; }

        [BsonElement("isavailable")]
        public bool IsAvailable { get; set; }

    }

    public enum BookType
    {
        Fiction,
        NonFiction,
        Science,
        History,
        Biography,
        Fantasy
    }
}
