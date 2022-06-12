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
        Upravljanje_podataka u;
        public FrmPlacanjeMjesecneClanarine()
        {
            InitializeComponent();
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
            }
            else
            {
                MessageBox.Show("Članarina već plaćena");
            }
        }
    }
}
