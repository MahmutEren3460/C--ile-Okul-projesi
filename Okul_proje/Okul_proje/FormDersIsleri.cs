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
    public partial class FormDersIsleri : Form
    {
        public FormDersIsleri()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tbl_dersTableAdapter ds = new DataSet1TableAdapters.tbl_dersTableAdapter();
        private void FormOgrenciIsleri_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(txtAD.Text);
            MessageBox.Show("Ders Başarıyla Eklendi");
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(txtID.Text));
            MessageBox.Show("Ders Başarıyla Silindi");
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(txtAD.Text,byte.Parse(txtID.Text));
            MessageBox.Show("Ders Başarıyla Güncellendi");
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAD.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
