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
    public partial class giaovien : Form
    {
        public giaovien()
        {
            InitializeComponent();
        }

        //Code

        SqlConnection con;

        private void giaovien_Load(object sender, EventArgs e)
        {
            string ketnoi = ConfigurationManager.ConnectionStrings["QuanlyTTNN"].ConnectionString.ToString();
            con = new SqlConnection(ketnoi);
            con.Open();
            hienthi();
        }

        private void giaovien_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        public void hienthi()
        {
            string sqlSELECT = "SELECT * FROM giaovien";
            SqlCommand cmd = new SqlCommand(sqlSELECT, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvgiaovien.DataSource = dt;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string sqlINSET = "INSERT INTO giaovien VALUES(@magiaovien, @tengiaovien, @gioitinh, @ngaysinh, @quequan, @ngaybatdaulam, @lienhe, @chuyennganh)";
            SqlCommand cmd = new SqlCommand(sqlINSET, con);
            cmd.Parameters.AddWithValue("magiaovien", txtmagiaovien.Text);
            cmd.Parameters.AddWithValue("tengiaovien", txttengiaovien.Text);
            cmd.Parameters.AddWithValue("gioitinh", cbbgioitinh.Text);
            cmd.Parameters.AddWithValue("ngaysinh", txtngaysinh.Text);
            cmd.Parameters.AddWithValue("quequan", txtquequan.Text);
            cmd.Parameters.AddWithValue("ngaybatdaulam", txtngaybatdaulam.Text);
            cmd.Parameters.AddWithValue("lienhe", txtlienhe.Text);
            cmd.Parameters.AddWithValue("chuyennganh", txtchuyennganh.Text);
            cmd.ExecuteNonQuery();
            hienthi();
            MessageBox.Show("Thêm thành công");
            txtmagiaovien.Clear();
            txttengiaovien.Clear();
            cbbgioitinh.SelectedIndex = -1;
            txtngaysinh.Clear();
            txtquequan.Clear();
            txtngaybatdaulam.Clear();
            txtlienhe.Clear();
            txtchuyennganh.Clear();
            
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa", "Thông báo" , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string sqlEDIT = "UPDATE giaovien SET tengiaovien = @tengiaovien, gioitinh = @gioitinh, ngaysinh = @ngaysinh, quequan = @quequan, ngaybatdaulam = @ngaybatdaulam, lienhe = @lienhe, chuyennganh = @chuyennganh where magiaovien = @magiaovien";
                SqlCommand cmd = new SqlCommand(sqlEDIT, con);
                cmd.Parameters.AddWithValue("magiaovien", txtmagiaovien.Text);
                cmd.Parameters.AddWithValue("tengiaovien", txttengiaovien.Text);
                cmd.Parameters.AddWithValue("gioitinh", cbbgioitinh.Text);
                cmd.Parameters.AddWithValue("ngaysinh", txtngaysinh.Text);
                cmd.Parameters.AddWithValue("quequan", txtquequan.Text);
                cmd.Parameters.AddWithValue("ngaybatdaulam", txtngaybatdaulam.Text);
                cmd.Parameters.AddWithValue("lienhe", txtlienhe.Text);
                cmd.Parameters.AddWithValue("chuyennganh", txtchuyennganh.Text);
                cmd.ExecuteNonQuery();
                hienthi();
                MessageBox.Show("Sửa thành công");
                txtmagiaovien.Clear();
                txttengiaovien.Clear();
                cbbgioitinh.SelectedIndex = -1;
                txtngaysinh.Clear();
                txtquequan.Clear();
                txtngaybatdaulam.Clear();
                txtlienhe.Clear();
                txtchuyennganh.Clear();
                txttkmagiaovien.Clear();
                txttktengiaovien.Clear();
                cbbtkgioitinh.SelectedIndex = -1;
                txttkngaysinh.Clear();
                txttkquequan.Clear();
                txttkngaybatdaulam.Clear();
                txttklienhe.Clear();
                txttkchuyennganh.Clear();
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
                string sqlDEL = "DELETE FROM giaovien WHERE magiaovien = @magiaovien";
                SqlCommand cmd = new SqlCommand(sqlDEL, con);
                cmd.Parameters.AddWithValue("magiaovien", txtmagiaovien.Text);
                cmd.Parameters.AddWithValue("tengiaovien", txttengiaovien.Text);
                cmd.Parameters.AddWithValue("gioitinh", cbbgioitinh.Text);
                cmd.Parameters.AddWithValue("ngaysinh", txtngaysinh.Text);
                cmd.Parameters.AddWithValue("quequan", txtquequan.Text);
                cmd.Parameters.AddWithValue("ngaybatdaulam", txtngaybatdaulam.Text);
                cmd.Parameters.AddWithValue("lienhe", txtlienhe.Text);
                cmd.Parameters.AddWithValue("chuyennganh", txtchuyennganh.Text);
                cmd.ExecuteNonQuery();
                hienthi();
                MessageBox.Show("Sửa thành công");
                txtmagiaovien.Clear();
                txttengiaovien.Clear();
                cbbgioitinh.SelectedIndex = -1;
                txtngaysinh.Clear();
                txtquequan.Clear();
                txtngaybatdaulam.Clear();
                txtlienhe.Clear();
                txtchuyennganh.Clear();
                txttkmagiaovien.Clear();
                txttktengiaovien.Clear();
                cbbtkgioitinh.SelectedIndex = -1;
                txttkngaysinh.Clear();
                txttkquequan.Clear();
                txttkngaybatdaulam.Clear();
                txttklienhe.Clear();
                txttkchuyennganh.Clear();
            }
            else
            {
            }
          
        }

        //Click

        private void dtgvgiaovien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmagiaovien.Text = dtgvgiaovien.CurrentRow.Cells[0].Value.ToString();
            txttengiaovien.Text = dtgvgiaovien.CurrentRow.Cells[1].Value.ToString();
            cbbgioitinh.Text = dtgvgiaovien.CurrentRow.Cells[2].Value.ToString();
            txtngaysinh.Text = dtgvgiaovien.CurrentRow.Cells[3].Value.ToString();
            txtquequan.Text = dtgvgiaovien.CurrentRow.Cells[4].Value.ToString();
            txtngaybatdaulam.Text = dtgvgiaovien.CurrentRow.Cells[5].Value.ToString();
            txtlienhe.Text = dtgvgiaovien.CurrentRow.Cells[6].Value.ToString();
            txtchuyennganh.Text = dtgvgiaovien.CurrentRow.Cells[7].Value.ToString();

        }

        private void dtgvgiaovien_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmagiaovien.Text = dtgvgiaovien.CurrentRow.Cells[0].Value.ToString();
            txttengiaovien.Text = dtgvgiaovien.CurrentRow.Cells[1].Value.ToString();
            cbbgioitinh.Text = dtgvgiaovien.CurrentRow.Cells[2].Value.ToString();
            txtngaysinh.Text = dtgvgiaovien.CurrentRow.Cells[3].Value.ToString();
            txtquequan.Text = dtgvgiaovien.CurrentRow.Cells[4].Value.ToString();
            txtngaybatdaulam.Text = dtgvgiaovien.CurrentRow.Cells[5].Value.ToString();
            txtlienhe.Text = dtgvgiaovien.CurrentRow.Cells[6].Value.ToString();
            txtchuyennganh.Text = dtgvgiaovien.CurrentRow.Cells[7].Value.ToString();
        }

        //Timkiem

        private void txttkmagiaovien_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  giaovien where magiaovien like N'%" + txttkmagiaovien.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvgiaovien.DataSource = dt;
        }

        private void txttktengiaovien_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  giaovien where tengiaovien like N'%" + txttktengiaovien.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvgiaovien.DataSource = dt;
        }

        private void cbbtkgioitinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  giaovien where gioitinh like N'%" + cbbtkgioitinh.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvgiaovien.DataSource = dt;
        }

        private void txttkngaysinh_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  giaovien where ngaysinh like N'%" + txttkngaysinh.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvgiaovien.DataSource = dt;
        }

        private void txttkquequan_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  giaovien where quequan like N'%" + txttkquequan.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvgiaovien.DataSource = dt;
        }

        private void txttklienhe_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  giaovien where lienhe like N'%" + txttklienhe.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvgiaovien.DataSource = dt;
        }

        private void txttkchuyennganh_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  giaovien where chuyennganh like N'%" + txttkchuyennganh.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvgiaovien.DataSource = dt;
        }

        private void txttkngaybatdaulam_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  giaovien where ngaybatdaulam like N'%" + txttkngaybatdaulam.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvgiaovien.DataSource = dt;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            lophoc dlg2 = new lophoc();
            dlg2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            monhoc dlg2 = new monhoc();
            dlg2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            hocvien dlg2 = new hocvien();
            dlg2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            giaovien dlg2 = new giaovien();
            dlg2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            diemkt dlg2 = new diemkt();
            dlg2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            taichinh dlg2 = new taichinh();
            dlg2.ShowDialog();
        }

    }

}
