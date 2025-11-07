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
    public partial class frmLichSu : Form
    {
        //db
        DBConnection db = new DBConnection();


        //
        public frmLichSu()
        {
            InitializeComponent();


            //Default: Hóa đơn
            ShowForm(new frmLichSuaHoaDon());

            // Reset màu nút
            btnHoaDon.ForeColor = Color.FromArgb(100, 100, 100);
            btnPhieuNhap.ForeColor = Color.FromArgb(100, 100, 100);

            // Hóa đơn được chọn
            btnHoaDon.ForeColor = Color.FromArgb(0, 122, 204);
            pnlIndicator.BackColor = Color.FromArgb(0, 122, 204);

            // Di chuyển thanh
            pnlIndicator.Width = btnHoaDon.Width;
            pnlIndicator.Left = btnHoaDon.Left;
            pnlIndicator.Top = btnHoaDon.Bottom;
            pnlIndicator.BringToFront();


            //

        }
        public Form activeForm = null;
        public void ShowForm(Form pages)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }


            activeForm = pages; // định bị form hiện tại

            //Thiet lập các thuộc tính cho form con
            pages.TopLevel = false;
            pages.FormBorderStyle = FormBorderStyle.None;
            pages.Dock = DockStyle.Fill;

            //Thêm form vào panel đã được định vị trí sẵn
            this.pnlContent.Controls.Add(pages);

           

            //Hiển thị form
            pages.BringToFront();
            pages.Show();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            ShowForm(new frmLichSuaHoaDon());

            // Reset màu nút
            btnHoaDon.ForeColor = Color.FromArgb(100, 100, 100);
            btnPhieuNhap.ForeColor = Color.FromArgb(100, 100, 100);

            // Hóa đơn được chọn
            btnHoaDon.ForeColor = Color.FromArgb(0, 122, 204);
            pnlIndicator.BackColor = Color.FromArgb(0, 122, 204);

            // Di chuyển thanh
            pnlIndicator.Width = btnHoaDon.Width;
            pnlIndicator.Left = btnHoaDon.Left;
            pnlIndicator.Top = btnHoaDon.Bottom;
            pnlIndicator.BringToFront();
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            ShowForm(new frmLichSuPhieuNhap());
            // Reset màu nút
            btnHoaDon.ForeColor = Color.FromArgb(100, 100, 100);
            btnPhieuNhap.ForeColor = Color.FromArgb(100, 100, 100);

            // Hóa đơn được chọn
            btnPhieuNhap.ForeColor = Color.Green;
            pnlIndicator.BackColor = Color.Green;

            // Di chuyển thanh
            pnlIndicator.Width = btnPhieuNhap.Width;
            pnlIndicator.Left = btnPhieuNhap.Left;
            pnlIndicator.Top = btnPhieuNhap.Bottom; // di chuyển xuống dưới nút
            pnlIndicator.BringToFront();
        }
    }
}
