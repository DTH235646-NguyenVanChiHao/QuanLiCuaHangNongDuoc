using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCuaHang_NongDuoc
{
    public partial class frmMainApp : Form
    {
        

        private DBConnection dBConnection;

        //Biến lưu form con hiện tại
        public frmMainApp()
        {
            InitializeComponent();
            KhoiTaoGiaoDien();
           this.dBConnection = new DBConnection();
        }


        
       
        //Form từ giao diện 
        private void frmMainApp_Load(object sender, EventArgs e)
        {
          
        }


        // ===========================Các hàm cập nhật 
        //Hàm khởi tạo
        public void ShowThongBao(string msg, frmThongBao.enmType type)
        {
            frmThongBao f = new frmThongBao();
            f.showAlert(msg, type);
        }

        public void KhoiTaoGiaoDien()
        {
            // Hỗ trợ hiển thị Giao diện bằng một vùng nhớ ẩn 
            this.DoubleBuffered = true;


            //Hiển thị giờ và ngày lên hệ thống
            string datetime = DateTime.Now.ToString();

            string time = datetime.Substring(datetime.IndexOf(" ") + 1);
            lblTimeRendering.Text = time;

            string date = datetime.Substring(0, datetime.IndexOf(" "));
            lblDateRendering.Text = date;


            //Mặc định hiển thị trang đầu tiên
            OpenChildForm(new frmTrangChu());
            //Set màu cho button khi được chọn
            // Set màu cho các nút
            this.btnTrangChu.ForeColor = SystemColors.InfoText; // Nút đang được chọn
            this.btnHoaDon.ForeColor = Color.Gray;              // Nút không chọn
            this.btnPhieuNhap.ForeColor = Color.Gray;
            this.btnSanPham.ForeColor = Color.Gray;
            this.btnNhaCC.ForeColor = Color.Gray;
            this.btnKhachHang.ForeColor = Color.Gray;


            //Hiệu ứng chuyển đổi màu khi nhấn button

            //SetButtonColors(btnTrangChu,ActiveColor);
            pnlActive.Height = btnTrangChu.Height;
            pnlActive.Top = btnTrangChu.Top;

            //hiển thị đè lên các control khác nếu chúng bị chồng lấp.
            pnlActive.BringToFront();

        }



        //Hàm mở các form con bên trong form chính
        private Form activeForm = null;

        //Do form là form cha nên ta cần truyền vào form con
        public void OpenChildForm(Form pages) {
            if(activeForm != null)
                activeForm.Close();

            //Create a form
            activeForm = pages; // định bị form hiện tại

            //Thiet lập các thuộc tính cho form con
            pages.TopLevel = false;
            pages.FormBorderStyle = FormBorderStyle.None;
            pages.Dock = DockStyle.Fill;

            //Thêm form vào panel đã được định vị trí sẵn
            this.pnlContentPages.Controls.Add(pages);

            //Thay đổi tên trang hiện tại
            this.lblNamePage.Text = pages.Text;

            //Hiển thị form
            pages.BringToFront();
            pages.Show();
        }

        public void HideSubMenu() { }

        //Button on navigation panel
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTrangChu());

            //Set màu cho button khi được chọn
            // Set màu cho các nút
            this.btnTrangChu.ForeColor = SystemColors.InfoText; // Nút đang được chọn
            this.btnHoaDon.ForeColor = Color.Gray;              // Nút không chọn
            this.btnPhieuNhap.ForeColor = Color.Gray;
            this.btnSanPham.ForeColor = Color.Gray;
            this.btnNhaCC.ForeColor = Color.Gray;
            this.btnKhachHang.ForeColor = Color.Gray;





            //Hiệu ứng khi chuyển trang : Thanh màu cam - di chuyển theo button
            //SetButtonColors(btnTrangChu,ActiveColor);
            pnlActive.Height = btnTrangChu.Height;
            pnlActive.Top = btnTrangChu.Top;

            //hiển thị đè lên các control khác nếu chúng bị chồng lấp.
            pnlActive.BringToFront();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHoaDon());
            //Set màu cho button khi được chọn
            // Set màu cho các nút
            this.btnTrangChu.ForeColor = Color.Gray; // Nút đang được chọn
            this.btnHoaDon.ForeColor = SystemColors.InfoText;              // Nút không chọn
            this.btnPhieuNhap.ForeColor = Color.Gray;
            this.btnSanPham.ForeColor = Color.Gray;
            this.btnNhaCC.ForeColor = Color.Gray;
            this.btnKhachHang.ForeColor = Color.Gray;




            //Hiệu ứng khi chuyển trang : Thanh màu cam - di chuyển theo button
            //SetButtonColors(btnTrangChu,ActiveColor);
            pnlActive.Height = btnHoaDon.Height;

            //👉 Dòng này điều chỉnh vị trí theo trục Y (trên–dưới) của pnlActive
            //để đặt nó ngay tại vị trí của nút Hóa đơn.
            pnlActive.Top = btnHoaDon.Top;

            //hiển thị đè lên các control khác nếu chúng bị chồng lấp.
            pnlActive.BringToFront();



        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPhieuNhap());
            //Set màu cho button khi được chọn
            // Set màu cho các nút
            this.btnTrangChu.ForeColor = Color.Gray; // Nút đang được chọn
            this.btnHoaDon.ForeColor = Color.Gray;              // Nút không chọn
            this.btnPhieuNhap.ForeColor = SystemColors.InfoText;
            this.btnSanPham.ForeColor = Color.Gray;
            this.btnNhaCC.ForeColor = Color.Gray;
            this.btnKhachHang.ForeColor = Color.Gray;


            //Hiệu ứng khi chuyển trang : Thanh màu cam - di chuyển theo button
            //SetButtonColors(btnTrangChu,ActiveColor);
            pnlActive.Height = btnPhieuNhap.Height;
            pnlActive.Top = btnPhieuNhap.Top;

            //hiển thị đè lên các control khác nếu chúng bị chồng lấp.
            pnlActive.BringToFront();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSanPham());
            //set màu cho button khi được chọn
            this.btnTrangChu.ForeColor = Color.Gray; // Nút đang được chọn
            this.btnHoaDon.ForeColor = Color.Gray;              // Nút không chọn
            this.btnPhieuNhap.ForeColor = Color.Gray;
            this.btnSanPham.ForeColor = SystemColors.InfoText;
            this.btnNhaCC.ForeColor = Color.Gray;
            this.btnKhachHang.ForeColor = Color.Gray;

            //Hiệu ứng khi chuyển trang : Thanh màu cam - di chuyển theo button
            //SetButtonColors(btnTrangChu,ActiveColor);
            pnlActive.Height = btnSanPham.Height;
            pnlActive.Top = btnSanPham.Top;

            //hiển thị đè lên các control khác nếu chúng bị chồng lấp.
            pnlActive.BringToFront();
        }

        private void btnNhaCC_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhaCungCap());
            //set màu cho button khi được chọn
            this.btnTrangChu.ForeColor = Color.Gray; // Nút đang được chọn
            this.btnHoaDon.ForeColor = Color.Gray;              // Nút không chọn
            this.btnPhieuNhap.ForeColor = Color.Gray;
            this.btnSanPham.ForeColor = Color.Gray;
            this.btnNhaCC.ForeColor = SystemColors.InfoText;
            this.btnKhachHang.ForeColor = Color.Gray;

            //Hiệu ứng khi chuyển trang : Thanh màu cam - di chuyển theo button
            //SetButtonColors(btnTrangChu,ActiveColor);
            pnlActive.Height = btnNhaCC.Height;
            pnlActive.Top = btnNhaCC.Top;

            //hiển thị đè lên các control khác nếu chúng bị chồng lấp.
            pnlActive.BringToFront();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhachHang());
            //
            this.btnTrangChu.ForeColor = Color.Gray; // Nút đang được chọn
            this.btnHoaDon.ForeColor = Color.Gray;              // Nút không chọn
            this.btnPhieuNhap.ForeColor = Color.Gray;
            this.btnSanPham.ForeColor = Color.Gray;
            this.btnNhaCC.ForeColor = Color.Gray;
            this.btnKhachHang.ForeColor = SystemColors.InfoText;

            //Hiệu ứng khi chuyển trang : Thanh màu cam - di chuyển theo button
            //SetButtonColors(btnTrangChu,ActiveColor);
            pnlActive.Height = btnKhachHang.Height;
            pnlActive.Top = btnKhachHang.Top;

            //hiển thị đè lên các control khác nếu chúng bị chồng lấp.
            pnlActive.BringToFront();
        }

       

        //Avatar user click => Show profile + Users + password
        private void picBoxUserAvatar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien());

            //
            this.btnTrangChu.ForeColor = Color.Gray; // Nút đang được chọn
            this.btnHoaDon.ForeColor = Color.Gray;              // Nút không chọn
            this.btnPhieuNhap.ForeColor = Color.Gray;
            this.btnSanPham.ForeColor = Color.Gray;
            this.btnNhaCC.ForeColor = Color.Gray;
            this.btnKhachHang.ForeColor = Color.Gray;

            //Hiệu ứng khi chuyển trang : Thanh màu cam - di chuyển theo button
            //SetButtonColors(btnTrangChu,ActiveColor);
            pnlActive.Height = btnTrangChu.Height;
            pnlActive.Top = btnTrangChu.Top;

            //hiển thị đè lên các control khác nếu chúng bị chồng lấp.
            pnlActive.BringToFront();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chua the dang xuat");


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Timer là một hàm chạy ngầm định kỳ - dùng interval và phải enable để chạy
            // đơn vị dùng là : milliseconds - 1 giây = 1000 milliseconds
            //100 mili = 0.1 giây 
            this.lblTimeRendering.Text = DateTime.Now.ToString("HH:mm:ss");
        }


    }
}
