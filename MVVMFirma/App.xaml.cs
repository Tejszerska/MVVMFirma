using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using MVVMFirma.Views;
using MVVMFirma.ViewModels;

namespace MVVMFirma
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new MainWindow();
            var viewModel = new MainWindowViewModel();
            window.DataContext = viewModel;
            window.Show();
        }

        public void UpdateTheme(bool isDark)
        {
            // path for new mode
            string themeName = isDark ? "Themes/DarkMode.xaml" : "Themes/LightMode.xaml";
            var newDict = new ResourceDictionary { Source = new Uri(themeName, UriKind.Relative) };

            // find and remove old mode
            var oldDict = Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("Mode.xaml"));

            if (oldDict != null)
            {
                Resources.MergedDictionaries.Remove(oldDict);
            }

            // add new mode
            Resources.MergedDictionaries.Add(newDict);
        }

    }

}
