using System.Windows;
using System.Windows.Controls;

namespace LoginControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        public string Username
        {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }
        public static DependencyProperty UsernameProperty =
            DependencyProperty.Register(nameof(Username), typeof(string), typeof(LoginUserControl),
                new PropertyMetadata("Username"));
        public string Password
        {
            get
            {
                return (string)GetValue(PasswordProperty);
            }
            set
            {
                SetValue(PasswordProperty, value);
                txtPassword.Password = value;
            }
        }
        public static DependencyProperty PasswordProperty =
            DependencyProperty.Register(nameof(Password), typeof(string), typeof(LoginUserControl),
                new PropertyMetadata("Password"));
        public LoginUserControl()
        {
            InitializeComponent();

        }
    }
}
