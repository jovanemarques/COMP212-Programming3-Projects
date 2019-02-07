using System.Windows;

namespace LoginUserControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (ucLogin.Username.Equals("jovane") && ucLogin.Password.Equals("123"))
            {
                MessageBox.Show("Login Sucessful");
            }
            else
            {
                MessageBox.Show("Login Fail");
            }
        }
    }
}
