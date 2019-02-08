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
            ucLogin.Username = "";
            ucLogin.Password = "";
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = "jovane";
            string password = "123";
            if (ucLogin.Username.Equals(username) && ucLogin.Password.Equals(password))
            {
                MessageBox.Show("Login Sucessful.");
            }
            else
            {
                MessageBox.Show($"Login Fail. Expecting: Username '{username}' and password '{password}'");
            }
        }
    }
}
