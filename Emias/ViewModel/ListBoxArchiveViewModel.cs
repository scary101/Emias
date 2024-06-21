using Emias.View;
using Emias.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emias.ViewModel
{
    internal class ListBoxArchiveViewModel : BindingHelpers
    {
        public ObservableCollection<ArxivZapisCardView> Current {  get; set; }

        private string _date;
        public string Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(nameof(Date)); }
        }

        private string _ifnull;
        public string IfNull
        {
            get { return _ifnull; }
            set { _ifnull = value; OnPropertyChanged(nameof(IfNull)); }
        }


        public ListBoxArchiveViewModel(ObservableCollection<ArxivZapisCardView> card, DateTime date, int plusminus)
        {
            if (card.Count == 0)
            {
                _date = FormatDate(date, plusminus);
                IfNull = "На это месяц записей не найдено";
            }
            else
            {
                Current = card;
                _date = FormatDate(date, plusminus);
            }
        }

        static string FormatDate(DateTime date, int a)
        {
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month + a);
            string formattedDate = $"{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(monthName)} {date.Year}";


            return formattedDate;
        }


    }
}
