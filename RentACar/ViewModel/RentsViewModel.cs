using RentACar.Model;
using RentACar.Model.Database.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.ViewModel
{


    class RentsViewModel
    {
        public ObservableCollection<RentInfo> Rents { get; set; }

        public RentsViewModel()
        {

            RentDAO rentDAO = new RentDAO();
            Rents = new ObservableCollection<RentInfo>(rentDAO.GetAll());

        }


    }
}
