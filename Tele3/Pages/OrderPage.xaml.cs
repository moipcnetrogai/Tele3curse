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
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
        }
        private void SetOrder_Click(object sender, RoutedEventArgs e)
        {
            if((Name.Text != null)&&(Surname.Text !=null)&&(Secondname.Text != null))
            {
                DateTime now = DateTime.Now;
                var Orders = new Entities.Tele3_Orders
                {
                    name = Name.Text,
                    surmane = Surname.Text,
                    secondname = Secondname.Text,
                    date = now
                };

                string next = DateTime.Today.AddDays(10).ToString("d");
                App.Context.Tele3_Orders.Add(Orders);
                App.Context.SaveChanges();
                Name.Text = null;
                Surname.Text = null;
                Secondname.Text = null;
                MessageBox.Show("Заказ на ваше имя оформлен, приходите в любой оффис нашей компании " + next + " с 10.00 до 20.00");
            }
            else
            {
                MessageBox.Show("Есть пустые поля!");
            }
            

        }
    }
}
