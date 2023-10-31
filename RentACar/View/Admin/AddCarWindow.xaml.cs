using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        private string selectedImagePath = string.Empty;
        public AddCarWindow()
        {
            InitializeComponent();
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ChassisNumberTextBox.Text))
            {
                MessageBox.Show("You must first enter the chassisNumber!");
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == true)
                {
                    string selectedImagePath = openFileDialog.FileName;

                    // Specify the destination folder and filename
                    string destinationFolder = "../../../Assets/CarImages";  // Change to your desired destination folder
                    string destinationFileName = ChassisNumberTextBox.Text + ".png";     // Change to your desired filename

                    // Combine the destination path
                    string destinationPath = System.IO.Path.Combine(destinationFolder, destinationFileName);

                    try
                    {
                        File.Copy(selectedImagePath, destinationPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            }
        }
    }
}

