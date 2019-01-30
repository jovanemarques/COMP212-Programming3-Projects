using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoEventHandler
{
    public partial class Form1 : Form
    {
        Utility utility = new Utility();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex!=-1) MessageBox.Show(utility.signers[comboBox1.SelectedIndex].Invoke());
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show("Mouse is hovering on the button");
        }
    }
}
