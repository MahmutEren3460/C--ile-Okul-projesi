using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Okul_proje
{
    public partial class FormOgrenciIsleri : Form
    {
        public FormOgrenciIsleri()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-6F9GQRG\SQLEXPRESS;Initial Catalog=Okul;Integrated Security=True");



        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void FormOgrenciIsleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Kulupveogrenci();
            bgl.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_kulup",bgl);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbKulup.DisplayMember = "KulupAd";
            cmbKulup.ValueMember = "KulupId";
            cmbKulup.DataSource = dt;
            bgl.Close();
        }
        string c = "";
        private void btnEkle_Click(object sender, EventArgs e)
        {
            
           
            ds.OgrenciEkle(txtAD.Text,txtSoyad.Text,byte.Parse(cmbKulup.SelectedValue.ToString()),c);
            MessageBox.Show("Öğrenci Başarıyla Eklendi");
            dataGridView1.DataSource = ds.Kulupveogrenci();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Kulupveogrenci();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtAD.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.Ogrenciguncelle(txtAD.Text,txtSoyad.Text,c,byte.Parse( cmbKulup.SelectedValue.ToString()),int.Parse( txtID.Text));
            MessageBox.Show("Öğrenci Başarıyla Güncellendi");
            dataGridView1.DataSource = ds.Kulupveogrenci();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.Ogrencisil(int.Parse(txtID.Text));
            MessageBox.Show("Öğrenci Başarıyla Silindi");
            dataGridView1.DataSource = ds.Kulupveogrenci();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "Erkek";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                c = "Kız";
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciAra(txtAra.Text);
        }
    }
}
