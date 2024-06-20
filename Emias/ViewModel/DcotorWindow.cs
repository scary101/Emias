using API6.Models;
using Emias.Interfaces;
using Emias.Model;
using Emias.Service;
using Emias.View;
using Emias.ViewModel.Helpers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Xml.Linq;
using static Emias.Model.Dat;


namespace Emias.ViewModel
{
    class DoctorWidnow : BindingHelpers
    {
        private Dat.Schedule _selectedSchedule;
        public Dat.Schedule SelectedSchedule
        {
            get { return _selectedSchedule; }
            set
            {
                _selectedSchedule = value;
                OnPropertyChanged(nameof(SelectedSchedule));
            }
        }


        private Page _mainDoctorPage;
        public Page MainDoctorPage
        {
            get { return _mainDoctorPage; }
            set
            {
                _mainDoctorPage = value;
                OnPropertyChanged(nameof(MainDoctorPage));
            }
        }





        private List<Patient> _pat;
        public List<Patient> _Pat
        {
            get { return _pat; }
            set
            {
                _pat = value;
                OnPropertyChanged(nameof(_Pat));
            }
        }
        private string _newDate;
        public string NewDate
        {
            get { return _newDate; }
            set
            {
                _newDate = value;
                OnPropertyChanged(nameof(NewDate));
            }
        }

        private string _newTime;
        public string NewTime
        {
            get { return _newTime; }
            set
            {
                _newTime = value;
                OnPropertyChanged(nameof(NewTime));
            }
        }

        private string _newProcedure;
        public string NewProcedure
        {
            get { return _newProcedure; }
            set
            {
                _newProcedure = value;
                OnPropertyChanged(nameof(NewProcedure));
            }

        }
        private List<Appointment> _appointment;
        public List<Appointment> Appointment
        {
            get { return _appointment; }
            set
            {
                _appointment = value;
                OnPropertyChanged(nameof(Appointment));
            }
        }



        private List<Schedule> _schedules;
        public List<Schedule> Schedules
        {
            get { return _schedules; }
            set
            {
                _schedules = value;
                OnPropertyChanged(nameof(Schedules));
            }
        }
        public RelayCommand Vuhod { get; set; }
        public RelayCommand Otmena { get; set; }
        
       






        private readonly INavigationService _navigationService;
        public DoctorWidnow()
        {
            LoadPat();
            LoadAppointments();
            Vuhod = new RelayCommand(_ => v_okno_avtorizacii());
            Schedules = new List<Schedule>(); 


        }
        public void v_okno_avtorizacii()
        {
           
            

        }


        private async Task LoadPat()
        {
            var apiService = new ApiService();
            var patt = await apiService.GetDataAsync<Patient>("api/Patients");
            _Pat = patt;

            // Загрузка данных о расписании
            Schedules = new List<Schedule>
            {





            };
        }
       

        private async Task LoadAppointments()
        {
            var apiService = new ApiService();
            var appointments = await apiService.GetDataAsync<Appointment>("api/Appointments");
            Schedules = appointments.Select(a => new Schedule
            {
                Date = a.AppointmentDate,
                Time = a.AppointmentTime.ToString(),
                Procedure = Convert.ToString(a.IdStatus)
            }).OrderBy(a => a.Date).ToList();
        }
        private async Task ChangeAppointmentStatus(int appointmentId, int newStatus)
        {
            var apiService = new ApiService();
            var appointment = await apiService.GetDataAsync<Appointment>($"api/Appointments/{appointmentId}");

            if (appointment != null)
            {
                Appointment appoinetmnt = new Appointment();
                appoinetmnt.IdStatus = newStatus;
                await apiService.UpdateDataAsync($"api/Appointments/{appointmentId}", appoinetmnt);
            }
        }
    }
}

    
        
    






