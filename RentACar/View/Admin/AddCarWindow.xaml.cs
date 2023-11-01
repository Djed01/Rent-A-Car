using Microsoft.Win32;
using Org.BouncyCastle.Utilities;
using RentACar.Model;
using RentACar.Model.Database.DAO;
using RentACar.ViewModel;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ChassisNumberTextBox.Text) ||
               string.IsNullOrEmpty(BrandTextBox.Text) ||
               string.IsNullOrEmpty(ModelTextBox.Text) ||
               string.IsNullOrEmpty(YearTextBox.Text) ||
               string.IsNullOrEmpty(PricePerDayTextBox.Text) ||
               string.IsNullOrEmpty(FuelTypeTextBox.Text))
            {
                MessageBox.Show("Please fill in all the required fields.");
                return;
            }
            else
            {
                Car car = new Car(ChassisNumberTextBox.Text, BrandTextBox.Text, ModelTextBox.Text,int.Parse(YearTextBox.Text),
                                  double.Parse(PricePerDayTextBox.Text), FuelTypeTextBox.Text,"/Assets/CarImages/"+ ChassisNumberTextBox.Text + ".png");
                CarDAO carDAO = new CarDAO();
                carDAO.Add(car);
                CarsViewModel.AddCar(car);
                this.Close();
            }

        }
    }
}

