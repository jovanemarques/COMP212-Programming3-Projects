using System.Collections.Specialized;

namespace MenuRepository
{
    public class Item : INotifyCollectionChanged
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        //private void OnPropertyChanged(string property)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(property));
        //    }
        //}
    }
}