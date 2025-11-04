using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
<<<<<<< HEAD
=======
using System.Security.Cryptography;
>>>>>>> 3316b5bb2ca6c031132a68e5c07e8d71446aa92a
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

<<<<<<< HEAD
=======

        //Dùng để tái kích hoạt form tải lại table()
>>>>>>> 3316b5bb2ca6c031132a68e5c07e8d71446aa92a
        frmNhanVien nv;
        public subfrmNhanVien(frmNhanVien nvList)
        {
            InitializeComponent();
            this.nv = nvList;

            //lấy vai trò + Trạng thái có sẵn từ db
            this.getVaiTroCoSan();
<<<<<<< HEAD

=======
            this.getTrangThaiCoSan();

            //Mặc định nút thêm được kích hoạt, nút sửa bị vô hiệu hóa
>>>>>>> 3316b5bb2ca6c031132a68e5c07e8d71446aa92a
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
<<<<<<< HEAD
=======
            //Datatable là tải toàn bộ table về bộ nhớ => có thể chậm 
            //dùng cho: 🔸 Cần hiển thị dữ liệu lên DataGridView, ComboBox, ListView,...

            // còn sqldatareader: 🔸 Dùng để đọc dữ liệu từ cơ sở dữ liệu một cách nhanh chóng và hiệu quả.
            //Cho việc truy xuất và hiện thị cột - dòng
>>>>>>> 3316b5bb2ca6c031132a68e5c07e8d71446aa92a
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

<<<<<<< HEAD
                    //Hiển thị tên vai trò -> mã vai trò là giá trị để truy xuất
=======
                    //display: hiển thị ra bên ngoài - value : là giá trị để truy xuất hoặc dugnf để tính toán
>>>>>>> 3316b5bb2ca6c031132a68e5c07e8d71446aa92a
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
    }
}
