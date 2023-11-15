using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Okul_proje
{
    public partial class FormSinavNotlari : Form
    {
        public FormSinavNotlari()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tbl_notTableAdapter ds = new DataSet1TableAdapters.tbl_notTableAdapter();
        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-6F9GQRG\SQLEXPRESS;Initial Catalog=Okul;Integrated Security=True");

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtID.Text));
        }

        private void FormSinavNotlari_Load(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_ders", bgl);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbDers.DisplayMember = "DersAd";
            cmbDers.ValueMember = "DersId";
            cmbDers.DataSource = dt;
            bgl.Close();
        }
        int notid;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            notid=int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            
        }
        int sinav1, sinav2, sinav3, proje;

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        double ortalama;
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            int sınav1, sınav2, sınav3, proje;
            double ortalama;
            //string durum;
            sınav1 = Convert.ToInt16(txtSınav1.Text);
            sınav2 = Convert.ToInt16(txtSınav2.Text);
            sınav3 = Convert.ToInt16(txtSınav3.Text);
            proje = Convert.ToInt16(txtProje.Text);
            ortalama = (sınav1 + sınav2 + sınav3 + proje) / 4;
            txtOrtalama.Text=ortalama.ToString();
            if (ortalama >= 50)
            {
                txtDurum.Text = "True";
            }
            else
            {
                txtDurum.Text = "False";
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(cmbDers.SelectedValue.ToString()),int.Parse(txtID.Text),byte.Parse(txtSınav1.Text),byte.Parse(txtSınav2.Text),byte.Parse(txtSınav3.Text),byte.Parse(txtProje.Text),decimal.Parse(txtOrtalama.Text),bool.Parse(txtDurum.Text),notid);
        }
    }
}
