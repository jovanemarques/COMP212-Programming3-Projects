using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q3DbShow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void booksBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.booksBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this._Assignment3_BookContextDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_Assignment3_BookContextDataSet.Books' table. You can move, or remove it, as needed.
            //this.booksTableAdapter.Fill(this._Assignment3_BookContextDataSet.Books);

        }
    }
}
