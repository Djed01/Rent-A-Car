using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string IdNumber { get; set; }

        public Customer(int id, string name, string surname, string email, string phone, string idNumber, string dateOfBirth, string gender)
        {
            ID = id;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            IdNumber = idNumber;
            DateOfBirth = dateOfBirth;
            Gender = gender;
        }

        public Customer()
        {
        }
    }
}
