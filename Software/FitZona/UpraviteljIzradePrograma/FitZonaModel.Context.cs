﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FitZonaEntities : DbContext
    {
        public FitZonaEntities()
            : base("name=FitZonaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Grupa> Grupa { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Paket> Paket { get; set; }
        public virtual DbSet<prostor_termin> prostor_termin { get; set; }
        public virtual DbSet<Rezervacija> Rezervacija { get; set; }
        public virtual DbSet<Rezervacija_opreme> Rezervacija_opreme { get; set; }
        public virtual DbSet<Sportska_oprema> Sportska_oprema { get; set; }
        public virtual DbSet<Sportski_prostor> Sportski_prostor { get; set; }
        public virtual DbSet<Termin> Termin { get; set; }
        public virtual DbSet<Vlastiti_trening> Vlastiti_trening { get; set; }
        public virtual DbSet<Zaposlenik> Zaposlenik { get; set; }
    }
}
