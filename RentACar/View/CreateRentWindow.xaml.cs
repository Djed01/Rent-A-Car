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
using System.Windows.Shapes;

namespace RentACar.View
{
    /// <summary>
    /// Interaction logic for CreateRentWindow.xaml
    /// </summary>
    public partial class CreateRentWindow : Window
    {
        public CreateRentWindow()
        {
            InitializeComponent();
        }

        private void OpenNewWindow(object sender, RoutedEventArgs e)
        {
            // Create a new window or navigate to a new page
            AddCustomerWindow addCustomerWindow = new AddCustomerWindow();
            addCustomerWindow.Show();
        }

    }
}
