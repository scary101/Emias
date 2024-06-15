using System;
using System.Collections.Generic;

namespace API6.Models
{
    public partial class Doctor
    {
        

        public int IdDoctor { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public int IdSpeciality { get; set; }
        public string EnterPassword { get; set; } = null!;
        public string WorkAdderss { get; set; } = null!;

        
    }
}
