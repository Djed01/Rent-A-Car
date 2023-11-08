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
        public static ObservableCollection<Car> AdminCars { get; set; } = new ObservableCollection<Car>();

        public AdminCarsViewModel()
        {
            AdminCars = CarsViewModel.Cars;
        }

        public static void AddCar(Car car)
        {
            AdminCars.Add(car);
        }

        public static void RemoveCar(Car car)
        {
            AdminCars.Remove(car);
        }
    }
}
