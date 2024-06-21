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
    internal class ListBoxZapisiViewModel : BindingHelpers
    {
        public ObservableCollection<ZapisToVrachCardView> Current { get; set; }

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

        public ListBoxZapisiViewModel(ObservableCollection<ZapisToVrachCardView> card, DateTime date, int plusminus)
        {
            Current = card;
            _date = FormatDate(date, plusminus);
            IfNull = card.Count == 0 ? "На этот месяц записей не найдено" : string.Empty;
        }

        static string FormatDate(DateTime date, int a)
        {
            DateTime adjustedDate = date.AddMonths(a);
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(adjustedDate.Month);
            string formattedDate = $"{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(monthName)} {adjustedDate.Year}";

            return formattedDate;
        }
    }

}
