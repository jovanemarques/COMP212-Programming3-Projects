using MenuRepository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace RestaurantBillCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ObservableCollection<Item> items = new ObservableCollection<Item>();
        ObservableCollection<Item> chosenItems = new ObservableCollection<Item>();
        public MainWindow()
        {
            InitializeComponent();

            InitRtBill();

            InitCombos();

            dgItems.ItemsSource = chosenItems;
        }

        private void InitCombos()
        {
            MenuRepository.MenuRepository mr = new MenuRepository.MenuRepository();

            IEnumerable<Item> itemsAppetizer = new List<Item>() { new Item { } };
            itemsAppetizer = mr.Items.Where(item => item.Category.Equals("Appetizer")).ToList<Item>();
            cbxAppetizer.ItemsSource = itemsAppetizer;

            IEnumerable<Item> itemsBeverage = new List<Item>() { new Item { } };
            itemsBeverage = mr.Items.Where(item => item.Category.Equals("Beverage"));
            cbxBeverage.ItemsSource = itemsBeverage;

            IEnumerable<Item> itemsMainCourse = new List<Item>() { new Item { } };
            itemsMainCourse = mr.Items.Where(item => item.Category.Equals("Main Course"));
            cbxMainCourse.ItemsSource = itemsMainCourse;

            IEnumerable<Item> itemsDessert = new List<Item>() { new Item { } };
            itemsDessert = mr.Items.Where(item => item.Category.Equals("Dessert"));
            cbxDessert.ItemsSource = itemsDessert;

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

            PrintOnBill("Un   Descr\t Price\t Total ", Position.LEFT);
            PrintOnBill("", Position.CENTER);

            double subTotal = 0;
            foreach (Item item in chosenItems)
            {
                PrintOnBill(item.Quantity + "   " + (item.Name.Length > 6 ? item.Name.Substring(0, 6) : item.Name) + "." + "\t " + item.Price + "\t " +
                    item.Total, Position.LEFT);
                subTotal += (double)item.Total;
            }
            double subTotalTax = subTotal * (0.15);
            double totalTax = subTotal * (1.15);
            PrintOnBill("", Position.CENTER);
            PrintOnBill("SubTotal: " + subTotal , Position.LEFT);
            PrintOnBill("Total Tax (15%): " + subTotalTax, Position.LEFT);
            PrintOnBill("Total Bill: " + totalTax, Position.LEFT);
            PrintOnBill("=============================", Position.CENTER);
            PrintOnBill("", Position.CENTER);
            PrintOnBill("Thank You!", Position.CENTER);
        }

        private enum Position { LEFT, CENTER, RIGHT };

        private void PrintOnBill(string text, Position pos)
        {
            int lineSize = 30;// line break for font type courier new
            if (pos.Equals(Position.RIGHT))
            {
                rtBill.AppendText(text.PadLeft(lineSize, ' ') + "\r\n");
            }
            else if (pos.Equals(Position.CENTER))
            {
                rtBill.AppendText(text.PadLeft(lineSize - ((lineSize - text.Length) / 2), ' ')
                    .PadRight(lineSize, ' ') + "\r\n");
            }
            else // LEFT
            {
                rtBill.AppendText(text + "\r\n");
            }
        }

        private void lblCentennial_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.centennialcollege.ca");
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            cbxAppetizer.SelectedIndex = -1;
            cbxBeverage.SelectedIndex = -1;
            cbxDessert.SelectedIndex = -1;
            cbxMainCourse.SelectedIndex = -1;

            chosenItems.Clear();

            rtBill.Document.Blocks.Clear();
        }

        private void cbx_DropDownClosed(object sender, System.EventArgs e)
        {
            ComboBox cbx = (ComboBox)sender;
            if (cbx.SelectedIndex >= 0)
            {
                IEnumerable<Item> items = chosenItems.Where(item => item.Equals(cbx.SelectedItem));
                if (items.Count() > 0)
                {
                    items.ElementAt(0).Quantity++;
                }
                else
                {
                    ((MenuRepository.Item)cbx.SelectedItem).Quantity = 1;
                    chosenItems.Add((MenuRepository.Item)cbx.SelectedItem);
                }
            }
          }

        private void btnGenerateInvoice_Click(object sender, RoutedEventArgs e)
        {
            InitRtBill();
        }
    }
}
