using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

namespace LoginUserControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        public LoginUserControl()
        {
            InitializeComponent();
        }

        public string Username
        {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }

        public static readonly DependencyProperty UsernameProperty =
           DependencyProperty.Register(nameof(Username), typeof(string), typeof(LoginUserControl), new PropertyMetadata("user name"));

        public SecureString Password
        {
            get { return (SecureString)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register(nameof(Password), typeof(SecureString), typeof(LoginUserControl), new PropertyMetadata(default(SecureString)));

        /**
         * Cannot bind data to PasswordBox directly due to security.
         */
        private void CtrlPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = ((PasswordBox)sender).SecurePassword;
        }
    }
}
