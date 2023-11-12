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
    /// Interaction logic for DeactivatedView.xaml
    /// </summary>
    public partial class DeactivatedView : UserControl
    {
        public DeactivatedView()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = searchTextBox.Text;

            // Collection view of the DataGrid items source
            ICollectionView view = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);

            // Collection view is valid
            if (view != null)
            {
                view.Filter = item =>
                {
                    if (item is Employee employee)
                    {
                        return employee.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                    }
                    return false;
                };
            }
        }

        private void ActivateButtonClick(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Employee selectedEmployee = (Employee)dataGrid.SelectedItem;

                if (selectedEmployee != null)
                {
                    EmployeeDAO employeeDAO = new EmployeeDAO();
                    employeeDAO.Activate(selectedEmployee.ID);
                    EmployeeViewModel.AddEmployee(selectedEmployee);
                    DeactivatedViewModel.DeleteDeactivated(selectedEmployee);
                }
            }
        }
    }
}
