using RentACar.Model.Database.DAO;
using RentACar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
using MySql.Data.MySqlClient;
using RentACar.View.Admin;

namespace RentACar.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Login()
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if(username != null && password != null)
            {
                int adminID = GetAdminId(username, password);
                int employeeID = GetEmployeeId(username, password);

                if (adminID != -1) {
                    AdminMainWindow adminMainWindow = new AdminMainWindow(adminID);
                    adminMainWindow.Show();
                    this.Close();
                
                }else if(employeeID != -1) {
                    MainWindow mainWindow = new MainWindow(employeeID)
                    {
                        DataContext = new ViewModel.MainViewModel()
                    };
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong username or password!");
                }
            }

           
        }


        private int GetAdminId(string username, string password)
        {
            string query = "SELECT u.idUSER FROM user u " +
                           "INNER JOIN admin a ON u.idUSER = a.USER_idUSER " +
                           "WHERE u.Username = @username AND u.Password = @password";

            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = Util.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetInt32("idUSER");
                            }
                            else
                            {
                                // Admin not found with the provided username and password
                                return -1; // or any other suitable value to indicate no match
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Greska", ex);
                    }
             }

        private int GetEmployeeId(string username, string password)
        {
            string query = "SELECT u.idUSER FROM user u " +
                           "INNER JOIN employee e ON u.idUSER = e.USER_idUSER " +
                           "WHERE u.Username = @username AND u.Password = @password";

            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = Util.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32("idUSER");
                    }
                    else
                    {
                        // Admin not found with the provided username and password
                        return -1; // or any other suitable value to indicate no match
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greska", ex);
            }
        }



    }
}
