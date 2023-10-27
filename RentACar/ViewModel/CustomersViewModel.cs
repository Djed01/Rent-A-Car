using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Model;

namespace RentACar.ViewModel
{
    class CustomersViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }

        public CustomersViewModel()
        {
            Customers = new ObservableCollection<Customer>();
            // Initialize the collection with existing data if needed.
            Customer customer = new Customer(1,"Polina","Petrova","polina@nail.com","0888888888","1234567890","01.01.1990",true);
            Customer customer2 = new Customer(2, "Polina", "Popa", "polina@nail.com", "0888888888", "1234567890", "01.01.1990", true);
            AddCustomer(customer);
            AddCustomer(customer2);
        }

        // Add a method for adding customers
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }
    }
}
