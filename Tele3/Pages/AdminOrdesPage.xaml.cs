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
    /// Логика взаимодействия для AdminOrdesPage.xaml
    /// </summary>
    public partial class AdminOrdesPage : Page
    {
        public AdminOrdesPage()
        {
            InitializeComponent();
            UpdateServices();
        }
        private void UpdateServices()
        {
            var services = App.Context.Tele3_Orders.ToList();
            LViewServices.ItemsSource = services;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var currentService = (sender as Button).DataContext as Entities.Tele3_Orders;
            if (MessageBox.Show($"Вы уверены, что хотите закрыть данный запрос?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.Context.Tele3_Orders.Remove(currentService);
                App.Context.SaveChanges();
                UpdateServices();
            }
        }
    }
}
