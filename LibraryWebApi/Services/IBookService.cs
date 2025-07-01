using LibraryWebApi.Dtos;
using LibraryWebApi.Models;

namespace LibraryWebApi.Services
{
    public interface IBookService
    {
        Task<List<GetBookDto>> GetAllBooks();
        Task<GetBookDto> GetBookById(string id);
        Task<CreateBookDto> CreateBook(CreateBookDto dto);
        Task<string> UpdateBook(UpdateBookDto dto);
        Task<string> DeleteBook(string id);

    }
}
