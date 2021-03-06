using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для AdminNumbersPage.xaml
    /// </summary>
    public partial class AdminNumbersPage : Page
    {
        SqlDataAdapter adapter;
        DataTable ad;
        public AdminNumbersPage()
        {
            InitializeComponent();
            string command = "Select * from Tele3_Numbers";
            LoadDataBase(command);
        }
        private void LoadDataBase(string a)
        {
            SqlCommand command = new SqlCommand(a, Connection.MyConnection);
            Connection.MyConnection.Open();
            command.ExecuteNonQuery();
            adapter = new SqlDataAdapter(command);
            ad = new DataTable("list");
            adapter.Fill(ad);
            searchGrid.ItemsSource = ad.DefaultView;
            Connection.MyConnection.Close();
        }
        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(ad);
        }
        private void updateButton_click(object sender, RoutedEventArgs e)
        {
            string message = "Сохранить изменения?";
            string caption = "Обновление";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            string result = "";

            result = Convert.ToString(MessageBox.Show(message, caption, buttons, MessageBoxImage.Question));

            if(result == Convert.ToString(MessageBoxResult.Yes))
            {
                UpdateDB();
                MessageBox.Show("Данные обновлены");
            }
            else { }
        }
    }
}
