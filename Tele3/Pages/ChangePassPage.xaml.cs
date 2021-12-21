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
    /// Interaction logic for ChangePassPage.xaml
    /// </summary>
    public partial class ChangePassPage : Page
    {
        public bool pass_set;
        public string oldpass = null;
        public ChangePassPage()
        {
            InitializeComponent();
            this.PasswordNew.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
            this.PasswordOld.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);

            string SqlCommand1 = "Select password_set from Tele3_Numbers where id ='" + myclass.CurrentUser + "'";
            SqlCommand cmd1 = new SqlCommand(SqlCommand1, Connection.MyConnection);
            Connection.MyConnection.Open();
            SqlDataReader rd1 = cmd1.ExecuteReader();
            while (rd1.Read())
                pass_set = rd1.GetBoolean(0);
            if(pass_set == true)
            {
                OldGrid.Visibility = Visibility.Visible;
                NewGrid.Visibility = Visibility.Collapsed;
                Connection.MyConnection.Close();
            }
            else
            {
                NewGrid.Visibility = Visibility.Visible;
                OldGrid.Visibility = Visibility.Collapsed;
                Connection.MyConnection.Close();
            }

        }
        void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void SaveBut_Click(object sender, RoutedEventArgs e)
        {
            //newpass
            string SqlCommand3 = "Update Tele3_Numbers set password_set ='1', password ='" + PasswordNew.Text + "' where id ='" + myclass.CurrentUser + "'";
            SqlCommand cmd3 = new SqlCommand(SqlCommand3, Connection.MyConnection);
            Connection.MyConnection.Open();
            cmd3.ExecuteNonQuery();
            Connection.MyConnection.Close();
            MessageBox.Show("Пароль успешно установлен!");
        }

        private void GoBut_Click(object sender, RoutedEventArgs e)
        {
            //oldpass
            string SqlCommand2 = "Select password from Tele3_Numbers where id ='" + myclass.CurrentUser + "'";
            SqlCommand cmd2 = new SqlCommand(SqlCommand2, Connection.MyConnection);
            Connection.MyConnection.Open();
            SqlDataReader rd2 = cmd2.ExecuteReader();
            while (rd2.Read())
                oldpass = rd2.GetString(0);
            if(PasswordOld.Text == oldpass)
            {
                Connection.MyConnection.Close();
                OldGrid.Visibility = Visibility.Collapsed;
                NewGrid.Visibility = Visibility.Visible;
            }
            else
            {
                Connection.MyConnection.Close();
                MessageBox.Show("Неправильный пароль!");
            }
        }

        private void PasswordNew_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(PasswordNew.Text.Length >= 6)
            {
                SaveBut.Visibility = Visibility.Visible;
            }
            else
            {
                SaveBut.Visibility = Visibility.Collapsed;
            }
        }

        private void PasswordOld_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(PasswordOld.Text.Length >= 6)
            {
                GoBut.Visibility = Visibility.Visible;
            }
            else
            {
                GoBut.Visibility = Visibility.Collapsed;
            }
        }
    }
}
