using RentACar.Model;
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
        public EditCustomerWindow(Customer selectedCustomer)
        {
            InitializeComponent();

            // Populate the text boxes, radio buttons, and other controls with the selected customer's data
            // For example:
            NameTextBox.Text = selectedCustomer.Name;
            SurnameTextBox.Text = selectedCustomer.Surname;
            EmailTextBox.Text = selectedCustomer.Email;
            PhoneTextBox.Text = selectedCustomer.Phone;
            DateOfBirthTextBox.Text = selectedCustomer.DateOfBirth.ToString();
            IdNumberTextBox.Text = selectedCustomer.IdNumber;
            // ...

            // Set up event handlers for Save/Update button, etc.
        }
    }
}
