using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Q2StringBuilderExtension
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCount_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder str = new StringBuilder(txtString.Text);
            //StringBuilder str = new StringBuilder("This is to test whether the extension method count can return a right answer or not");
            lblResult.Content = "The count to the string is: " + str.CountWords();
        }
    }

    public static class Extension
    {
        public static int CountWords(this StringBuilder strB)
        {
            String[] str = strB.ToString().Trim().Split(' ');
            return str.Length;
        }
    }
}
