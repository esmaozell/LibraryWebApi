using LibraryWebApi.Dtos;

namespace LibraryWebApi.Repositories
{
    public interface IBookRepository
    {
        Task<List<GetBookDto>> GetAllBooks();
        Task<GetBookDto> GetBookById(string id);
        Task<CreateBookDto> CreateBook(CreateBookDto dto);
        Task<string> UpdateBook(UpdateBookDto dto);
        Task<string> DeleteBook(string id);
    }
}
