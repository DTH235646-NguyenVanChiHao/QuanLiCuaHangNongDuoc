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
    public partial class frmSanPham : Form
    {
        //Kết nối sql
        DBConnection db = new DBConnection();

        //Phân Trang
        private int TrangHienTai = 1;
        private int TongTrang = 1;
        private int SoSPDuocHienThi = 10;
        private int TongSP = 1;

        public frmSanPham()
        {
            InitializeComponent();
            LoadSanPham();
        }

        public void ThongBao(string msg, frmThongBao.enmType type)
        {
            frmThongBao frm = new frmThongBao();
            frm.showAlert(msg, type);
        }

        private void HienThiSoTrang()
        {
            int TongTrang = (int)Math.Ceiling((double)this.TongSP / this.SoSPDuocHienThi);
            lblTongTrang.Text = TongTrang == 0 ? "1" : TongTrang.ToString();
            lblTrangHienTai.Text = this.TrangHienTai.ToString();
        }

        private void CapNhatNutChuyenTrang()
        {
            if (this.TrangHienTai == 1)
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPrev.Enabled = true;
            }

            if (this.TrangHienTai == this.TongTrang)
            {
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }
        }

        public void LoadSanPham()
        {
            using (SqlConnection cn = db.GetConnection())
            {
                cn.Open();

                string where = @"
                    sp.MaSP LIKE @search 
                    OR sp.TenSP LIKE @search 
                    OR sp.MoTaSP LIKE @search 
                    OR sp.DonViTinh LIKE @search
                    OR sp.TrangThai LIKE @search";

                string query = $"SELECT COUNT(*) FROM SanPham AS sp WHERE {where}";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    this.TongSP = (int)cmd.ExecuteScalar();

                    int TongTrang = (int)Math.Ceiling((double)this.TongSP / this.SoSPDuocHienThi);
                    this.TongTrang = TongTrang == 0 ? 1 : TongTrang;
                }

                string query2 = @"
                    SELECT 
                        sp.MaSP,   
                        sp.TenSP, 
                        sp.MoTaSP, 
                        sp.GiaMua, 
                        sp.GiaBan, 
                        sp.SoLuongConLai, 
                        sp.DonViTinh, 
                        sp.TrangThai
                    FROM SanPham AS sp
                    WHERE 
                        sp.MaSP LIKE '%' + @search + '%' 
                        OR sp.TenSP LIKE '%' + @search + '%' 
                        OR sp.MoTaSP LIKE '%' + @search + '%' 
                        OR sp.DonViTinh LIKE '%' + @search + '%'
                        OR sp.TrangThai LIKE '%' + @search + '%'
                    ORDER BY sp.MaSP DESC
                    OFFSET @offset ROWS
                    FETCH NEXT @fetch ROWS ONLY;";

                using (SqlCommand cmd = new SqlCommand(query2, cn))
                {
                    int rowIndex = (this.TrangHienTai - 1) * this.SoSPDuocHienThi;
                    dgvDSSP.Rows.Clear();

                    cmd.Parameters.AddWithValue("@search", txtSearch.Text);
                    cmd.Parameters.AddWithValue("@offset", (this.TrangHienTai - 1) * this.SoSPDuocHienThi);
                    cmd.Parameters.AddWithValue("@fetch", this.SoSPDuocHienThi);

                    string index;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            
                            dgvDSSP.Rows.Add(
                             
                                dr["MaSP"].ToString(),
                                dr["TenSP"].ToString(),
                                dr["MoTaSP"].ToString(),
                                Convert.ToDecimal(dr["GiaMua"]).ToString("N0"),
                                Convert.ToDecimal(dr["GiaBan"]).ToString("N0"),
                                dr["SoLuongConLai"].ToString(),
                                dr["DonViTinh"].ToString(),
                                dr["TrangThai"].ToString()
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
            this.TrangHienTai = 1;
            LoadSanPham();

            if (dgvDSSP.RowCount <= 0)
            {
                ThongBao("Không tìm thấy sản phẩm phù hợp!", frmThongBao.enmType.Warning);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            subfrmSanPham sp = new subfrmSanPham(this);
            sp.btnSua.Enabled = false;
            sp.btnThem.Enabled = true;
            sp.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDSSP.CurrentRow == null)
                {
                    ThongBao("Vui lòng chọn sản phẩm cần sửa!", frmThongBao.enmType.Warning);
                    return;
                }

                subfrmSanPham sp = new subfrmSanPham(this);
                sp.btnSua.Enabled = true;
                sp.btnThem.Enabled = false;

                sp.txtMaSP.Text = dgvDSSP.CurrentRow.Cells["MaSP"].Value.ToString();
                sp.txtTenSP.Text = dgvDSSP.CurrentRow.Cells["TenSP"].Value.ToString();
                sp.txtMoTaSP.Text = dgvDSSP.CurrentRow.Cells["MoTaSP"].Value.ToString();
                sp.txtGiaMua.Text = dgvDSSP.CurrentRow.Cells["GiaMua"].Value.ToString().Replace(",", "");
                sp.txtGiaBan.Text = dgvDSSP.CurrentRow.Cells["GiaBan"].Value.ToString().Replace(",", "");
                sp.txtSoLuong.Text = dgvDSSP.CurrentRow.Cells["SoLuongConLai"].Value.ToString();
                sp.cbbDonViTinh.SelectedValue = dgvDSSP.CurrentRow.Cells["DonViTinh"].Value.ToString();
                sp.cbbTrangThai.Text = dgvDSSP.CurrentRow.Cells["TrangThai"].Value.ToString();

                sp.txtMaSP.Enabled = false;
                sp.Show();
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
                if (dgvDSSP.CurrentRow == null)
                {
                    ThongBao("Vui lòng chọn sản phẩm cần xóa!", frmThongBao.enmType.Warning);
                    return;
                }

                DialogResult dg = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa sản phẩm này không?\nLưu ý: Sẽ xóa tất cả dữ liệu liên quan!",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dg == DialogResult.Yes)
                {
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();
                        string maSP = dgvDSSP.CurrentRow.Cells["MaSP"].Value.ToString();

                        string deleteChiTietPhieuNhap = "DELETE FROM ChiTietPhieuNhap WHERE MaSP = @MaSP";
                        using (SqlCommand cmd = new SqlCommand(deleteChiTietPhieuNhap, cn))
                        {
                            cmd.Parameters.AddWithValue("@MaSP", maSP);
                            cmd.ExecuteNonQuery();
                        }

                        string deleteChiTietHD = "DELETE FROM ChiTietHoaDon WHERE MaSP = @MaSP";
                        using (SqlCommand cmd = new SqlCommand(deleteChiTietHD, cn))
                        {
                            cmd.Parameters.AddWithValue("@MaSP", maSP);
                            cmd.ExecuteNonQuery();
                        }

                        string deleteSanPham = "DELETE FROM SanPham WHERE MaSP = @MaSP";
                        using (SqlCommand cmd = new SqlCommand(deleteSanPham, cn))
                        {
                            cmd.Parameters.AddWithValue("@MaSP", maSP);
                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                ThongBao("Xóa sản phẩm thành công!", frmThongBao.enmType.Success);
                                LoadSanPham();
                            }
                            else
                            {
                                ThongBao("Xóa sản phẩm thất bại!", frmThongBao.enmType.Error);
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
            if (this.TrangHienTai > 1)
            {
                this.TrangHienTai = 1;
                LoadSanPham();
            }
        }

      
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.TrangHienTai < this.TongTrang)
            {
                this.TrangHienTai++;
                LoadSanPham();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (this.TrangHienTai < this.TongTrang)
            {
                this.TrangHienTai = this.TongTrang;
                LoadSanPham();
            }
        }

        public bool toggle = false;
        private void btnSort_Click(object sender, EventArgs e)
        {
            toggle = !toggle;
            string asc = toggle ? "ASC" : "DESC";

            using (SqlConnection cn = db.GetConnection())
            {
                cn.Open();

                string where = @"
                    sp.MaSP LIKE '%' + @search + '%' 
                    OR sp.TenSP LIKE '%' + @search + '%' 
                    OR sp.MoTaSP LIKE '%' + @search + '%' 
                    OR sp.DonViTinh LIKE '%' + @search + '%'
                    OR sp.TrangThai LIKE '%' + @search + '%'";

                string query = $"SELECT COUNT(*) FROM SanPham AS sp WHERE {where}";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@search", txtSearch.Text);
                    this.TongSP = (int)cmd.ExecuteScalar();

                    int TongTrang = (int)Math.Ceiling((double)this.TongSP / this.SoSPDuocHienThi);
                    this.TongTrang = TongTrang == 0 ? 1 : TongTrang;
                }

                string query2 = $@"
                    SELECT 
                        sp.MaSP, 
                        sp.TenSP, 
                        sp.MoTaSP, 
                        sp.GiaMua, 
                        sp.GiaBan, 
                        sp.SoLuongConLai, 
                        sp.DonViTinh, 
                        sp.TrangThai
                    FROM SanPham AS sp
                    WHERE 
                        sp.MaSP LIKE '%' + @search + '%' 
                        OR sp.TenSP LIKE '%' + @search + '%' 
                        OR sp.MoTaSP LIKE '%' + @search + '%' 
                        OR sp.DonViTinh LIKE '%' + @search + '%'
                        OR sp.TrangThai LIKE '%' + @search + '%'
                    ORDER BY sp.MaSP {asc}
                    OFFSET @offset ROWS
                    FETCH NEXT @fetch ROWS ONLY;";

                using (SqlCommand cmd = new SqlCommand(query2, cn))
                {
                    int rowIndex = (this.TrangHienTai - 1) * this.SoSPDuocHienThi;
                    dgvDSSP.Rows.Clear();

                    cmd.Parameters.AddWithValue("@search", txtSearch.Text);
                    cmd.Parameters.AddWithValue("@offset", (this.TrangHienTai - 1) * this.SoSPDuocHienThi);
                    cmd.Parameters.AddWithValue("@fetch", this.SoSPDuocHienThi);

             
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                           
                            dgvDSSP.Rows.Add(
                               
                                dr["MaSP"].ToString(),
                                dr["TenSP"].ToString(),
                                dr["MoTaSP"].ToString(),
                                Convert.ToDecimal(dr["GiaMua"]).ToString("N0"),
                                Convert.ToDecimal(dr["GiaBan"]).ToString("N0"),
                                dr["SoLuongConLai"].ToString(),
                                dr["DonViTinh"].ToString(),
                                dr["TrangThai"].ToString()
                            );
                        }
                    }
                }

                HienThiSoTrang();
                CapNhatNutChuyenTrang();
            }
        }

      

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (this.TrangHienTai > 1)
            {
                this.TrangHienTai--;
                LoadSanPham();
            }
        }
    }
}
