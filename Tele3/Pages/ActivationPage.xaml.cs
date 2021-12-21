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
    /// Interaction logic for ActivationPage.xaml
    /// </summary>
    public partial class ActivationPage : Page
    {
        public int Phone_ID = -1; 
        public ActivationPage()
        {
            InitializeComponent();
            this.Phone.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string SqlCommand1 = "Select id from Tele3_Numbers where number ='+7 " + Phone.Text + "'";
            string SqlCommand2 = "Update Tele3_Numbers set IsActive ='" + 1 + "'";

            SqlCommand cmd1 = new SqlCommand(SqlCommand1, Connection.MyConnection);
            SqlCommand cmd2 = new SqlCommand(SqlCommand2, Connection.MyConnection);
            Connection.MyConnection.Open();
            SqlDataReader rd = cmd1.ExecuteReader();
            while (rd.Read())
                Phone_ID = rd.GetInt32(0);
            if(Phone_ID == -1)
            {
                MessageBox.Show("Данный номер еще не был зарегистрирован или его не существует!");
                Connection.MyConnection.Close();
            }
            else
            {
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Номер успешно активирован!");
                Phone.Text = null;
                Connection.MyConnection.Close();
            }
        }

        void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
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

            Phone.SelectionStart = Phone.Text.Length;
            if (text.Length >= 13)
            {
                ActivateBut.Visibility = Visibility.Visible;
            }
            else
            {
                ActivateBut.Visibility = Visibility.Collapsed;
            }
        }
    }
}
