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
    
    public partial class Grupa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Grupa()
        {
            this.Korisnik = new HashSet<Korisnik>();
        }
    
        public int grupa_id { get; set; }
        public string ime { get; set; }
        public Nullable<int> zaposlenik_id { get; set; }
    
        public virtual Zaposlenik Zaposlenik { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Korisnik> Korisnik { get; set; }
    }
}
