using RentACar.Core;
using RentACar.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.ViewModel.Admin
{
    class AdminMainWindowViewModel : ObservableObject
    {
        public RelayCommand AdminCarsViewCommand { get; set; }
        public RelayCommand EmployeesViewCommand { get; set; }
        public RelayCommand DeactivatedViewCommand { get; set; }

        public RelayCommand SettingsViewCommand { get; set; }

        public AdminCarsViewModel CarsVM { get; set; }

        public EmployeeViewModel EmployeesVM { get; set; }
        public DeactivatedViewModel DeactivatedVM { get; set; }

        public SettingsViewModel SettingsVM { get; set; }

        private object _currentView;

        public object CurrentAdminView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public AdminMainWindowViewModel()
        {
            CarsVM = new AdminCarsViewModel();
            EmployeesVM = new EmployeeViewModel();
            DeactivatedVM = new DeactivatedViewModel();
            SettingsVM = new SettingsViewModel();
            CurrentAdminView = CarsVM;


            AdminCarsViewCommand = new RelayCommand(o =>
            {
                CurrentAdminView = CarsVM;
            });

            EmployeesViewCommand = new RelayCommand(o =>
            {
                CurrentAdminView = EmployeesVM;
            });

            DeactivatedViewCommand = new RelayCommand(o =>
            {
                CurrentAdminView = DeactivatedVM;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentAdminView = SettingsVM;
            }); 

        }
    }
}
