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
    public partial class FormKulup : Form
    {
        public FormKulup()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-6F9GQRG\SQLEXPRESS;Initial Catalog=Okul;Integrated Security=True");
        public void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_kulup", bgl);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FormKulup_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand cmd = new SqlCommand("insert into tbl_kulup (KulupAd) values (@p1)",bgl);
            cmd.Parameters.AddWithValue("@p1", txtAD.Text);
            cmd.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Kulüp Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.LightYellow;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        { 
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAD.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand cmd = new SqlCommand("delete from tbl_kulup where KulupId=@p1",bgl);
            cmd.Parameters.AddWithValue("@p1",txtID.Text);
            cmd.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Kulüp Başarıyla Silindi");
            liste();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand cmd = new SqlCommand("update tbl_kulup set KulupAd=@p1 where KulupId=@p2",bgl);
            cmd.Parameters.AddWithValue("@p1",txtAD.Text);
            cmd.Parameters.AddWithValue("@p2", txtID.Text);
            cmd.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Kulüp Başarıyla Güncellendi");
            liste();
        }

       
    }
}
