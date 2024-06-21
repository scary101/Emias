using Emias.Model;
using Emias.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emias.ViewModel
{
    internal class ArxiveZapisCardViewModel : BindingHelpers
    {
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


        public ArxiveZapisCardViewModel(CardZapisModel card)
        {
            Vrachtype = card.vrachCardType;
            VrachName = card.vrachName;
            Adres = card.adres;
            Date = card.date;
        }
    }
}
