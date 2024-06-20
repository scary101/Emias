using API6.Models;
using Emias.Interfaces;
using Emias.Model;
using Emias.Service;
using Emias.View;
using Emias.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Emias.ViewModel
{
    internal class AdminLoginViewModel : BindingHelpers
    {
        private int _adminId;
        public int AdminId
        {
            get { return _adminId; }
            set { _adminId = value; OnPropertyChanged(nameof(AdminId)); }
        }
        private int _doctorId;
        public int DoctorId
        {
            get { return _doctorId; }
            set { _doctorId = value; OnPropertyChanged(nameof(DoctorId)); }
        }
        public RelayCommand OpenUserLoginPage { get; set; }
        public RelayCommand OpenAdminWindow { get; set; }
        private List<Admin> _admims;
        private List<Doctor> _docs;
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



            LoadAdmins();
          
             LoadDoctor();
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
            Doctor idExist = null;
            Admin idExists = null;
            try
            {
                idExists = _admims.FirstOrDefault(obj => obj.IdAdmin == Convert.ToInt32(ID));
                idExist = _docs.FirstOrDefault(obj => obj.IdDoctor == Convert.ToInt32(ID));

            }
            catch { }

            if (idExists != null && ValidationData.ValidateAdminID(ID) && ValidationData.ValidatePassword(Pass))
            {
                var admin = _admims.First(obj => obj.IdAdmin == Convert.ToInt32(ID));

                if (admin.EnterPassword == Pass)
                {
                    AdminId = (int)admin.IdAdmin;
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
           else if (idExist != null && ValidationData.ValidateAdminID(ID) && ValidationData.ValidatePassword(Pass))
            {
                var doctor = _docs.First(obj => obj.IdDoctor == Convert.ToInt32(ID));
              
                if (doctor.EnterPassword == Pass)
                {
                    DoctorId = doctor.IdDoctor;
                    var newWindow = new MainDoctorWindow();
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

        private async Task LoadAdmins()
        {
            var apiService = new ApiService();
            var admins = await apiService.GetDataAsync<Admin>("api/Admins");
            _admims = admins;
        }
        private async Task LoadDoctor()
        {
            var apiService = new ApiService();
            var docs = await apiService.GetDataAsync<Doctor>("api/Doctors");
            _docs = docs; 
        }

    }
}
