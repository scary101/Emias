using Emias.Interfaces;
using Emias.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Emias.ViewModel;

namespace Emias.View
{
    /// <summary>
    /// Логика взаимодействия для ChoiseDoctorPage.xaml
    /// </summary>
    public partial class ChoiseDoctorPage : Page
    {
        private INavigationService _navigationService;
        public ChoiseDoctorPage(INavigationService navigationService)
        {
            InitializeComponent();
            DataContext = new ChoiceDoctorPageViewModel(navigationService);
        }
    }
}
