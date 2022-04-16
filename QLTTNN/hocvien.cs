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
using Excel = Microsoft.Office.Interop.Excel;

namespace QLTTNN
{
    public partial class hocvien : Form
    {
        public hocvien()
        {
            InitializeComponent();
        }

        // Code

        SqlConnection con;

        private void hocvien_Load(object sender, EventArgs e)
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

        private void hocvien_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnthem_Click(object sender, EventArgs e)
        {
            string sqlINSET = "INSERT INTO hocvien VALUES(@mahocvien, @tenhocvien, @gioitinh, @ngaysinh, @quequan, @tenphuhuynh, @lienhe, @dotnhaphoc, @tenlophoc, @tenmonhoc)";
            SqlCommand cmd = new SqlCommand(sqlINSET, con);
            cmd.Parameters.AddWithValue("mahocvien", txtmahocvien.Text);
            cmd.Parameters.AddWithValue("tenhocvien", txttenhocvien.Text);
            cmd.Parameters.AddWithValue("gioitinh", cbbgioitinh.Text);
            cmd.Parameters.AddWithValue("ngaysinh", txtngaysinh.Text);
            cmd.Parameters.AddWithValue("quequan", txtquequan.Text);
            cmd.Parameters.AddWithValue("tenphuhuynh", txttenphuhuynh.Text);
            cmd.Parameters.AddWithValue("lienhe", txtlienhe.Text);
            cmd.Parameters.AddWithValue("dotnhaphoc", txtdotnhaphoc.Text);
            cmd.Parameters.AddWithValue("tenlophoc", cbbtenlophoc.Text);
            cmd.Parameters.AddWithValue("tenmonhoc", cbbtenmonhoc.Text);
            cmd.ExecuteNonQuery();
            hienthi();
            MessageBox.Show("Thêm thành công");
            txtmahocvien.Clear();
            txttenhocvien.Clear();
            cbbgioitinh.SelectedIndex = -1;
            txtngaysinh.Clear();
            txtquequan.Clear();
            txttenphuhuynh.Clear();
            txtlienhe.Clear();
            txttkdotnhaphoc.Clear();
            txttkmonhoc.Clear();
            txttklophoc.Clear();
        }


        private void btnsua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa", "Thông báo" , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

             if (result == System.Windows.Forms.DialogResult.Yes)
        {
            string sqlEDIT = "UPDATE hocvien SET tenhocvien = @tenhocvien, gioitinh = @gioitinh, ngaysinh = @ngaysinh, quequan = @quequan, tenphuhuynh = @tenphuhuynh, lienhe = @lienhe, dotnhaphoc = @dotnhaphoc, tenlophoc = @tenlophoc, tenmonhoc = @tenmonhoc WHERE mahocvien = @mahocvien";
            SqlCommand cmd = new SqlCommand(sqlEDIT, con);
            cmd.Parameters.AddWithValue("mahocvien", txtmahocvien.Text);
            cmd.Parameters.AddWithValue("tenhocvien", txttenhocvien.Text);
            cmd.Parameters.AddWithValue("gioitinh", cbbgioitinh.Text);
            cmd.Parameters.AddWithValue("ngaysinh", txtngaysinh.Text);
            cmd.Parameters.AddWithValue("quequan", txtquequan.Text);
            cmd.Parameters.AddWithValue("tenphuhuynh", txttenphuhuynh.Text);
            cmd.Parameters.AddWithValue("lienhe", txtlienhe.Text);
            cmd.Parameters.AddWithValue("dotnhaphoc", txtdotnhaphoc.Text);
            cmd.Parameters.AddWithValue("tenlophoc", cbbtenlophoc.Text);
            cmd.Parameters.AddWithValue("tenmonhoc", cbbtenmonhoc.Text);
            cmd.ExecuteNonQuery();
            hienthi();
            MessageBox.Show("Sửa thành công");
            txtmahocvien.Clear();
            txttenhocvien.Clear();
            cbbgioitinh.SelectedIndex = -1;
            txtngaysinh.Clear();
            txtquequan.Clear();
            txttenphuhuynh.Clear();
            txtlienhe.Clear();
            txtdotnhaphoc.Clear();
            cbbtenlophoc.SelectedIndex = -1;
            cbbtenmonhoc.SelectedIndex = -1;
            txttkmahocvien.Clear();
            txttktenhocvien.Clear();
            cbbtkgioitinh.SelectedIndex = -1;
            txttkngaysinh.Clear();
            txttkquequan.Clear();
            txttktenphuhuynh.Clear();
            txttklienhe.Clear();
            txttkdotnhaphoc.Clear();
            txttkmonhoc.Clear();
            txttklophoc.Clear();
            
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
                string sqlDEL = "DELETE FROM hocvien WHERE mahocvien = @mahocvien";
                SqlCommand cmd = new SqlCommand(sqlDEL, con);
                cmd.Parameters.AddWithValue("mahocvien", txtmahocvien.Text);
                cmd.Parameters.AddWithValue("tenhocvien", txttenhocvien.Text);
                cmd.Parameters.AddWithValue("gioitinh", cbbgioitinh.Text);
                cmd.Parameters.AddWithValue("ngaysinh", txtngaysinh.Text);
                cmd.Parameters.AddWithValue("quequan", txtquequan.Text);
                cmd.Parameters.AddWithValue("tenphuhuynh", txttenphuhuynh.Text);
                cmd.Parameters.AddWithValue("lienhe", txtlienhe.Text);
                cmd.Parameters.AddWithValue("dotnhaphoc", txtdotnhaphoc.Text);
                cmd.Parameters.AddWithValue("tenlophoc", cbbtenlophoc.Text);
                cmd.Parameters.AddWithValue("tenmonhoc", cbbtenmonhoc.Text);
                cmd.ExecuteNonQuery();
                hienthi();
                MessageBox.Show("Xóa thành công");
                txtmahocvien.Clear();
                txttenhocvien.Clear();
                cbbgioitinh.SelectedIndex = -1;
                txtngaysinh.Clear();
                txtquequan.Clear();
                txttenphuhuynh.Clear();
                txtlienhe.Clear();
                txtdotnhaphoc.Clear();
                cbbtenlophoc.SelectedIndex = -1;
                cbbtenmonhoc.SelectedIndex = -1;
                txttkmahocvien.Clear();
                txttktenhocvien.Clear();
                cbbtkgioitinh.SelectedIndex = -1;
                txttkngaysinh.Clear();
                txttkquequan.Clear();
                txttktenphuhuynh.Clear();
                txttklienhe.Clear();
                txttkdotnhaphoc.Clear();
                txttkmonhoc.Clear();
                
            }
            else
            {
            }
        }

