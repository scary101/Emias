using API6.Models;
using Emias.Interfaces;
using Emias.Model;
using Emias.Service;
using Emias.View;
using Emias.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Emias.ViewModel
{
    public class ZapisToVrachCardViewModel : BindingHelpers
    {

        private Appointment _appointmentselect;
        public Appointment Appointment
        {
            get { return _appointmentselect; }
            set { _appointmentselect = value; OnPropertyChanged(nameof(Appointment)); }
        }

        private string _vrachtype;
        public string Vrachtype
        {
            get { return _vrachtype; }
            set { _vrachtype = value; OnPropertyChanged(nameof(Vrachtype)); }
        }

        private string _vrachname;
        public string VrachName
        {
            get { return _vrachname; }
            set { _vrachname = value; OnPropertyChanged(nameof(VrachName)); }
        }

        private string _adres;
        public string Adres
        {
            get { return _adres; }
            set { _adres = value; OnPropertyChanged(nameof(Adres)); }
        }

        private string _date;
        public string Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(nameof(Date)); }
        }
        
        public RelayCommand Delete {  get; set; }

        private ServiceNavigation _navigation;

        public ZapisToVrachCardViewModel(CardZapisModel card, ServiceNavigation navigation)
        {

            _navigation = navigation;
            _navigation = navigation ?? throw new ArgumentNullException(nameof(navigation));
            _appointmentselect = card.appointmentselect;
            Vrachtype = card.vrachCardType;
            VrachName = card.vrachName;
            Adres = card.adres;
            Date = card.date;
            Delete = new RelayCommand(_ => DeleteZapis());
        }
        private void DeleteZapis()
        {
            DelData();
            for(int i = 0; i < 1; i++)
            {
                _navigation.ReloadCurrentPage();
            }
        }

        private async Task DelData()
        {
            ApiService apiService = new ApiService();

            await apiService.DeleteDataAsync($"api/Appointments/{_appointmentselect.IdAppointment}");

        }

    }
}
