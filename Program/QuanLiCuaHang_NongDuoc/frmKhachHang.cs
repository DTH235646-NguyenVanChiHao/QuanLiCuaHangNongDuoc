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
    public partial class frmKhachHang : Form
    {
        //Connect db
        DBConnection db = new DBConnection();

     
        //Phân Trang
        private int TrangHIenTai = 1;
        private int TongTrang = 1;
        private int SoKHDuocHienThi = 10; //Mặc định số lượng hiển thị trên một trang
        private int TongKH = 1;


        public frmKhachHang()
        {
            InitializeComponent();
            LoadKhachHang();
        }


        //Hien thi trang
        private void HienThiSoTrang()
        {
            int TongTrang = (int)Math.Round((double)this.TongKH / this.SoKHDuocHienThi);

            lblTongTrang.Text = TongTrang == 0 ? "1" : TongTrang.ToString();
            lblTrangHienTai.Text = this.TrangHIenTai.ToString();
        }

        //

        private void CapNhatNutChuyenTrang()
        {
            //Nút trang đầu và trang trước
            if (this.TrangHIenTai == 1)
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPrev.Enabled = true;
            }
            //Nút trang cuối và trang sau
            if (this.TrangHIenTai == this.TongTrang)
            {
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnPrev.Enabled = true;
            }
        }
        //Tai khach hang
        public void ThongBao(string msg, frmThongBao.enmType type)
        {
            frmThongBao f = new frmThongBao();
            f.showAlert(msg, type);
        }

        //Tai khach hang
        public void LoadKhachHang()
            {
            //Lấy dữ liệu từ database và hiển thị lên datagridview
            using (SqlConnection cn = db.GetConnection())
            {
                cn.Open();
                //Đếm số lượng khách hàng = kết hợp tất cả các cột -> chỉ cần search là ra hết
                string where = "kh.MaKH LIKE '%' + @search + '%' OR kh.TenKH LIKE '%' + @search + '%' OR kh.DiaChi LIKE '%' + @search + '%' OR kh.SDT LIKE '%' + @search + '%' OR kh.Email LIKE '%' + @search + '%' OR kh.TrangThai LIKE '%' + @search + '%'";
                string query = $"select count(*) from KhachHang as kh where {where}";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@search", $"{txtSearch.Text}");
                    this.TongKH = (int)cmd.ExecuteScalar();

                    int TongTrang = (int)Math.Round((double)this.TongKH / this.SoKHDuocHienThi);
                    this.TongTrang = TongTrang == 0 ? 1 : TongTrang;
                }

                //Thêm khách hàng vào bảng 
                string query2 = $"SELECT kh.MaKH, kh.TenKH, kh.DiaChi, kh.SDT, kh.Email, kh.TrangThai FROM KhachHang AS kh WHERE (kh.MaKH LIKE '%' + @search + '%' OR kh.TenKH LIKE '%' + @search + '%' OR kh.DiaChi LIKE '%' + @search + '%' OR kh.SDT LIKE '%' + @search + '%' OR kh.Email LIKE '%' + @search + '%' OR kh.TrangThai LIKE '%' + @search + '%') ORDER BY kh.MaKH DESC OFFSET @offset ROWS FETCH NEXT @fetch ROWS ONLY;";
                using (SqlCommand cmd = new SqlCommand(query2, cn))
                {
                    //Reset lại số lượng khách hàng hiển thị
                    int rowIndex = (this.TrangHIenTai - 1) * this.SoKHDuocHienThi;
                    dgvDSKH.Rows.Clear();

                    //
                    cmd.Parameters.AddWithValue("@search", txtSearch.Text);

                    //Số trang bị bỏ qua
                    cmd.Parameters.AddWithValue("@offset", (this.TrangHIenTai - 1) * this.SoKHDuocHienThi);

                    //Số trang sẽ hiển thị
                    cmd.Parameters.AddWithValue("@fetch", this.SoKHDuocHienThi);
                    string index;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            index = "KH" + (rowIndex++).ToString();
                            dgvDSKH.Rows.Add(
                                index,
                                dr["MaKH"].ToString(),
                                dr["TenKH"].ToString(),
                                dr["DiaChi"].ToString(),
                                dr["Email"].ToString(),
                                dr["TrangThai"].ToString(),
                                dr["SDT"].ToString()
                                
                                
                            );
                        }
                    }
                }
                HienThiSoTrang();
                CapNhatNutChuyenTrang();
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadKhachHang();

            if (dgvDSKH.RowCount <= 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            subfrmKhachHang kh = new subfrmKhachHang(this);
            kh.btnSua.Enabled = false;
            kh.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy dữ liệu và thêm vào sub form
                subfrmKhachHang kh = new subfrmKhachHang(this);
                kh.btnSua.Enabled = true;

                kh.txtMaKH.Text = dgvDSKH.CurrentRow.Cells["MaKH"].Value.ToString();
                kh.txtTenKH.Text = dgvDSKH.CurrentRow.Cells["TenKH"].Value.ToString();
                kh.txtDiaChi.Text = dgvDSKH.CurrentRow.Cells["DiaChi"].Value.ToString();
                kh.txtSDT.Text = dgvDSKH.CurrentRow.Cells["SDT"].Value.ToString();
                kh.txtEmail.Text = dgvDSKH.CurrentRow.Cells["Email"].Value.ToString();
                kh.cbbTrangThai.Text = dgvDSKH.CurrentRow.Cells["TrangThai"].Value.ToString();

                kh.btnSua.Enabled = true;
                kh.btnThem.Enabled = false;

                //Các thuộc tính không được sửa
                kh.txtMaKH.Enabled = false;

                kh.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dg;
                dg = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();

                        //Xóa trong ChiTietHoaDon
                        string deleteChiTietHD = "DELETE FROM ChiTietHoaDon WHERE MaHD IN (SELECT MaHD FROM HoaDon WHERE MaKH = @MaKH);";
                        using (SqlCommand cmd = new SqlCommand(deleteChiTietHD, cn))
                        {
                            cmd.Parameters.AddWithValue("@MaKH", dgvDSKH.CurrentRow.Cells["MaKH"].Value.ToString());
                            cmd.ExecuteNonQuery();
                        }

                        //Xóa trong HoaDon
                        string deleteHoaDon = "DELETE FROM HoaDon WHERE MaKH = @MaKH";
                        using (SqlCommand cmd = new SqlCommand(deleteHoaDon, cn))
                        {
                            cmd.Parameters.AddWithValue("@MaKH", dgvDSKH.CurrentRow.Cells["MaKH"].Value.ToString());
                            cmd.ExecuteNonQuery();
                        }

                        //Xóa trong KhachHang
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM KhachHang WHERE MaKH = @MaKH", cn))
                        {
                            cmd.Parameters.AddWithValue("@MaKH", dgvDSKH.CurrentRow.Cells["MaKH"].Value.ToString());
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                ThongBao("Xóa khách hàng thành công!", frmThongBao.enmType.Success);
                                LoadKhachHang();
                            }
                            else
                            {
                                ThongBao("Xóa khách hàng thất bại!", frmThongBao.enmType.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            //Tải khách hàng đã có cập nhật nút chuyển trang
            if (this.TrangHIenTai > 1)
            {
                this.TrangHIenTai = 1;
                LoadKhachHang();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (this.TrangHIenTai > 1)
            {
                this.TrangHIenTai--;
                LoadKhachHang();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.TrangHIenTai < this.TongTrang)
            {
                this.TrangHIenTai++;
                LoadKhachHang();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (this.TrangHIenTai < this.TongTrang)
            {
                this.TrangHIenTai = this.TongTrang;
                LoadKhachHang();
            }
        }

        public bool toggle = false;
        private void btnSort_Click(object sender, EventArgs e)
        {
            toggle = !toggle;
            bool ascending = toggle;
            string asc = ascending ? "ASC" : "DESC";

            using (SqlConnection cn = db.GetConnection())
            {
                cn.Open();
                //Đếm số lượng khách hàng
                string where = "kh.MaKH LIKE '%' + @search + '%' OR kh.TenKH LIKE '%' + @search + '%' OR kh.DiaChi LIKE '%' + @search + '%' OR kh.SDT LIKE '%' + @search + '%' OR kh.Email LIKE '%' + @search + '%' OR kh.TrangThai LIKE '%' + @search + '%'";
                string query = $"SELECT COUNT(*) FROM KhachHang AS kh WHERE {where}";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@search", $"{txtSearch.Text}");
                    this.TongKH = (int)cmd.ExecuteScalar();

                    int TongTrang = (int)Math.Round((double)this.TongKH / this.SoKHDuocHienThi);
                    this.TongTrang = TongTrang == 0 ? 1 : TongTrang;
                }

                //Thêm khách hàng vào bảng 
                string query2 = $"SELECT kh.MaKH, kh.TenKH, kh.DiaChi, kh.SDT, kh.Email, kh.TrangThai FROM KhachHang AS kh WHERE (kh.MaKH LIKE '%' + @search + '%' OR kh.TenKH LIKE '%' + @search + '%' OR kh.DiaChi LIKE '%' + @search + '%' OR kh.SDT LIKE '%' + @search + '%' OR kh.Email LIKE '%' + @search + '%' OR kh.TrangThai LIKE '%' + @search + '%') ORDER BY kh.MaKH {asc} OFFSET @offset ROWS FETCH NEXT @fetch ROWS ONLY;";
                using (SqlCommand cmd = new SqlCommand(query2, cn))
                {
                    int rowIndex = (this.TrangHIenTai - 1) * this.SoKHDuocHienThi;
                    dgvDSKH.Rows.Clear();

                    cmd.Parameters.AddWithValue("@search", txtSearch.Text);
                    cmd.Parameters.AddWithValue("@offset", (this.TrangHIenTai - 1) * this.SoKHDuocHienThi);
                    cmd.Parameters.AddWithValue("@fetch", this.SoKHDuocHienThi);

                    string index;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            index = "KH" + (rowIndex++).ToString();
                            dgvDSKH.Rows.Add(
                                index,
                                dr["MaKH"].ToString(),
                                dr["TenKH"].ToString(),
                                dr["DiaChi"].ToString(),
                                dr["SDT"].ToString(),
                                dr["Email"].ToString(),
                                dr["TrangThai"].ToString()
                            );
                        }
                    }
                }
                HienThiSoTrang();
                CapNhatNutChuyenTrang();
            }
        }

       
    }

      
}
