using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCuaHang_NongDuoc
{
    public partial class frmLogin : Form
    {
        #region PublicDeclarations
        public string _pass = "";
        public bool _isactivate;
        #endregion

        DBConnection dbConnect = new DBConnection();
        private frmMainApp app;

        public frmLogin(frmMainApp main)
        {
            InitializeComponent();
            this.app = main;
            txtEmail.Focus();

            // Đặt PasswordChar cho textbox password
            txtPassword.PasswordChar = '●';

            // Đăng ký sự kiện KeyPress để hỗ trợ nhấn Enter
            txtEmail.KeyPress += TextBox_KeyPress;
            txtPassword.KeyPress += TextBox_KeyPress;
        }

        // Hỗ trợ nhấn Enter để đăng nhập
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnDangNhap_Click(sender, e);   
                e.Handled = true;
            }
        }

        public void ThongBao(string msg, frmThongBao.enmType type)
        {
            frmThongBao frm = new frmThongBao();
            frm.showAlert(msg, type);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            string enteredEmail = txtEmail.Text.Trim();
            string enteredPassword = txtPassword.Text;

            try
            {
                using (SqlConnection cn = dbConnect.GetConnection())
                {
                    cn.Open();
                    string query = @"SELECT nv.MaNhanVien, nv.TenNhanVien, nv.Email, 
                                    nv.MatKhau, vt.VaiTro, nv.TrangThaiTaiKhoan 
                                    FROM NhanVien AS nv 
                                    INNER JOIN VaiTro AS vt ON nv.MaVaiTro = vt.MaVaiTro 
                                    WHERE nv.Email = @email";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@email", enteredEmail);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string storedEmail = dr["Email"].ToString();
                                string storedPassword = dr["MatKhau"].ToString();
                                string name = dr["TenNhanVien"].ToString();
                                string accountStatus = dr["TrangThaiTaiKhoan"].ToString();
                                string role = dr["VaiTro"].ToString();

                                // Kiểm tra trạng thái tài khoản
                                if (accountStatus == "Tạm khoá")
                                {
                                    MessageBox.Show("Tài khoản của bạn đã bị tạm khoá. Vui lòng liên hệ quản trị viên.",
                                        "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                if (accountStatus == "Không hoạt động")
                                {
                                    MessageBox.Show("Tài khoản của bạn đã ngưng hoạt động. Vui lòng liên hệ quản trị viên.",
                                        "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                // Kiểm tra mật khẩu
                                // Nếu bạn đang dùng hash password, thay thế bằng hàm verify hash
                                if (enteredPassword != storedPassword)
                                {
                                    MessageBox.Show("Email hoặc mật khẩu không đúng!",
                                        "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtPassword.Clear();
                                    txtPassword.Focus();
                                    return;
                                }

                                // Đăng nhập thành công
                                MessageBox.Show($"Chào mừng {name}!\nVai trò: {role}",
                                    "ĐĂNG NHẬP THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Cập nhật thông tin lên form chính
                                this.app.lblEmail.Text = storedEmail;
                                this.app.lblUsername.Text = name;

                                // Đặt DialogResult để form chính biết đăng nhập thành công
                                this.DialogResult = DialogResult.OK;

                                // Xóa dữ liệu và đóng form
                                txtEmail.Clear();
                                txtPassword.Clear();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Email hoặc mật khẩu không đúng!",
                                    "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtPassword.Clear();
                                txtPassword.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message,
                    "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (traloi == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                Application.Exit();
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Nếu form đóng mà chưa đăng nhập thành công
            if (this.DialogResult != DialogResult.OK)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}