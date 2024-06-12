using System;
using System.Collections.Generic;

namespace API6.Models
{
    public partial class AppointmentDocument
    {
        public int? Appid { get; set; }
        public int IdAppointment { get; set; }
        public string Rtf { get; set; } = null!;

        
    }
}
