using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLiCuaHang_NongDuoc
{
    public partial class subfrmLichSuHoaDon : Form
    {
        DBConnection db = new DBConnection();
        frmLichSuaHoaDon lshd;

        public subfrmLichSuHoaDon(frmLichSuaHoaDon lsHoaDon)
        {
            InitializeComponent();
            this.lshd = lsHoaDon;   // Gán đúng biến
            this.btnSua.Enabled = false;
            this.btnThem.Enabled = true;
        }

        public void ThongBao(string msg, frmThongBao.enmType type)
        {
            frmThongBao frm = new frmThongBao();
            frm.showAlert(msg, type);
        }

        public bool KiemTraGiaTriNhap()
        {
            if (string.IsNullOrWhiteSpace(txtMaHD.Text) ||
                string.IsNullOrEmpty(txtMaKH.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                string.IsNullOrWhiteSpace(txtPhanTramGiam.Text) ||
                string.IsNullOrWhiteSpace(txtThanhTien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin hoá đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpNgayNhap.Value == null)
            {
                MessageBox.Show("Vui lòng chọn ngày nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cbbTenSP.SelectedValue == null || cbbTenNV.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn mã khách hàng hoặc chọn mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtPhanTramGiam.Text, out _) ||
                !int.TryParse(txtSoLuong.Text, out _) ||
                !decimal.TryParse(txtThanhTien.Text, out _))
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public void clear()
        {
            txtMaHD.Text = "";
            dtpNgayNhap.Value = DateTime.Now;
            cbbTenNV.SelectedIndex = -1;

            txtSoLuong.Text = "";
            txtPhanTramGiam.Text = "";
            txtThanhTien.Text = "";
            txtMaKH.Text = "";
            txtTenKhachHang.Text = "";
            cbbTenSP.SelectedIndex = -1;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
        }

        public void GetMaNhanVien()
        {
            try
            {
                using (SqlConnection cn = db.GetConnection())
                {



                    cn.Open();
                    DataTable dt = new DataTable();
                    string query = "SELECT MaNhanVien ,TenNhanVien FROM NhanVien";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, cn))
                    {

                        da.Fill(dt);

                    }
                    cbbTenNV.DataSource = dt;
                    cbbTenNV.DisplayMember = "TenNhanVien";
                    cbbTenNV.ValueMember = "MaNhanVien";

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã nhân viên: " + ex.Message);
            }
        }

        public void GetMaSP()
        {
            try
            {
                using (SqlConnection cn = db.GetConnection())
                {
                    cn.Open();
                    DataTable dt = new DataTable();
                    string query = "SELECT MaSP, TenSP FROM SanPham";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, cn))
                    {

                        da.Fill(dt);

                    }


                        cbbTenSP.DataSource = dt;
                        cbbTenSP.DisplayMember = "TenSP";
                        cbbTenSP.ValueMember = "MaSP";

                  
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã sản phẩm: " + ex.Message);
            }
        }

        private void TinhTien()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSoLuong.Text))
                    return;

                if (cbbTenSP.SelectedValue == null || cbbTenSP.SelectedValue is DataRowView)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (!decimal.TryParse(txtPhanTramGiam.Text, out decimal phanTramGiam))
                    phanTramGiam = 0;

                if (!int.TryParse(txtSoLuong.Text, out int soLuongMua) || soLuongMua <= 0)
                    return;

                 soLuongMua = Convert.ToInt32(txtSoLuong.Text);



                using (SqlConnection cn = db.GetConnection())
                {
                    cn.Open();
                    string query = "SELECT GiaBan, SoLuongConLai FROM SanPham WHERE MaSP = @MaSP";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@MaSP", cbbTenSP.SelectedValue.ToString());
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                decimal donGia = Convert.ToDecimal(dr["GiaBan"]);
                                int soLuongConLai = Convert.ToInt32(dr["SoLuongConLai"]);
                                phanTramGiam = decimal.Parse(txtPhanTramGiam.Text);

                                if (soLuongMua > soLuongConLai)
                                {
                                    MessageBox.Show($"Sản phẩm chỉ còn {soLuongConLai} trong kho. Vui lòng nhập lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtSoLuong.Focus();
                                    return;
                                }

                                decimal thanhTien = soLuongMua * donGia * (1 - phanTramGiam / 100);
                                txtThanhTien.Text = thanhTien.ToString("N2");
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy mã sản phẩm này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tiền hoặc kiểm tra số lượng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraGiaTriNhap()) return;

            try
            {
                using (SqlConnection cn = db.GetConnection())
                {
                    cn.Open();

                    string queryHoaDon = @"INSERT INTO HoaDon (MaHD, NgayNhap, MaNhanVien, MaKH, PhanTramGiam)
                                           VALUES (@MaHD, @NgayNhap, @MaNhanVien, @MaKH, @PhanTramGiam);";
                    using (SqlCommand cmdHD = new SqlCommand(queryHoaDon, cn))
                    {
                        cmdHD.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                        cmdHD.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value);
                        cmdHD.Parameters.AddWithValue("@MaNhanVien", cbbTenNV.SelectedValue);
                        cmdHD.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                        cmdHD.Parameters.Add("@PhanTramGiam", SqlDbType.Decimal).Value = decimal.Parse(txtPhanTramGiam.Text);
                        cmdHD.ExecuteNonQuery();
                    }

                    string queryChiTiet = @"INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, ThanhTien)
                                            VALUES (@MaHD, @MaSP, @SoLuong, @ThanhTien)";
                    using (SqlCommand cmdCT = new SqlCommand(queryChiTiet, cn))
                    {
                        cmdCT.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                        cmdCT.Parameters.AddWithValue("@MaSP", cbbTenSP.SelectedValue);
                        cmdCT.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(txtSoLuong.Text));
                        cmdCT.Parameters.Add("@ThanhTien", SqlDbType.Decimal).Value = decimal.Parse(txtThanhTien.Text);
                        cmdCT.ExecuteNonQuery();
                    }
                }

                ThongBao("Thêm hoá đơn thành công!", frmThongBao.enmType.Success);
                lshd.LoadHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm hoá đơn: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraGiaTriNhap()) return;

            DialogResult dg = MessageBox.Show("Bạn có chắc muốn sửa hoá đơn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg != DialogResult.Yes) return;

            try
            {
                using (SqlConnection cn = db.GetConnection())
                {
                    cn.Open();

                    string queryHD = @"UPDATE HoaDon 
                                       SET NgayNhap = @NgayNhap, MaNhanVien = @MaNhanVien, PhanTramGiam = @PhanTramGiam
                                       WHERE MaHD = @MaHD";
                    using (SqlCommand cmdHD = new SqlCommand(queryHD, cn))
                    {
                        cmdHD.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value);
                        cmdHD.Parameters.AddWithValue("@MaNhanVien", cbbTenNV.SelectedValue);
                        cmdHD.Parameters.Add("@PhanTramGiam", SqlDbType.Decimal).Value = decimal.Parse(txtPhanTramGiam.Text);
                        cmdHD.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                        cmdHD.ExecuteNonQuery();
                    }

                    string queryCT = @"UPDATE ChiTietHoaDon 
                                       SET MaSP = @MaSP, SoLuong = @SoLuong, ThanhTien = @ThanhTien
                                       WHERE MaHD = @MaHD";
                    using (SqlCommand cmdCT = new SqlCommand(queryCT, cn))
                    {
                        cmdCT.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                        cmdCT.Parameters.AddWithValue("@MaSP", cbbTenSP.SelectedValue);
                        cmdCT.Parameters.AddWithValue("@SoLuong", int.Parse(txtSoLuong.Text));
                        cmdCT.Parameters.Add("@ThanhTien", SqlDbType.Decimal).Value = decimal.Parse(txtThanhTien.Text);
                        cmdCT.ExecuteNonQuery();
                    }
                }

                ThongBao("Cập nhật hoá đơn thành công!", frmThongBao.enmType.Success);
                lshd.LoadHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật hoá đơn: " + ex.Message);
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSoLuong.Text))
                TinhTien();
        }

        private void subfrmLichSuHoaDon_Load(object sender, EventArgs e)
        {
            GetMaNhanVien();
            GetMaSP();
        }

        private void txtSDT_Leave(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = db.GetConnection())
                {
                    cn.Open();
                    string queryHD = "SELECT TenKH ,TrangThai , MaKH FROM KhachHang WHERE SDT = @SDT";
                    using (SqlCommand cmdHD = new SqlCommand(queryHD, cn))
                    {
                        cmdHD.Parameters.AddWithValue("@SDT", txtSDT.Text);
                        SqlDataReader dataReader = cmdHD.ExecuteReader();

                        if (dataReader.Read())
                        {
                            txtMaKH.Text = dataReader["MaKH"].ToString();
                            txtTenKhachHang.Text = dataReader["TenKH"].ToString();
                            txtPhanTramGiam.Text = (dataReader["TrangThai"].ToString() == "Thân thiết") ? "10" : "0";

                            txtMaKH.Enabled = false;
                            txtTenKhachHang.Enabled = false;
                            txtPhanTramGiam.Enabled = false;
                        }
                        else
                        {
                            subfrmKhachHang kh = new subfrmKhachHang();
                            kh.btnThem.Enabled = true;
                            kh.btnSua.Enabled = false;
                            kh.Show();

                         
                            txtPhanTramGiam.Text = "0";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy Ma KH: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbTenSP.SelectedIndex == -1)
            {
                return;
            }
            try
            {
                using (SqlConnection cn = db.GetConnection())
                {
                    cn.Open();
                    string queryHD = "SELECT GiaBan FROM SanPham WHERE MaSP = @MaSP";
                    using (SqlCommand cmdHD = new SqlCommand(queryHD, cn))
                    {
                        cmdHD.Parameters.AddWithValue("@MaSP", cbbTenSP.SelectedValue);
                        object result = cmdHD.ExecuteScalar();
                        txtGiaTien.Text = (result != null && result != DBNull.Value) ? Convert.ToDecimal(result).ToString("N2") : "0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy giá sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
