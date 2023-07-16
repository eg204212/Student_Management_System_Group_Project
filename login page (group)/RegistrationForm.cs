using SQL_Group_4115_4212.NewFolder;
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
using System.Data.SQLite;
using Microsoft.Data.Sqlite;
using System.DirectoryServices.ActiveDirectory;

namespace SQL_Group_4115_4212
{
    /// <summary>
    /// Interaction logic for RegistrationForm.xaml
    /// </summary>
    public partial class RegistrationForm : Window
    {
        internal List<crudop> Databasecrudops { get; private set; }
        private string connectionString;
        public RegistrationForm()
        {
            InitializeComponent();
            connectionString = "Data Source = DataFile.db";
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectionPage main = new SelectionPage();
            main.Show();
        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the entered values
            string StuId = IdTextBox.Text;
            string FirstName = FirstnameTextBox.Text;
            string LastName = LastnameTextBox.Text;
            string StudentEmail = StudentEmailTextBox.Text;
            string Address = AddressTextBox.Text;
            string RegUsername = RegUsernameTextBox.Text;
            string RegPassword = RegPasswordTextBox.Text;

            string connectionString = "Data Source=DataFile.db";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO crudops (StuID,FirstName,LastName,StudentEmail,Address,RegUsername,RegPassword)" +
                        " VALUES (@StuID, @FirstName,@LastName,@StudentEmail,@Address,@RegUsername,@RegPassword)";
                    command.Parameters.AddWithValue("@StuID", StuId);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@StudentEmail", StudentEmail);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@RegUsername", RegUsername);
                    command.Parameters.AddWithValue("@RegPassword", RegPassword);
                    // Execute the INSERT query
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT COUNT(*) FROM crudops WHERE RegUsername = @RegUsername AND RegPassword = @RegPassword";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@RegUsername", RegUsername);
                    command.Parameters.AddWithValue("@RegPassword", RegPassword);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        // Open the UserProfileWindow with username and password arguments
                        UserSProfile userProfileWindow = new UserSProfile(RegUsername, RegPassword);
                        userProfileWindow.Show();

                        // Close the current window
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password. Please try again.", "Login Failed");
                    }
                }

                connection.Close();
            }
            MessageBox.Show("Data saved successfully!");

            // Clear the text boxes after saving
            FirstnameTextBox.Text = string.Empty;
            LastnameTextBox.Text = string.Empty;
            IdTextBox.Text = string.Empty;
            StudentEmailTextBox.Text = string.Empty;
            AddressTextBox.Text = string.Empty;
        }



    }
}
