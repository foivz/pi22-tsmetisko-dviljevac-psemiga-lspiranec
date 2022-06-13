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
    public partial class FrmIzradaVlastitihPrograma : Form
    {
        Upravljanje_podataka u;
        
        public FrmIzradaVlastitihPrograma()
        {
            InitializeComponent();
            u = new Upravljanje_podataka();
            
            buttonMeniPrijavaZaIzraduVlastitihPrograma.Enabled = false;
        }

        private void FrmIzradaVlastitihPrograma_Load(object sender, EventArgs e)
        {
            Osvjezi();
        }

        private void Osvjezi()
        {
            dataGridViewSlobodniProstoriZaIzradu.DataSource = u.DohvatiSlobodneProstore();
        }

        private void buttonIzradiProgram_Click(object sender, EventArgs e)
        {
            string sportskiProstor = dataGridViewSlobodniProstoriZaIzradu.CurrentRow.Cells[0].Value.ToString();
            string vrijemeIzradeOd = dataGridViewSlobodniProstoriZaIzradu.CurrentRow.Cells[3].Value.ToString();
            TimeSpan vrijemeOd = u.IzradiProgram(sportskiProstor, vrijemeIzradeOd, textBoxImePrograma.Text, textBoxHardCodeIDKorisnika.Text);
            int? duljina = int.Parse(textBoxDuljinaRezervacije.Text);
            u.AzurirajTermine(vrijemeOd, duljina);
            Osvjezi();
        }

        private void buttonMeniRezervacijaSportskihProstora_Click(object sender, EventArgs e)
        {
            this.Hide();
            u.OtvoriRezervacijuSportskihProstora();
            this.Close();
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
    }
}
