 using API6.Models;
using Emias.Interfaces;
using Emias.Model;
using Emias.View;
using Emias.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Xml.Serialization;

namespace Emias.ViewModel
{
    public class MainUserViewModel : BindingHelpers
    {
        public ObservableCollection<UserTreeViewItem> MenuItems { get; set; }
        private string _patientName;
        private MainUserWindow win;
        public string PatientName
        {
            get { return _patientName; }
            set { _patientName = value; OnPropertyChanged(nameof(PatientName)); }
        }
        private UserTreeViewItem _selectedTreeViewItem;
        public UserTreeViewItem SelectedTreeViewItem
        {
            get { return _selectedTreeViewItem; }
            set
            {
                _selectedTreeViewItem = value;
                OnPropertyChanged(nameof(SelectedTreeViewItem));
            }
        }

        public RelayCommand GoToProfile {  get; set; }
        public RelayCommand TreeViewSelectItemCommand { get; set; }
        public RelayCommand CloseWindow { get; set; }
        public RelayCommand MinimizeWindow { get; set; }
        public RelayCommand ChangeScreen { get; set; }
        private readonly INavigationService _navigationService;
        public MainUserViewModel(INavigationService navigation, MainUserWindow window)
        {
            PatientName = App.Patient.Name;
            win = window;
            _navigationService = navigation ?? throw new ArgumentNullException(nameof(navigation));
            _navigationService.NavigateTo("MainMenuUserPage");
            MenuItems = new ObservableCollection<UserTreeViewItem>
            {
                new UserTreeViewItem("Главная")
            {
                Items =
                {
                    new UserTreeViewItem("Записи и направления"),
                    new UserTreeViewItem("Рецепты"),
                    new UserTreeViewItem("Диспансеризация")
                }
            },
            new UserTreeViewItem("Медкарта")
            {
                Items =
                {
                    new UserTreeViewItem("Приёмы"),
                    new UserTreeViewItem("Анализы"),
                    new UserTreeViewItem("Исследования")
                }
            }
            };
            CloseWindow = new RelayCommand(_ => Close());
            MinimizeWindow = new RelayCommand(_ => Minimize());
            ChangeScreen = new RelayCommand(_ => FullScreen());
            GoToProfile = new RelayCommand(_ => OpenProfile());

            TreeViewSelectItemCommand = new RelayCommand(CommandSelectedItemTreeview);
        }

        private void CommandSelectedItemTreeview(object parameter)
        {
            if (parameter is UserTreeViewItem selectedTreeViewItem)
            {
                switch (selectedTreeViewItem.Header)
                {

                    case "Записи и направления":
                        _navigationService.NavigateTo("DoctorChoiceUserPage");
                        break;
                    case "Приёмы":
                        _navigationService.NavigateTo("AppointmentUserPage");
                        break;
                    case "Анализы":
                        _navigationService.NavigateTo("AnalysisUserPage");
                        break;
                    case "Исследования":
                        _navigationService.NavigateTo("ResearchesUserPage");
                        break;
                    case "Главная":
                        _navigationService.NavigateTo("MainMenuUserPage");
                        break;
                }

            }
        }

        private void Minimize()
        {
            win.WindowState = WindowState.Minimized;
        }

        private void Close()
        {
            win.Close();
        }
        private void FullScreen()
        {
            if (win.WindowState == WindowState.Normal)
            {
                win.WindowState = WindowState.Maximized;

            }
            else
            {
                win.WindowState = WindowState.Normal;

            }
        }
        public void OpenProfile()
        {
            _navigationService.NavigateTo("ProfileUserPage");
        }
    }
}
