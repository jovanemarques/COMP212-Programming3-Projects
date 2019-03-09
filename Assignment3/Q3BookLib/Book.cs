using System.Collections.Generic;

namespace Q3BookLib
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual List<Author> Authors { get; set; }
    }
}