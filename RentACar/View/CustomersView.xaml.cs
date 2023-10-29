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

        private void EditCustomerClick(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Customer selectedCustomer = (Customer)dataGrid.SelectedItem; // Assuming dataGrid is the name of your DataGrid control

                EditCustomerWindow editWindow = new EditCustomerWindow(selectedCustomer);
                editWindow.ShowDialog();
            }
        }

    }
}
