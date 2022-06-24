﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitZona
{
    public class Upravljanje_podataka
    {
        public List<SlobodniProstori> DohvatiSlobodneProstore()
        {
            using (var ctx = new FitZona_Entitiess())
            {
                var query = from pt in ctx.prostor_termin
                            from s in ctx.Sportski_prostor
                            from t in ctx.Termin
                            where s.sportski_prostor_id == pt.sportski_prostor_id && t.termin_id == pt.termin_id && pt.slobodan == 1
                            orderby s.sportski_prostor_id
                            select new SlobodniProstori
                            {
                                Sportski_prostor_id = s.sportski_prostor_id,
                                Sportski_prostor = s.ime,
                                Vrijeme_početka = t.vrijeme_od,
                                Vrijeme_završetka = t.vrijeme_do
                            };

                return query.ToList();
            }
        }

        internal object DohvatiSportskeProstore()
        {
            using (var ctx = new FitZona_Entitiess())
            {
                var query = from s in ctx.Sportski_prostor
                            select s.ime;

                return query.Distinct().ToList();
            }
        }

        public string DohvatiCijenuClanarine(int idKorisnika)
        {
            string cijena = "";
            using (var ctx = new FitZona_Entitiess())
            {
                var query = from k in ctx.Korisnik
                            from p in ctx.Paket
                            where k.korisnik_id == idKorisnika && p.paket_id==k.paket_id
                            select p.cijena;
                double? paketCijena = query.FirstOrDefault();
                cijena = paketCijena.ToString();
                return cijena;
            }
        }

        public bool ProvjeriTermineSDuljinom(int? duljinaRezervacije, TimeSpan vrijemeOd)
        {
            bool provjera = true;
            List<SlobodniProstori> SlobodniProstori = DohvatiSlobodneProstore();

            int index = SlobodniProstori.FindIndex(x => x.Vrijeme_početka == vrijemeOd);

            TimeSpan? vrijemeZavrsetkaProvjeraPrvi = null;
            TimeSpan? vrijemePocetkaProvjeraDrugi = null;
            
            for (int i = index; i <= index+duljinaRezervacije-2; i++)
            {
                vrijemeZavrsetkaProvjeraPrvi = SlobodniProstori[i].Vrijeme_završetka;
                vrijemePocetkaProvjeraDrugi = SlobodniProstori[i+1].Vrijeme_početka;

                if (vrijemeZavrsetkaProvjeraPrvi != vrijemePocetkaProvjeraDrugi)
                {
                    provjera = false;
                }
                
            }

            return provjera;
        }

        internal TimeSpan IzradiProgram(string sportskiProstor, string vrijemeIzradeOd, string ime, string idKorisnika)
        {
            
            DateTime sad = DateTime.Now;
            TimeSpan vrijemeOdDohvaceno = TimeSpan.Parse(vrijemeIzradeOd);
            DateTime vrijeme = new DateTime(sad.Year, sad.Month, sad.Day, vrijemeOdDohvaceno.Hours, vrijemeOdDohvaceno.Minutes, vrijemeOdDohvaceno.Seconds);
            int IDKor = int.Parse(idKorisnika);
            int IDSport = int.Parse(sportskiProstor);
            Vlastiti_trening trening = new Vlastiti_trening()
            {
                ime = ime,
                vrijeme = vrijeme,
                korisnik_id = IDKor,
                sportski_prostor_id = IDSport
            };
            using (var ctx = new FitZona_Entitiess())
            {
                ctx.Vlastiti_trening.Add(trening);
                ctx.SaveChanges();
            }
            return vrijemeOdDohvaceno;
            
        }

        internal object DohvatiFiltriraneSlobodneProstore(string ime)
        {
            using (var ctx = new FitZona_Entitiess())
            {
                var query = from pt in ctx.prostor_termin
                            from s in ctx.Sportski_prostor
                            from t in ctx.Termin
                            where s.sportski_prostor_id == pt.sportski_prostor_id && t.termin_id == pt.termin_id && pt.slobodan == 1 && s.ime == ime
                            orderby s.sportski_prostor_id
                            select new SlobodniProstori
                            {
                                Sportski_prostor_id = s.sportski_prostor_id,
                                Sportski_prostor = s.ime,
                                Vrijeme_početka = t.vrijeme_od,
                                Vrijeme_završetka = t.vrijeme_do
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

        public void AzurirajTermine(TimeSpan vrijeme_od, int? duljina_rezervacija_sati, int? sportskiProstorID)
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
                                where pt.termin_id == terminID+i && pt.sportski_prostor_id == sportskiProstorID
                                select pt;
                    prostor_termin ptDohvaceni = query1.FirstOrDefault();
                    ptDohvaceni.slobodan = 0;
                    
                }
                ctx.SaveChanges();
            }
        }

        internal void OtvoriMjesecnaClanarina()
        {
            FrmPlacanjeMjesecneClanarine frm = new FrmPlacanjeMjesecneClanarine();
            frm.ShowDialog();
        }

        internal void OtvoriPlacanjeProstora()
        {
            FrmPlacanjeRezerviranogProstora frm = new FrmPlacanjeRezerviranogProstora();
            frm.ShowDialog();
        }

        internal void OtvoriPrijavuZaIzraduVlastitihPrograma()
        {
            FrmIzradaVlastitihPrograma frm = new FrmIzradaVlastitihPrograma();
            frm.ShowDialog();
        }

        internal void OtvoriRezervacijuSportskihProstora()
        {
            
            FrmRezervacijaSportskihProstora frm = new FrmRezervacijaSportskihProstora();
            frm.ShowDialog();

        }
    }
}
