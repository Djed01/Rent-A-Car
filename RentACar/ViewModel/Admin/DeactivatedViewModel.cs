using RentACar.Model;
using RentACar.Model.Database.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.ViewModel.Admin
{

    class DeactivatedViewModel
    {

        public static ObservableCollection<Employee> Deactivated { get; set; }


        public DeactivatedViewModel()
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();
            Deactivated = new ObservableCollection<Employee>(employeeDAO.GetDeactivated());
        }

        public static void AddDeactivated(Employee employee)
        {
            Deactivated.Add(employee);
        }

        public static void RefreshEmployeeView()
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();
            Deactivated = new ObservableCollection<Employee>(employeeDAO.GetDeactivated());
        }

        public static void DeleteDeactivated(Employee employee)
        {
            Deactivated.Remove(employee);
        }
    }
}
