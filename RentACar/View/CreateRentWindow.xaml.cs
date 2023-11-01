using Org.BouncyCastle.Utilities;
using RentACar.Model;
using RentACar.Model.Database.DAO;
using RentACar.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private int totalPrice = 0;
        public CreateRentWindow(Car car)
        {

            InitializeComponent();
            DataContext = new CustomersViewModel();
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
                    totalPrice = numberOfDays * (int)car.PricePerDay;
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


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Get the text entered in the search TextBox
            string searchText = searchTextBox.Text;

            // Access the collection view of the DataGrid's items source
            ICollectionView view = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);

            // Check if the collection view is valid
            if (view != null)
            {
                // Apply a filter to the collection view
                view.Filter = item =>
                {
                    if (item is Customer customer)
                    {
                        // Filter logic: Case-insensitive name comparison
                        return customer.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                    }
                    return false;
                };
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Rent rent = CreateRent();
            if (rent != null)
            {
                RentDAO rentDAO = new RentDAO();
                rent.ID = rentDAO.Add(rent);
                RentsViewModel.RefreshRentView();
                this.Close();
            }
        }


        private Rent CreateRent()
        {
            // Get the selected customer and dates from your window
            Customer selectedCustomer = dataGrid.SelectedItem as Customer;
            string pickupDate = pickupDatePicker.SelectedDate?.ToString("yyyy-MM-dd");
            string returnDate = returnDatePicker.SelectedDate?.ToString("yyyy-MM-dd");

            // Check if all required information is available
            if (selectedCustomer != null && !string.IsNullOrEmpty(pickupDate) && !string.IsNullOrEmpty(returnDate))
            {
                // Create a new Rent object
                Rent rent = new Rent()
                {
                    CustomerID = selectedCustomer.ID,
                    ChassisNumber = car.ChassisNumber,
                    PickupDate = pickupDate,
                    ReturnDate = returnDate,
                    TotalPrice = totalPrice,
                    EmployeeID = MainWindow.EmployeeID 
                };

                return rent;
            }
            else
            {
                // Handle the case where not all required information is provided.
                // You can display an error message or return null, depending on your requirements.
                return null;
            }
        }

    }
}
