using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LibraryWebApi.Models
{
    public class BorrowBook
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("bookId")]
        public string BookId { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("borrowDate")]
        public DateTime BorrowDate { get; set; }

        [BsonElement("returnDate")]
        public DateTime? ReturnDate { get; set; }
    }
}
