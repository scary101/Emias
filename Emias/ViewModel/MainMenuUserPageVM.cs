using API6.Models;
using Emias.Interfaces;
using Emias.Model;
using Emias.Service;
using Emias.View;
using Emias.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Emias.ViewModel
{
    public class MainMenuUserPageVM : BindingHelpers
    {
        public ObservableCollection<CardVrachUserControl> VrachCards { get; set; }
        private List<Appointment> fullappointments;
        private List<Doctor> doctors;

        public ObservableCollection<ListBoxArchiveCard> ArchiveCards { get; set; }
        public ObservableCollection<ListBoxZapisiCard> ZapisiCards { get; set; }
        public RelayCommand GoToZapis { get; set; }

        private ServiceNavigation _navigationService;

        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
                ZapisiCards.Clear();
                LoadZapisi();
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
                ZapisiCards.Clear();
                LoadZapisi();
            }
        }

        private DateTime _startDateAr;
        public DateTime StartDateAr
        {
            get { return _startDateAr; }
            set
            {
                _startDateAr = value;
                OnPropertyChanged(nameof(StartDateAr));
                LoadArchiveZapisi();
            }
        }

        private DateTime _endDateAr;
        public DateTime EndDateAr
        {
            get { return _endDateAr; }
            set
            {
                _endDateAr = value;
                OnPropertyChanged(nameof(EndDateAr));
                LoadArchiveZapisi();
            }
        }

        public MainMenuUserPageVM(ServiceNavigation navigation)
        {
            GoToZapis = new RelayCommand(_ => OpenPageZapis());
            ArchiveCards = new ObservableCollection<ListBoxArchiveCard>();
            ZapisiCards = new ObservableCollection<ListBoxZapisiCard>();
            _startDate = DateTime.Now;
            _endDate = _startDate.AddMonths(2);
            _startDateAr = DateTime.Now;
            _endDateAr = _startDateAr.AddMonths(-2);
            InitializeData();
            _navigationService = navigation ?? throw new ArgumentNullException(nameof(navigation));
            VrachCards = new ObservableCollection<CardVrachUserControl>
            {
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Педиатр", "/Images/naushniki.png", SelectVrachCardType.Pediatr)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Офтальмолог", "/Images/ochki.png", SelectVrachCardType.Oftolmolog)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Уролог", "/Images/urolog.png", SelectVrachCardType.Urolog)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Стоматолог", "/Images/zub.png", SelectVrachCardType.Stomatolog)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Дежурный врач", "/Images/vrach.png", SelectVrachCardType.Dejurny)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Травматолог", "/Images/noga.png", SelectVrachCardType.Travmotolog))
            };
        }
        public void OpenPageZapis()
        {
            _navigationService.NavigateTo("ChoiseDoctorPage");
        }
        private async Task LoadZapis()
        {
            var apiService = new ApiService();
            var fullappont = await apiService.GetDataAsync<Appointment>("api/Appointments");
            var appoint = fullappont.Where(i => i.Oms == App.Patient.Oms).ToList();
            fullappointments = appoint;
        }

        private async Task LoadDoctors()
        {
            var apiService = new ApiService();
            var doc = await apiService.GetDataAsync<Doctor>("api/Doctors");
            doctors = doc;
        }

        private async Task InitializeData()
        {
            await LoadZapis();
            await LoadDoctors();

            if (fullappointments != null)
            {
                LoadZapisi();
                LoadArchiveZapisi();
            }
        }

        private void LoadZapisi()
        {
            for (int i = 0; i <= (_endDate.Year - _startDate.Year) * 12 + _endDate.Month - _startDate.Month; i++)
            {
                ObservableCollection<ZapisToVrachCardView> Current = new ObservableCollection<ZapisToVrachCardView>();

                DateTime targetMonth = _startDate.AddMonths(i);
                List<Appointment> zap = fullappointments.Where(obj => obj.AppointmentDate.Date.Month == targetMonth.Month && obj.AppointmentDate.Date.Year == targetMonth.Year).ToList();

                if (zap != null)
                {
                    foreach (var appointment in zap)
                    {
                        var doc = doctors.FirstOrDefault(o => o.IdDoctor == appointment.IdDoctor);
                        if (appointment.IdStatus == (int)EnumStatus.Expectation && doc != null)
                        {
                            string docname = $"{doc.Surname} {doc.Name} {doc.Patronymic}";
                            var cur = new CardZapisModel(doc.IdDoctor, docname, appointment.AppointmentDate.Date, doc.WorkAdderss, appointment);
                            Current.Add(new ZapisToVrachCardView(cur, _navigationService));
                        }
                    }
                }

                ZapisiCards.Add(new ListBoxZapisiCard(Current, _startDate, i));
            }
        }

        private void LoadArchiveZapisi()
        {
            ArchiveCards.Clear(); 

            DateTime currentStartDate = _startDateAr;
            DateTime currentEndDate = _endDateAr;

            if (_startDateAr > _endDateAr)
            {
                currentStartDate = _endDateAr;
                currentEndDate = _startDateAr;
            }

            for (int i = 0; i <= (currentEndDate.Year - currentStartDate.Year) * 12 + currentEndDate.Month - currentStartDate.Month; i++)
            {
                ObservableCollection<ArxivZapisCardView> Archive = new ObservableCollection<ArxivZapisCardView>();

                DateTime targetMonth = currentEndDate.AddMonths(-i);
                List<Appointment> zap = fullappointments.Where(obj => obj.AppointmentDate.Date.Month == targetMonth.Month && obj.AppointmentDate.Date.Year == targetMonth.Year).ToList();

                if (zap != null)
                {
                    foreach (var appointment in zap)
                    {
                        var doc = doctors.FirstOrDefault(o => o.IdDoctor == appointment.IdDoctor);
                        if (appointment.IdStatus == (int)EnumStatus.Completed && doc != null)
                        {
                            string docname = $"{doc.Surname} {doc.Name} {doc.Patronymic}";
                            var carta = new CardZapisModel(doc.IdDoctor, docname, appointment.AppointmentDate.Date, doc.WorkAdderss, appointment);
                            Archive.Add(new ArxivZapisCardView(carta));
                        }
                    }
                }

                ArchiveCards.Add(new ListBoxArchiveCard(Archive, targetMonth, 0));
            }
        }
    }
}
