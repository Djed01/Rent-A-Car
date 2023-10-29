using RentACar.Model;
using RentACar.ViewModel;
using System;
using System.Collections.Generic;
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

namespace RentACar.View
{
    /// <summary>
    /// Interaction logic for CarView.xaml
    /// </summary>
    public partial class CarView : UserControl
    {
        public CarView()
        {
            InitializeComponent();
        }

        private void RentButton_Click(object sender, RoutedEventArgs e)
        {
            Car car = (Car)this.DataContext;
            // Create a new instance of the detailed car information window
            CreateRentWindow detailedInfoWindow = new CreateRentWindow(car);

            // Show the detailed information window
            detailedInfoWindow.Show();
        }

    }
}
