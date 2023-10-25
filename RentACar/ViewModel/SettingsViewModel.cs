using RentACar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.ViewModel
{
    class SettingsViewModel : ObservableObject
    {
        public RelayCommand SerbianLanguageCommand { get; set; }
        public RelayCommand EnglishLanguageCommand { get; set; }    
        public RelayCommand ThemeCommand { get; set; }

        private string _language;
        public string Language
        {
            get { return _language; }
            set { 
                _language = value;
                OnPropertyChanged();
            }
        }

        private string _theme;

        public string Theme
        {
            get { return _theme;}
            set
            {
                _theme = value;
                OnPropertyChanged();
            }
        }

        public SettingsViewModel() { 

            SerbianLanguageCommand = new RelayCommand(o =>
            {
                Language = "Serbian";
            });

            EnglishLanguageCommand = new RelayCommand(o =>
            {
                Language = "English";
            });


            ThemeCommand = new RelayCommand(o =>
            {
                Theme = o.ToString();
            });
        
        }
        
    }
}
