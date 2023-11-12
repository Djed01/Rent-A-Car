using MySql.Data.MySqlClient;
using RentACar.Model.Database.DAO;
using RentACar.Model;
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
using System.Windows.Shapes;

namespace RentACar.View.Admin
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public static int AdminID;
        public static int Language;
        public AdminMainWindow(int adminID)
        {
            AdminID = adminID;
            InitializeComponent();



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
                cmd.Parameters.AddWithValue("@UserId", AdminID);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    language = reader.GetInt32(0);
                    Language = language;
                    mode = reader.GetInt32(1);


                    if (mode == 1)
                    {
                        AppTheme.ChangeTheme(new Uri("Theme/Light.xaml", UriKind.Relative), 1);
                    }
                    else if (mode == 2)
                    {
                        AppTheme.ChangeTheme(new Uri("Theme/Dark.xaml", UriKind.Relative), 2);
                    }
                    else if (mode == 3)
                    {
                        AppTheme.ChangeTheme(new Uri("Theme/Nordic.xaml", UriKind.Relative), 3);
                    }
                    else
                    {
                        throw new Exception("Greska");
                    }

                    if (language == 0)
                    {
                        AppTheme.ChangeLanguage(new Uri("Theme/StringResources.sr.xaml", UriKind.Relative), 0);
                    }
                    else if (language == 1)
                    {
                        AppTheme.ChangeLanguage(new Uri("Theme/StringResources.en.xaml", UriKind.Relative), 1);
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

        private void LogoutClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    
}
