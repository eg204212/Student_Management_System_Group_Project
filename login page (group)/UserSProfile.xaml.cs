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
using System.Net;

namespace SQL_Group_4115_4212
{
    /// <summary>
    /// Interaction logic for UserSProfile.xaml
    /// </summary>
    public partial class UserSProfile : Window
    {
        public crudop UserDetails { get; set; }

        public UserSProfile(string username, string password)
        {
            InitializeComponent();
            RetrieveUserDetailsFromDatabase(username, password);
            DataContext = UserDetails;
        }

        private void RetrieveUserDetailsFromDatabase(string username, string password)
        {
            string connectionString = "Data Source=DataFile.db";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT StuId, FirstName, LastName, StudentEmail, Address, RegUsername, RegPassword " +
                                          "FROM crudops WHERE RegUsername = @Username AND RegPassword = @Password";
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserDetails = new crudop
                            {
                                StuId = reader.GetString(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                StuEmail = reader.GetString(3),
                                Address = reader.GetString(4),
                                RegUsername = reader.GetString(5),
                                RegPassword = reader.GetString(6)
                            };
                        }
                        else
                        {
                            MessageBox.Show("User not found. Please try again.", "Error");
                        }
                    }
                }

                connection.Close();
            }
        }

        private void PSWD_Click(object sender, RoutedEventArgs e)
        {
            // Handle the change password button click event
        }
    }
}
