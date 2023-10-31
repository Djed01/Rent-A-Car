using RentACar.Model;
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
            // Get the text entered in the search TextBox
            string searchText = searchTextBox.Text;

            // Access the collection view of the DataGrid's items source
            ICollectionView view = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);

            // Check if the collection view is valid
            if (view != null)
            {
                // Apply a filter to the collection view
                view.Filter = item =>
                {
                    if (item is RentInfo rent)
                    {
                        // Filter logic: Case-insensitive name comparison
                        return rent.name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                    }
                    return false;
                };
            }
        }
    }
}
