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
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace SQL_Group_4115_4212
{
    /// <summary>
    /// Interaction logic for SelectionPage.xaml
    /// </summary>
    /// 
    public partial class SelectionPage : Window
    {
        public SelectionPage()
        {
            InitializeComponent();
        }
      
        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {
                UserLogin main = new UserLogin();
                main.Show();
                Close();
        }

        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
                AdminLogin main = new AdminLogin();
                main.Show();
                Close();
        }
    }
}
