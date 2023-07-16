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
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectionPage main = new SelectionPage();
            main.Show();
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            var AdminName = AdminNameText.Text;
            var AdminPassword = AdminPasswordText.Password;

            using (AdminDataContext context = new AdminDataContext())
            {
                bool adminfound = context.Admins.Any(admin => admin.AdminName == AdminName && admin.AdminPassWord == AdminPassword);

                if (adminfound)
                {
                    Window1 main = new Window1();
                    main.Show();

                }
                else
                {
                    MessageBox.Show("Incorrect AdminName or Password");
                }
            }
        }

    }
}
 
