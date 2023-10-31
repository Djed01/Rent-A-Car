using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Model;
using RentACar.Model.Database.DAO;

namespace RentACar.ViewModel
{
    class CustomersViewModel
    {
        public static ObservableCollection<Customer> Customers { get; set; }

        public CustomersViewModel()
        {

            CustomerDAO customerDAO = new CustomerDAO();
            Customers = new ObservableCollection<Customer>(customerDAO.GetAll());

        }

        // Add a method for adding customers
        public static void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public static void RemoveCustomer(Customer customer)
        {
            Customers.Remove(customer);
        }

        public static void refreshCustomerView()
        {
            CustomerDAO customerDAO = new CustomerDAO();
            Customers = new ObservableCollection<Customer>(customerDAO.GetAll());
        }
    }
}
