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
    class EmployeeViewModel
    {

        public static ObservableCollection<Employee> Employees { get; set; }

        public EmployeeViewModel()
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();
            Employees = new ObservableCollection<Employee>(employeeDAO.GetAll());
        }

        public static void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public static void RemoveEmployee(Employee employee)
        {
            Employees.Remove(employee);
        }

        public static void RefreshEmployeeView()
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();
            Employees = new ObservableCollection<Employee>(employeeDAO.GetAll());
        }
    }
}
