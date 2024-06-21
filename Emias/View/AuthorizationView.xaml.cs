using API6;
using Emias.Interfaces;
using Emias.Service;
using Emias.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Emias.View
{
    public partial class AuthorizationView : Window
    {
        private readonly INavigationService _navigationService;

        public AuthorizationView()
        {
            InitializeComponent();
            _navigationService = new ServiceNavigation(PageFrame);

            DataContext = new AuthorizationViewModel(_navigationService);
        }


        // Метод для перемещения окна при нажатии на его область
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                this.DragMove();
        }
       
    }
}
