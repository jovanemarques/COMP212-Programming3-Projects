using Q3BookLib;
using System.Collections.Generic;

namespace Assignment3
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
            Book book3 = new Book
            {
                Title = "Java: How To Program",
                Authors = new List<Author> {
                    new Author {
                        FirstName = "Harvey", LastName = "Deitel"
                    },
                    new Author {
                        FirstName = "Paul", LastName = "Deitel"
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
