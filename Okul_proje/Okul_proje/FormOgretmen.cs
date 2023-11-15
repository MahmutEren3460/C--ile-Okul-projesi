using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul_proje
{
    public partial class FormOgretmen : Form
    {
        public FormOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormKulup frk = new FormKulup();
            frk.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDersIsleri fdı = new FormDersIsleri();
            fdı.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormOgrenciIsleri fd = new FormOgrenciIsleri();
            fd.Show();  
        }

        private void btnSinavNotlar_Click(object sender, EventArgs e)
        {
            FormSinavNotlari fd = new FormSinavNotlari();   
            fd.Show();
        }
    }
}
