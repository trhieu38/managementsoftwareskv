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
    public partial class diemkt : Form
    {
        public diemkt()
        {
            InitializeComponent();
        }

        //Code

        SqlConnection con;

        private void diemkt_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTTNNDataSet1.lophoc' table. You can move, or remove it, as needed.
            this.lophocTableAdapter.Fill(this.qLTTNNDataSet1.lophoc);
            
            string ketnoi = ConfigurationManager.ConnectionStrings["QuanlyTTNN"].ConnectionString.ToString();
            con = new SqlConnection(ketnoi);
            con.Open();
            hienthi();
        }

        private void diemkt_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        public void hienthi()
        {
            string sqlSELECT = "SELECT * FROM diemkt";
            SqlCommand cmd = new SqlCommand(sqlSELECT, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvdiemkt.DataSource = dt;
            
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string sqlINSET = "INSERT INTO diemkt VALUES(@mahocvien, @tenhocvien, @dotthi,@tenmonhoc, @tenlophoc, @diemkt)";
            SqlCommand cmd = new SqlCommand(sqlINSET, con);
            cmd.Parameters.AddWithValue("mahocvien", dtgvdiemkt.CurrentRow.Cells[0].Value.ToString());
            cmd.Parameters.AddWithValue("tenhocvien", dtgvdiemkt.CurrentRow.Cells[1].Value.ToString());
            cmd.Parameters.AddWithValue("dotthi", dtgvdiemkt.CurrentRow.Cells[2].Value.ToString());
            cmd.Parameters.AddWithValue("tenlophoc", dtgvdiemkt.CurrentRow.Cells[3].Value.ToString());
            cmd.Parameters.AddWithValue("diemkt", dtgvdiemkt.CurrentRow.Cells[4].Value.ToString());
            cmd.ExecuteNonQuery();
            hienthi();
            MessageBox.Show("Thêm thành công");
            txtmahocvien.Clear();
            txtdiemkt.Clear();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
                string sqlEDIT = "UPDATE diemkt SET tenhocvien = @tenhocvien, dotthi = @dotthi, tenlophoc = @tenlophoc, diemkt = @diemkt  WHERE mahocvien = @mahocvien";
                SqlCommand cmd = new SqlCommand(sqlEDIT, con);
                    cmd.Parameters.AddWithValue("mahocvien", dtgvdiemkt.CurrentRow.Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("tenhocvien", dtgvdiemkt.CurrentRow.Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("dotthi", dtgvdiemkt.CurrentRow.Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("tenlophoc", dtgvdiemkt.CurrentRow.Cells[3].Value.ToString());
                    cmd.Parameters.AddWithValue("diemkt", dtgvdiemkt.CurrentRow.Cells[4].Value.ToString());
                    cmd.ExecuteNonQuery();
                    hienthi();
                    txtmahocvien.Clear();
                    txtdiemkt.Clear();
        }


        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa !", "Thông báo" , MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                string sqlDEL = "DELETE FROM diemkt WHERE mahocvien = @mahocvien";
                SqlCommand cmd = new SqlCommand(sqlDEL, con);
                cmd.Parameters.AddWithValue("mahocvien", dtgvdiemkt.CurrentRow.Cells[0].Value.ToString());
                cmd.Parameters.AddWithValue("tenhocvien", dtgvdiemkt.CurrentRow.Cells[1].Value.ToString());
                cmd.Parameters.AddWithValue("dotthi", dtgvdiemkt.CurrentRow.Cells[2].Value.ToString());
                cmd.Parameters.AddWithValue("tenlophoc", dtgvdiemkt.CurrentRow.Cells[3].Value.ToString());
                cmd.Parameters.AddWithValue("diemkt", dtgvdiemkt.CurrentRow.Cells[4].Value.ToString());
                cmd.ExecuteNonQuery();
                hienthi();
                MessageBox.Show("Xóa thành công");
                txtmahocvien.Clear();
                txtdiemkt.Clear();

            }
            else
            { 
            }

        }

        //Cap nhat danh sach sinh vien

        private void btncndshv_Click(object sender, EventArgs e)
        {
            string sqlINSET = "INSERT INTO diemkt  (mahocvien, tenhocvien, tenlophoc) select mahocvien, tenhocvien, tenlophoc from hocvien where tenlophoc = @tenlophoc UPDATE diemkt SET dotthi = @dotthi where dotthi is null";
            SqlCommand cmd = new SqlCommand(sqlINSET, con);
            cmd.Parameters.AddWithValue("dotthi", cbbcndotkt.Text);
            cmd.Parameters.AddWithValue("tenlophoc", cbbcntenlophoc.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Cập nhật thành công");
        }

        //Tim kiem
        private void cbbcntenlophoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  diemkt where tenlophoc like N'%" + cbbcntenlophoc.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvdiemkt.DataSource = dt;
        }

        private void cbbcndotkt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  diemkt where dotthi like N'%" + cbbcndotkt.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvdiemkt.DataSource = dt;
        }

        private void txtmahocvien_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  diemkt where mahocvien like N'%" + txtmahocvien.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvdiemkt.DataSource = dt;
        }


        private void txtdiemkt_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  diemkt where diemkt like N'%" + txtdiemkt.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvdiemkt.DataSource = dt;
        }

        //In ra Excel
        private void btnexcel_Click(object sender, EventArgs e)
        {
            {
                for (int i = 1; i <= 10; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)dtgvdiemkt.RowTemplate.Clone();
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

                for (int i = 0; i < dtgvdiemkt.Rows.Count - 1; i++, cellRowIndex++)
                {
                    cellColumnIndex = 1;

                    for (int j = 0; j < dtgvdiemkt.Columns.Count - 1; j++, cellColumnIndex++)
                    {
                        worksheet.Cells[cellRowIndex, cellColumnIndex] = dtgvdiemkt.Rows[i].Cells[j].Value.ToString();
                    }
                }

                cellColumnIndex = 1;

                for (int j = 0; j < dtgvdiemkt.Columns.Count - 1; j++, cellColumnIndex++)
                {
                    worksheet.Cells[1, cellColumnIndex] = dtgvdiemkt.Columns[j].HeaderText;
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

        private void thốngKêHọcViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            tkhocvien dlg2 = new tkhocvien();
            dlg2.ShowDialog();
        }

      
    }
}
