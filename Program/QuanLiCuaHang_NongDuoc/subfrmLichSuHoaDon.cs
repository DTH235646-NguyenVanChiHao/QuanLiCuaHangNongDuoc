    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    namespace QuanLiCuaHang_NongDuoc
    {
        public partial class subfrmLichSuHoaDon : Form
        {
            // Gọi lớp kết nối (giống subfrmNhanVien)
            DBConnection db = new DBConnection();


            frmLichSuaHoaDon lshd;

        //dùng để sửa và tải dữ liệu từ data grid view
        private DataGridViewRow TaiDuLieu;

            public subfrmLichSuHoaDon(frmLichSuaHoaDon lsHoaDon)
            {
                this.lshd = lsHoaDon;

                InitializeComponent();
                

                this.btnSua.Enabled = false;
                this.btnThem.Enabled = true;
                this.lshd = lshd;
            }
            // ✅ Constructor cho chế độ SỬA
            public subfrmLichSuHoaDon(frmLichSuaHoaDon lsHoaDon, DataGridViewRow row)
            {
                this.lshd = lsHoaDon;
                this.TaiDuLieu = row;

                InitializeComponent();

                this.btnSua.Enabled = true;
                this.btnThem.Enabled = false;
            }
        public void ThongBao(string msg, frmThongBao.enmType type)
            {
                frmThongBao frm = new frmThongBao();
                frm.showAlert(msg, type);
            }

            public bool KiemTraGiaTriNhap()
            {
                // Kiểm tra các ô nhập liệu trống
                if (string.IsNullOrWhiteSpace(txtMaHD.Text) ||
                    string.IsNullOrWhiteSpace(txtTenNhanVien.Text) ||
                    string.IsNullOrEmpty(txtMaKH.Text) ||
                    string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                    string.IsNullOrWhiteSpace(txtPhanTramGiam.Text) ||
                    string.IsNullOrWhiteSpace(txtThanhTien.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin hoá đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Kiểm tra ngày nhập
                if (dtpNgayNhap.Value == null)
                {
                    MessageBox.Show("Vui lòng chọn ngày nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (cbbMaSP.SelectedValue == null || cbbMaNhanVien.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn mã khách hàng hoặc chọn mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }



                return true;
            }
            public void clear()
            {
                // Xóa toàn bộ dữ liệu trong các ô nhập
                txtMaHD.Text = "";
                dtpNgayNhap.Value = DateTime.Now; // đặt lại ngày nhập về hiện tại
                cbbMaNhanVien.SelectedIndex = -1;

                txtTenNhanVien.Text = "";
          
                txtSoLuong.Text = "";
                txtPhanTramGiam.Text = "";
                txtThanhTien.Text = "";
                txtMaKH.Text = "";
                txtTenKhachHang.Text = "";
                cbbMaSP.SelectedIndex = -1;
                txtTenSP.Text = "";


                // Đặt lại trạng thái nút
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
                        string query = "SELECT MaNhanVien FROM NhanVien";
                        using (SqlCommand cmd = new SqlCommand(query, cn))
                        {

                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            // Giả sử bạn có một ComboBox để hiển thị mã nhân viên
                            cbbMaNhanVien.DataSource = dt;
                            cbbMaNhanVien.DisplayMember = "MaNhanVien";
                            cbbMaNhanVien.ValueMember = "MaNhanVien";
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy mã nhân viên: " + ex.Message);
                }
            }

            public void btnThem_Click(object sender, EventArgs e)
            {
                try
                {
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();

                        // 1️⃣ Thêm vào bảng HoaDon
                        string queryHoaDon = @"INSERT INTO HoaDon (MaHD, NgayNhap, MaNhanVien, MaKH, PhanTramGiam)
                               VALUES (@MaHD, @NgayNhap, @MaNhanVien, @MaKH, @PhanTramGiam);";

                        using (SqlCommand cmdHD = new SqlCommand(queryHoaDon, cn))
                        {
                            cmdHD.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                            cmdHD.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value);

                            // Lấy MaNhanVien từ combobox
                            cmdHD.Parameters.AddWithValue("@MaNhanVien", cbbMaNhanVien.SelectedValue);

                            // Lấy MaKH từ combobox khách hàng vừa thêm
                            cmdHD.Parameters.AddWithValue("@MaKH", txtMaKH.Text);

                            cmdHD.Parameters.AddWithValue("@PhanTramGiam",double.Parse(txtPhanTramGiam.Text));

                            cmdHD.ExecuteNonQuery(); // Thực thi thêm hóa đơn
                        }

                        // 2️⃣ Thêm vào bảng ChiTietHoaDon
                        string queryChiTiet = @"INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, ThanhTien)
                                VALUES (@MaHD, @MaSP, @SoLuong, @ThanhTien)";

                        using (SqlCommand cmdCT = new SqlCommand(queryChiTiet, cn))
                        {
                            cmdCT.Parameters.AddWithValue("@MaHD", txtMaHD.Text); // Lưu ý phải .Text
                            cmdCT.Parameters.AddWithValue("@MaSP", cbbMaSP.SelectedValue);
                            cmdCT.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(txtSoLuong.Text));
                            cmdCT.Parameters.AddWithValue("@ThanhTien", Convert.ToDouble(txtThanhTien.Text));

                            cmdCT.ExecuteNonQuery(); // Thực thi thêm chi tiết hóa đơn
                        }
                    }


                    this.ThongBao("Thêm hoá đơn thành công!", frmThongBao.enmType.Success);
                    this.lshd.LoadHoaDon();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm hoá đơn: " + ex.Message);
                }
            }

            private void btnSua_Click(object sender, EventArgs e)
            {
                try
                {
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();

                        // Cập nhật thông tin hoá đơn
                        string queryHD = @"UPDATE HoaDon 
                                           SET NgayNhap = @NgayNhap, MaNhanVien = @MaNhanVien, PhanTramGiam = @PhanTramGiam
                                           WHERE MaHD = @MaHD";

                      


                        // Cập nhật chi tiết hoá đơn
                        string queryCT = @"UPDATE ChiTietHoaDon 
                                           SET MaSP = @MaSP, SoLuong = @SoLuong, ThanhTien = @ThanhTien
                                           WHERE MaHD = @MaHD";
                        DialogResult dg;
                        dg = MessageBox.Show("Bạn có chắc muốn sửa hoá đơn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dg == DialogResult.Yes) {
                        // Cập nhật thông tin hoá đơn
                        using (SqlCommand cmdHD = new SqlCommand(queryHD, cn))
                        {
                            cmdHD.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value);
                            cmdHD.Parameters.AddWithValue("@MaNhanVien", cbbMaNhanVien.SelectedValue);
                            cmdHD.Parameters.AddWithValue("@PhanTramGiam", double.Parse(txtPhanTramGiam.Text));
                            cmdHD.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                            cmdHD.ExecuteNonQuery();
                        }


                        // Cập nhật chi tiết hoá đơn
                        using (SqlCommand cmdCT = new SqlCommand(queryCT, cn))
                        {

                            cmdCT.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                            cmdCT.Parameters.AddWithValue("@MaSP", cbbMaSP.SelectedValue);
                            cmdCT.Parameters.AddWithValue("@SoLuong", int.Parse(txtSoLuong.Text));
                            cmdCT.Parameters.AddWithValue("@ThanhTien", double.Parse(txtThanhTien.Text));
                            cmdCT.ExecuteNonQuery();
                        }


                        this.ThongBao("Cập nhật hoá đơn thành công!", frmThongBao.enmType.Success);
                        this.lshd.LoadHoaDon();

                    }
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật hoá đơn: " + ex.Message);
                }
            }

            private void cbbMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
            {
            
            if (cbbMaNhanVien.SelectedValue == null || cbbMaNhanVien.SelectedIndex == -1)
                return;
            try
                {
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();

                        string queryHD = "SELECT TenNhanVien FROM NhanVien WHERE MaNhanVien = @MaNV";

                        using (SqlCommand cmdHD = new SqlCommand(queryHD, cn))
                        {
                            // ✅ Nên dùng SelectedValue thay vì SelectedItem
                            cmdHD.Parameters.AddWithValue("@MaNV", cbbMaNhanVien.SelectedValue);

                            object result = cmdHD.ExecuteScalar();

                            if (result != null)
                                txtTenNhanVien.Text = result.ToString();
                            else
                                txtTenNhanVien.Text = "Khong tim thay ten Nhan vien";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy tên nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

            public void TinhTien()
            {
                try
                {

                    if (string.IsNullOrWhiteSpace(txtSoLuong.Text))
                    {
                        return;
                    }
                    
                    if (cbbMaSP.SelectedValue == null)
                    {
                        return;
                    }
                double thanhtien = 0;
                    using (SqlConnection cn = db.GetConnection())
                    {

                        cn.Open();

                        // Lấy thông tin sản phẩm: đơn giá và số lượng tồn kho
                        string query = "SELECT GiaBan, SoLuongConLai FROM SanPham WHERE MaSP = @MaSP";
                        using (SqlCommand cmd = new SqlCommand(query, cn))
                        {
                            cmd.Parameters.AddWithValue("@MaSP",cbbMaSP.SelectedValue);

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    double donGia = Convert.ToDouble(dr["GiaBan"]);
                                    int soLuongConLai = Convert.ToInt32(dr["SoLuongConLai"]);

                                    int soLuongMua = Convert.ToInt32(txtSoLuong.Text);
                                    double phanTramGiam = Convert.ToDouble(txtPhanTramGiam.Text);



                                    if (soLuongMua > soLuongConLai)
                                    {
                                        MessageBox.Show($"Sản phẩm chỉ còn {soLuongConLai} trong kho. Vui lòng nhập lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        txtSoLuong.Focus();
                                        return;
                                    }



                                    // Tính tiền sau giảm giá


                                    thanhtien = soLuongMua * donGia * (1 - phanTramGiam / 100);

                                    txtThanhTien.Text = thanhtien.ToString("N2");
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
            private void txtSoLuong_TextChanged(object sender, EventArgs e)
            {
                if (txtSoLuong.Text != "")
                    TinhTien();
            }




            public void GetMaSP()
            {
                try
                {
                    
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();
                        string query = "SELECT MaSP FROM SanPham";
                        using (SqlCommand cmd = new SqlCommand(query, cn))
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            // Giả sử bạn có một ComboBox để hiển thị mã khách hàng
                            cbbMaSP.DataSource = dt;
                            cbbMaSP.DisplayMember = "MaSP";
                            cbbMaSP.ValueMember = "MaSP";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy mã sản phẩm: " + ex.Message);
                }
            }
            private void cbbMaSP_SelectedIndexChanged(object sender, EventArgs e)
            {
                
                try
                {
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();

                        string queryHD = "SELECT TenSP FROM SanPham WHERE MaSP = @MaSP";

                        using (SqlCommand cmdHD = new SqlCommand(queryHD, cn))
                        {
                            // ✅ Nên dùng SelectedValue thay vì SelectedItem
                            cmdHD.Parameters.AddWithValue("@MaSP", cbbMaSP.SelectedValue);

                            object result = cmdHD.ExecuteScalar();

                            if (result != null)
                                txtTenSP.Text = result.ToString();
                            else
                                txtTenSP.Text = "Khong tim thay ten Nhan vien";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy Ten SP: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

          

        private void subfrmLichSuHoaDon_Load(object sender, EventArgs e)
        {
            this.GetMaNhanVien();
            this.GetMaSP();

            // ✅ NẾU LÀ CHẾ ĐỘ SỬA, LOAD DỮ LIỆU
            if (this.TaiDuLieu != null)
            {
                LoadDataForEdit();
            }
            else
            {
                // ✅ CHẾ ĐỘ THÊM: Reset ComboBox
                cbbMaNhanVien.SelectedIndex = -1;
                cbbMaSP.SelectedIndex = -1;
            }


        }

        

        private void LoadDataForEdit()
        {
            try
            {
                // ✅ Kiểm tra an toàn trước khi gán
                txtMaHD.Text = TaiDuLieu.Cells["MaHD"].Value?.ToString() ?? "";

                if (TaiDuLieu.Cells["NgayNhap"].Value != null)
                    dtpNgayNhap.Value = Convert.ToDateTime(TaiDuLieu.Cells["NgayNhap"].Value);

                // ✅ Set SelectedValue SAU KHI DataSource đã load xong
                if (TaiDuLieu.Cells["MaNhanVien"].Value != null)
                    cbbMaNhanVien.SelectedValue = TaiDuLieu.Cells["MaNhanVien"].Value.ToString();

                if (TaiDuLieu.Cells["MaSP"].Value != null)
                    cbbMaSP.SelectedValue = TaiDuLieu.Cells["MaSP"].Value.ToString();

                txtTenSP.Text = TaiDuLieu.Cells["TenSP"].Value?.ToString() ?? "";
                txtMaKH.Text = TaiDuLieu.Cells["MaKH"].Value?.ToString() ?? "";
                txtTenKhachHang.Text = TaiDuLieu.Cells["TenKH"].Value?.ToString() ?? "";
                txtTenNhanVien.Text = TaiDuLieu.Cells["TenNhanVien"].Value?.ToString() ?? "";

                txtSoLuong.Text = TaiDuLieu.Cells["SoLuong"].Value?.ToString() ?? "";
                txtThanhTien.Text = TaiDuLieu.Cells["ThanhTien"].Value?.ToString() ?? "";
                txtPhanTramGiam.Text = TaiDuLieu.Cells["PhanTramGiam"].Value?.ToString() ?? "";

                // ✅ Kiểm tra cột có tồn tại không
             
                   txtSDT.Text = TaiDuLieu.Cells["SDT"].Value?.ToString() ?? "";

              
                   txtGiaTien.Text = TaiDuLieu.Cells["GiaBan"].Value?.ToString() ?? "";

                txtMaHD.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = db.GetConnection())
                {
                    cn.Open();

                    string queryHD = "SELECT TenKH ,TrangThai , MaKH FROM KhachHang WHERE SDT = @SDT";

                    using (SqlCommand cmdHD = new SqlCommand(queryHD, cn))
                    {
                        // ✅ Nên dùng SelectedValue thay vì SelectedItem
                        cmdHD.Parameters.AddWithValue("@SDT", txtSDT.Text);

                        SqlDataReader dataReader = cmdHD.ExecuteReader();

                        if (dataReader.Read())
                        {
                            txtMaKH.Text = dataReader["MaKH"].ToString();
                            txtTenKhachHang.Text = dataReader["TenKH"].ToString();
                            if (dataReader["TrangThai"].ToString() == "Thân thiết")
                            {
                                txtPhanTramGiam.Text = "10";
                            }
                            else
                            {
                                txtPhanTramGiam.Text = "0";
                            }

                            txtMaKH.Enabled = false;
                            txtTenKhachHang.Enabled = false;
                            txtPhanTramGiam.Enabled = false;

                        }
                        else
                        {
                            txtMaKH.Text = "Hãy Nhập Mã KH...";
                            txtTenKhachHang.Text = "Hãy nhập tên khách hàng...";
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
    }
   }
