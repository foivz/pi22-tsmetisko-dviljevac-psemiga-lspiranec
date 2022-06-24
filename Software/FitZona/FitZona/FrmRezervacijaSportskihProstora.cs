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

            comboBoxFilter.DataSource = u.DohvatiSportskeProstore();
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
                vrijeme_od = TimeSpan.Parse(dataGridViewSlobodniProstori.CurrentRow.Cells[2].Value.ToString()),
                duljina_rezervacija_sati = int.Parse(textBoxDuljinaRezervacije.Text),
                plaćena = 0,
                korisnik_id = int.Parse(textBoxHardCodeIDKorisnika.Text),
                sportski_prostor_id = int.Parse(dataGridViewSlobodniProstori.CurrentRow.Cells[0].Value.ToString()),
                zaposlenik_id = null
            };
            if (u.ProvjeriTermineSDuljinom(nova.duljina_rezervacija_sati, nova.vrijeme_od))
            {
                u.UpisiRezervaciju(nova);
                u.AzurirajTermine(nova.vrijeme_od, nova.duljina_rezervacija_sati, nova.sportski_prostor_id);
            }
            else
            {
                MessageBox.Show("Nije moguće rezervirati toliko sati od odabranog termina");
            }
            
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

        private void comboBoxFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            string ime = comboBoxFilter.Text;
            dataGridViewSlobodniProstori.DataSource = u.DohvatiFiltriraneSlobodneProstore(ime);
        }

        private void buttonPrikaziSve_Click(object sender, EventArgs e)
        {
            Osvjezi();
        }
    }
}
