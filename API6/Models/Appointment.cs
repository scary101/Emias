using System;
using System.Collections.Generic;

namespace API6.Models
{
    public partial class Appointment
    {
        

        public int? IdAppointment { get; set; }
        public long Oms { get; set; }
        public int IdDoctor { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public int? IdStatus { get; set; }

        
    }
}
