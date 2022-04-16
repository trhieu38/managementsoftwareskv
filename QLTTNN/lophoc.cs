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
    public partial class lophoc : Form
    {
    
        
        public lophoc()
        {
            InitializeComponent();
        }

        //Code 

        SqlConnection con;


        private void lophoc_Load(object sender, EventArgs e)
        {
            string ketnoi = ConfigurationManager.ConnectionStrings["QuanlyTTNN"].ConnectionString.ToString();
            con = new SqlConnection(ketnoi);
            con.Open();
            hienthi();
        }

        private void lophoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        public void hienthi()
        {
            string sqlSELECT = "SELECT * FROM lophoc";
            SqlCommand cmd = new SqlCommand(sqlSELECT, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvlophoc.DataSource = dt;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string sqlINSET = "INSERT INTO lophoc VALUES(@malophoc, @tenlophoc, @ngayhoc, @siso, @tengiaovien)";
            SqlCommand cmd = new SqlCommand(sqlINSET, con);
            cmd.Parameters.AddWithValue("malophoc", txtmalophoc.Text);
            cmd.Parameters.AddWithValue("tenlophoc", txttenlophoc.Text);
            cmd.Parameters.AddWithValue("ngayhoc", txtngayhoc.Text);
            cmd.Parameters.AddWithValue("siso", txtsiso.Text);
            cmd.Parameters.AddWithValue("tengiaovien", txttengiaovien.Text);
            cmd.ExecuteNonQuery();
            hienthi();
            MessageBox.Show("Thêm thành công");
            txtmalophoc.Clear();
            txttenlophoc.Clear();
            txtngayhoc.Clear();
            txtsiso.Clear();
            txttengiaovien.Clear();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa", "Thông báo" , MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)

            {
                string sqlEDIT = "UPDATE lophoc SET tenlophoc = @tenlophoc, ngayhoc = @ngayhoc, siso = @siso, tengiaovien = @tengiaovien WHERE malophoc = @malophoc";
                SqlCommand cmd = new SqlCommand(sqlEDIT, con);
                cmd.Parameters.AddWithValue("malophoc", txtmalophoc.Text);
                cmd.Parameters.AddWithValue("tenlophoc", txttenlophoc.Text);
                cmd.Parameters.AddWithValue("ngayhoc", txtngayhoc.Text);
                cmd.Parameters.AddWithValue("siso", txtsiso.Text);
                cmd.Parameters.AddWithValue("tengiaovien", txttengiaovien.Text);
                cmd.ExecuteNonQuery();
                hienthi();
                MessageBox.Show("Sửa thành công ");
                txtmalophoc.Clear();
                txttenlophoc.Clear();
                txtngayhoc.Clear();
                txtsiso.Clear();
                txttengiaovien.Clear();
                txttkmalophoc.Clear();
                txttktenlophoc.Clear();
                txttkngayhoc.Clear();
                txttktengiaovien.Clear();
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

                string sqlDEL = "DELETE FROM lophoc WHERE malophoc = @malophoc";
                SqlCommand cmd = new SqlCommand(sqlDEL, con);
                cmd.Parameters.AddWithValue("malophoc", txtmalophoc.Text);
                cmd.Parameters.AddWithValue("tenlophoc", txttenlophoc.Text);
                cmd.Parameters.AddWithValue("ngayhoc", txtngayhoc.Text);
                cmd.Parameters.AddWithValue("siso", txtsiso.Text);
                cmd.Parameters.AddWithValue("tengiaovien", txttengiaovien.Text);
                cmd.ExecuteNonQuery();
                hienthi();
                MessageBox.Show("Xóa thành công ");
                txtmalophoc.Clear();
                txttenlophoc.Clear();
                txtngayhoc.Clear();
                txtsiso.Clear();
                txttengiaovien.Clear();
                txtmalophoc.Clear();
                txttenlophoc.Clear();
                txtngayhoc.Clear();
                txtsiso.Clear();
                txttengiaovien.Clear();
                txttkmalophoc.Clear();
                txttktenlophoc.Clear();
                txttkngayhoc.Clear();
                txttktengiaovien.Clear();
            }

            else
            {
            }

        }

        //Tim kiem

        private void txttkmalophoc_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  lophoc where malophoc like N'%" + txttkmalophoc.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvlophoc.DataSource = dt;
        }

        private void txttktenlophoc_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  lophoc where tenlophoc like N'%" + txttktenlophoc.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvlophoc.DataSource = dt;
        }

        private void txttkngaybatdauhoc_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  lophoc where ngayhoc like N'%" + txttkngayhoc.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvlophoc.DataSource = dt;
        }

        private void txttktengiaovien_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  lophoc where tengiaovien like N'%" + txttktengiaovien.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvlophoc.DataSource = dt;
        }

        //Click


        private void dtgvlophoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmalophoc.Text = dtgvlophoc.CurrentRow.Cells[0].Value.ToString();
            txttenlophoc.Text = dtgvlophoc.CurrentRow.Cells[1].Value.ToString();
            txtngayhoc.Text = dtgvlophoc.CurrentRow.Cells[2].Value.ToString();
            txtsiso.Text = dtgvlophoc.CurrentRow.Cells[3].Value.ToString();
            txttengiaovien.Text = dtgvlophoc.CurrentRow.Cells[4].Value.ToString();
        }

        private void dtgvlophoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmalophoc.Text = dtgvlophoc.CurrentRow.Cells[0].Value.ToString();
            txttenlophoc.Text = dtgvlophoc.CurrentRow.Cells[1].Value.ToString();
            txtngayhoc.Text = dtgvlophoc.CurrentRow.Cells[2].Value.ToString();
            txtsiso.Text = dtgvlophoc.CurrentRow.Cells[3].Value.ToString();
            txttengiaovien.Text = dtgvlophoc.CurrentRow.Cells[4].Value.ToString();
        }

        //Xuat file Excel

        private void btnexcel_Click(object sender, EventArgs e)
        {
            {
                for (int i = 1; i <= 10; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)dtgvlophoc.RowTemplate.Clone();
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

                for (int i = 0; i < dtgvlophoc.Rows.Count - 1; i++, cellRowIndex++)
                {
                    cellColumnIndex = 1;

                    for (int j = 0; j < dtgvlophoc.Columns.Count - 1; j++, cellColumnIndex++)
                    {
                        worksheet.Cells[cellRowIndex, cellColumnIndex] = dtgvlophoc.Rows[i].Cells[j].Value.ToString();
                    }
                }

                cellColumnIndex = 1;

                for (int j = 0; j < dtgvlophoc.Columns.Count - 1; j++, cellColumnIndex++)
                {
                    worksheet.Cells[1, cellColumnIndex] = dtgvlophoc.Columns[j].HeaderText;
                }
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Xuất thành công");
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

        private void itthongkehocvien_Click(object sender, EventArgs e)
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
