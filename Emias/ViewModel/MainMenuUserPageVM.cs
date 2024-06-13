using Emias.Interfaces;
using Emias.Model;
using Emias.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Emias.ViewModel
{
    public class MainMenuUserPageVM
    {
        public ObservableCollection<CardVrachUserControl> VrachCards {  get; set; }
        private INavigationService _navigationService;

        public MainMenuUserPageVM(INavigationService navigation)
        {
            _navigationService = navigation ?? throw new ArgumentNullException(nameof(navigation));
            VrachCards = new ObservableCollection<CardVrachUserControl>
            {
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Педаитр", "/Images/naushniki.png", SelectVrachCardType.Pediatr)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Офтальмолог", "/Images/ochki.png", SelectVrachCardType.Oftolmolog)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Уролог", "/Images/urolog.png", SelectVrachCardType.Urolog)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Стамотолог", "/Images/zub.png", SelectVrachCardType.Stomatolog)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Дежурный врач", "/Images/vrach.png", SelectVrachCardType.Dejurny)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Травмотолог", "/Images/noga.png", SelectVrachCardType.Travmotolog))
            };

        }
    }
}
