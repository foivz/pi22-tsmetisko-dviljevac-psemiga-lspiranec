using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitZona
{
    public class Upravljanje_podataka
    {
        public object DohvatiSlobodneProstore()
        {
            using (var ctx = new FitZona_Entitiess())
            {
                var query = from pt in ctx.prostor_termin
                            from s in ctx.Sportski_prostor
                            from t in ctx.Termin
                            where s.sportski_prostor_id == pt.sportski_prostor_id && t.termin_id == pt.termin_id && pt.slobodan == 1
                            select new
                            {
                                s.sportski_prostor_id,
                                s.ime,
                                t.vrijeme_do,
                                t.vrijeme_od
                            };

                return query.ToList();
            }
        }

        public string DohvatiPopust(int idKorisnika)
        {
            string popust = "";
            using (var ctx = new FitZona_Entitiess())
            {
                var query = from k in ctx.Korisnik
                            
                            where k.korisnik_id == idKorisnika
                            select k.paket_id;
                int? paketID = query.FirstOrDefault();

                if (paketID == 1)
                {
                    popust = "10";
                    
                }
                else if (paketID == 2)
                {
                    popust = "20";
                    
                }
                else if (paketID == 3)
                {
                    popust = "30";
                    
                }
                return popust;
            }
        }

        public object DohvatiRezervacijeKorisnika(string idKorisnika)
        {
            int idKor = int.Parse(idKorisnika);
            using (var ctx = new FitZona_Entitiess())
            {
                var query = from r in ctx.Rezervacija
                            from s in ctx.Sportski_prostor
                            where s.sportski_prostor_id == r.sportski_prostor_id && r.korisnik_id == idKor
                            select new
                            {
                                r.rezervacija_id,
                                s.ime,
                                r.datum,
                                r.vrijeme_od,
                                r.duljina_rezervacija_sati,
                                r.plaćena
                            };

                return query.ToList();
            }
        }

        public void PlatiRezervaciju(string idRezervacije)
        {
            int idRez = int.Parse(idRezervacije);
            using (var ctx = new FitZona_Entitiess())
            {
                var query = from r in ctx.Rezervacija
                            where r.rezervacija_id == idRez
                            select r;
                Rezervacija dohvacena = query.FirstOrDefault();
                
                dohvacena.plaćena = 1;
                ctx.SaveChanges();
            }
        }

        public void UpisiRezervaciju(Rezervacija nova)
        {
            using (var ctx = new FitZona_Entitiess())
            {
                ctx.Rezervacija.Add(nova);
                ctx.SaveChanges();
            }
        }

        public void AzurirajTermine(TimeSpan vrijeme_od, int? duljina_rezervacija_sati)
        {
            using (var ctx = new FitZona_Entitiess())
            {
                var query = from t in ctx.Termin
                            where t.vrijeme_od == vrijeme_od
                            select t.termin_id;
                int terminID = query.FirstOrDefault();
                for (int i = 0; i < duljina_rezervacija_sati; i++)
                {
                    var query1 = from pt in ctx.prostor_termin
                                where pt.termin_id == terminID+i
                                select pt;
                    prostor_termin ptDohvaceni = query1.FirstOrDefault();
                    ptDohvaceni.slobodan = 0;
                    
                }
                ctx.SaveChanges();
            }
        }

        internal void OtvoriMjesecnaClanarina()
        {
            throw new NotImplementedException();
        }

        internal void OtvoriPlacanjeProstora()
        {
            FrmPlacanjeRezerviranogProstora frm = new FrmPlacanjeRezerviranogProstora();
            frm.ShowDialog();
        }

        internal void OtvoriPrijavuZaIzraduVlastitihPrograma()
        {
            throw new NotImplementedException();
        }

        internal void OtvoriRezervacijuSportskihProstora()
        {
            
            FrmRezervacijaSportskihProstora frm = new FrmRezervacijaSportskihProstora();
            frm.ShowDialog();

        }
    }
}
