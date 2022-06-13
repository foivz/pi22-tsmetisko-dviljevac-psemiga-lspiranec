using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitZona
{
    public partial class FrmRezervacijaSportskihProstora : Form
    {
        Upravljanje_podataka u;
        public FrmRezervacijaSportskihProstora()
        {
            InitializeComponent();
            u = new Upravljanje_podataka();
        }

        private void FrmRezervacijaSportskihProstora_Load(object sender, EventArgs e)
        {
            Osvjezi();
            buttonMeniRezervacijaSportskihProstora.Enabled = false;
        }

        private void Osvjezi()
        {
            dataGridViewSlobodniProstori.DataSource = u.DohvatiSlobodneProstore();
        }

        private void buttonRezervirajSportskiProstor_Click(object sender, EventArgs e)
        {
            Rezervacija nova = new Rezervacija()
            {
                datum = DateTime.Parse(DateTime.Now.ToShortDateString()),
                vrijeme_od = TimeSpan.Parse(dataGridViewSlobodniProstori.CurrentRow.Cells[3].Value.ToString()),
                duljina_rezervacija_sati = int.Parse(textBoxDuljinaRezervacije.Text),
                plaćena = 0,
                korisnik_id = int.Parse(textBoxHardCodeIDKorisnika.Text),
                sportski_prostor_id = int.Parse(dataGridViewSlobodniProstori.CurrentRow.Cells[0].Value.ToString()),
                zaposlenik_id = null
            };

            u.UpisiRezervaciju(nova);
            u.AzurirajTermine(nova.vrijeme_od, nova.duljina_rezervacija_sati);
            Osvjezi();
        }

        private void buttonMeniRezervacijaSportskihProstora_Click(object sender, EventArgs e)
        {
            //Onemogucen gumb umjesto implementacije otvaranje i zatvaranja dialoga
        }

        private void buttonMeniPlacanjeProstora_Click(object sender, EventArgs e)
        {
            this.Hide();
            u.OtvoriPlacanjeProstora();
            this.Close();
        }

        private void buttonMeniMjesecnaClanarina_Click(object sender, EventArgs e)
        {
            this.Hide();
            u.OtvoriMjesecnaClanarina();
            this.Close();
        }

        private void buttonMeniPrijavaZaIzraduVlastitihPrograma_Click(object sender, EventArgs e)
        {
            this.Hide();
            u.OtvoriPrijavuZaIzraduVlastitihPrograma();
            this.Close();
        }
    }
}
