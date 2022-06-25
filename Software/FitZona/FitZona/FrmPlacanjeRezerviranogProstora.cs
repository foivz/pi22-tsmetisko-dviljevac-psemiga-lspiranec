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
    public partial class FrmPlacanjeRezerviranogProstora : Form
    {
        Upravljanje_podataka u;
        public FrmPlacanjeRezerviranogProstora()
        {
            InitializeComponent();
            u = new Upravljanje_podataka();
        }

        private void FrmPlacanjeRezerviranogProstora_Load(object sender, EventArgs e)
        {
            Osvjezi();
            buttonMeniPlacanjeProstora.Enabled = false;
            dataGridViewRezervacija.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void Osvjezi()
        {
            dataGridViewRezervacija.DataSource = u.DohvatiRezervacijeKorisnika(textBoxHardCodeIDKorisnika.Text);
        }

        private void buttonPlatiRezervaciju_Click(object sender, EventArgs e)
        {
            if (dataGridViewRezervacija.CurrentRow.Cells[5].Value.ToString() == "0")
            {
                FrmPlacanjeOnlineRezervacija fmr = new FrmPlacanjeOnlineRezervacija(dataGridViewRezervacija.CurrentRow.Cells[0].Value.ToString());
                fmr.ShowDialog();
                Osvjezi();
            }
            else
            {
                MessageBox.Show("Rezervacija je vec plaćena");
            }
            
        }

        private void buttonMeniRezervacijaSportskihProstora_Click(object sender, EventArgs e)
        {
            this.Hide();
            u.OtvoriRezervacijuSportskihProstora();
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

        private void buttonPDF_Click(object sender, EventArgs e)
        {
            u.GenerirajPDF(dataGridViewRezervacija);
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/foivz/pi22-tsmetisko-dviljevac-psemiga-lspiranec/wiki/Tehni%C4%8Dka-dokumentacija#281-slu%C4%8Daj-kori%C5%A1tenja-pla%C4%87anja-rezervacije");
        }
    }
}
