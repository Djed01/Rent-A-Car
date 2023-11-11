using RentACar.Model;
using RentACar.Model.Database.DAO;
using RentACar.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RentACar.View.Admin
{
    /// <summary>
    /// Interaction logic for AdminCarView.xaml
    /// </summary>
    public partial class AdminCarView : UserControl
    {
        public AdminCarView()
        {
            InitializeComponent();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            Car car = (Car)this.DataContext;
            EditCarWindow editCarWindow = new EditCarWindow(car);
            editCarWindow.Show();
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            Car car = (Car)this.DataContext;
            CarDAO carDAO = new CarDAO();
            bool deleted = carDAO.Delete(car.ChassisNumber);
            if (deleted && File.Exists("../../.." + car.Image))
            {
                CarsViewModel.RemoveCar(car);
              //  File.Delete("../../.." + car.Image);
            }

        }
    }
}
