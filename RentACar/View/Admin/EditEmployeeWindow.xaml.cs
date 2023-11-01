using RentACar.Model;
using RentACar.Model.Database.DAO;
using RentACar.ViewModel.Admin;
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
    /// Interaction logic for EditEmployeeWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        private Employee selectedEmployee;
        public EditEmployeeWindow(Employee employee)
        {
            InitializeComponent();
            this.selectedEmployee = employee;
            NameTextBox.Text = employee.Name;
            SurnameTextBox.Text = employee.Surname;
            EmailTextBox.Text = employee.Email;
            PhoneTextBox.Text = employee.Phone;
            AddressTextBox.Text = employee.Address;
            CityTextBox.Text = employee.City;
            PostCodeTextBox.Text = employee.PostCode;
            UsernameTextBox.Text = employee.Username;
            PassowrdBox.Password = employee.Password;
            ReenteredPassowrdBox.Password = employee.Password;
        }

        private void UpdateEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            Employee updatedEmployee = new Employee(selectedEmployee.ID, NameTextBox.Text, SurnameTextBox.Text, EmailTextBox.Text,
                 PhoneTextBox.Text, AddressTextBox.Text, CityTextBox.Text, PostCodeTextBox.Text, UsernameTextBox.Text, PassowrdBox.Password);
            EmployeeDAO employeeDAO = new EmployeeDAO();
            employeeDAO.Update(updatedEmployee);
            EmployeeViewModel.RefreshEmployeeView();
            this.Close();
        }
    }
}
