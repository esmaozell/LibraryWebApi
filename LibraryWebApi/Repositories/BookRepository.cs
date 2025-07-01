using LibraryWebApi.Data;
using LibraryWebApi.Dtos;
using LibraryWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace LibraryWebApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book>  _collection;
        public BookRepository(IMongoDbContext context)
        {
            _collection = context.GetCollection<Book>("Books");
        }
        public async Task<CreateBookDto> CreateBook(CreateBookDto dto)
        {
            var existing =  _collection
               .Find(b => b.Name == dto.BookName && b.Author == dto.AuthorName)
               .FirstOrDefault();

            if (existing != null)
            {
                throw new InvalidOperationException("This book by the same author already exists!");
            }

            var newBook = new Book
            {
                Name = dto.BookName,
                Author = dto.AuthorName,
                Type = dto.BookType,
                ReturnDate = dto.ReturnDay,
                IsAvailable = true,
            };

            _collection.InsertOne(newBook);

            return dto;
        }

        public async Task<string> DeleteBook(string id)
        {
            //Check Book

            var checkBook = _collection.Find(b => b.Id == id).FirstOrDefault();

            if (checkBook == null)
            {
                throw new InvalidOperationException("Simek istediğiniz kitaba ulaşılamadı");
            }

            //Şöyle de olabilirdi
            //var delete2 = _collection.DeleteOne(Builders<Book>.Filter.Eq("Id", id));

            var deleteBook = _collection.DeleteOne(b => b.Id == id);

            return deleteBook.DeletedCount == 0 ? "Silme başarısız" : "Başarılı bir şekilde silindi";
        }

        public async Task<List<GetBookDto>> GetAllBooks()
        {
            var allBooks = _collection.Find(x => true).ToList();

            var dtoList = allBooks.Select(x => new GetBookDto
            {
                Id = x.Id,
                BookName = x.Name,
                AuthorName = x.Author,
                ReturnDay = x.ReturnDate,
                BookType = x.Type,
                IsAvailable = true,

            }).ToList();

            return dtoList;
        }

        public async Task<GetBookDto> GetBookById(string id)
        {
            var filter = Builders<Book>.Filter.Eq("Id", id);

            var book = _collection.Find(filter).First();

            if (book == null)
                throw new InvalidCastException("Kitap bulunamadı");

            var dto = new GetBookDto
            {
                Id = book.Id,
                BookName = book.Name,
                AuthorName = book.Author,
                ReturnDay = book.ReturnDate,
                BookType = book.Type,
                IsAvailable = book.IsAvailable,
            };

            return dto;
        }

        public async  Task<string> UpdateBook(UpdateBookDto dto)
        {
            var existingBook = await _collection.Find(b => b.Id == dto.Id).FirstOrDefaultAsync();
            if (existingBook == null)
                return "Book not found";

            var update = Builders<Book>.Update
               .Set(b => b.Name, dto.BookName)
               .Set(b => b.Author, dto.AuthorName)
               .Set(b => b.Type, dto.BookType)
               .Set(b => b.ReturnDate, dto.ReturnDay)
               .Set(b => b.IsAvailable, dto.İsAvailable);

            var filter = Builders<Book>.Filter.Eq(b => b.Id, dto.Id);


            // 4️⃣ Güncelleme işlemi
            var result = await _collection.UpdateOneAsync(filter, update);

            if (result.MatchedCount == 0)
                return "Book not found";

            return "Book updated successfully";

        }
    }
}
