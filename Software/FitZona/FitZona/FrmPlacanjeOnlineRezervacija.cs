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
    public partial class FrmPlacanjeOnlineRezervacija : Form
    {
        string idRez;
        Upravljanje_podataka u;
        public FrmPlacanjeOnlineRezervacija(string idRezervacije)
        {
            InitializeComponent();
            u = new Upravljanje_podataka();
            idRez = idRezervacije;
        }

        private void buttonNaplati_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text != "" && textBoxKartica.Text != "" && textBoxCVC.Text != "" && textBoxDatumIsteka.Text != "" && textBoxAdresaZaNaplatu.Text != "" && textBoxGrad.Text != "" && textBoxZupanija.Text != "" && textBoxPostanskiBroj.Text != "")
            {
                u.PlatiRezervaciju(idRez);
                this.Close();
            }
            else
            {
                MessageBox.Show("Neispravno popunjen format");
            }
            
        }

        private void FrmPlacanjeOnline_Load(object sender, EventArgs e)
        {
            //Hard Kodiranje idKorisnika = 1
            string popust = u.DohvatiPopust(1);
            labelIznosPopusta.Text = popust + "%";
        }
    }
}