        //Timkiem

        private void txttkmahocvien_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocvien where mahocvien like N'%" + txttkmahocvien.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocvien.DataSource = dt;
        }

        private void txttktenhocvien_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocvien where tenhocvien like N'%" + txttktenhocvien.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocvien.DataSource = dt;
        }

        private void cbbtkgioitinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocvien where gioitinh like N'%" + cbbtkgioitinh.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocvien.DataSource = dt;
        }

        private void txttkngaysinh_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocvien where ngaysinh like N'%" + txttkngaysinh.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocvien.DataSource = dt;
        }

        private void txttkquequan_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocvien where quequan like N'%" + txttkquequan.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocvien.DataSource = dt;
        }


        private void txttktenphuhuynh_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocvien where tenphuhuynh like N'%" + txttktenphuhuynh.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocvien.DataSource = dt;
        }

        private void txttkdotnhaphoc_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocvien where dotnhaphoc like N'%" + txttkdotnhaphoc.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocvien.DataSource = dt;
        }

        private void txttklienhe_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocvien where lienhe like N'%" + txttklienhe.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocvien.DataSource = dt;
        }

        private void txttklophoc_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocvien where tenlophoc like N'%" + txttklophoc.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocvien.DataSource = dt;
        }
        private void txttkmonhoc_TextChanged(object sender, EventArgs e)
        {

            string sqlTIMKIEM = "SELECT * FROM  hocvien where tenmonhoc like N'%" + txttkmonhoc.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocvien.DataSource = dt;

        }

       

        // Click

        private void dtgvhocvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmahocvien.Text = dtgvhocvien.CurrentRow.Cells[0].Value.ToString();
            txttenhocvien.Text = dtgvhocvien.CurrentRow.Cells[1].Value.ToString();
            cbbgioitinh.Text = dtgvhocvien.CurrentRow.Cells[2].Value.ToString();
            txtngaysinh.Text = dtgvhocvien.CurrentRow.Cells[3].Value.ToString();
            txtquequan.Text = dtgvhocvien.CurrentRow.Cells[4].Value.ToString();
            txttenphuhuynh.Text = dtgvhocvien.CurrentRow.Cells[5].Value.ToString();
            txtlienhe.Text = dtgvhocvien.CurrentRow.Cells[6].Value.ToString();
            txtdotnhaphoc.Text = dtgvhocvien.CurrentRow.Cells[7].Value.ToString();
            cbbtenlophoc.Text = dtgvhocvien.CurrentRow.Cells[8].Value.ToString();
            cbbtenmonhoc.Text = dtgvhocvien.CurrentRow.Cells[9].Value.ToString();
        }

        private void dtgvhocvien_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmahocvien.Text = dtgvhocvien.CurrentRow.Cells[0].Value.ToString();
            txttenhocvien.Text = dtgvhocvien.CurrentRow.Cells[1].Value.ToString();
            cbbgioitinh.Text = dtgvhocvien.CurrentRow.Cells[2].Value.ToString();
            txtngaysinh.Text = dtgvhocvien.CurrentRow.Cells[3].Value.ToString();
            txtquequan.Text = dtgvhocvien.CurrentRow.Cells[4].Value.ToString();
            txttenphuhuynh.Text = dtgvhocvien.CurrentRow.Cells[5].Value.ToString();
            txtlienhe.Text = dtgvhocvien.CurrentRow.Cells[6].Value.ToString();
            txtdotnhaphoc.Text = dtgvhocvien.CurrentRow.Cells[7].Value.ToString();
            cbbtenlophoc.Text = dtgvhocvien.CurrentRow.Cells[8].Value.ToString();
            cbbtenmonhoc.Text = dtgvhocvien.CurrentRow.Cells[9].Value.ToString();
        }


        //Xuat file excel

        private void btnexcel_Click(object sender, EventArgs e)
        {
            {
              for (int i = 1; i <= 10; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)dtgvhocvien.RowTemplate.Clone();
                }
            }
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "ExportedFromDatGrid";
                int cellRowIndex = 2;
                int cellColumnIndex;

                for (int i = 0; i < dtgvhocvien.Rows.Count - 1; i++, cellRowIndex++)
                {
                    cellColumnIndex = 1;

                    for (int j = 0; j < dtgvhocvien.Columns.Count - 1; j++, cellColumnIndex++)
                    {
                        worksheet.Cells[cellRowIndex, cellColumnIndex] = dtgvhocvien.Rows[i].Cells[j].Value.ToString();
                    }
                }

                cellColumnIndex = 1;

                for (int j = 0; j < dtgvhocvien.Columns.Count - 1; j++, cellColumnIndex++)
                {
                    worksheet.Cells[1, cellColumnIndex] = dtgvhocvien.Columns[j].HeaderText;
                }
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("In thành công");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;

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
