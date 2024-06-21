using Emias.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Emias.ViewModel
{
    internal class ProfileCardViewModel : BindingHelpers
    {
        private string _polis;
        public string Polis
        {
            get { return _polis; }
            set { _polis = value; OnPropertyChanged(nameof(Polis)); }
        }
        private string _namepolis;
        public string NamePolis
        {
            get { return _namepolis; }
            set { _namepolis = value; OnPropertyChanged(nameof(NamePolis)); }
        }
        private string _fio;
        public string FIO
        {
            get { return _fio; }
            set { _fio = value; OnPropertyChanged(nameof(FIO)); }
        }
        private string _born;
        public string Born
        {
            get { return _born; }
            set { _born = value; OnPropertyChanged(nameof(Born)); }
        }

        public ProfileCardViewModel()
        {
            if (App.Patient != null)
            {
                Polis = $"{App.Patient.Oms.ToString().Substring(0, 4)} {App.Patient.Oms.ToString().Substring(4, 4)} {App.Patient.Oms.ToString().Substring(8, 4)} {App.Patient.Oms.ToString().Substring(12, 4)}";
                NamePolis = App.Patient.Name;
                FIO = $"{App.Patient.Surname} {App.Patient.Name} {App.Patient.Patronymic}";
                Born = App.Patient.BirthDate.ToShortDateString();
            }
            else
            {

            }
        }

    }
}
