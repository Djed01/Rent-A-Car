using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model
{
    internal class RentInfo
    {
        public int idRent { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string idNumber { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string pickUp { get; set; }
        public string returnDate { get; set; }
        public double totalPrice { get; set; }

        public RentInfo(int idRent, string name, string surname, string idNumber, string brand, string model, string pickUp, string returnDate, double totalPrice)
        {
            this.idRent = idRent;
            this.name = name;
            this.surname = surname;
            this.idNumber = idNumber;
            this.brand = brand;
            this.model = model;
            this.pickUp = pickUp;
            this.returnDate = returnDate;
            this.totalPrice = totalPrice;
        }

        public RentInfo() { }
    }
}
