//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FitZona
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rezervacija_opreme
    {
        public int rezervacija_opreme_id { get; set; }
        public Nullable<int> korisnik_id { get; set; }
        public Nullable<int> sportska_oprema_id { get; set; }
        public Nullable<int> rezervacija_id { get; set; }
    
        public virtual Korisnik Korisnik { get; set; }
        public virtual Rezervacija Rezervacija { get; set; }
        public virtual Sportska_oprema Sportska_oprema { get; set; }
    }
}
