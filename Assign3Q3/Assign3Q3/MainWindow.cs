using System;
using System.Linq;
using System.Windows.Forms;

namespace Assign3Q3
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void titlesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.titlesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.booksDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'booksDataSet.Titles' table. You can move, or remove it, as needed.
            this.titlesTableAdapter.Fill(this.booksDataSet.Titles);

        }

        private void cboQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (((ComboBox)sender).SelectedIndex)
            {
                case 0:
                    var question1 = from auth_isbn in booksDataSet.AuthorISBN
                                    join title in booksDataSet.Titles on auth_isbn.ISBN equals title.ISBN
                                    join author in booksDataSet.Authors on auth_isbn.AuthorID equals author.AuthorID
                                    orderby title.Title
                                    select (new { Title = title.Title, Author = author.FirstName + " " + author.LastName });
                    //var question1 = from auth_isbn in booksDataSet.AuthorISBN
                    //                select auth_isbn.AuthorID;
                    //txtResult.AppendText("LINES:"+ question1.Count());
                    foreach (var item in question1)
                    {
                        txtResult.AppendText("Title: " + item.Title + " Author: " + item.Author);
                        //txtResult.AppendText("ID: " + item);
                    }
                    break;
                case 1:
                    var question2 = from auth_isbn in booksDataSet.AuthorISBN
                                    join title in booksDataSet.Titles on auth_isbn.ISBN equals title.ISBN
                                    join author in booksDataSet.Authors on auth_isbn.AuthorID equals author.AuthorID
                                    orderby title.Title, author.LastName, author.FirstName
                                    select (new { Title = title.Title, Author = author.FirstName + " " + author.LastName });
                    foreach (var item in question2)
                    {
                        txtResult.AppendText("Title: " + item.Title + " Author: " + item.Author);
                    }
                    break;
                case 2:
                    var question3 = from auth_isbn in booksDataSet.AuthorISBN
                                    join title in booksDataSet.Titles on auth_isbn.ISBN equals title.ISBN
                                    join author in booksDataSet.Authors on auth_isbn.AuthorID equals author.AuthorID
                                    group title by title.Title into g
                                    select ( new { Title = g.Key });
                    foreach (var item in question3)
                    {
                        txtResult.AppendText("Title: " + item.Title + " Author: ");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
