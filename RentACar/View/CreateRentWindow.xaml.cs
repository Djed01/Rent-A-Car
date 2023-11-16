using Org.BouncyCastle.Utilities;
using RentACar.Model;
using RentACar.Model.Database.DAO;
using RentACar.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
                    if (MainWindow.currentLanguage == 1)
                    {
                        totalPriceTextBlock.Text = $"Total price: {numberOfDays * car.PricePerDay}$";
                    }
                    else
                    {
                        totalPriceTextBlock.Text = $"Укупна цијена: {numberOfDays * car.PricePerDay}$";
                    }
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
            string searchText = searchTextBox.Text;

            // Collection view of the DataGrid items source
            ICollectionView view = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);

            if (view != null)
            {
                view.Filter = item =>
                {
                    if (item is Customer customer)
                    {
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
            Customer selectedCustomer = dataGrid.SelectedItem as Customer;
            string pickupDate = pickupDatePicker.SelectedDate?.ToString("yyyy-MM-dd");
            string returnDate = returnDatePicker.SelectedDate?.ToString("yyyy-MM-dd");

            if (selectedCustomer != null && !string.IsNullOrEmpty(pickupDate) && !string.IsNullOrEmpty(returnDate))
            {
                // Check for overlapping rents in the database
                RentDAO rentDAO = new RentDAO();
                List<RentInfo> existingRents = rentDAO.GetAll();
                DateTime existingPickupDate = new DateTime();
                DateTime existingReturnDate = new DateTime();

                bool isOverlapping = existingRents.Any(rent =>
                {
                    existingPickupDate = DateTime.ParseExact(rent.pickUp, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    existingReturnDate = DateTime.ParseExact(rent.returnDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    DateTime newPickupDate = DateTime.ParseExact(pickupDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    DateTime newReturnDate = DateTime.ParseExact(returnDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    // Check for date overlap
                    return rent.idRent != 0 &&
                           rent.brand == car.Brand && 
                           rent.model == car.Model && 
                           ((newPickupDate >= existingPickupDate && newPickupDate <= existingReturnDate) ||
                            (newReturnDate >= existingPickupDate && newReturnDate <= existingReturnDate));
                });

                if (isOverlapping)
                {
                    if (MainWindow.currentLanguage == 0)
                    {
                        MessageBox.Show("Овај аутомобил је изнајмљен од " + existingPickupDate.ToString("dd-MM-yyyy") + " до " + existingReturnDate.ToString("dd-MM-yyyy"));
                    }
                    else
                    {
                        MessageBox.Show("This car is rented from " + existingPickupDate.ToString("dd-MM-yyyy") + " to " + existingReturnDate.ToString("dd-MM-yyyy"));
                    }
                    return null;
                }

                // Continue with creating the rent if no overlapping rents were found
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
                return null;
            }
        }


    }
}
