using Emias.Interfaces;
using Emias.Model;
using Emias.Service;
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
using System.Windows.Shapes;

namespace Emias.View
{
    /// <summary>
    /// Логика взаимодействия для MainUserWindow.xaml
    /// </summary>
    public partial class MainUserWindow : Window
    {
        private readonly INavigationService _navigationService;
        public MainUserWindow()
        {
            InitializeComponent();
            MainUserWindow win = this;
            _navigationService = new ServiceNavigation(PageFrame);
            DataContext = new MainUserViewModel(_navigationService, win);
        }
        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (DataContext is MainUserViewModel viewModel && e.NewValue is UserTreeViewItem selectedItem)
            {
                viewModel.TreeViewSelectItemCommand.Execute(selectedItem);
            }
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                this.DragMove();
        }

    }
}

