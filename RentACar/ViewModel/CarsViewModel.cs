using RentACar.Model;
using RentACar.Model.Database.DAO;
using System.Collections.ObjectModel;

namespace RentACar.ViewModel
{
    class CarsViewModel
    {
        public static ObservableCollection<Car> Cars { get; set; } = new ObservableCollection<Car>();

        public CarsViewModel()
        {

            CarDAO carDAO = new CarDAO();
            Cars = new ObservableCollection<Car>(carDAO.GetAll());
        }

        public static void AddCar(Car car)
        {
            Cars.Add(car);
        }

        public static void RemoveCar(Car car)
        {
            Cars.Remove(car);
        }

        public static void RefreshCarsView()
        {
            CarDAO carDAO = new CarDAO();
            Cars = new ObservableCollection<Car>(carDAO.GetAll());
        }
    }
}
