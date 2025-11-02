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
    public partial class frmMainApp : Form
    {
        //Hiệu ứng khi nhân hoặc thả
        private Color ActiveColor = Color.FromArgb(46, 51, 73);
        private Color InactiveColor = Color.FromArgb(24, 30, 54);


        //Biến lưu form con hiện tại
        public frmMainApp()
        {
            InitializeComponent();
            KhoiTaoGiaoDien();
            DBConnection dBConnection = new DBConnection();
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

            //OpenChildForm(new frmTrangChu());
            //HideSubMenu();    


            //Hiệu ứng chuyển đổi màu khi nhấn button

            //SetButtonColors(btnTrangChu,ActiveColor);
            pnlActive.Height = btnTrangChu.Height;
            pnlActive.Top = btnTrangChu.Top;
            pnlActive.BringToFront();

        }


        //Hàm mở các form con bên trong form chính
        public void OpenChildForm(Form pages) {

        }

        public void HideSubMenu() { }

       

        //public void SetButtonColors(Button btn, ){

        //}


    }
}
