using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DemoObservableCollection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Student> students = new ObservableCollection<Student>();
        public MainWindow()
        {
            InitializeComponent();

            students.Add(new Student() { Name = "John Doe", ID="300111222" });
            students.Add(new Student() { Name = "Jane Doe", ID="300222333" });

            studentList.ItemsSource = students;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student s = new Student { Name = "New added", ID = "300333444" };
            students.Add(s);
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            students.RemoveAt(studentList.SelectedIndex);
        }
    }
}
