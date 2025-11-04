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
    public partial class subfrmNhanVien : Form
    {

        private bool drag;
        private int MouseX;
        private int MouseY;

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }


        //Dùng để tái kích hoạt form tải lại table()
        frmNhanVien nv;
        public subfrmNhanVien(frmNhanVien nvList)
        {
            InitializeComponent();
            this.nv = nvList;

            //lấy vai trò + Trạng thái có sẵn từ db
            this.getVaiTroCoSan();
            this.getTrangThaiCoSan();

            //Mặc định nút thêm được kích hoạt, nút sửa bị vô hiệu hóa
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = false;
        }

        public void ThongBao(string msg, frmThongBao.enmType type)
        {
            frmThongBao f = new frmThongBao();
            f.showAlert(msg, type);
        }

        //Connect sql server
        DBConnection db = new DBConnection();


        public bool KiemTraGiaTriNhap()
        {
            if (txtMaNhanVien.Text == "" || txtTenNV.Text == "" || txtEmail.Text == "" || txtMK.Text == "" || txtNhapLaiMK.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (cbbTrangThai.SelectedValue == null || cbbVaiTro.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
        }



        //======================================Các hàm xử lí
        public void clear()
        {

            txtMaNhanVien.Text = "";
            txtTenNV.Text = "";
            txtEmail.Text = "";
            txtMK.Text = "";
            txtNhapLaiMK.Text = "";
            cbbVaiTro.SelectedIndex = -1;
            cbbTrangThai.SelectedIndex = -1;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
        }

        public void getVaiTroCoSan()
        {
            //Datatable là tải toàn bộ table về bộ nhớ => có thể chậm 
            //dùng cho: 🔸 Cần hiển thị dữ liệu lên DataGridView, ComboBox, ListView,...

            // còn sqldatareader: 🔸 Dùng để đọc dữ liệu từ cơ sở dữ liệu một cách nhanh chóng và hiệu quả.
            //Cho việc truy xuất và hiện thị cột - dòng
            try
            {
                using (SqlConnection cn = db.GetConnection())
                {
                    cn.Open();
                    DataTable dt = new DataTable();
                    string query = "SELECT MaVaiTro, TenVaiTro FROM VaiTro";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, cn))
                    {

                        da.Fill(dt);

                    }
                    cbbVaiTro.DataSource = dt;

                    //Hiển thị tên vai trò -> mã vai trò là giá trị để truy xuất
                    cbbVaiTro.DisplayMember = "TenVaiTro";
                    cbbVaiTro.ValueMember = "MaVaiTro";

                    //Mặc định không chọn giá trị nào
                    cbbVaiTro.SelectedIndex = -1;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy vai trò có sẵn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void getTrangThaiCoSan()
        {
            try
            {
                using (SqlConnection cn = db.GetConnection())
                {
                    cn.Open();
                    DataTable dt = new DataTable();
                    string query = "SELECT TrangThai FROM TrangThaiNhanVien";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, cn))
                    {
                        da.Fill(dt);
                    }
                    cbbTrangThai.DataSource = dt;

                    //display: hiển thị ra bên ngoài - value : là giá trị để truy xuất hoặc dugnf để tính toán
                    cbbTrangThai.DisplayMember = "TrangThai";
                    cbbTrangThai.ValueMember = "TrangThai";
                    cbbTrangThai.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy trạng thái có sẵn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //using System.Security.Cryptography;
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {

                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] bytes = sha256.ComputeHash(passwordBytes);
                string hashedPassword = Convert.ToBase64String(bytes);

                return hashedPassword;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraGiaTriNhap())
                    return;

                // sửa nhân viên vào CSDL
                //Hỏi: có đồng ý thêm không
                DialogResult dg;
                dg = MessageBox.Show("Bạn có chắc chắn muốn sửa nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    //Thêm vào db
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();
                        using (SqlCommand cmd = cn.CreateCommand())
                        {
                            //Thêm tham số để tránh sql injection
                            cmd.CommandText = "UPDATE NhanVien SET TenNhanVien = @TenNhanVien, Email = @Email, MatKhau = @MatKhau, MaVaiTro = @MaVaiTro, TrangThai = @TrangThai " +
                                              "WHERE MaNhanVien = @MaNhanVien";

                            cmd.Parameters.AddWithValue("@MaNhanVien", txtMaNhanVien.Text);
                            cmd.Parameters.AddWithValue("@TenNhanVien", txtTenNV.Text);
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("@MatKhau", txtMK.Text);
                            cmd.Parameters.AddWithValue("@MaVaiTro", cbbVaiTro.SelectedValue);
                            cmd.Parameters.AddWithValue("@TrangThai", cbbTrangThai.SelectedValue);

                            cmd.ExecuteNonQuery();
                        }

                        this.clear();
                        this.Close();

                        //Sau khi thêm code vào frmNhanVien thì đảo lại đây load lại danh sách
                        //this.nv.LoadNhanVienList();

                        //Thong báo sửa thành công
                        this.ThongBao("Sửa thành công", frmThongBao.enmType.Success);

                        //
                        btnThem.Enabled = true;
                        btnSua.Enabled = false;

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraGiaTriNhap())
                    return;


                if (txtMK.Text != txtNhapLaiMK.Text) {
                    MessageBox.Show("Mật khẩu không khớp, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string hashedpassword = HashPassword(txtMK.Text);

                // Thêm nhân viên vào CSDL
                //Hỏi: có đồng ý thêm không
                DialogResult dg;
                dg = MessageBox.Show("Bạn có chắc chắn muốn thêm nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    //Thêm vào db
                    using (SqlConnection cn = db.GetConnection()) {
                        cn.Open();
                        using (SqlCommand cmd = cn.CreateCommand()) {
                            //Thêm tham số để tránh sql injection
                            cmd.CommandText = "INSERT INTO NhanVien (MaNhanVien, TenNhanVien, Email, MatKhau, MaVaiTro, TrangThai) " +
                                              "VALUES (@MaNhanVien, @TenNhanVien, @Email, @MatKhau, @MaVaiTro, @TrangThai)";

                            cmd.Parameters.AddWithValue("@MaNhanVien", txtMaNhanVien.Text);
                            cmd.Parameters.AddWithValue("@TenNhanVien", txtTenNV.Text);
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("@MatKhau", hashedpassword);
                            cmd.Parameters.AddWithValue("@MaVaiTro", cbbVaiTro.SelectedValue);
                            cmd.Parameters.AddWithValue("@TrangThai", cbbTrangThai.SelectedValue);

                            cmd.ExecuteNonQuery();
                        }

                        this.clear();
                        this.Close();

                        //Sau khi thêm code vào frmNhanVien thì đảo lại đây load lại danh sách
                        //this.nv.LoadNhanVienList();
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
