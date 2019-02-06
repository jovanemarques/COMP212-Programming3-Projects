using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MenuRepository
{
    public class MenuRepository
    {
        private ObservableCollection<Item> _items;

        public ObservableCollection<Item> Items => _items;
        public MenuRepository()
        {
            _items = new ObservableCollection<Item>(){
                new Item() { Name = "Soda", Category = "Beverage", Price = 1.95M },
                new Item() { Name = "Tea", Category = "Beverage", Price = 1.5M },
                new Item() { Name = "Coffee", Category = "Beverage", Price = 1.25M },
                new Item() { Name = "Buffalo Wings", Category = "Appetizer", Price = 1.25M },
                new Item() { Name = "Seafood Alfredo", Category = "Main Course", Price = 15.95M },
                new Item() { Name = "Apple Pie", Category = "Dessert", Price = 5.95M }
            };
        }
    }
}
