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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RentACar.View
{
    /// <summary>
    /// Interaction logic for CustomersViewxaml.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        public CustomersView()
        {
            InitializeComponent();
        }

        private void AddCustomerClick(object sender, RoutedEventArgs e)
        {
            // Create a new window or navigate to a new page
            AddCustomerWindow addCustomerWindow = new AddCustomerWindow();
            addCustomerWindow.Show();
        }

        private void DeleteCustomerClick(object sender, RoutedEventArgs e)
        {
            Customer customer = (Customer)dataGrid.SelectedItem;
            CustomerDAO customerDAO = new CustomerDAO();
            customerDAO.Delete(customer.ID);
            CustomersViewModel.RemoveCustomer(customer);
        }

        private void EditCustomerClick(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Customer selectedCustomer = (Customer)dataGrid.SelectedItem; // Assuming dataGrid is the name of your DataGrid control

                EditCustomerWindow editWindow = new EditCustomerWindow(selectedCustomer);
                editWindow.ShowDialog();
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

    }
}
