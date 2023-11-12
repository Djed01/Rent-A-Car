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
    /// Interaction logic for EditCustomerWindow.xaml
    /// </summary>
    public partial class EditCustomerWindow : Window
    {
        private Customer selectedCustomer;
        public EditCustomerWindow(Customer selectedCustomer)
        {
            InitializeComponent();
            this.selectedCustomer = selectedCustomer;

            NameTextBox.Text = selectedCustomer.Name;
            SurnameTextBox.Text = selectedCustomer.Surname;
            EmailTextBox.Text = selectedCustomer.Email;
            PhoneTextBox.Text = selectedCustomer.Phone;
            DateOfBirthTextBox.Text = selectedCustomer.DateOfBirth.ToString();
            IdNumberTextBox.Text = selectedCustomer.IdNumber;
            if(selectedCustomer.Gender == "Male")
            {
                MaleRadioButton.IsChecked = true;
            }else if(selectedCustomer.Gender == "Female")
            {
                FemaleRadioButton.IsChecked = true;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String gender = "";
            if(MaleRadioButton.IsChecked == true)
            {
                gender = "Male";
            }else if(FemaleRadioButton.IsChecked == true)
            {
                gender = "Female";
            }

            Customer customer = new Customer(selectedCustomer.ID,NameTextBox.Text, SurnameTextBox.Text, EmailTextBox.Text,
                PhoneTextBox.Text, IdNumberTextBox.Text, DateOfBirthTextBox.Text, gender);

            if (customer != null)
            {
                CustomerDAO customerDAO = new CustomerDAO();
                customerDAO.Update(selectedCustomer.ID, customer);
                CustomersViewModel.RemoveCustomer(selectedCustomer);
                CustomersViewModel.AddCustomer(customer);
                CustomersViewModel.refreshCustomerView();
                this.Close();
            }
        }
    }
}
