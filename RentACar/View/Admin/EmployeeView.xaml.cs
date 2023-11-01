using RentACar.Model;
using RentACar.Model.Database.DAO;
using RentACar.ViewModel.Admin;
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

namespace RentACar.View.Admin
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl
    {
        public EmployeeView()
        {
            InitializeComponent();
        }

        private void AddEmployeeClick(object sender, RoutedEventArgs e)
        {
            // Create a new window or navigate to a new page
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.Show();
        }

        private void EditEmployeeClick(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Employee selectedEmployee = (Employee)dataGrid.SelectedItem; // Assuming dataGrid is the name of your DataGrid control

                EditEmployeeWindow editWindow = new EditEmployeeWindow(selectedEmployee);
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
                    if (item is Employee employee)
                    {
                        // Filter logic: Case-insensitive name comparison
                        return employee.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                    }
                    return false;
                };
            }
        }

        private void DeactivateEmployeeClick(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Employee selectedEmployee = (Employee)dataGrid.SelectedItem;
                EmployeeDAO employeeDAO = new EmployeeDAO();
                employeeDAO.Deactivate(selectedEmployee.ID,AdminMainWindow.AdminID);
                DeactivatedViewModel.AddDeactivated(selectedEmployee);
                EmployeeViewModel.RemoveEmployee(selectedEmployee);
            }
        }
    }
}
