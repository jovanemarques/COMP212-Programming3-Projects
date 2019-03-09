using System;
using System.Linq;
using System.Windows.Forms;

namespace Q3Lab3
{
    static class Program
    {
        //public static IQueryable<Book> books { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Book book1 = new Book
            {
                Title = "Don Quixote",
                Author = "Miguel De Cervantes"
            };
            Book book2 = new Book
            {
                Title = "Gulliver's Travels",
                Author = "Jonathan Swift"
            };

            BookContext db = new BookContext();
            db.Books.Add(book1);
            db.Books.Add(book2);
            db.SaveChanges();

            Application.Run(new MainWindow());
        }
    }
}
