using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLiCuaHang_NongDuoc
{
    public partial class subfrmLichSuPhieuNhap : Form
    {
        DBConnection db = new DBConnection();
        private frmLichSuPhieuNhap lspn;
        private bool isExist;

        // Constructor cho chế độ THÊM MỚI
        public subfrmLichSuPhieuNhap(frmLichSuPhieuNhap parent)
        {
            InitializeComponent();
            this.lspn = parent;
     

            //Them
            btnSua.Enabled = false;
            btnThem.Enabled = true;

            //
            txtGiaMua.Enabled = true;
        }

        // Constructor cho chế độ SỬA
       

        public void ThongBao(string msg, frmThongBao.enmType type)
        {
            frmThongBao f = new frmThongBao();
            f.showAlert(msg, type);
        }



       public void LoadComboBoxNhanVien()
        {
            try
            {
                using (SqlConnection cn = db.GetConnection())
                {
                    cn.Open();

                    DataTable dt = new DataTable();
                    string query = "SELECT MaNhanVien , TenNhanVien FROM NhanVien";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, cn))
                    {

                        da.Fill(dt);

                    }
                    cbbMaNhanVien.DataSource = dt;
                    cbbMaNhanVien.DisplayMember = "TenNhanVien";
                    cbbMaNhanVien.ValueMember = "MaNhanVien";

                    //Mặc định không chọn giá trị nào
                    cbbMaNhanVien.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                ThongBao("Lỗi load nhân viên: " + ex.Message, frmThongBao.enmType.Error);
            }
        }

        public void LoadComboBoxNhaCC()
        {
            try
            {
                using (SqlConnection cn = db.GetConnection())
                {

                     
                    DataTable dt = new DataTable();
                    string query = "SELECT MaNhaCC ,TenNhaCC FROM NhaCC";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, cn))
                    {

                        da.Fill(dt);

                    }
                    cbbMaNhaCC.DataSource = dt;
                    cbbMaNhaCC.DisplayMember = "TenNhaCC";
                    cbbMaNhaCC.ValueMember = "MaNhaCC";

                    //Mặc định không chọn giá trị nào
                    cbbMaNhaCC.SelectedIndex = -1;
                    cn.Open();
                   
                    
                }
            }
            catch (Exception ex)
            {
                ThongBao("Lỗi load nhà cung cấp: " + ex.Message, frmThongBao.enmType.Error);
            }
        }

        
       

       
        

        

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            CalculateThanhTien();
        }

        private void CalculateThanhTien()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSoLuong.Text) && !string.IsNullOrEmpty(txtGiaMua.Text))
                {
                    int soLuong = int.Parse(txtSoLuong.Text);
                    decimal giaMua = decimal.Parse(txtGiaMua.Text.Replace(",", ""));
                    decimal thanhTien = soLuong * giaMua;
                    txtThanhTien.Text = string.Format("{0:N0}", thanhTien);
                }
            }
            catch
            {
                txtThanhTien.Text = "0";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaPhieuNhap.Text))
            {
                ThongBao("Vui lòng nhập mã phiếu nhập!", frmThongBao.enmType.Warning);
                return false;
            }

            if (cbbMaNhanVien.SelectedValue == null)
            {
                ThongBao("Vui lòng chọn nhân viên!", frmThongBao.enmType.Warning);
                return false;
            }

            if (cbbMaNhaCC.SelectedValue == null)
            {
                ThongBao("Vui lòng chọn nhà cung cấp!", frmThongBao.enmType.Warning);
                return false;
            }

            

            if (string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                ThongBao("Vui lòng nhập số lượng!", frmThongBao.enmType.Warning);
                return false;
            }

            int soLuong;
            if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong <= 0)
            {
                ThongBao("Số lượng phải là số nguyên dương!", frmThongBao.enmType.Warning);
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
                if (!ValidateInput()) return;

                try
                {
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();
                        // Bước 1: Thêm phiếu nhập
                    string insertPN = @"INSERT INTO PhieuNhap (MaPhieuNhap, NgayNhap, MaNhanVien, MaNhaCC) 
                                                  VALUES (@MaPN, @NgayNhap, @MaNV, @MaNhaCC)";
                    using (SqlCommand cmd = new SqlCommand(insertPN, cn))
                    {
                        cmd.Parameters.AddWithValue("@MaPN", txtMaPhieuNhap.Text.Trim());
                        cmd.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value);
                        cmd.Parameters.AddWithValue("@MaNV", cbbMaNhanVien.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@MaNhaCC", cbbMaNhaCC.SelectedValue.ToString());
                        cmd.ExecuteNonQuery();
                    }

                                // Bước 2: Thêm chi tiết phiếu nhập
                     string insertCTPN = @"INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSP, SoLuong, ThanhTien) 
                                                    VALUES (@MaPN, @MaSP, @SoLuong, @ThanhTien)";
                    using (SqlCommand cmd = new SqlCommand(insertCTPN, cn))
                    {
                        cmd.Parameters.AddWithValue("@MaPN", txtMaPhieuNhap.Text.Trim());

                        cmd.Parameters.AddWithValue("@SoLuong", int.Parse(txtSoLuong.Text));
                        cmd.Parameters.AddWithValue("@ThanhTien", decimal.Parse(txtThanhTien.Text.Replace(",", "")));
                        cmd.ExecuteNonQuery();
                    }

                   
                        // Bước 3: Cập nhật số lượng sản phẩm trong kho
                        string updateStock = @"UPDATE SanPham 
                                                     SET SoLuongConLai = SoLuongConLai + @SoLuong 
                                                     WHERE MaSP = @MaSP";
                        using (SqlCommand cmd = new SqlCommand(updateStock, cn))
                        {
                            cmd.Parameters.AddWithValue("@MaSP", txtMaSP.Text.Trim());
                            cmd.Parameters.AddWithValue("@SoLuong", int.Parse(txtSoLuong.Text));
                            cmd.ExecuteNonQuery();
                        }
                    





                     ThongBao("Thêm phiếu nhập thành công!", frmThongBao.enmType.Success);
                     this.lspn.LoadPhieuNhap();
                     this.Close();
                        
                       
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm phiếu nhâp " + ex.Message);
                    
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                DialogResult dg;
                dg = MessageBox.Show("Bạn có chắc muốn sửa phiếu nhập này không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(dg == DialogResult.Yes)
                {
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();

                                //Sửa Sản phẩm: Tang so luong trong kkho
                                string SanPham = @"UPDATE SanPham 
                                                 SET SoLuongConLai = SoLuongConLai + @SoLuong 
                                                 WHERE MaSP = @MaSP";
                                using (SqlCommand cmd = new SqlCommand(SanPham, cn))
                                {
                                    cmd.Parameters.AddWithValue("@MaSP", txtMaSP.Text.Trim());
                                    cmd.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(txtSoLuong.Text));
                                    cmd.ExecuteNonQuery();
                                }
                        

                                // Bước 2: Cập nhật phiếu nhập
                                string updatePN = @"UPDATE PhieuNhap 
                                              SET NgayNhap = @NgayNhap, MaNhanVien = @MaNV, MaNhaCC = @MaNhaCC 
                                              WHERE MaPhieuNhap = @MaPN";
                                using (SqlCommand cmd = new SqlCommand(updatePN, cn))
                                {
                                    cmd.Parameters.AddWithValue("@MaPN", txtMaPhieuNhap.Text.Trim());
                                    cmd.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value);
                                    cmd.Parameters.AddWithValue("@MaNV", cbbMaNhanVien.SelectedValue.ToString());
                                    cmd.Parameters.AddWithValue("@MaNhaCC", cbbMaNhaCC.SelectedValue.ToString());
                                    cmd.ExecuteNonQuery();
                                }

                                // Bước 3: Cập nhật chi tiết phiếu nhập
                                string updateCTPN = @"UPDATE ChiTietPhieuNhap 
                                                SET SoLuong = @SoLuong, ThanhTien = @ThanhTien, MaSP = @MaSP 
                                                WHERE MaPhieuNhap = @MaPN AND MaSP = @MaSP";
                                using (SqlCommand cmd = new SqlCommand(updateCTPN, cn))
                                {
                                    cmd.Parameters.AddWithValue("@MaPN", txtMaPhieuNhap.Text.Trim());

                                    cmd.Parameters.AddWithValue("@MaSP", txtMaSP.Text.Trim());
                                    cmd.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(txtSoLuong.Text));
                                    cmd.Parameters.AddWithValue("@ThanhTien", decimal.Parse(txtThanhTien.Text.Replace(",", "")));
                                    cmd.ExecuteNonQuery();
                                }

                                
                                ThongBao("Cập nhật phiếu nhập thành công!", frmThongBao.enmType.Success);
                                this.lspn.LoadPhieuNhap();
                                this.Close();
                           
                        
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật phiếu nhập: " + ex.Message);
            }
        }

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {
            try {
                using (SqlConnection cn = db.GetConnection())
                {
                    cn.Open();

                    string query = "SELECT TenSP , GiaMua from SanPham where MaSP = @MaSP";
                    using (SqlCommand cm = new SqlCommand(query, cn))
                    {
                        cm.Parameters.AddWithValue("@MaSP", $"{txtMaSP.Text.Trim()}");
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                txtTenSP.Text = dr["TenSP"].ToString();
                                txtGiaMua.Text = dr["GiaMua"].ToString();
                                this.isExist = true;
                            }
                            else
                            {
                                subfrmSanPham sp = new subfrmSanPham();
                                sp.btnSua.Enabled = false;
                                sp.btnThem.Enabled = true;

                                sp.Show();

                            }
                        }
                    }
                }
                
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm mã sản phẩm: " + ex, "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            if(txtSoLuong.Text != "")
            {
                CalculateThanhTien();
            }
        }

        private void subfrmLichSuPhieuNhap_Load_1(object sender, EventArgs e)
        {
            LoadComboBoxNhanVien();
            LoadComboBoxNhaCC();
        }
    }
    }
