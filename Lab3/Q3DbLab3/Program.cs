using BooksLib;
using System.Collections.Generic;

namespace Q3DbLab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book
            {
                Title = "Don Quixote",
                Authors = new List<Author> {
                    new Author {
                        FirstName = "Miguel",LastName = "De Cervantes"
                    }
            }
            };
            Book book2 = new Book
            {
                Title = "Gulliver's Travels",
                Authors = new List<Author> {
                    new Author {
                        FirstName = "Jonathan",LastName = "Swift"
                    }
            }
            };

            BookContext db = new BookContext();
            db.Books.Add(book1);
            db.Books.Add(book2);
            db.SaveChanges();
        }
    }
}
