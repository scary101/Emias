using API6.Models;
using Emias.Interfaces;
using Emias.Service;
using Emias.View;
using Emias.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private List<Patient> patients;
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
            LoadPatient();
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
            Patient pat = null;
            try
            {
                pat = patients.FirstOrDefault(i => i.Oms == Convert.ToInt64(Polis));
            }
            catch { }


            if (ValidationData.ValidatePolis(Polis) && pat != null)
            {
                App.Patient = pat;
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
        private async Task LoadPatient()
        {
            var apiService = new ApiService();
            var patinets = await apiService.GetDataAsync<Patient>("api/Patients");
            this.patients = patinets;
        } 
    }
}
