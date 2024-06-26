﻿using RentACar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RentACar.ViewModel
{

    class MainViewModel : ObservableObject
    {

        public RelayCommand CarsViewCommand { get; set; }
        public RelayCommand CustomersViewCommand { get; set; }
        public RelayCommand RentsViewCommand { get; set; }

        public RelayCommand SettingsViewCommand { get; set; }

        public CarsViewModel CarsVM { get; set; }

        public CustomersViewModel CustomersVM { get; set; }
        public RentsViewModel RentsVM { get; set; }

        public SettingsViewModel SettingsVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { 
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            CarsVM = new CarsViewModel();
            CustomersVM = new CustomersViewModel();
            RentsVM = new RentsViewModel();
            SettingsVM = new SettingsViewModel();
            CurrentView = CarsVM;


            CarsViewCommand = new RelayCommand(o =>
            {
                CurrentView = CarsVM;
            });

            CustomersViewCommand = new RelayCommand(o =>
            {
                CurrentView = CustomersVM;
            });

            RentsViewCommand = new RelayCommand(o =>
            {
                CurrentView = RentsVM;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVM;
                    
            });

        }
    }
}
