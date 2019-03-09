using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BooksExamples;

namespace DisplayQueryResult
{
    public partial class DisplayQueryResult : Form
    {
        private BooksEntities bookDb = new BooksEntities(); //
        public DisplayQueryResult()
        {
            InitializeComponent();
        }

        private void DisplayQueryResult_Load(object sender, EventArgs e)
        {
            bookDb.Titles.Load();// load data into memory
            queriesComboBox.SelectedIndex = 0;

            titleBindingSource.DataSource = bookDb.Titles.Local;
        }

        private void queriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (queriesComboBox.SelectedIndex)
            {
                case 0:
                    titleBindingSource.DataSource = bookDb.Titles.Local;
                    break;
                case 1:
                    //titleBindingSource.DataSource = from book in bookDb.Titles.Local
                    //                                where book.Copyright == "2014"
                    //                                orderby book.Title1
                    //                                select book;  //query syntax
                    titleBindingSource.DataSource = bookDb.Titles.Local
                                                   .Where(book => book.Copyright == "2014")
                                                   .OrderBy(book => book.Title1);
                    break;
                case 2:
                    titleBindingSource.DataSource = from book in bookDb.Titles.Local
                                                    where book.Title1.EndsWith("How to Program")
                                                    orderby book.Title1
                                                    select book;
                    break;
            }
        }
    }
}
