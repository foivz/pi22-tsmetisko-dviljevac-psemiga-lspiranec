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
    }
}
