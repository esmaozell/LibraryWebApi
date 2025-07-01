using LibraryWebApi.Dtos;
using LibraryWebApi.Models;
using LibraryWebApi.Repositories;

namespace LibraryWebApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookService;
        public BookService(IBookRepository bookService) 
        {
            _bookService = bookService;
        }
        public Task<CreateBookDto> CreateBook(CreateBookDto dto)
        {
            try
            {
                return _bookService.CreateBook(dto);
            }
            catch (InvalidCastException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

        }

        public Task<string> DeleteBook(string id)
        {
            try
            {
                return _bookService.DeleteBook(id);
            }
            catch (InvalidCastException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public Task<List<GetBookDto>> GetAllBooks()
        {
            try
            {
                return _bookService.GetAllBooks();
            }
            catch (InvalidCastException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public Task<GetBookDto> GetBookById(string id)
        {
            try
            {
                return _bookService.GetBookById(id);
            }
            catch (InvalidCastException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            catch (Exception ex) 
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public Task<string> UpdateBook(UpdateBookDto dto)
        {
            return _bookService.UpdateBook(dto);
        }
    }
}
