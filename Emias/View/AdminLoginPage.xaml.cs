using Emias.Interfaces;
using Emias.ViewModel;
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

namespace Emias.View
{
    /// <summary>
    /// Логика взаимодействия для AdminLoginPage.xaml
    /// </summary>
    public partial class AdminLoginPage : Page
    {
        private readonly INavigationService _navigationService;
        public AdminLoginPage(INavigationService navigationService)
        {
            InitializeComponent();
            _navigationService = navigationService;
            DataContext = new AdminLoginViewModel(_navigationService);
        }
    }
}
