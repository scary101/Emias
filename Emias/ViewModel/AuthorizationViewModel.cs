using Emias.Interfaces;
using Emias.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Emias.ViewModel
{
    internal class AuthorizationViewModel
    {
        public RelayCommand CloseWindow { get; set; }
        public RelayCommand MinimizeWindow { get; set; }
        public RelayCommand ChangeTheme { get; set; }
        private readonly INavigationService _navigationService;

        public AuthorizationViewModel(INavigationService navigation)
        {
            _navigationService = navigation ?? throw new ArgumentNullException(nameof(navigation));
            NavigateToDefaultPage();
            CloseWindow = new RelayCommand(_ => Close());
            MinimizeWindow = new RelayCommand(_ => Minimize());
            ChangeTheme = new RelayCommand(_ => ThemeChage());
        }

        private void NavigateToDefaultPage()
        {
            _navigationService.NavigateTo("UserLogin");
        }

        private void Minimize()
        {
            if (Application.Current.MainWindow != null)
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            }
        }

        private void Close()
        {
            if (Application.Current.MainWindow != null)
            {
                Application.Current.MainWindow.Close();
            }
        }
        private void ThemeChage()
        {
            if(App.Theme == "LightTheme")
            {
                App.Theme = "DarkTheme";
            }
            else
            {
                App.Theme = "LightTheme";
            }
        }
    }
}
