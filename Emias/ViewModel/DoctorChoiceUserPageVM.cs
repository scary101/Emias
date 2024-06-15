using Emias.Interfaces;
using Emias.Model;
using Emias.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emias.ViewModel
{
    public class DoctorChoiceUserPageVM : BindingHelpers
    {
        private SelectVrachCardType _vrachType;
        public SelectVrachCardType VrachType
        {
            get { return _vrachType; }
            set { _vrachType = value; OnPropertyChanged(nameof(VrachType)); }
        }

        public DoctorChoiceUserPageVM(INavigationService navigation, SelectVrachCardType vrachType)
        {
            _vrachType = vrachType;
        }
    }
}
