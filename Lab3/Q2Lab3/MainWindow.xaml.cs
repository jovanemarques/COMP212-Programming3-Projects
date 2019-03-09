using System;
using System.Collections;
using System.Collections.Generic;
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

namespace Q2Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IQueryable<Player> players = Player.GetPlayers();

        public MainWindow()
        {
            InitializeComponent();
            dgPlayers.ItemsSource = players;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            players = players.Where(p => p.LastName == txtLastName.Text);
            dgPlayers.ItemsSource = players;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            players = Player.GetPlayers();
            dgPlayers.ItemsSource = players;
        }
    }
}
