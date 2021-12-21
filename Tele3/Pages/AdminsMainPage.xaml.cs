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
    /// Логика взаимодействия для AdminsMainPage.xaml
    /// </summary>
    public partial class AdminsMainPage : Page
    {
        public AdminsMainPage()
        {
            InitializeComponent();
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminOrdesPage());
        }

        private void Number_base_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminNumbersPage());
        }

        private void Clients_base_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminClientsPage());
        }

        private void Tarifs_base_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminTarifsPage());
        }
    }
}
