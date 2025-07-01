using LibraryWebApi.Models;

namespace LibraryWebApi.Dtos
{
    public class CreateBookDto
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public BookType BookType { get; set; }
        public int ReturnDay { get; set; }
        public bool İsAvailable { get; set; }
    }
}
