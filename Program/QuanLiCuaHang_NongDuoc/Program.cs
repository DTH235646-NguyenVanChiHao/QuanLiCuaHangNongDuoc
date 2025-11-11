using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCuaHang_NongDuoc
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();


            // Tạo form chính
            frmMainApp mainApp = new frmMainApp();

            // Hiển thị form đăng nhập trước
            frmLogin loginForm = new frmLogin(mainApp);
            DialogResult loginResult = loginForm.ShowDialog();

            // Nếu đăng nhập thành công, chạy form chính
            if (loginResult == DialogResult.OK)
            {
                Application.Run(mainApp);
            }
            else
            {
                // Đăng nhập thất bại hoặc người dùng thoát
                Application.Exit();
            }

            
        }
    }
}
