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
using Tele3.Entities;

namespace Tele3.Pages
{
    /// <summary>
    /// Логика взаимодействия для TarifChangePage.xaml
    /// </summary>
    public partial class TarifChangePage : Page
    {
        private Entities.Tele3_Numbers _currentTarif = null;
        private Entities.Tele3_Tarifs _currentTar = null;
        public TarifChangePage()
        {
            InitializeComponent();
            UpdateClientServices();
            _currentTarif = App.CurrentUser;
        }
        public void UpdateClientServices()
        {
            var blabla = App.Context.Tele3_Tarifs.ToList();
            LViewServices.ItemsSource = blabla;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var currentService = (sender as Button).DataContext as Entities.Tele3_Tarifs;
            if (MessageBox.Show($"Вы уверены, что хотите подключить данный тариф?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var blabla = App.Context.Tele3_Tarifs.FirstOrDefault(p=> p.name == currentService.name);
                _currentTar = blabla;
                _currentTarif.id_tarif = _currentTar.id;
                App.Context.SaveChanges();
                UpdateClientServices();
                MessageBox.Show("Вы были успешно подключены к выбранному тарифу!");
            }
        }
    }
}
