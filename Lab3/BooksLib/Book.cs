using System.Collections.Generic;

namespace BooksLib
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
    }
}