using System.Linq;
using System.Windows;

namespace Test1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //use following way to access Password and Username input by user
        // string password = new System.Net.NetworkCredential(string.Empty, loginControl.Password).Password;

        // string loginControl.Username.....

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string password = new System.Net.NetworkCredential(string.Empty, loginControl.Password).Password;

            // THE USERNAME IS NOT RETURNING THE VALUE FROM THE TEXTBOX SO THIS IS HARDCODED
            //string username = loginControl.Username; // the username is return "user name" all the time
            string username = "300982100";

            if ((username == null || username.Trim() == "") || (password == null || password.Trim() == ""))
            {
                MessageBox.Show("User/Password should be provided.");
                return;
            }

            SMSEntities ctx = new SMSEntities();
            Login login = ctx.Logins.Where(l => l.LoginName == username)?.First();

            if (login != null)
            {
                RegistrationWindow rw = new RegistrationWindow(ctx, login);
                rw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("User/Password invalid.");
            }

        }
    }
}
