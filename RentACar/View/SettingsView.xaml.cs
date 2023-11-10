using MySql.Data.MySqlClient;
using RentACar.Model.Database.DAO;
using RentACar.View.Admin;
using RentACar.ViewModel;
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

namespace RentACar.View
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            if (MainWindow.EmployeeID != 0)
            {
                GetUserSettings(MainWindow.EmployeeID);
            }
            else
            {
                GetUserSettings(AdminMainWindow.AdminID); 
            }
        }

        private void LightRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri("Theme/Light.xaml", UriKind.Relative),1);
        }

        private void DarkRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri("Theme/Dark.xaml", UriKind.Relative),2);
        }
        private void NordicRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri("Theme/Nordic.xaml", UriKind.Relative),3);
        }

        public void GetUserSettings(int userId)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;
            MySqlDataReader reader = null;
            int mode;
            int language;

            try
            {
                conn = Util.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Language, Mode FROM settings WHERE USER_idUSER = @UserId";
                cmd.Parameters.AddWithValue("@UserId", userId);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    language = reader.GetInt32(0);
                    mode = reader.GetInt32(1);


                    if (mode == 1)
                    {
                        LightRadioButton.IsChecked = true;
                    }
                    else if (mode == 2)
                    {
                        DarkRadioButton.IsChecked = true;
                    }
                    else if (mode == 3)
                    {
                        NordicRadioButton.IsChecked = true;
                    }
                    else
                    {
                        throw new Exception("Greska");
                    }

                    if (language == 0)
                    {
                        SerbainRadioButton.IsChecked = true;
                    }
                    else if (language == 1)
                    {
                        EnglishRadioButton.IsChecked = true;
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching user settings", ex);
            }
            finally
            {
                Util.CloseQuietly(reader, conn);
            }

           
        }



        public void InsertLanguage(int userId, int language)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;

            try
            {
                conn = Util.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE settings SET Language = @Language WHERE USER_idUSER = @UserId";
                cmd.Parameters.AddWithValue("@Language", language);
                cmd.Parameters.AddWithValue("@UserId", userId);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Handle the exception, e.g., log or throw an error
            }
            finally
            {
                Util.CloseQuietly(conn);
            }
        }


        public void InsertMode(int userId, int mode)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd;

            try
            {
                conn = Util.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE settings SET Mode = @Mode WHERE USER_idUSER = @UserId";
                cmd.Parameters.AddWithValue("@Mode", mode);
                cmd.Parameters.AddWithValue("@UserId", userId);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Handle the exception, e.g., log or throw an error
            }
            finally
            {
                Util.CloseQuietly(conn);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.EmployeeID != 0)
            {
                if (SerbainRadioButton.IsChecked == true)
                {
                    InsertLanguage(MainWindow.EmployeeID, 0);
                } else if (EnglishRadioButton.IsChecked == true)
                {
                    InsertLanguage(MainWindow.EmployeeID, 1);
                }

                if(LightRadioButton.IsChecked == true)
                {
                    InsertMode(MainWindow.EmployeeID, 1);
                }else if(DarkRadioButton.IsChecked == true)
                {
                    InsertMode(MainWindow.EmployeeID, 2);
                }
                else if(NordicRadioButton.IsChecked == true)
                {
                    InsertMode(MainWindow.EmployeeID, 3);
                }
                
            }
            else
            {
                if (SerbainRadioButton.IsChecked == true)
                {
                    InsertLanguage(AdminMainWindow.AdminID, 0);
                }
                else if (EnglishRadioButton.IsChecked == true)
                {
                    InsertLanguage(AdminMainWindow.AdminID, 1);
                }

                if (LightRadioButton.IsChecked == true)
                {
                    InsertMode(AdminMainWindow.AdminID, 1);
                }
                else if (DarkRadioButton.IsChecked == true)
                {
                    InsertMode(AdminMainWindow.AdminID, 2);
                }
                else if (NordicRadioButton.IsChecked == true)
                {
                    InsertMode(AdminMainWindow.AdminID, 3);
                }
            }
            if(EnglishRadioButton.IsChecked == true)
            {
                MessageBox.Show("Saved!", "Info");
            }else if(SerbainRadioButton.IsChecked==true)
            {
                MessageBox.Show("Сачувано!", "Обавјештење");
            }
            
        }

        private void SerbainRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeLanguage(new Uri("Theme/StringResources.sr.xaml", UriKind.Relative),0);
        }

        private void EnglishRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeLanguage(new Uri("Theme/StringResources.en.xaml", UriKind.Relative),1);
        }
    }
}
