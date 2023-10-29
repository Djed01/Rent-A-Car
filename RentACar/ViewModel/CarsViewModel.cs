using RentACar.Model;
using System.Collections.ObjectModel;

namespace RentACar.ViewModel
{
    class CarsViewModel
    {
        public ObservableCollection<Car> Cars { get; } = new ObservableCollection<Car>();

        public CarsViewModel()
        {
            // Initialize your Cars collection by adding CarViewModels here.
            Cars.Add(new Car("Chassis1", "Toyota", "Camry", 2022, 50.0, "V6", "car1.jpg"));
            Cars.Add(new Car("Chassis2", "Honda", "Civic", 2021, 40.0, "Inline-4", "car2.jpg"));
            Cars.Add(new Car("Chassis3", "Mazda", "3", 2020, 30.0, "Inline-4", "car3.jpg"));
            Cars.Add(new Car("Chassis4", "Nissan", "Altima", 2019, 20.0, "Inline-4", "car4.jpg"));
            Cars.Add(new Car("Chassis5", "Hyundai", "Elantra", 2018, 10.0, "Inline-4", "car5.jpg"));
            // Add more cars as needed.
        }
    }
}
