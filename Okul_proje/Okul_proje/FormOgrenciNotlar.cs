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
    public partial class FormOgrenciNotlar : Form
    {
        public FormOgrenciNotlar()
        {
            InitializeComponent();
        }

        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-6F9GQRG\SQLEXPRESS;Initial Catalog=Okul;Integrated Security=True");
        public string numara;
        private void FormOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select DersAd,Sinav1,Sinav2,Sinav3,Ortalama,Durum from tbl_not inner join tbl_ders on tbl_not.DersId=tbl_Ders.DersId where OgrId=@p1", bgl);
            cmd.Parameters.AddWithValue("@p1", numara);
            //this.Text=numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
