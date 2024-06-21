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

namespace Emias.Model
{
    /// <summary>
    /// Логика взаимодействия для DoktorInfoCardUS.xaml
    /// </summary>
    public partial class DoktorInfoCardUS : UserControl
    {
        public DoctorInfo info { get; set; }
        public DoktorInfoCardUS(DoctorInfo info)
        {
            InitializeComponent();
            this.info = info;
            DataContext = new DoctorInfoUSViewModel(this.info);
        }
    }
}
