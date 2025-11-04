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

        private bool Drag;
        private int MouseX;
        private int MouseY;









        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;

        }


        #region PublicDeclarations
        public string _pass = "";
        public bool _isactivate;
        #endregion
        DBConnection dbConnect = new DBConnection();
        public frmLogin()
        {
            InitializeComponent();

            txtEmail.Focus();
        }

        public void ThongBao(string msg, frmThongBao.enmType type)
        {
            frmThongBao frm = new frmThongBao();
            frm.showAlert(msg, type);
        }


        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                string hashedPassword = Convert.ToBase64String(hashBytes);
                return hashedPassword;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (this.txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (this.txtPassword.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            string enteredEmail = txtEmail.Text;
            string enteredPassword = txtPassword.Text;

            try
            {
                using (SqlConnection cn = dbConnect.GetConnection())
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT u.email, u.password, u.roleid, u.name, u.accountstatus, "))
                    {
                        cmd.Parameters.AddWithValue("@email", enteredEmail);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string storedEmail = dr["email"].ToString();
                                string storedPasswordHash = dr["password"].ToString();
                                int roleId = Convert.ToInt32(dr["roleId"]);
                                string name = dr["name"].ToString();
                                string accountStatus = dr["accountStatus"].ToString();

                                if (accountStatus == "Deactivated")
                                {
                                    MessageBox.Show("Tài khoản của bạn đã ngưng hoạt động","THÔNG BÁO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                    return;
                                }

                                string enteredPasswordHash = HashPassword(enteredPassword);

                                if (enteredPasswordHash != storedPasswordHash)
                                {
                                    MessageBox.Show("Email hoặc mật khẩu của bạn không đúng!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                MessageBox.Show("Welcome " + name,"THÔNG BÁO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                txtEmail.Clear();
                                txtPassword.Clear();
                                this.Close();

                                this.Hide();

                                if (roleId == 1)
                                {
                                    /*frmMainApp main = new frmMainApp();
                                    main.lblUsername.Text = storedEmail;
                                    main.lblRole.Text = "Admin";
                                    main.lblFullName.Text = name;
                                    main._pass = storedPasswordHash;
                                    main.ShowDialog();*/
                                }
                                else
                                {
                                    /*frmMainApp main = new frmMainApp();
                                    main.lblUsername.Text = storedEmail;
                                    main.lblRole.Text = "Guest";
                                    main.lblFullName.Text = name;
                                    main._pass = storedPasswordHash;
                                    main.ShowDialog();*/
                                }
                            }
                            else
                            {
                                MessageBox.Show("Email hoặc mật khẩu không đúng !","THÔNG BÁO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Drag = true;
            MouseX = Cursor.Position.X - this.Left;
            MouseY = Cursor.Position.Y - this.Top;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drag)
            {
                this.Top = Cursor.Position.Y - MouseY;
                this.Left = Cursor.Position.X - MouseX;
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            Drag = false;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            Drag = true;
            MouseX = Cursor.Position.X - this.Left;
            MouseY = Cursor.Position.Y - this.Top;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            Drag = true;
            MouseX = Cursor.Position.X - this.Left;
            MouseY = Cursor.Position.Y - this.Top;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            Drag = false;
        }
    }
}

