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
        Pediatr = 0,
        Oftolmolog = 1,
        Urolog = 2,
        Stomatolog = 3,
        Document = 4,
        Dejurny = 5,
        Travmotolog = 6
    }
}
