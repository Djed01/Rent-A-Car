using RentACar.Model;
using RentACar.Model.Database.DAO;
using System.Collections.ObjectModel;

namespace RentACar.ViewModel
{
    class CarsViewModel
    {
        public ObservableCollection<Car> Cars { get; } = new ObservableCollection<Car>();

        public CarsViewModel()
        {
            // Initialize your Cars collection by adding CarViewModels here.
            /* Cars.Add(new Car("Chassis1", "Toyota", "Camry", 2022, 50.0, "Petrol", "/Assets/CarImages/Chassis1.png"));
             Cars.Add(new Car("Chassis2", "Honda", "Civic", 2021, 40.0, "Petrol", "/Assets/CarImages/Chassis2.png"));
             Cars.Add(new Car("Chassis3", "Mazda", "3", 2020, 30.0, "Diesel", "/Assets/CarImages/Chassis3.png")); */
            // Add more cars as needed.

            CarDAO carDAO = new CarDAO();
            Cars = new ObservableCollection<Car>(carDAO.GetAll());
        }
    }
}
