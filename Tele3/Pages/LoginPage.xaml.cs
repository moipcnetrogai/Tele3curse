using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public static int Phone_ID = -1;
        public static string Phone_Password = null;
        public static bool Admin = false;
        public LoginPage()
        {
            InitializeComponent();
            this.Phone.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
            this.Password.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
        }

        void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {           
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
        void DeleteBackEntry(object sender, NavigatingCancelEventArgs e)
        {
            if(e.NavigationMode == NavigationMode.Back)
            {
                e.Cancel = true;
            }
        }
        private void Phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = Phone.Text;

            if (Regex.IsMatch(text, "\\d{4}"))
            {
                Phone.Text = Regex.Replace(text, "(\\d{3})(\\d)", "$1 $2");
            }
            else if (Regex.IsMatch(text, "\\d{3} \\d{3}"))
            {
                Phone.Text = Regex.Replace(text, "(\\d{3} \\d{2})(\\d)", "$1 $2");
            }
            else if (Regex.IsMatch(text, "\\d{3} \\d{2} \\d{3}"))
            {
                Phone.Text = Regex.Replace(text, "(\\d{3} \\d{2} \\d{2})(\\d)", "$1-$2");
            }
            else if (!Regex.IsMatch(text, "\\d{3} \\d{2} \\d{2}-\\d{2}"))
            {
                // Invalid entry
            }

            // Keep the cursor at the end of the input
            Phone.SelectionStart = Phone.Text.Length;
            if (text.Length >= 13)
            {
                Go.Visibility = Visibility.Visible;
                Go1.Visibility = Visibility.Visible;
            } else
            {
                Go.Visibility = Visibility.Collapsed;
                Go1.Visibility = Visibility.Collapsed;
            }
        }
        private void Gopass_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = Password.Text;
            if(text.Length >= 6)
            {
                Gopass.Visibility = Visibility.Visible;
                Gopass1.Visibility = Visibility.Visible;
            }
            else
            {
                Gopass.Visibility = Visibility.Collapsed;
                Gopass1.Visibility = Visibility.Collapsed;
            }
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            
            myclass.number = "+7 " + Phone.Text;
            string SqlCommandpass = "Select password_set from Tele3_Numbers where number ='" + myclass.number + "'";
            string SqlCommandnumb = "Select id from Tele3_Numbers where number = '" + myclass.number + "'";
            

            SqlCommand cmd_id = new SqlCommand(SqlCommandnumb, Connection.MyConnection);
            SqlCommand cmd_pass = new SqlCommand(SqlCommandpass, Connection.MyConnection);

            Connection.MyConnection.Open();
            SqlDataReader rd = cmd_id.ExecuteReader();
            while (rd.Read())
                Phone_ID = rd.GetInt32(0);

            var currentUser = App.Context.Tele3_Numbers.FirstOrDefault(p => p.id == Phone_ID);

            string SqlCommand1 = "Select role from Tele3_Clients inner join Tele3_Numbers on Tele3_Clients.id = Tele3_Numbers.id_client where Tele3_Numbers.id ='" + Phone_ID + "'";
            SqlCommand cmd1 = new SqlCommand(SqlCommand1, Connection.MyConnection);
            SqlDataReader rd1 = cmd1.ExecuteReader();
            while (rd1.Read())
                Admin = rd1.GetBoolean(0);
            if (Phone_ID == -1)
            {
                MessageBox.Show("Такой пользователь не найден!");
                Connection.MyConnection.Close();
            }
            else
            {
                SqlDataReader rds = cmd_pass.ExecuteReader();
                while (rds.Read())
                    myclass.password_set = rds.GetBoolean(0);
                if (myclass.password_set == false)
                {
                    App.CurrentUser = currentUser;
                    myclass.CurrentUser = Phone_ID;
                    Connection.MyConnection.Close();
                    Password.Text = null;
                    Phone.Text = null;
                    NavigationService.Navigate(new MainPage());
                }
                else
                {
                    passwordbox.Visibility = Visibility.Visible;
                    mainly.Visibility = Visibility.Collapsed;
                    Connection.MyConnection.Close();
                }
            }
        }
        private void Gopass_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = App.Context.Tele3_Numbers.FirstOrDefault(p => p.id == Phone_ID);
            string SqlCommand_GET_pass = "Select password from Tele3_Numbers where number ='" + myclass.number + "'";
            SqlCommand cmd_getpass = new SqlCommand(SqlCommand_GET_pass, Connection.MyConnection);
            Connection.MyConnection.Open();
            SqlDataReader rdf = cmd_getpass.ExecuteReader();
            while (rdf.Read())
                Phone_Password = rdf.GetString(0);
            if (Phone_Password == Password.Text)
            {
                myclass.number = "+7 " + Phone.Text;
                myclass.CurrentUser = Phone_ID;
                Phone_ID = -1;
                Phone_Password = null;
                mainly.Visibility = Visibility.Visible;
                passwordbox.Visibility = Visibility.Collapsed;
                Connection.MyConnection.Close();
                if(Admin == true)
                {
                    App.CurrentUser = currentUser;
                    Password.Text = null;
                    Phone.Text = null;
                    NavigationService.Navigate(new AdminsMainPage());
                }
                else
                {
                    App.CurrentUser = currentUser;
                    Password.Text = null;
                    Phone.Text = null;
                    NavigationService.Navigate(new MainPage());
                }   
            }
            else
            {               
                MessageBox.Show("Неправильный пароль");
                Connection.MyConnection.Close();
            }              
        }

        private void eSIM_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new eSIMPage());
        }

        private void Zakaz_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderPage());
        }

        private void AktivateSIM_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ActivationPage());
        }

        private void TarifiTele3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TarifsPage());
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            mainly.Visibility = Visibility.Visible;
            passwordbox.Visibility = Visibility.Collapsed;
            Password.Text = null;
            Phone.Text = null;
            Phone_ID = -1;
            Phone_Password = null;
        }
    }
}
