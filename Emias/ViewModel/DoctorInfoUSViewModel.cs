using Emias.Model;
using Emias.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emias.ViewModel
{
    internal class DoctorInfoUSViewModel : BindingHelpers
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value;  OnPropertyChanged(nameof(Name)); } }

        private string _adres;
        public string Adres { get { return _adres; } set { _adres = value; OnPropertyChanged(nameof(Adres)); } }

        private string _nearestdate;
        public string NearestDate { get { return _nearestdate; } set { _nearestdate = value; OnPropertyChanged(nameof(NearestDate)); } }


        public DoctorInfoUSViewModel(DoctorInfo info)
        {
            _name = info.Name;
            _adres = info.Adres;
            _nearestdate = info.NearestDate;
        }
    }
}
