using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitZona
{
    public class SlobodniProstori
    {
        public int Sportski_prostor_id { get; set; }
        public string Sportski_prostor { get; set; }
        public TimeSpan? Vrijeme_početka { get; set; }
        public TimeSpan? Vrijeme_završetka { get; set; }
    }
}
