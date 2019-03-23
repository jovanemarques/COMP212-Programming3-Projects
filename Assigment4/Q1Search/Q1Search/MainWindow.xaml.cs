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
                doubs[i] = Math.Round((r.NextDouble() * 100), 2);
            }
            txtInts.Text = "The Int numbers are:\n";
            txtDoubles.Text = "The Double numbers are:\n";
            for (int i = 0; i < MAX_NUMS; i++)
            {
                txtInts.Text += ints[i] + ", ";
                txtDoubles.Text += doubs[i] + ", ";
            }
        }
        private int Search<T>(T item, T[] inputArray) where T : IComparable<T>
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i].CompareTo(item) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumber.Text.Trim() != "")
            {
                int valueInt;
                double valueDoub;
                if (Int32.TryParse(txtNumber.Text, out valueInt))
                {
                    int pos = Search<int>(valueInt, ints);
                    if (pos > -1)
                    {
                        txtResult.Text = "The number is at position: " + (pos + 1);
                    }
                    else
                    {
                        txtResult.Text = "The number was not found.";
                    }
                }
                else if (Double.TryParse(txtNumber.Text, out valueDoub))
                {
                    int pos = Search<double>(valueDoub, doubs);
                    if (pos > -1)
                    {
                        txtResult.Text = "The number is at position: " + (pos + 1);
                    }
                    else
                    {
                        txtResult.Text = "The number was not found.";
                    }
                }
                else
                {
                    txtResult.Text = "Invalid data.";
                }
            }
        }
    }
}
