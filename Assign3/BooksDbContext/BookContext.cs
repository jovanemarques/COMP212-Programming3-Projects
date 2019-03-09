using BooksDb;
using System.Data.Entity;

namespace BooksDbContext
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }

}
