using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model
{
    class Rent
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string ChassisNumber { get; set; }
        public string PickupDate { get; set; }
        public string ReturnDate { get; set; }
        public double TotalPrice { get; set; }
        public int EmployeeID { get; set; }

        public Rent(int iD, int customerID, string chassisNumber, string pickupDate, string returnDate, double totalPrice, int employeeID)
        {
            ID = iD;
            CustomerID = customerID;
            ChassisNumber = chassisNumber;
            PickupDate = pickupDate;
            ReturnDate = returnDate;
            TotalPrice = totalPrice;
            EmployeeID = employeeID;
        }
    }
}
