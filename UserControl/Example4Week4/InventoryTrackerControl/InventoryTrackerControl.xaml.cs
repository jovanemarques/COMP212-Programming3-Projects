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

namespace InventoryTrackerControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class InventoryTrackerControl : UserControl
    {
        public InventoryTrackerControl()
        {
            InitializeComponent();
        }


        public string ProductItemName
        {
            get { return (string)GetValue(ProductItemNameProperty); }
            set { SetValue(ProductItemNameProperty, value); }
        }

        public static DependencyProperty ProductItemNameProperty =
           DependencyProperty.Register(nameof(ProductItemName), typeof(string), typeof(InventoryTrackerControl), new PropertyMetadata("Item Name"));

        public int StartValue
        {
            get { return (int)GetValue(StartValueProperty); }
            set { SetValue(StartValueProperty, value); }
        }

        public static DependencyProperty StartValueProperty =
           DependencyProperty.Register(nameof(StartValue), typeof(int), typeof(InventoryTrackerControl),new PropertyMetadata(0));

        public int CurrentValue
        {
            get { return (int)GetValue(CurrentValueProperty); }
            set { SetValue(CurrentValueProperty, value); }
        }

        public static DependencyProperty CurrentValueProperty =
           DependencyProperty.Register(nameof(CurrentValue), typeof(int), typeof(InventoryTrackerControl), new PropertyMetadata(0));
    }
}
