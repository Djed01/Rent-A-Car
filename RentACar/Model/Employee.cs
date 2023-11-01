using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public Employee(int iD, string name, string surname, string email, string phone, string address, string city, string postCode, string username, string password)
        {
            ID = iD;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            Address = address;
            City = city;
            PostCode = postCode;
            Username = username;
            Password = password;
        }

        public Employee() { }
    }
}
