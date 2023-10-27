using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model
{
    class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IdNumber { get; set; }
        public string DateOfBirth { get; set; }
        public bool Gender { get; set; }

        public Customer(int iD, string name, string surname, string email, string phone, string idNumber, string dateOfBirth, bool gender)
        {
            ID = iD;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            IdNumber = idNumber;
            DateOfBirth = dateOfBirth;
            Gender = gender;
        }
    }
}
