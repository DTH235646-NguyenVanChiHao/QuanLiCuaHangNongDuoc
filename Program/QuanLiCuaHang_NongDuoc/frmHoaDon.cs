using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCuaHang_NongDuoc
{
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.listView1.Clear();
            this.txtNhapSP.Clear(); 
            this.txtNhapSP.Focus();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi= MessageBox.Show("Xác nhận thanh toán!", "Thanh Toán",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if(traloi == DialogResult.OK)
            {
                MessageBox.Show("thanh toán thành công", "Thông Báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }    
        }
    }
}
