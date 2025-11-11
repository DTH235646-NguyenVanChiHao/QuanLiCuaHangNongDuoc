using System;
using System.Collections;
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
    public partial class subfrmKhachHang : Form
    {
        //Connect sql server
        DBConnection db = new DBConnection();

        //Dùng để tái kích hoạt form tải lại table()
        frmKhachHang kh;

        //anchor
        private bool isKH = true;

        public subfrmKhachHang(frmKhachHang khachhang)
        {
            InitializeComponent();
            this.kh = khachhang;

            //Lấy trạng thái có sẵn
            this.getTrangThaiCoSan();

            //Mặc định nút thêm được kích hoạt, nút sửa bị vô hiệu hóa
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = false;

            //Anchor
            
        }


        public subfrmKhachHang()
        {
            InitializeComponent();
       

            //Lấy trạng thái có sẵn
            this.getTrangThaiCoSan();

            //Mặc định nút thêm được kích hoạt, nút sửa bị vô hiệu hóa
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = false;

            //
            this.isKH = false;
        }
        public void ThongBao(string msg, frmThongBao.enmType type)
        {
            frmThongBao f = new frmThongBao();
            f.showAlert(msg, type);
        }

        public bool KiemTraGiaTriNhap()
        {
            if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (cbbTrangThai.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
        }

        //======================================Các hàm xử lí
        public void clear()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            cbbTrangThai.SelectedIndex = -1;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
        }

        public void getTrangThaiCoSan()
        {
            try
            {
                string[] dt = { "Thân thiết", "Không thân thiết" };

                cbbTrangThai.DataSource = dt;
                cbbTrangThai.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy trạng thái có sẵn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraGiaTriNhap())
                {
                    return;
                }

                DialogResult dg;
                dg = MessageBox.Show("Bạn có chắc muốn thêm khách hàng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();
                        //Ma KH Tu tao
                        using (SqlCommand cmd = cn.CreateCommand())
                        {
                            cmd.CommandText = "INSERT INTO KhachHang (MaKH,TenKH, DiaChi, SDT, Email, TrangThai) " +
                                       "VALUES (@MaKH,@TenKH, @DiaChi, @SDT, @Email, @TrangThai)";
                            cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                            cmd.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
                            cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                            cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("@TrangThai", cbbTrangThai.SelectedValue);

                            cmd.ExecuteNonQuery();
                        }
                        clear();
                        this.Close();

                        this.kh.LoadKhachHang();
                        this.ThongBao("Thêm khách hàng thành công!", frmThongBao.enmType.Success);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraGiaTriNhap())
                {
                    return;
                }

                DialogResult dg;
                dg = MessageBox.Show("Bạn có chắc muốn sửa khách hàng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();
                        using (SqlCommand cmd = cn.CreateCommand())
                        {
                            cmd.CommandText = "UPDATE KhachHang SET TenKH = @TenKH, DiaChi = @DiaChi, SDT = @SDT, Email = @Email, TrangThai = @TrangThai " +
                                       "WHERE MaKH = @MaKH";

                            cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                            cmd.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
                            cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                            cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("@TrangThai", cbbTrangThai.SelectedValue);

                            cmd.ExecuteNonQuery();
                        }
                        clear();
                        this.Close();

                        if (isKH)
                        {
                            this.kh.LoadKhachHang();
                            this.ThongBao("Sửa khách hàng thành công!", frmThongBao.enmType.Success);
                        }

                     
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}