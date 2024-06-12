﻿using Emias.Service;
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
    /// Логика взаимодействия для DoctorChoiceUserPage.xaml
    /// </summary>
    public partial class DoctorChoiceUserPage : Page
    {
        private ServiceNavigation _navigationService;

        public DoctorChoiceUserPage(ServiceNavigation navigationService)
        {
            InitializeComponent();
            _navigationService = navigationService;
            DataContext = new DoctorChoiceUserPageVM(_navigationService);
        }
    }
}
