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
    public partial class hocphi : Form
    {
        public hocphi()
        {
            InitializeComponent();
        }

        //Code

        SqlConnection con;

        private void hocphi_Load(object sender, EventArgs e)
        {
            string ketnoi = ConfigurationManager.ConnectionStrings["QuanlyTTNN"].ConnectionString.ToString();
            con = new SqlConnection(ketnoi);
            con.Open();
            hienthi();
            hienthi1();
        }

        private void hocphi_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        public void hienthi()
        {
            string sqlSELECT = "SELECT * FROM hocphi";
            SqlCommand cmd = new SqlCommand(sqlSELECT, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocphi.DataSource = dt;

        }
        public void hienthi1()
        {
            string sqlSELECT = "SELECT SUM (sotien) FROM hocphi";
            SqlCommand cmd = new SqlCommand(sqlSELECT, con);
            SqlDataReader drs = cmd.ExecuteReader();
            if (drs.Read())
            {
                lbtktongsohocphi.Text = (drs.GetValue(0).ToString());
            }

        }



        private void btnthem_Click(object sender, EventArgs e)
        {
            string sqlINSET = "INSERT INTO hocphi VALUES(@mahocvien, @tenhocvien, @gioitinh, @ngaysinh ,@dotnop, @ngaynop, @sotien, @nguoithu)";
            SqlCommand cmd = new SqlCommand(sqlINSET, con);
            cmd.Parameters.AddWithValue("mahocvien", dtgvhocphi.CurrentRow.Cells[0].Value.ToString());
            cmd.Parameters.AddWithValue("tenhocvien", dtgvhocphi.CurrentRow.Cells[1].Value.ToString());
            cmd.Parameters.AddWithValue("gioitinh", dtgvhocphi.CurrentRow.Cells[2].Value.ToString());
            cmd.Parameters.AddWithValue("ngaysinh", dtgvhocphi.CurrentRow.Cells[3].Value.ToString());
            cmd.Parameters.AddWithValue("dotnop", dtgvhocphi.CurrentRow.Cells[4].Value.ToString());
            cmd.Parameters.AddWithValue("ngaynop", dtgvhocphi.CurrentRow.Cells[5].Value.ToString());
            cmd.Parameters.AddWithValue("sotien", dtgvhocphi.CurrentRow.Cells[6].Value.ToString());
            cmd.Parameters.AddWithValue("nguoithu", dtgvhocphi.CurrentRow.Cells[7].Value.ToString());
            cmd.ExecuteNonQuery();
            hienthi();
            MessageBox.Show("Thêm thành công");
            txtmahocvien.Clear();
            txttenhocvien.Clear();
            cbbgioitinh.SelectedIndex = -1;
            txtngaysinh.Clear();
            txtngaynop.Clear();
            txtnguoithu.Clear();
        }

        private void btnchinhsua_Click(object sender, EventArgs e)
        {
            string sqlEDIT = "UPDATE hocphi SET tenhocvien = @tenhocvien, gioitinh = @gioitinh, ngaysinh = @ngaysinh, dotnop = @dotnop, ngaynop = @ngaynop, sotien = @sotien, nguoithu = @nguoithu  WHERE mahocvien = @mahocvien";
            SqlCommand cmd = new SqlCommand(sqlEDIT, con);
            cmd.Parameters.AddWithValue("mahocvien", dtgvhocphi.CurrentRow.Cells[0].Value.ToString());
            cmd.Parameters.AddWithValue("tenhocvien", dtgvhocphi.CurrentRow.Cells[1].Value.ToString());
            cmd.Parameters.AddWithValue("gioitinh", dtgvhocphi.CurrentRow.Cells[2].Value.ToString());
            cmd.Parameters.AddWithValue("ngaysinh", dtgvhocphi.CurrentRow.Cells[3].Value.ToString());
            cmd.Parameters.AddWithValue("dotnop", dtgvhocphi.CurrentRow.Cells[4].Value.ToString());
            cmd.Parameters.AddWithValue("ngaynop", dtgvhocphi.CurrentRow.Cells[5].Value.ToString());
            cmd.Parameters.AddWithValue("sotien", dtgvhocphi.CurrentRow.Cells[6].Value.ToString());
            cmd.Parameters.AddWithValue("nguoithu", dtgvhocphi.CurrentRow.Cells[7].Value.ToString());
            cmd.ExecuteNonQuery();
            hienthi();
            txtmahocvien.Clear();
            txttenhocvien.Clear();
            cbbgioitinh.SelectedIndex = -1;
            txtngaysinh.Clear();
            txtngaynop.Clear();
            txtnguoithu.Clear();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                string sqlDEL = "DELETE FROM hocphi WHERE mahocvien = @mahocvien";
                SqlCommand cmd = new SqlCommand(sqlDEL, con);
                cmd.Parameters.AddWithValue("mahocvien", dtgvhocphi.CurrentRow.Cells[0].Value.ToString());
                cmd.Parameters.AddWithValue("tenhocvien", dtgvhocphi.CurrentRow.Cells[1].Value.ToString());
                cmd.Parameters.AddWithValue("gioitinh", dtgvhocphi.CurrentRow.Cells[2].Value.ToString());
                cmd.Parameters.AddWithValue("ngaysinh", dtgvhocphi.CurrentRow.Cells[3].Value.ToString());
                cmd.Parameters.AddWithValue("dotnop", dtgvhocphi.CurrentRow.Cells[4].Value.ToString());
                cmd.Parameters.AddWithValue("ngaynop", dtgvhocphi.CurrentRow.Cells[5].Value.ToString());
                cmd.Parameters.AddWithValue("sotien", dtgvhocphi.CurrentRow.Cells[6].Value.ToString());
                cmd.Parameters.AddWithValue("nguoithu", dtgvhocphi.CurrentRow.Cells[7].Value.ToString());
                cmd.ExecuteNonQuery();
                hienthi();
                MessageBox.Show("Xóa thành công");
                txtmahocvien.Clear();
                txttenhocvien.Clear();
                cbbgioitinh.SelectedIndex = -1;
                txtngaysinh.Clear();
                txtngaynop.Clear();
                txtnguoithu.Clear();
            }
            else
            {
            }
        }

        //Timkiem

        private void cbbdotnop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocphi where dotnop like N'%" + cbbdotnop.Text + "%' SELECT SUM (sotien) FROM hocphi where dotnop = @dotnop";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.Parameters.AddWithValue("dotnop", cbbdotnop.Text);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocphi.DataSource = dt;
            if (dr.Read())
            {
                lbtkdotnop.Text = (dr.GetValue(0).ToString());
            }

        }

        private void txtmahocvien_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocphi where mahocvien like N'%" + txtmahocvien.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocphi.DataSource = dt;
        }

        private void txttenhocvien_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocphi where tenhocvien like N'%" + txttenhocvien.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocphi.DataSource = dt;
        }

        private void cbbgioitinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocphi where gioitinh like N'%" + cbbgioitinh.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocphi.DataSource = dt;
        }

        private void txtngaysinh_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocphi where ngaysinh like N'%" + txtngaysinh.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocphi.DataSource = dt;
        }

        private void txtngaynop_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocphi where ngaynop like N'%" + txtngaynop.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocphi.DataSource = dt;
        }

        private void txtnguoithu_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocphi where nguoithu like N'%" + txtnguoithu.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocphi.DataSource = dt;
        }

        //Thongke

        private void btnthongke_Click(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT SUM (sotien) FROM hocphi where mahocvien = @mahocvien or tenhocvien = @tenhocvien or gioitinh = @gioitinh or ngaysinh = @ngaysinh or ngaynop = @ngaynop or nguoithu = @nguoithu";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.Parameters.AddWithValue("mahocvien", txtmahocvien.Text);
            cmd.Parameters.AddWithValue("tenhocvien", txttenhocvien.Text);
            cmd.Parameters.AddWithValue("gioitinh", cbbgioitinh.Text);
            cmd.Parameters.AddWithValue("ngaysinh", txtngaysinh.Text);
            cmd.Parameters.AddWithValue("ngaynop", txtngaynop.Text);
            cmd.Parameters.AddWithValue("nguoithu", txtnguoithu.Text);
            SqlDataReader drs = cmd.ExecuteReader();
            if (drs.Read())
            {
                lbthongke.Text = (drs.GetValue(0).ToString());
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

        private void llnopluong_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
        
        
    }
}
