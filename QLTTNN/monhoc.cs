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
    public partial class monhoc : Form
    {
        public monhoc()
        {
            InitializeComponent();
        }

        //Code

        SqlConnection con;

        private void monhoc_Load(object sender, EventArgs e)
        {
            string ketnoi = ConfigurationManager.ConnectionStrings["QuanlyTTNN"].ConnectionString.ToString();
            con = new SqlConnection(ketnoi);
            con.Open();
            hienthi();
        }

        private void monhoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        public void hienthi()
        {
            string sqlSELECT = "SELECT * FROM monhoc";
            SqlCommand cmd = new SqlCommand(sqlSELECT, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvmonhoc.DataSource = dt;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string sqlINSET = "INSERT INTO monhoc VALUES(@mamonhoc, @tenmonhoc)";
            SqlCommand cmd = new SqlCommand(sqlINSET, con);
            cmd.Parameters.AddWithValue("mamonhoc", txtmamonhoc.Text);
            cmd.Parameters.AddWithValue("tenmonhoc", txttenmonhoc.Text);
            cmd.ExecuteNonQuery();
            hienthi();
            MessageBox.Show("Thêm thành công");
            txtmamonhoc.Clear();
            txttenmonhoc.Clear();
            txttkmamonhoc.Clear();
            txttktenmonhoc.Clear();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {

             DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa", "Thông báo" , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

             if (result == System.Windows.Forms.DialogResult.Yes)
             {
                 string sqlEDIT = "UPDATE monhoc SET tenmonhoc = @tenmonhoc WHERE mamonhoc = @mamonhoc";
                 SqlCommand cmd = new SqlCommand(sqlEDIT, con);
                 cmd.Parameters.AddWithValue("mamonhoc", txtmamonhoc.Text);
                 cmd.Parameters.AddWithValue("tenmonhoc", txttenmonhoc.Text);
                 cmd.ExecuteNonQuery();
                 hienthi();
                 MessageBox.Show("Sửa thành công");
                 txtmamonhoc.Clear();
                 txttenmonhoc.Clear();
                 txttkmamonhoc.Clear();
                 txttktenmonhoc.Clear();
             }

             else
             { 
             }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string sqlDEL = "DELETE FROM monhoc WHERE mamonhoc = @mamonhoc";
                SqlCommand cmd = new SqlCommand(sqlDEL, con);
                cmd.Parameters.AddWithValue("mamonhoc", txtmamonhoc.Text);
                cmd.Parameters.AddWithValue("tenmonhoc", txttenmonhoc.Text);
                cmd.ExecuteNonQuery();
                hienthi();
                MessageBox.Show("Xóa thành công");
                txtmamonhoc.Clear();
                txttenmonhoc.Clear();
                txttkmamonhoc.Clear();
                txttktenmonhoc.Clear();
            }
            else
            {
            }
        }


        //Click
        
        private void dtgvmonhoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmamonhoc.Text = dtgvmonhoc.CurrentRow.Cells[0].Value.ToString();
            txttenmonhoc.Text = dtgvmonhoc.CurrentRow.Cells[1].Value.ToString();
        }

        private void dtgvmonhoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmamonhoc.Text = dtgvmonhoc.CurrentRow.Cells[0].Value.ToString();
            txttenmonhoc.Text = dtgvmonhoc.CurrentRow.Cells[1].Value.ToString();
        }

        //Tim kiem

        private void txttkmamonhoc_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  monhoc where mamonhoc like N'%" + txttkmamonhoc.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvmonhoc.DataSource = dt;
        }

        private void txttktenmonhoc_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  monhoc where tenmonhoc like N'%" + txttktenmonhoc.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvmonhoc.DataSource = dt;
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
