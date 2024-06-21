using Emias.Model;
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
    /// Логика взаимодействия для ArxivZapisCardView.xaml
    /// </summary>
    public partial class ArxivZapisCardView : UserControl
    {
        public ArxivZapisCardView(CardZapisModel card)
        {
            InitializeComponent();
            DataContext = new ArxiveZapisCardViewModel(card);
        }
    }
}
