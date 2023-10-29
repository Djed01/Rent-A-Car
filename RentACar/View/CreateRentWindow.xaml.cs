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

namespace RentACar.View
{
    /// <summary>
    /// Interaction logic for CreateRentWindow.xaml
    /// </summary>
    public partial class CreateRentWindow : Window
    {
        private Car car;
        public CreateRentWindow(Car car)
        {

            InitializeComponent();

            this.car = car;
            carNameTextBlock.Text += car.Brand + " " + car.Model;
        }

        private void OpenNewWindow(object sender, RoutedEventArgs e)
        {
            // Create a new window or navigate to a new page
            AddCustomerWindow addCustomerWindow = new AddCustomerWindow();
            addCustomerWindow.Show();
        }

        private void ReturnDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime pickupDate = pickupDatePicker.SelectedDate ?? DateTime.MinValue;
            DateTime returnDate = returnDatePicker.SelectedDate ?? DateTime.MinValue;

            if (pickupDate != DateTime.MinValue && returnDate != DateTime.MinValue)
            {
                TimeSpan timeSpan = returnDate - pickupDate;
                int numberOfDays = (int)timeSpan.TotalDays;

                if (numberOfDays > 0)
                {
                    totalPriceTextBlock.Text = $"Total price: {numberOfDays*car.PricePerDay}$";
                }
                else
                {
                    totalPriceTextBlock.Text = "Return date must be after pickup date.";
                }
            }
            else
            {
                totalPriceTextBlock.Text = "Please select both Pickup and Return dates.";
            }
        }



    }
}
