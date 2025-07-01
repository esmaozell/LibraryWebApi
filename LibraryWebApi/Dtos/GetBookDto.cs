using LibraryWebApi.Models;

namespace LibraryWebApi.Dtos
{
    public class GetBookDto
    {
        public string Id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public BookType BookType { get; set; }
        public int ReturnDay { get; set; }
        public bool IsAvailable { get; set; }
    }
}
