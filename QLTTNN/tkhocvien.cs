using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace QLTTNN
{
    public partial class tkhocvien : Form
    {
        public tkhocvien()
        {
            InitializeComponent();
        }

        //Code

        SqlConnection con;

        private void tkhocvien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTTNNDataSet2.monhoc' table. You can move, or remove it, as needed.
            this.monhocTableAdapter.Fill(this.qLTTNNDataSet2.monhoc);
            // TODO: This line of code loads data into the 'qLTTNNDataSet1.lophoc' table. You can move, or remove it, as needed.
            this.lophocTableAdapter.Fill(this.qLTTNNDataSet1.lophoc);
            string ketnoi = ConfigurationManager.ConnectionStrings["QuanlyTTNN"].ConnectionString.ToString();
            con = new SqlConnection(ketnoi);
            con.Open();
            hienthi();
        }

        private void tkhocvien_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        public void hienthi()
        {
            string sqlSELECT = "SELECT * FROM hocvien";
            SqlCommand cmd = new SqlCommand(sqlSELECT, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocvien.DataSource = dt;

        }

        private void txttkdotnhaphoc_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocvien where dotnhaphoc like N'%" + txttkdotnhaphoc.Text + "%' SELECT COUNT (mahocvien) FROM hocvien where dotnhaphoc = @dotnhaphoc ";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.Parameters.AddWithValue("dotnhaphoc", txttkdotnhaphoc.Text);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocvien.DataSource = dt;
            if (dr.Read())
            {
                lbthongke.Text = (dr.GetValue(0).ToString());
            }
        }

        private void cbbtkgioitinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocvien where gioitinh like N'%" + cbbtkgioitinh.Text + "%' SELECT COUNT (mahocvien) FROM hocvien where  gioitinh = @gioitinh ";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.Parameters.AddWithValue("gioitinh", cbbtkgioitinh.Text);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocvien.DataSource = dt;
            if (dr.Read())
            {
                lbthongke.Text = (dr.GetValue(0).ToString());
            }
        }


        private void txttkmonhoc_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocvien where tenmonhoc like N'%" + cbbtenmonhoc.Text + "%' SELECT COUNT (mahocvien) FROM hocvien where tenmonhoc = @tenmonhoc ";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.Parameters.AddWithValue("tenmonhoc", cbbtenmonhoc.Text);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocvien.DataSource = dt;
            if (dr.Read())
            {
                lbthongke.Text = (dr.GetValue(0).ToString());
            }
        }

        private void cbbtenlophoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocvien where tenlophoc like N'%" + cbbtenlophoc.Text + "%' SELECT COUNT (mahocvien) FROM hocvien where tenlophoc = @tenlophoc ";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.Parameters.AddWithValue("tenlophoc", cbbtenlophoc.Text);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocvien.DataSource = dt;
            if (dr.Read())
            {
                lbthongke.Text = (dr.GetValue(0).ToString());
            }
        }

        private void cbbtenmonhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocvien where tenmonhoc like N'%" + cbbtenmonhoc.Text + "%' SELECT COUNT (mahocvien) FROM hocvien where tenmonhoc = @tenmonhoc ";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.Parameters.AddWithValue("tenmonhoc", cbbtenmonhoc.Text);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocvien.DataSource = dt;
            if (dr.Read())
            {
                lbthongke.Text = (dr.GetValue(0).ToString());
            }
        }

        private void txttkquequan_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocvien where quequan like N'%" + txttkquequan.Text + "%' SELECT COUNT (mahocvien) FROM hocvien where quequan = @quequan ";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.Parameters.AddWithValue("quequan", txttkquequan.Text);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocvien.DataSource = dt;
            if (dr.Read())
            {
                lbthongke.Text = (dr.GetValue(0).ToString());
            }
        }

        //Menu

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            taikhoan dlg2 = new taikhoan();
            dlg2.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thốngKêHọcViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            tkhocvien dlg2 = new tkhocvien();
            dlg2.ShowDialog();
        }

        private void tToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotro dlg2 = new hotro();
            dlg2.ShowDialog();
        }

        private void btnlophoc_Click(object sender, EventArgs e)
        {
            this.Hide();
            lophoc dlg2 = new lophoc();
            dlg2.ShowDialog();
        }

        private void btnmonhoc_Click(object sender, EventArgs e)
        {
            this.Hide();
            monhoc dlg2 = new monhoc();
            dlg2.ShowDialog();
        }

        private void btnhocvien_Click(object sender, EventArgs e)
        {
            this.Hide();
            hocvien dlg2 = new hocvien();
            dlg2.ShowDialog();
        }

        private void btngiaovien_Click(object sender, EventArgs e)
        {
            this.Hide();
            giaovien dlg2 = new giaovien();
            dlg2.ShowDialog();
        }

        private void btndiemkt_Click(object sender, EventArgs e)
        {
            this.Hide();
            diemkt dlg2 = new diemkt();
            dlg2.ShowDialog();
        }

        private void btntaichinh_Click(object sender, EventArgs e)
        {
            this.Hide();
            taichinh dlg2 = new taichinh();
            dlg2.ShowDialog();
        }


    }
}
