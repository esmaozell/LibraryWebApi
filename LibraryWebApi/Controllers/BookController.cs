using LibraryWebApi.Dtos;
using LibraryWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetBookDto>>> GetAll()
        {
            try
            {
                var books = await _bookService.GetAllBooks();
                return Ok(books);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sunucu hatası: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetBookDto>> GetById(string id)
        {
            try
            {
                var book = await _bookService.GetBookById(id);
                return Ok(book);
            }
            catch (ApplicationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sunucu hatası: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CreateBookDto>> Create(CreateBookDto dto)
        {
            try
            {
                var createdBook = await _bookService.CreateBook(dto);
                return Ok(createdBook);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sunucu hatası: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Update(string id, UpdateBookDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return BadRequest("Id mismatch.");

                var result = await _bookService.UpdateBook(dto);
                return Ok(result);
            }
            catch (ApplicationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sunucu hatası: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(string id)
        {
            try
            {
                var result = await _bookService.DeleteBook(id);
                return Ok(result);
            }
            catch (ApplicationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sunucu hatası: " + ex.Message);
            }
        }
    }
}
