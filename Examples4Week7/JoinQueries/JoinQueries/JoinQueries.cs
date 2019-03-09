using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BooksExamples;

namespace JoinQueries
{
    public partial class JoinQueries : Form
    {
        private BooksEntities boodDb = new BooksEntities();
        public JoinQueries()
        {
            InitializeComponent();
        }

        private void JoinQueries_Load(object sender, EventArgs e)
        {
            var authorAndIsbn = from author in boodDb.Authors
                                from book in author.Titles
                                orderby author.LastName, author.FirstName
                                select new { author.FirstName, author.LastName, book.ISBN };

            outputTxtBox.AppendText("Authors and ISBNs:");

            foreach (var element in authorAndIsbn)
                outputTxtBox.AppendText(string.Format("\r\n\t{0,-10} {1,-10} {2,-10}",
                    element.FirstName, element.LastName,element.ISBN));

            //get authors and titles of each book they co-authored
            var authorsAndTitles = from book in boodDb.Titles
                                   from author in book.Authors
                                   orderby author.LastName, author.FirstName, book.Title1
                                   select new { author.LastName, author.FirstName, book.Title1 };

            outputTxtBox.AppendText("\r\n\r\nAuthors and Titles:");

            foreach (var element in authorsAndTitles)
                outputTxtBox.AppendText(string.Format("\r\n\t{0,-10} {1,-10} {2,-10}",
                    element.FirstName, element.LastName, element.Title1));

            //get authors and titles of each book
            //they co-authored, group by author

            var titlesByAuthor = from author in boodDb.Authors
                                 orderby author.LastName, author.FirstName
                                 select new
                                 {
                                     Name = author.FirstName + " " + author.LastName,
                                     titles = from book in author.Titles
                                              orderby book.Title1
                                              select book.Title1
                                 };

            outputTxtBox.AppendText("\r\n\r\n Titles group by author");

            foreach (var element in titlesByAuthor)
            {
                outputTxtBox.AppendText(string.Format("\r\n\t{0,-10}",element.Name));
                foreach (var title in element.titles)
                {
                    outputTxtBox.AppendText(string.Format("\r\n\t\t\t{0,-10}",title));
                }
            }
        }
    }
}
