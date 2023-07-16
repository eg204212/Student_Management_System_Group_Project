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

namespace SQL_Group_4115_4212
{
    /// <summary>
    /// Interaction logic for AdminLogged.xaml
    /// </summary>
    public partial class AdminLogged : Window
    {
        public AdminLogged()
        {
            InitializeComponent();
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            RegistrationForm main = new RegistrationForm();
            main.Show();

        }    }
}
