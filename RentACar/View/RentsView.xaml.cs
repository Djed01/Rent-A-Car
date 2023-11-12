using RentACar.Model;
using RentACar.Model.Database.DAO;
using RentACar.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for RentsView.xaml
    /// </summary>
    public partial class RentsView : UserControl
    {
        public RentsView()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = searchTextBox.Text;

            // Collection view of the DataGrid items source
            ICollectionView view = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);

            if (view != null)
            {
                view.Filter = item =>
                {
                    if (item is RentInfo rent)
                    {
                        return rent.name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                    }
                    return false;
                };
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RentInfo rentInfo = (RentInfo)dataGrid.SelectedItem;
            RentDAO rentDAO = new RentDAO();
            rentDAO.Delete(rentInfo.idRent);
            RentsViewModel.RemoveRentInfo(rentInfo);
        }
    }
}
