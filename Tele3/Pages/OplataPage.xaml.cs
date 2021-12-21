using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для OplataPage.xaml
    /// </summary>
    public partial class OplataPage : Page
    {
        public string fullMoney = null;
        public int money = 0;
        public int money_fromDB = 0;
        public OplataPage()
        {
            InitializeComponent();
            this.Money.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
        }
        void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string SqlCommand1 = "Select Balance from Tele3_Numbers where id ='" + myclass.CurrentUser + "'";
            SqlCommand cmd1 = new SqlCommand(SqlCommand1, Connection.MyConnection);

            Connection.MyConnection.Open();
            SqlDataReader rd1 = cmd1.ExecuteReader();
            while (rd1.Read())
                money_fromDB = rd1.GetInt32(0);

            fullMoney = Money.Text;
            money = Convert.ToInt32(fullMoney);
            money +=money_fromDB;
            
            string SqlCommand2 = "Update Tele3_Numbers set Balance ='" + money + "' where id = '" + myclass.CurrentUser + "'";
            SqlCommand cmd2 = new SqlCommand(SqlCommand2, Connection.MyConnection);
            cmd2.ExecuteNonQuery();
            Connection.MyConnection.Close();
            Money.Text = null;
            MessageBox.Show("Оплата совершена успешно!");
        }

        private void Money_TextChanged(object sender, TextChangedEventArgs e)
        {
            string mylength = Money.Text;
            if (mylength.Length != 0)
            {
                Platezh_PROSHEL.Visibility = Visibility.Visible;
            }
            else
            {
                Platezh_PROSHEL.Visibility = Visibility.Collapsed;
            }
        }
    }
}
