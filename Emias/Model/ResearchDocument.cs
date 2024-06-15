using System;
using System.Collections.Generic;

namespace API6.Models
{
    public partial class ResearchDocument
    {
        public int? Reserchdocid { get; set; }
        public int IdAppointment { get; set; }
        public string Rtf { get; set; } = null!;
        public byte[]? Attachment { get; set; }

        
    }
}
