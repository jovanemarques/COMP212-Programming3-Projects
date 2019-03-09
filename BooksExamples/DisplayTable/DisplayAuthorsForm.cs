using BooksExamples;
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

namespace DisplayTable
{
    public partial class DisplayAuthorsForm : Form
    {
        private BooksEntities dbContext = new BooksEntities();
        public DisplayAuthorsForm()
        {
            InitializeComponent();
        }

        private void DisplayAuthorsForm_Load(object sender, EventArgs e)
        {
            dbContext.Authors.Load();

            //(from author in dbContext.Authors             //use query syntax 
            // orderby author.LastName, author.FirstName
            // select author).Load();

            authorBindingSource.DataSource = dbContext.Authors.Local;
        }
    }
}
