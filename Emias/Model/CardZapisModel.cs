using API6.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emias.Model
{
    public class CardZapisModel
    {
        public string vrachCardType { get; set; }
        public string vrachName { get; set; }

        public string date {  get; set; }

        public string adres {  get; set; }
        public Appointment appointmentselect { get; set; }

        public CardZapisModel(int type, string vrachname, DateTime date, string adres, Appointment appointmentselect)
        {
            this.appointmentselect = appointmentselect;
            this.date = $"{date.Day} {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month).ToLower()}";
            this.vrachCardType = VracSpecName(type);
            this.vrachName = vrachname;
            this.adres = adres;
        }

        private string VracSpecName(int cardType)
        {
            string name = null;
            switch (cardType)
            {
                case 1:
                    name = "Педиатр";
                    break;
                case 2:
                    name = "Офтальмолог";
                    break;
                case 3:
                    name = "Уролог";
                    break;
                case 4:
                    name = "Стоматолог";
                    break;
                case 5:
                    name = "Канцелярия";
                    break;
                case 6:
                    name = "Дежурный";
                    break;
                case 7:
                    name = "Травматолог";
                    break;
            }
            return name;
        }
    }
}
