//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UpraviteljIzradePrograma
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vlastiti_trening
    {
        public int vlastiti_trening_id { get; set; }
        public string ime { get; set; }
        public Nullable<System.DateTime> vrijeme { get; set; }
        public Nullable<int> korisnik_id { get; set; }
        public Nullable<int> sportski_prostor_id { get; set; }
    
        public virtual Korisnik Korisnik { get; set; }
        public virtual Sportski_prostor Sportski_prostor { get; set; }
    }
}