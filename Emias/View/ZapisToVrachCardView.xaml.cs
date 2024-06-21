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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Emias.View
{
    /// <summary>
    /// Логика взаимодействия для ZapisToVrachCardView.xaml
    /// </summary>
    public partial class ZapisToVrachCardView : UserControl
    {
        public CardZapisModel card { get; set; }
        private ServiceNavigation navigationService;
        public ZapisToVrachCardView(CardZapisModel card, ServiceNavigation navigation)
        {
            InitializeComponent();
            this.card = card;
            navigationService = navigation;
            DataContext = new ZapisToVrachCardViewModel(this.card, navigation);
        }
    }
}
