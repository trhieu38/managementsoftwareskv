using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTTNN
{
    public partial class trangchu : Form
    {
        public trangchu()
        {
            InitializeComponent();
        }

        private void tìmKiếmHọcViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            taikhoan dlg2 = new taikhoan();
            dlg2.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thốngKêHọcViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tkhocvien dlg2 = new tkhocvien();
            dlg2.ShowDialog();
        }
        
        private void tToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hotro dlg2 = new hotro();
            dlg2.ShowDialog();
        }

        private void btnlophoc_Click(object sender, EventArgs e)
        {
            lophoc dlg2 = new lophoc();
            dlg2.ShowDialog();
        }

        private void btnmonhoc_Click(object sender, EventArgs e)
        {
            monhoc dlg2 = new monhoc();
            dlg2.ShowDialog();
        }

        private void btnhocvien_Click(object sender, EventArgs e)
        {
            hocvien dlg2 = new hocvien();
            dlg2.ShowDialog();
        }

        private void btngiaovien_Click(object sender, EventArgs e)
        {
            giaovien dlg2 = new giaovien();
            dlg2.ShowDialog();
        }

        private void btndiemkt_Click(object sender, EventArgs e)
        {
            diemkt dlg2 = new diemkt();
            dlg2.ShowDialog();
        }

        private void btntaichinh_Click(object sender, EventArgs e)
        {
            taichinh dlg2 = new taichinh();
            dlg2.ShowDialog();
        }

    }
}
