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
    /// Логика взаимодействия для TarifsPage.xaml
    /// </summary>
    public partial class TarifsPage : Page
    {
        public TarifsPage()
        {
            InitializeComponent();
            UpdateClientServices();
        }
        public void UpdateClientServices()
        {
            var blabla = App.Context.Tele3_Tarifs.ToList();
            LViewServices.ItemsSource = blabla;
        }
    }
}
