using RentACar.Model;
using System.ComponentModel;

namespace RentACar.ViewModel
{
    class CarViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Car car;

        public string ChassisNumber
        {
            get { return car.ChassisNumber; }
            set
            {
                car.ChassisNumber = value;
                OnPropertyChanged(nameof(ChassisNumber));
            }
        }

        public string Brand
        {
            get { return car.Brand; }
            set
            {
                car.Brand = value;
                OnPropertyChanged(nameof(Brand));
            }
        }

        public string Model
        {
            get { return car.Model; }
            set
            {
                car.Model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        public int Year
        {
            get { return car.Year; }
            set
            {
                car.Year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        public double PricePerDay
        {
            get { return car.PricePerDay; }
            set
            {
                car.PricePerDay = value;
                OnPropertyChanged(nameof(PricePerDay));
            }
        }

        public string Engine
        {
            get { return car.Engine; }
            set
            {
                car.Engine = value;
                OnPropertyChanged(nameof(Engine));
            }
        }

        public string Image
        {
            get { return car.Image; }
            set
            {
                car.Image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        public CarViewModel(Car car)
        {
            this.car = car;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
