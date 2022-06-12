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
    public partial class FrmPlacanjeMjesecneClanarineOnline : Form
    {
        public string Placena { get; set; }
        public FrmPlacanjeMjesecneClanarineOnline()
        {
            InitializeComponent();
        }

        private void buttonNaplati_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text != "" && textBoxKartica.Text != "" && textBoxCVC.Text != "" && textBoxDatumIsteka.Text != "" && textBoxAdresaZaNaplatu.Text != "" && textBoxGrad.Text != "" && textBoxZupanija.Text != "" && textBoxPostanskiBroj.Text != "")
            {
                Placena = "DA";
                this.Close();
            }
            else
            {
                MessageBox.Show("Neispravno popunjen format");
            }
        }
    }
}
