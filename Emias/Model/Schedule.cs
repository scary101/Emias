using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emias.Model
{
    internal class Dat
    {
        public class Schedule
        {
            public DateTime Date { get; set; }
            public string Time { get; set; }
            public string Procedure { get; set; }
            public string Status { get; set; }
        }
    }
}
