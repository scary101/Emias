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
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Xml.Serialization;

namespace Emias.ViewModel
{
    public class MainUserViewModel : BindingHelpers
    {
        public ObservableCollection<UserTreeViewItem> MenuItems { get; set; }

        public RelayCommand TreeViewSelectItemCommand { get; set; }
        private readonly INavigationService _navigationService;
        public MainUserViewModel(INavigationService navigation)
        {
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
                }
            }
        }
    }
}
