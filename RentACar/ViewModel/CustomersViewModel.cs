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
        public ObservableCollection<Customer> Customers { get; set; }

        public CustomersViewModel()
        {

            CustomerDAO customerDAO = new CustomerDAO();
            Customers = new ObservableCollection<Customer>(customerDAO.GetAll());

        }

        // Add a method for adding customers
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }
    }
}
