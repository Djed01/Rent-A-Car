using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model
{
    class Car
    {
        public string ChassisNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double PricePerDay { get; set; }
        public string Engine { get; set; }
        public string Image { get; set; }

        public Car(string chassisNumber, string brand, string model, int year, double pricePerDay, string engine, string image)
        {
            ChassisNumber = chassisNumber;
            Brand = brand;
            Model = model;
            Year = year;
            PricePerDay = pricePerDay;
            Engine = engine;
            Image = image;
        }
    }
}
