﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ListBoxArchiveCard.xaml
    /// </summary>
    public partial class ListBoxArchiveCard : UserControl
    {
        public ListBoxArchiveCard(ObservableCollection<ArxivZapisCardView> card, DateTime date, int plusminus)
        {
            InitializeComponent();
            DataContext = new ListBoxArchiveViewModel(card, date, plusminus);
        }
    }
}
