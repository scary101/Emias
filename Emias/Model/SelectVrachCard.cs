using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emias.Model
{
    public class SelectVrachCard
    {
        public string NameSpecialty {  get; set; }
        public string ImagePath {  get; set; }
        public SelectVrachCardType vrachType { get; set; }

        public SelectVrachCard(string NameSpecialty, string ImagePath, SelectVrachCardType vrachType)
        {
            this.ImagePath = ImagePath;
            this.vrachType = vrachType;
            this.NameSpecialty = NameSpecialty;
        }

    }

    public  enum SelectVrachCardType
    {
        Pediatr = 1,
        Oftolmolog = 2,
        Urolog = 3,
        Stomatolog = 4,
        Document = 5,
        Dejurny = 6,
        Travmotolog = 7
    }
}
