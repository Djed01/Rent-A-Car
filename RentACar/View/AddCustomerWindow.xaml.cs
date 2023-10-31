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

namespace RentACar.View
{
    /// <summary>
    /// Interaction logic for AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        public AddCustomerWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustomerDAO customerDAO = new CustomerDAO();
            String gender = "";

       
            if (MaleRadioButton.IsChecked == true)
            {
                gender = "Male";
            }else if (FemaleRadioButton.IsChecked == true)
            {
                gender = "Female";
            }
            else
            {
                MessageBox.Show("You must select the gender!");
            }

            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                MessageBox.Show("Name cannot be empty.");
            }
            else if (string.IsNullOrEmpty(SurnameTextBox.Text))
            {
                MessageBox.Show("Surname cannot be empty.");
            }
            else if (string.IsNullOrEmpty(EmailTextBox.Text))
            {
                MessageBox.Show("Email cannot be empty.");
            }
            else if (string.IsNullOrEmpty(PhoneTextBox.Text))
            {
                MessageBox.Show("Phone cannot be empty.");
            }
            else if (string.IsNullOrEmpty(DateOfBirthTextBox.Text))
            {
                MessageBox.Show("Date of birth cannot be empty.");
            }
            else if (string.IsNullOrEmpty(IdNumberTextBox.Text))
            {
                MessageBox.Show("ID number cannot be empty.");
            }
            else
            {
               Customer customer = new Customer(0, NameTextBox.Text, SurnameTextBox.Text, EmailTextBox.Text,
               PhoneTextBox.Text, IdNumberTextBox.Text, DateOfBirthTextBox.Text, gender);

                customer.ID = customerDAO.Add(customer);
                CustomersViewModel.AddCustomer(customer);
               this.Close();
            }


           
        }
    }
}
