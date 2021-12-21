using System;
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

namespace Tele3.Pages
{
    /// <summary>
    /// Логика взаимодействия для Notifications.xaml
    /// </summary>
    public partial class Notifications : Page
    {
        public Notifications()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void Chagepass_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangePassPage());
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AboutPage());
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
            NavigationService.RemoveBackEntry();
        }
    }
}
