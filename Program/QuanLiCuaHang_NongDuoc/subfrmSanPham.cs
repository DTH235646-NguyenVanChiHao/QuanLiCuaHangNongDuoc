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
    public partial class subfrmSanPham : Form
    {
        //Dùng để tái kích hoạt form tải lại table()
        frmSanPham sp;

        //Connect sql server
        DBConnection db = new DBConnection();

        //
        public bool isSP = true;

        public subfrmSanPham(frmSanPham spList)
        {
            InitializeComponent();
            this.sp = spList;

            //Mặc định nút thêm được kích hoạt, nút sửa bị vô hiệu hóa
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = false;

            //Set giá trị mặc định cho ComboBox
            this.cbbDonViTinh.SelectedIndex = 0;
            this.cbbTrangThai.SelectedIndex = 0;
        }
        public subfrmSanPham()
        {
            InitializeComponent();
          

            //Mặc định nút thêm được kích hoạt, nút sửa bị vô hiệu hóa
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = false;

            //Set giá trị mặc định cho ComboBox
            this.cbbDonViTinh.SelectedIndex = 0;
            this.cbbTrangThai.SelectedIndex = 0;

            //
            this.isSP = false;
        }

        public void ThongBao(string msg, frmThongBao.enmType type)
        {
            frmThongBao f = new frmThongBao();
            f.showAlert(msg, type);
        }

        public bool KiemTraGiaTriNhap()
        {
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSP.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSP.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGiaMua.Text))
            {
                MessageBox.Show("Vui lòng nhập Giá mua!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaMua.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGiaBan.Text))
            {
                MessageBox.Show("Vui lòng nhập Giá bán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaBan.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập Số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return false;
            }

            if (cbbDonViTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Đơn vị tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbDonViTinh.Focus();
                return false;
            }

            if (cbbTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbTrangThai.Focus();
                return false;
            }

            // Kiểm tra giá trị số
            decimal giaMua, giaBan;
            int soLuong;

            if (!decimal.TryParse(txtGiaMua.Text, out giaMua) || giaMua < 0)
            {
                MessageBox.Show("Giá mua phải là số và lớn hơn hoặc bằng 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaMua.Focus();
                return false;
            }

            if (!decimal.TryParse(txtGiaBan.Text, out giaBan) || giaBan < 0)
            {
                MessageBox.Show("Giá bán phải là số và lớn hơn hoặc bằng 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaBan.Focus();
                return false;
            }

            if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên và lớn hơn hoặc bằng 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return false;
            }

            // Cảnh báo nếu giá bán nhỏ hơn giá mua
            if (giaBan < giaMua)
            {
                DialogResult dg = MessageBox.Show(
                    "Giá bán nhỏ hơn giá mua. Bạn có chắc chắn muốn tiếp tục?",
                    "Cảnh báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (dg == DialogResult.No)
                {
                    txtGiaBan.Focus();
                    return false;
                }
            }

            return true;
        }

        public void clear()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtMoTaSP.Text = "";
            txtGiaMua.Text = "";
            txtGiaBan.Text = "";
            txtSoLuong.Text = "";
            cbbDonViTinh.SelectedIndex = 0;
            cbbTrangThai.SelectedIndex = 0;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraGiaTriNhap())
                {
                    return;
                }

                DialogResult dg = MessageBox.Show(
                    "Bạn có chắc muốn thêm sản phẩm này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dg == DialogResult.Yes)
                {
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();

                        // Kiểm tra mã sản phẩm đã tồn tại chưa
                        string checkQuery = "SELECT COUNT(*) FROM SanPham WHERE MaSP = @MaSP";
                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, cn))
                        {
                            checkCmd.Parameters.AddWithValue("@MaSP", txtMaSP.Text.Trim());
                            int count = (int)checkCmd.ExecuteScalar();

                            if (count > 0)
                            {
                                MessageBox.Show(
                                    "Mã sản phẩm đã tồn tại! Vui lòng nhập mã khác.",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                                txtMaSP.Focus();
                                return;
                            }
                        }

                        // Thêm sản phẩm mới
                        string query = @"INSERT INTO SanPham 
                                        (MaSP, TenSP, MoTaSP, GiaMua, GiaBan, SoLuongConLai, DonViTinh, TrangThai) 
                                        VALUES 
                                        (@MaSP, @TenSP, @MoTaSP, @GiaMua, @GiaBan, @SoLuong, @DonViTinh, @TrangThai)";

                        using (SqlCommand cmd = new SqlCommand(query, cn))
                        {
                            cmd.Parameters.AddWithValue("@MaSP", txtMaSP.Text.Trim());
                            cmd.Parameters.AddWithValue("@TenSP", txtTenSP.Text.Trim());
                            cmd.Parameters.AddWithValue("@MoTaSP", txtMoTaSP.Text.Trim());
                            cmd.Parameters.AddWithValue("@GiaMua", decimal.Parse(txtGiaMua.Text));
                            cmd.Parameters.AddWithValue("@GiaBan", decimal.Parse(txtGiaBan.Text));
                            cmd.Parameters.AddWithValue("@SoLuong", int.Parse(txtSoLuong.Text));
                            cmd.Parameters.AddWithValue("@DonViTinh", cbbDonViTinh.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@TrangThai", cbbTrangThai.SelectedItem.ToString());

                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                if (isSP)
                                {
                                    this.ThongBao("Thêm sản phẩm thành công!", frmThongBao.enmType.Success);
                                    this.sp.LoadSanPham();
                                    this.Close();
                                }
                                clear();
                               
                            }
                            else
                            {
                                this.ThongBao("Thêm sản phẩm thất bại!", frmThongBao.enmType.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                DialogResult dg = MessageBox.Show(
                    "Bạn có chắc muốn sửa sản phẩm này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dg == DialogResult.Yes)
                {
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();

                        string query = @"UPDATE SanPham 
                                        SET TenSP = @TenSP, 
                                            MoTaSP = @MoTaSP, 
                                            GiaMua = @GiaMua, 
                                            GiaBan = @GiaBan, 
                                            SoLuongConLai = @SoLuong, 
                                            DonViTinh = @DonViTinh, 
                                            TrangThai = @TrangThai
                                        WHERE MaSP = @MaSP";

                        using (SqlCommand cmd = new SqlCommand(query, cn))
                        {
                            cmd.Parameters.AddWithValue("@MaSP", txtMaSP.Text.Trim());
                            cmd.Parameters.AddWithValue("@TenSP", txtTenSP.Text.Trim());
                            cmd.Parameters.AddWithValue("@MoTaSP", txtMoTaSP.Text.Trim());
                            cmd.Parameters.AddWithValue("@GiaMua", decimal.Parse(txtGiaMua.Text));
                            cmd.Parameters.AddWithValue("@GiaBan", decimal.Parse(txtGiaBan.Text));
                            cmd.Parameters.AddWithValue("@SoLuong", int.Parse(txtSoLuong.Text));
                            cmd.Parameters.AddWithValue("@DonViTinh", cbbDonViTinh.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@TrangThai", cbbTrangThai.SelectedItem.ToString());

                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                               
                                if (isSP)
                                {
                                    this.sp.LoadSanPham();
                                    this.ThongBao("Sửa sản phẩm thành công!", frmThongBao.enmType.Success);
                                }
                                clear();
                                this.Close();
                            }
                            else
                            {
                                this.ThongBao("Sửa sản phẩm thất bại!", frmThongBao.enmType.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện chỉ cho phép nhập số cho các trường giá và số lượng
        private void txtGiaMua_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép số, dấu thập phân và phím Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Chỉ cho phép một dấu thập phân
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép số, dấu thập phân và phím Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Chỉ cho phép một dấu thập phân
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép số và phím Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Định dạng giá tiền khi rời khỏi textbox
        private void txtGiaMua_Leave(object sender, EventArgs e)
        {
            decimal value;
            if (decimal.TryParse(txtGiaMua.Text, out value))
            {
                txtGiaMua.Text = value.ToString();
            }
        }

        private void txtGiaBan_Leave(object sender, EventArgs e)
        {
            decimal value;
            if (decimal.TryParse(txtGiaBan.Text, out value))
            {
                txtGiaBan.Text = value.ToString();
            }
        }
    }
}
