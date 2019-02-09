using System.ComponentModel;

namespace MenuRepository
{
    public class Item : INotifyPropertyChanged
    {
        public string Name
        {
            get { return Name; }
            set
            {
                Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Category
        {
            get { return Category; }
            set
            {
                Category = value;
                OnPropertyChanged("Category");
            }
        }
        public decimal Price
        {
            get { return Price; }
            set
            {
                Price = value;
                OnPropertyChanged("Price");
            }
        }
        public int Quantity
        {
            get { return Quantity; }
            set
            {
                Quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}