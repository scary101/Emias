using Emias.Interfaces;
using Emias.View;
using Emias.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Emias.ViewModel
{
    internal class AdminLoginViewModel : BindingHelpers
    {
        public RelayCommand OpenUserLoginPage { get; set; }
        public RelayCommand OpenAdminWindow { get; set; }
        private readonly INavigationService _navigationService;

        private string _id = "Номер сотрудника";
        public string ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(ID)); }
        }

        private string _pass = "Пароль";
        public string Pass
        {
            get { return _pass; }
            set { _pass = value; OnPropertyChanged(nameof(Pass)); }
        }
        private bool _isPolisInvalid;
        public bool IsPolisInvalid
        {
            get { return _isPolisInvalid; }
            set { _isPolisInvalid = value; OnPropertyChanged(nameof(IsPolisInvalid)); }
        }

        public AdminLoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            OpenUserLoginPage = new RelayCommand(_ => OpenUserPage());
            OpenAdminWindow = new RelayCommand(_ => OpenAdmin());
        }

        public void OpenUserPage()
        {
            _navigationService.NavigateTo("UserLogin");
        }
        public void OpenAdmin()
        {
            if (ValidationData.ValidateAdminID(ID) && ValidationData.ValidatePassword(Pass))
            {
                var newWindow = new MainAdminWindow();
                newWindow.Show();
                Window currentWindow = Application.Current.MainWindow;
                currentWindow.Close();
            }
            else
            {
                IsPolisInvalid = true;
                Pass = "Неверный логин или пароль!";
            }
        }
    }
}
