using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emias.Model
{
    public class DoctorInfo
    {
        public string Name { get; set; }
        public string Adres { get; set; }
        public string NearestDate { get; set; }

        public DoctorInfo(string name, string adres, string nearestDate)
        {
            Name = name;
            Adres = adres;
            NearestDate = nearestDate;
        }
    }
}
