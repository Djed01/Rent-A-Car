using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RentACar.ViewModel
{
    class AppTheme
    {
        public static void ChangeTheme(Uri themeuri, int themeId)
        {
            ResourceDictionary Theme = new ResourceDictionary() { Source = themeuri };


            if (themeId == 1)
            {
                Application.Current.Resources.MergedDictionaries.Remove(
                            new ResourceDictionary { Source = new Uri("Theme/Dark.xaml", UriKind.Relative) });

                Application.Current.Resources.MergedDictionaries.Remove(
                            new ResourceDictionary { Source = new Uri("Theme/Nordic.xaml", UriKind.Relative) });
            }
            else if (themeId == 2)
            {
                Application.Current.Resources.MergedDictionaries.Remove(
                           new ResourceDictionary { Source = new Uri("Theme/Light.xaml", UriKind.Relative) });

                Application.Current.Resources.MergedDictionaries.Remove(
                           new ResourceDictionary { Source = new Uri("Theme/Nordic.xaml", UriKind.Relative) }
                       );
            }
            else if (themeId == 3)
            {
                Application.Current.Resources.MergedDictionaries.Remove(
                          new ResourceDictionary { Source = new Uri("Theme/Light.xaml", UriKind.Relative) });

                Application.Current.Resources.MergedDictionaries.Remove(
                           new ResourceDictionary { Source = new Uri("Theme/Dark.xaml", UriKind.Relative) }
                       );
            }


            App.Current.Resources.MergedDictionaries.Add(Theme);
        }

        public static void ChangeLanguage(Uri language, int languageId)
        {
            ResourceDictionary Language = new ResourceDictionary() { Source = language };

            if (languageId == 0)
            {
                Application.Current.Resources.MergedDictionaries.Remove(
                            new ResourceDictionary { Source = new Uri("Theme/StringResources.en.xaml", UriKind.Relative) });
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Remove(
                          new ResourceDictionary { Source = new Uri("Theme/StringResources.sr.xaml", UriKind.Relative) });
            }

            App.Current.Resources.MergedDictionaries.Add(Language);
        }
    }
}
