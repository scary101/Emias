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
    internal class ChoiceDoctorPageViewModel
    {
        public ObservableCollection<CardVrachUserControl> OrviCovid {  get; set; }
        public ObservableCollection<CardVrachUserControl> Specialist { get; set; }
        public ObservableCollection<CardVrachUserControl> Napravlenia { get; set; }
        public ObservableCollection<CardVrachUserControl> CeliObrashenia { get; set; }
        private INavigationService _navigationService;
        public ChoiceDoctorPageViewModel(INavigationService navigation)
        {
            _navigationService = navigation ?? throw new ArgumentNullException(nameof(navigation));
            OrviCovid = new ObservableCollection<CardVrachUserControl>
            {
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Дежурный врач по ОРВИ", "/Images/vrach.png", SelectVrachCardType.Dejurny)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Вакцинация COVID 19", "/Images/virus.png", SelectVrachCardType.Dejurny))
            };

            Specialist = new ObservableCollection<CardVrachUserControl>
            {
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Офтальмолог", "/Images/ochki.png", SelectVrachCardType.Oftolmolog)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Уролог", "/Images/urolog.png", SelectVrachCardType.Urolog)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Травматолог", "/Images/noga.png", SelectVrachCardType.Travmotolog)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Уролог", "/Images/urolog.png", SelectVrachCardType.Urolog)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Педиатр", "/Images/naushniki.png", SelectVrachCardType.Pediatr))
            };

            CeliObrashenia = new ObservableCollection<CardVrachUserControl>
            {
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Вакцинация от гриппа", "/Images/shpric.png", SelectVrachCardType.Dejurny)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Острое заболевание", "/Images/molnya.png", SelectVrachCardType.Pediatr)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Дежурный врач по ОРВИ", "/Images/vrach.png", SelectVrachCardType.Dejurny)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Осмотр по хронике", "/Images/noga.png", SelectVrachCardType.Travmotolog)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Оформить документы", "/Images/svitok.png", SelectVrachCardType.Document)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Мужская консультация", "/Images/urolog.png", SelectVrachCardType.Urolog)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Профилактика", "/Images/naushniki.png", SelectVrachCardType.Pediatr)),
                new CardVrachUserControl(_navigationService, new SelectVrachCard("Запись к стоматолугу", "/Images/zub.png", SelectVrachCardType.Stomatolog)),
            };
        }
    }
}
