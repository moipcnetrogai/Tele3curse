using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Tele3.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Phone.Content = myclass.number;
            string SqlCommand1 = "Select minutes from Tele3_Numbers where id ='"+myclass.CurrentUser+"'";
            string SqlCommand2 = "Select Balance from Tele3_Numbers where id ='" + myclass.CurrentUser + "'";
            string SqlCommand3 = "Select nextpayment from Tele3_Numbers where id ='" + myclass.CurrentUser + "'";
            string SqlCommand4 = "Select name from Tele3_Tarifs inner join Tele3_Numbers on Tele3_Tarifs.id = Tele3_Numbers.id_tarif where Tele3_Numbers.id ='" + myclass.CurrentUser + "'";
            
            SqlCommand cmd1 = new SqlCommand(SqlCommand1, Connection.MyConnection);
            SqlCommand cmd2 = new SqlCommand(SqlCommand2, Connection.MyConnection);
            SqlCommand cmd3 = new SqlCommand(SqlCommand3, Connection.MyConnection);
            SqlCommand cmd4 = new SqlCommand(SqlCommand4, Connection.MyConnection);

            Connection.MyConnection.Open();

            SqlDataReader rd1 = cmd1.ExecuteReader();
            while (rd1.Read())
                minutes.Content = rd1.GetInt32(0).ToString();
            SqlDataReader rd2 = cmd2.ExecuteReader();

            while (rd2.Read())
                Money.Content = rd2.GetInt32(0).ToString() + ",00";

            SqlDataReader rd3 = cmd3.ExecuteReader();
            while (rd3.Read())
                date.Content = rd3.GetDateTime(0).ToString("d");

            SqlDataReader rd4 = cmd4.ExecuteReader();
            while (rd4.Read())
                tarif.Content = rd4.GetString(0);
            Connection.MyConnection.Close();
        }

        private void Notifications_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Notifications());
        }

        private void Platezh_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OplataPage());
        }

        private void Tarif_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TarifChangePage());
        }

        private void eSIM_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new eSIMPage());
        }

        private void Zakaz_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderPage());
        }

        private void Add_sim_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TarifiTele3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TarifsPage());
        }
    }
}
