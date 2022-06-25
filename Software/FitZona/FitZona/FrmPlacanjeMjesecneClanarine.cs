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
    public partial class FrmPlacanjeMjesecneClanarine : Form
    {
        int sekunde;
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        Upravljanje_podataka u;
        public FrmPlacanjeMjesecneClanarine()
        {
            InitializeComponent();
            t.Interval = 1000; 
            t.Tick += new EventHandler(timer1_Tick);
            buttonMeniMjesecnaClanarina.Enabled = false;
            u = new Upravljanje_podataka();
        }

        private void FrmPlacanjeMjesecneClanarine_Load(object sender, EventArgs e)
        {
            textBoxCijenaClanarine.Text = u.DohvatiCijenuClanarine(int.Parse(textBoxHardCodeIDKorisnika.Text.ToString()));
        }

        private void buttonPlatiRezervaciju_Click(object sender, EventArgs e)
        {
            if (labelPlacenaBool.Text == "NE")
            {
                FrmPlacanjeMjesecneClanarineOnline frm = new FrmPlacanjeMjesecneClanarineOnline();
                frm.ShowDialog();
                labelPlacenaBool.Text = frm.Placena;
                sekunde = int.Parse(labelSekunde.Text);
                t.Start();
            }
            else
            {
                MessageBox.Show("Članarina već plaćena");
            }
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

        private void buttonMeniPrijavaZaIzraduVlastitihPrograma_Click(object sender, EventArgs e)
        {
            this.Hide();
            u.OtvoriPrijavuZaIzraduVlastitihPrograma();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sekunde > -1)
            {
                labelSekunde.Text = sekunde--.ToString();
            }
            else if (sekunde <= 0)
            {
                timer1.Stop();
                labelPlacenaBool.Text = "NE";
            }
        }
    }
}
