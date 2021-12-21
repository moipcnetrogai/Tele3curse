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

namespace Tele3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            FrameMain.Navigate(new Pages.LoginPage());
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try { this.DragMove(); }
            catch (System.InvalidOperationException) { }
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Goback_Click(object sender, RoutedEventArgs e)
        {
            if (FrameMain.CanGoBack)
                FrameMain.GoBack();
        }
    }
}
