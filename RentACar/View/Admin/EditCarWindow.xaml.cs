using RentACar.Model;
using RentACar.Model.Database.DAO;
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
    /// Interaction logic for EditCarWindow.xaml
    /// </summary>
    public partial class EditCarWindow : Window
    {
        private Car selectedCar;
        public EditCarWindow(Car car)
        {
            InitializeComponent();
            selectedCar = car;
            BrandTextBox.Text = car.Brand;
            ModelTextBox.Text = car.Model;
            YearTextBox.Text = car.Year.ToString();
            PricePerDayTextBox.Text = car.PricePerDay.ToString();
            FuelTypeTextBox.Text = car.Engine;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (
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
                Car car = new Car(selectedCar.ChassisNumber, BrandTextBox.Text, ModelTextBox.Text, int.Parse(YearTextBox.Text),
                                 double.Parse(PricePerDayTextBox.Text), FuelTypeTextBox.Text, "/Assets/CarImages/" + selectedCar.ChassisNumber + ".png");
                CarDAO carDAO = new CarDAO();
                carDAO.Update(car);
                CarsViewModel.RemoveCar(car);
                CarsViewModel.RefreshCarsView();
                this.Close();
            }
        }
    }
}
