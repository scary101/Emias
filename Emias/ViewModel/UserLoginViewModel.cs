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
    public class UserLoginViewModel : BindingHelpers
    {
        public RelayCommand OpenAdminLoginPage {  get; set; }
        public RelayCommand OpenMainUserWindow { get; set; }
        private bool _isPolisInvalid;
        public bool IsPolisInvalid
        {
            get { return _isPolisInvalid; }
            set { _isPolisInvalid = value; OnPropertyChanged(nameof(IsPolisInvalid)); }
        }

        private readonly INavigationService _navigationService;

        private string _polis = "Номер полиса";
        public string Polis
        {
            get { return _polis; }
            set { _polis = value; OnPropertyChanged(nameof(Polis)); }
        }
        public UserLoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            OpenAdminLoginPage = new RelayCommand(_ => OpenAdminPage());
            OpenMainUserWindow = new RelayCommand(_ => OpenUserWindow());
        }

        public void OpenAdminPage()
        {
            _navigationService.NavigateTo("AdminLogin");
        }
        public void OpenUserWindow()
        {
            if (ValidationData.ValidatePolis(Polis))
            {
                var newWindow = new MainUserWindow();
                newWindow.Show();
                Window currentWindow = Application.Current.MainWindow;
                currentWindow.Close();
            }
            else
            {
                IsPolisInvalid = true;
                Polis = "Не верный номер полиса!";
            }
        }
    }
}
