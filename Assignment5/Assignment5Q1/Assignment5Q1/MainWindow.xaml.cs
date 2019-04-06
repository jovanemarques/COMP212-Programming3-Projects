using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Assignment5Q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IList<Stock> lines = new List<Stock>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            dgStock.ItemsSource = await LoadCsv();
        }

        private async Task<IList<Stock>> LoadCsv()
        {
            string fileName = "stockData.csv";
            pgPercent.Value = 0;
            pgPercent.Minimum = 0;
            pgPercent.Maximum = File.ReadLines(fileName).Count();
            using (StreamReader reader = new StreamReader(fileName))
            {
                reader.ReadLine();//skipping the title
                //((IProgress<int>)pgPercent).Report();
                while (!reader.EndOfStream)
                {
                    pgPercent.Value++;
                    String line = reader.ReadLine();
                    lines.Add(await Task.Run<Stock>(() =>
                    {
                        System.Threading.Thread.Sleep(1); //the load is too fast to see the async process working, I put this sleep to make it slower
                        String[] fields = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");// dealing with the values with , - regex taken from stackoverflow
                        return new Stock()
                        {
                            Symbol = fields[0],
                            Date = DateTime.Parse(fields[1].Trim()),
                            Open = fields[2].Replace("\"", "").Trim(),
                            High = fields[3].Replace("\"", "").Trim(),
                            Low = fields[4].Replace("\"", "").Trim(),
                            Close = fields[5].Replace("\"", "").Trim()
                        };
                    }));
                }
            }
            // removing negative values
            return lines.Where(
                l => !l.High.StartsWith("(")
                && !l.Low.StartsWith("(")
                && !l.Open.StartsWith("(")
                && !l.Close.StartsWith("(")
            ).ToList();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text.Trim() != "")
            {
                dgStock.ItemsSource = lines
                    .Where(l => l.Symbol.ToUpper().Equals(txtSearch.Text.ToUpper().Trim()))
                    .OrderBy(l => l.Date);
            }
            else
            {
                dgStock.ItemsSource = lines;
            }
        }

        private void BtnFactorial_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = factorial(long.Parse(txtNumber.Text));
        }

        private long factorial(long num)
        {
            if (num == 0)
            {
                return 0;
            }
            else if (num == 1)
            {
                return 1;
            }
            else
            {
                return num * (factorial(num - 1));
            }
        }
    }
}
