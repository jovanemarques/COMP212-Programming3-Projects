using System;
using System.Windows;

namespace Q1Search
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int MAX_NUMS = 50;
        const int MIN_INT = 1;
        const int MAX_INT = 100;

        Random r = new Random();
        int[] ints = new int[MAX_NUMS];
        double[] doubs = new double[MAX_NUMS];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < MAX_NUMS; i++)
            {
                ints[i] = r.Next(MIN_INT, MAX_INT);
                doubs[i] = (r.NextDouble() * 100);
            }
            lblInts.Content = "Int numbers are: ";
            for (int i = 0; i < MAX_NUMS; i++)
            {
                lblInts.Content += ints[i] + ", ";
                lblDouble.Content += doubs[i] + ", ";
            }
        }
    }
}
