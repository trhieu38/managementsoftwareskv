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
    public partial class taichinh : Form
    {
        public taichinh()
        {
            InitializeComponent();
        }

        //Code

        SqlConnection con;

        private void taichinh_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTTNNDataSet1.lophoc' table. You can move, or remove it, as needed.
            this.lophocTableAdapter.Fill(this.qLTTNNDataSet1.lophoc);
            string ketnoi = ConfigurationManager.ConnectionStrings["QuanlyTTNN"].ConnectionString.ToString();
            con = new SqlConnection(ketnoi);
            con.Open();
            hienthi();
        }


        private void taichinh_FormClosing(object sender, FormClosingEventArgs e)
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


        private void btnthem_Click(object sender, EventArgs e)
        {
            string sqlINSET = "INSERT INTO hocphi VALUES(@mahocvien, @tenhocvien, @tenlophoc, @dotnop, @ngaynop, @sotien, @nguoithu)";
            SqlCommand cmd = new SqlCommand(sqlINSET, con);
            cmd.Parameters.AddWithValue("mahocvien", txtmahocvien.Text);
            cmd.Parameters.AddWithValue("tenhocvien", txttenhocvien.Text);
            cmd.Parameters.AddWithValue("tenlophoc", cbbtenlophoc.Text);
            cmd.Parameters.AddWithValue("dotnop", cbbdotnop.Text);
            cmd.Parameters.AddWithValue("ngaynop", txtngaynop.Text);
            cmd.Parameters.AddWithValue("sotien", txtsotien.Text);
            cmd.Parameters.AddWithValue("nguoithu", txtnguoithu.Text);            
            cmd.ExecuteNonQuery();
            hienthi();
            MessageBox.Show("Nộp học phí thành công");
            txtmahocvien.Clear();
            txttenhocvien.Clear();
            cbbtenlophoc.SelectedIndex = -1;
            cbbdotnop.SelectedIndex = -1;
            txtsotien.Clear();
            txtnguoithu.Clear();
            
        }


        private void btnsua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string sqlEDIT = "UPDATE hocphi SET tenhocvien = @tenhocvien, tenlophoc = @tenlophoc, dotnop = @dotnop, ngaynop = @ngaynop, sotien = @sotien, nguoithu = @nguoithu  WHERE mahocvien = @mahocvien";
                SqlCommand cmd = new SqlCommand(sqlEDIT, con);
                cmd.Parameters.AddWithValue("mahocvien", txtmahocvien.Text);
                cmd.Parameters.AddWithValue("tenhocvien", txttenhocvien.Text);
                cmd.Parameters.AddWithValue("tenlophoc", cbbtenlophoc.Text);
                cmd.Parameters.AddWithValue("dotnop", cbbdotnop.Text);
                cmd.Parameters.AddWithValue("ngaynop", txtngaynop.Text);
                cmd.Parameters.AddWithValue("sotien", txtsotien.Text);
                cmd.Parameters.AddWithValue("nguoithu", txtnguoithu.Text);
                cmd.ExecuteNonQuery();
                hienthi();
                MessageBox.Show("Sửa thành công");
                txtmahocvien.Clear();
                txttenhocvien.Clear();
                cbbtenlophoc.SelectedIndex = -1;
                cbbdotnop.SelectedIndex = -1;
                txtsotien.Clear();
                txtnguoithu.Clear();
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
                string sqlDEL = "DELETE FROM hocphi WHERE mahocvien = @mahocvien";
                SqlCommand cmd = new SqlCommand(sqlDEL, con);
                cmd.Parameters.AddWithValue("mahocvien", txtmahocvien.Text);
                cmd.Parameters.AddWithValue("tenhocvien", txttenhocvien.Text);
                cmd.Parameters.AddWithValue("tenlophoc", cbbtenlophoc.Text);
                cmd.Parameters.AddWithValue("dotnop", cbbdotnop.Text);
                cmd.Parameters.AddWithValue("ngaynop", txtngaynop.Text);
                cmd.Parameters.AddWithValue("sotien", txtsotien.Text);
                cmd.Parameters.AddWithValue("nguoithu", txtnguoithu.Text);
                cmd.ExecuteNonQuery();
                hienthi();
                MessageBox.Show("Xóa thành công");
                txtmahocvien.Clear();
                txttenhocvien.Clear();
                cbbtenlophoc.SelectedIndex = -1;
                cbbdotnop.SelectedIndex = -1;
                txtsotien.Clear();
                txtnguoithu.Clear();

            }
            else
            {
            }
        }

        //Mahocvien set item

        private void txtmahocvien_TextChanged(object sender, EventArgs e)
        {
            string sqlSELECT = "SELECT * FROM hocvien where mahocvien ='" + txtmahocvien.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlSELECT, con);
            cmd.ExecuteNonQuery();
            SqlDataReader cd;
            cd = cmd.ExecuteReader();
            while (cd.Read())
            {
                string tenhocvien = (string)cd["tenhocvien"].ToString();
                txttenhocvien.Text = tenhocvien;
                string tenlophoc = (string)cd["tenlophoc"].ToString();
                cbbtenlophoc.Text = tenlophoc;
            }

        }

        //Click

        private void dtgvhocphi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmahocvien.Text = dtgvhocphi.CurrentRow.Cells[0].Value.ToString();
            txttenhocvien.Text = dtgvhocphi.CurrentRow.Cells[1].Value.ToString();
            cbbtenlophoc.Text = dtgvhocphi.CurrentRow.Cells[2].Value.ToString();
            cbbdotnop.Text = dtgvhocphi.CurrentRow.Cells[3].Value.ToString();
            txtngaynop.Text = dtgvhocphi.CurrentRow.Cells[4].Value.ToString();
            txtsotien.Text = dtgvhocphi.CurrentRow.Cells[5].Value.ToString();
            txtnguoithu.Text = dtgvhocphi.CurrentRow.Cells[6].Value.ToString();
        }

        private void dtgvhocphi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmahocvien.Text = dtgvhocphi.CurrentRow.Cells[0].Value.ToString();
            txttenhocvien.Text = dtgvhocphi.CurrentRow.Cells[1].Value.ToString();
            cbbtenlophoc.Text = dtgvhocphi.CurrentRow.Cells[2].Value.ToString();
            cbbdotnop.Text = dtgvhocphi.CurrentRow.Cells[3].Value.ToString();
            txtngaynop.Text = dtgvhocphi.CurrentRow.Cells[4].Value.ToString();
            txtsotien.Text = dtgvhocphi.CurrentRow.Cells[5].Value.ToString();
            txtnguoithu.Text = dtgvhocphi.CurrentRow.Cells[6].Value.ToString();
        }

        //Tim kiem

        private void txttkmahocvien_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocphi where mahocvien like N'%" + txttkmahocvien.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocphi.DataSource = dt;
        }

        private void cbbtktenlophoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocphi where tenlophoc like N'%" + cbbtktenlophoc.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocphi.DataSource = dt;
        }

        private void cbbtkdotnop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocphi where dotnop like N'%" + cbbtkdotnop.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocphi.DataSource = dt;
        }

        private void txttknguoithu_TextChanged(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT * FROM  hocphi where nguoithu like N'%" + txtnguoithu.Text + "%'";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgvhocphi.DataSource = dt;
        }

        //Thong ke

        private void btnthongke_Click(object sender, EventArgs e)
        {
            string sqlTIMKIEM = "SELECT SUM (sotien) FROM hocphi where mahocvien = @mahocvien or tenlophoc = @tenlophoc or dotnop = @dotnop or nguoithu = @nguoithu";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, con);
            cmd.Parameters.AddWithValue("mahocvien", txttkmahocvien.Text);
            cmd.Parameters.AddWithValue("tenlophoc", cbbtktenlophoc.Text);
            cmd.Parameters.AddWithValue("dotnop", cbbtkdotnop.Text);
            cmd.Parameters.AddWithValue("nguoithu", txttknguoithu.Text);
            SqlDataReader drs = cmd.ExecuteReader();
            if (drs.Read())
            {
                lbthongke.Text = (drs.GetValue(0).ToString());
            }
        }

        //Inexcel

        private void inexcel_Click(object sender, EventArgs e)
        {
            {
                for (int i = 1; i <= 10; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)dtgvhocphi.RowTemplate.Clone();
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

                for (int i = 0; i < dtgvhocphi.Rows.Count - 1; i++, cellRowIndex++)
                {
                    cellColumnIndex = 1;

                    for (int j = 0; j < dtgvhocphi.Columns.Count - 1; j++, cellColumnIndex++)
                    {
                        worksheet.Cells[cellRowIndex, cellColumnIndex] = dtgvhocphi.Rows[i].Cells[j].Value.ToString();
                    }
                }

                cellColumnIndex = 1;

                for (int j = 0; j < dtgvhocphi.Columns.Count - 1; j++, cellColumnIndex++)
                {
                    worksheet.Cells[1, cellColumnIndex] = dtgvhocphi.Columns[j].HeaderText;
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

        private void btntaichinh_Click(object sender, EventArgs e)
        {
            this.Hide();
            taichinh dlg2 = new taichinh();
            dlg2.ShowDialog();
        }

        private void btndiemkt_Click(object sender, EventArgs e)
        {
            this.Hide();
            diemkt dlg2 = new diemkt();
            dlg2.ShowDialog();
        }

    }
}
