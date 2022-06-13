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
    
    public partial class Korisnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Korisnik()
        {
            this.Rezervacija = new HashSet<Rezervacija>();
            this.Rezervacija_opreme = new HashSet<Rezervacija_opreme>();
            this.Vlastiti_trening = new HashSet<Vlastiti_trening>();
            this.Grupa = new HashSet<Grupa>();
            this.Zaposlenik = new HashSet<Zaposlenik>();
        }
    
        public int korisnik_id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string email { get; set; }
        public string adresa_stanovanja { get; set; }
        public string broj_mobitela { get; set; }
        public string korisnicko_ime { get; set; }
        public string slika_profila { get; set; }
        public Nullable<int> paket_id { get; set; }
    
        public virtual Paket Paket { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezervacija_opreme> Rezervacija_opreme { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vlastiti_trening> Vlastiti_trening { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grupa> Grupa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zaposlenik> Zaposlenik { get; set; }
    }
}
