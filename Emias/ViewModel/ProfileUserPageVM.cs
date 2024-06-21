using Emias.Interfaces;
using Emias.Service;
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
    public class ProfileUserPageVM
    {
        private readonly INavigationWinService _navigationWinService;
        public RelayCommand GoToLogin {  get; set; }
        public ProfileUserPageVM(INavigationService navigation)
        {
            _navigationWinService = new NavigationWinService();
            GoToLogin = new RelayCommand(_ => Leave());
        }
        public void Leave()
        {


        }
    }
}
