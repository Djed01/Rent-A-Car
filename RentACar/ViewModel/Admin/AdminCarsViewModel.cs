using RentACar.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.ViewModel.Admin
{
    class AdminCarsViewModel
    {
        public ObservableCollection<Car> AdminCars { get; } = new ObservableCollection<Car>();

        public AdminCarsViewModel()
        {
            // Initialize your Cars collection by adding CarViewModels here.
            AdminCars.Add(new Car("Chassis1", "Toyota", "Camry", 2022, 50.0, "V6", "car1.jpg"));
            AdminCars.Add(new Car("Chassis2", "Honda", "Civic", 2021, 40.0, "Inline-4", "car2.jpg"));
            AdminCars.Add(new Car("Chassis3", "Mazda", "3", 2020, 30.0, "Inline-4", "car3.jpg"));
            AdminCars.Add(new Car("Chassis4", "Nissan", "Altima", 2019, 20.0, "Inline-4", "car4.jpg"));
            AdminCars.Add(new Car("Chassis5", "Hyundai", "Elantra", 2018, 10.0, "Inline-4", "car5.jpg"));
            // Add more cars as needed.
        }
    }
}
