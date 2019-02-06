using MenuRepository;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace RestaurantBillCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Item> items = new ObservableCollection<Item>();
        public MainWindow()
        {
            InitializeComponent();

            InitRtBill();

            InitCombos();
        }

        private void InitCombos()
        {
            MenuRepository.MenuRepository mr = new MenuRepository.MenuRepository();
            items = mr.Items;
            cbxAppetizer.ItemsSource = items;
        }

        private void InitRtBill()
        {
            rtBill.Document.Blocks.Clear();
            rtBill.Document.Blocks.Add(new Paragraph());
            PrintOnBill("Restaurant Bill Calculator", Position.CENTER);
            PrintOnBill("937 Progress Ave", Position.CENTER);
            PrintOnBill("Scarborough, ON M1G 3T8", Position.CENTER);
            PrintOnBill("Tel: 416-289-5000", Position.CENTER);

            PrintOnBill("", Position.CENTER);

            PrintOnBill("-----------------------------", Position.CENTER);

            PrintOnBill(" Units Desc Price Total ", Position.LEFT);

            PrintOnBill("=============================", Position.CENTER);
            PrintOnBill("", Position.CENTER);
            PrintOnBill("Thank You!", Position.CENTER);
        }

        private enum Position { LEFT, CENTER, RIGHT };

        private void PrintOnBill(string text, Position pos)
        {
            int lineSize = 30;// line break for font type courier new
            if (pos.Equals(Position.LEFT))
            {
                // not necessary
                //rtBill.AppendText(text.PadRight(lineSize, ' ') + "\r\n");
            }
            else if (pos.Equals(Position.RIGHT))
            {
                rtBill.AppendText(text.PadLeft(lineSize, ' ') + "\r\n");
            }
            else //CENTER
            {
                rtBill.AppendText(text.PadLeft(lineSize - ((lineSize - text.Length) / 2), ' ')
                    .PadRight(lineSize, ' ') + "\r\n");
            }
        }

        private void lblCentennial_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.centennialcollege.ca");
        }
    }
}
