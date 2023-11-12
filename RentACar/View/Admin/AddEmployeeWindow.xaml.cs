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
    /// Interaction logic for AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        public AddEmployeeWindow()
        {
            InitializeComponent();
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(NameTextBox.Text) &&
                !string.IsNullOrEmpty(SurnameTextBox.Text) &&
                !string.IsNullOrEmpty(EmailTextBox.Text) &&
                !string.IsNullOrEmpty(PhoneTextBox.Text) &&
                !string.IsNullOrEmpty(AddressTextBox.Text) &&
                !string.IsNullOrEmpty(CityTextBox.Text) &&
                !string.IsNullOrEmpty(PostCodeTextBox.Text) &&
                !string.IsNullOrEmpty(UsernameTextBox.Text) &&
                !string.IsNullOrEmpty(PasswordTextBox.Password) &&
                !string.IsNullOrEmpty(ReenteredPassowrdTextBox.Password) &&
                PasswordTextBox.Password == ReenteredPassowrdTextBox.Password
                )
            {
                Employee employee = new Employee(0, NameTextBox.Text, SurnameTextBox.Text, EmailTextBox.Text, PhoneTextBox.Text,
                                            AddressTextBox.Text, CityTextBox.Text, PostCodeTextBox.Text, UsernameTextBox.Text, PasswordTextBox.Password);
                EmployeeDAO employeeDAO = new EmployeeDAO();
                employee.ID = employeeDAO.Add(employee);
                EmployeeViewModel.AddEmployee(employee);
                this.Close();
            }
            else
            {
                if (AdminMainWindow.Language == 0)
                {
                    MessageBox.Show("Попуните сва поља!");
                }
                else
                {
                    MessageBox.Show("Enter all fields!");
                }
            }

            

        }
    }
}
