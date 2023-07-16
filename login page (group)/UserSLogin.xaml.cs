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
    /// Interaction logic for UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectionPage main = new SelectionPage();
            main.Show();
        }

        private void UserLoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var UserName = RegUsernameText.Text;
            var Password = RegPasswordText.Password;

            using (UserDataContext context = new UserDataContext())
            {
                bool userFound = context.Crudops.Any(user => user.RegUsername == UserName && user.RegPassword == Password);

                if (userFound)
                {
                    UserSProfile userProfileWindow = new UserSProfile(UserName, Password); // Pass UserName and Password as arguments
                    userProfileWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect UserName or Password");
                }
            }
        }

        private void UserSignIn_Click(object sender, RoutedEventArgs e)
        {
            RegistrationForm main = new RegistrationForm();
            main.Show();
        }
    }
}
