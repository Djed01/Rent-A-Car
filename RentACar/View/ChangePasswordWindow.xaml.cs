using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
using RentACar.Model.Database.DAO;
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

namespace RentACar.View
{
    /// <summary>
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        private int userId;
        private int language;
        public ChangePasswordWindow(int userId, int language)
        {
            this.userId = userId;
            this.language = language;
            InitializeComponent();
        }

        private void UpdatePasswordClick(object sender, RoutedEventArgs e)
        {
            string currentPassword = CurrentPassowrdBox.Password;
            string newPassword = PassowrdBox.Password;
            string reenteredPassword = ReenteredPassowrdBox.Password;

            // Check if the new passwords match
            if (newPassword != reenteredPassword)
            {
                if (language == 1)
                {
                    MessageBox.Show("New passwords do not match. Please re-enter the new password.");
                }
                else if(language == 0)
                {
                    MessageBox.Show("Нове лозинке се не поклапају. Поново унесите нову лозинку.");
                }
                return;
            }


            // Update the password in the database
            if (UpdatePasswordInDatabase(userId, currentPassword, newPassword))
            {
                if (language == 1)
                {
                    MessageBox.Show("Password updated successfully!");
                }else if(language == 0)
                {
                    MessageBox.Show("Лозинка је успјешно ажурирана!");
                }
            }
            else
            {
                if (language == 1)
                {
                    MessageBox.Show("Failed to update password. Please check your current password.");
                }else if(language == 0)
                {
                    MessageBox.Show("Ажурирање лозинке није успело. Проверите своју тренутну лозинку.");
                }
            }
            this.Close();
        }

        private bool UpdatePasswordInDatabase(int userId, string currentPassword, string newPassword)
        {
           
           string checkCurrentPasswordQuery = "SELECT COUNT(*) FROM USER WHERE idUSER = @UserId AND Password = @CurrentPassword";
           string updatePasswordQuery = "UPDATE USER SET Password = @NewPassword WHERE idUSER = @UserId";

            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = Util.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = checkCurrentPasswordQuery;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@CurrentPassword", currentPassword);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 0)
                {
                    return false; // Current password is incorrect
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
            finally
            {
                Util.CloseQuietly(conn);
            }

            // Update the password
            try
            {
                conn = Util.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = updatePasswordQuery;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                cmd.ExecuteNonQuery();
                return true; // Password updated successfully
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
            finally
            {
                Util.CloseQuietly(conn);
            }


        }
 
    }

}
