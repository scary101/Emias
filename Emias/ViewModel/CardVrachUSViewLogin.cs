using Emias.Interfaces;
using Emias.Model;
using Emias.Service;
using Emias.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Emias.ViewModel
{
    internal class CardVrachUSViewLogin : BindingHelpers
    {
        private readonly INavigationService _navigationService;
        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged(nameof(Text)); }
        }
        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; OnPropertyChanged(nameof(ImagePath)); }
        }
        public RelayCommand GoToZapis {  get; set; }
        private SelectVrachCard _card;

        public CardVrachUSViewLogin(SelectVrachCard card, INavigationService navigationService)
        {
            _card = card;
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _text = card.NameSpecialty;
            _imagePath = card.ImagePath;
            GoToZapis = new RelayCommand(_ => OpenPageZapis());

        }

        private void OpenPageZapis()
        {
            _navigationService.NavigateToPageWithStringData(_navigationService, _card.vrachType);
        }
    }
}
