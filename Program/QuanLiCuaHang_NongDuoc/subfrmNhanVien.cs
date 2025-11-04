using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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

        frmNhanVien nv;
        public subfrmNhanVien(frmNhanVien nvList)
        {
            InitializeComponent();
            this.nv = nvList;

            //lấy vai trò + Trạng thái có sẵn từ db
            this.getVaiTroCoSan();

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

                    //Hiển thị tên vai trò -> mã vai trò là giá trị để truy xuất
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
