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

namespace QLTTNN
{
    public partial class dangnhap : Form
    {
        public dangnhap()
        {
            InitializeComponent();
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-EF0QU1B\SQLEXPRESS;Initial Catalog=QLTTNN;Integrated Security=True");
              try
                 {
                    conn.Open();
                    string sql = "select COUNT(*) From [QLTTNN].[dbo].[dangnhap] where taikhoan=@acc And matkhau=@pass";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add(new SqlParameter("@acc", txttaikhoan.Text));
                    cmd.Parameters.Add(new SqlParameter("@pass", txtmatkhau.Text));
                    int x = (int)cmd.ExecuteScalar();
                    if (x == 1)
                       {
                          trangchu hh;
                          this.Hide();
                          hh = new trangchu();
                          hh.Show();
                       }
                    else
                       {
                         MessageBox.Show("Đăng nhập không thành công");
                         txttaikhoan.Clear();
                         txtmatkhau.Clear();
                         txttaikhoan.Focus();
                       }
                 }
             catch (Exception ex)
                 {
                       MessageBox.Show(ex.Message);
                 }
        }
      }

        
    }
