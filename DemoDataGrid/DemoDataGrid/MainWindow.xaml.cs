using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace DemoDataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Author> authors = new ObservableCollection<Author>();
        public MainWindow()
        {
            InitializeComponent();
            LoadCollectionData();
            myDG.ItemsSource = authors;
        }
        private void LoadCollectionData()
        {
            authors.Add(new Author()
            {
                ID = 101,
                Name = "Cindy Smith",
                BookTitle = "C# Programming",
                DOB = new DateTime(1975, 1, 1),
                IsMVP = false
            });

            authors.Add(new Author()
            {
                ID = 101,
                Name = "Tom Smith",
                BookTitle = "Java Programming",
                DOB = new DateTime(1966, 1, 1),
                IsMVP = true
            });
        }
    }
}
