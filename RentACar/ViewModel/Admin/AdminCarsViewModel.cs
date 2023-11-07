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
            AdminCars = CarsViewModel.Cars;
            // Add more cars as needed.
        }
    }
}
