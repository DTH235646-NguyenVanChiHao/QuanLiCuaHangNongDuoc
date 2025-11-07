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
    public partial class frmNhaCungCap : Form
    {
        //Connect db
        DBConnection db = new DBConnection();

        //Phân Trang
        private int TrangHienTai = 1;
        private int TongTrang = 1;
        private int SoNCCDuocHienThi = 10; //Mặc định số lượng hiển thị trên một trang
        private int TongNCC = 1;

        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        public void ThongBao(string msg, frmThongBao.enmType type)
        {
            frmThongBao f = new frmThongBao();
            f.showAlert(msg, type);
        }

        //Hien thi trang
        private void HienThiSoTrang()
        {
            int TongTrang = (int)Math.Ceiling((double)this.TongNCC / this.SoNCCDuocHienThi);

            lblTongTrang.Text = TongTrang == 0 ? "1" : TongTrang.ToString();
            lblTrangHienTai.Text = this.TrangHienTai.ToString();
        }

        private void CapNhatNutChuyenTrang()
        {
            //Nút trang đầu và trang trước
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
            //Nút trang cuối và trang sau
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

        //Tai nha cung cap
        public void LoadNhaCungCap()
        {
            //Lấy dữ liệu từ database và hiển thị lên datagridview
            using (SqlConnection cn = db.GetConnection())
            {
                cn.Open();
                //Đếm số lượng nhà cung cấp
                string where = "ncc.MaNhaCC LIKE '%' + @search + '%' OR ncc.TenNhaCC LIKE '%' + @search + '%' OR ncc.DiaChi LIKE '%' + @search + '%' OR ncc.SDT LIKE '%' + @search + '%' OR ncc.Email LIKE '%' + @search + '%'";
                string query = $"SELECT COUNT(*) FROM NhaCungCap AS ncc WHERE {where}";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@search", $"{txtSearch.Text}");
                    this.TongNCC = (int)cmd.ExecuteScalar();

                    int TongTrang = (int)Math.Ceiling((double)this.TongNCC / this.SoNCCDuocHienThi);
                    this.TongTrang = TongTrang == 0 ? 1 : TongTrang;
                }

                //Thêm nhà cung cấp vào bảng 
                string query2 = $"SELECT ncc.MaNhaCC, ncc.TenNhaCC, ncc.DiaChi, ncc.SDT, ncc.Email FROM NhaCungCap AS ncc WHERE (ncc.MaNhaCC LIKE '%' + @search + '%' OR ncc.TenNhaCC LIKE '%' + @search + '%' OR ncc.DiaChi LIKE '%' + @search + '%' OR ncc.SDT LIKE '%' + @search + '%' OR ncc.Email LIKE '%' + @search + '%') ORDER BY ncc.MaNhaCC DESC OFFSET @offset ROWS FETCH NEXT @fetch ROWS ONLY;";
                using (SqlCommand cmd = new SqlCommand(query2, cn))
                {
                    int rowIndex = (this.TrangHienTai - 1) * this.SoNCCDuocHienThi;
                    dgvDSNCC.Rows.Clear();

                    cmd.Parameters.AddWithValue("@search", txtSearch.Text);
                    cmd.Parameters.AddWithValue("@offset", (this.TrangHienTai - 1) * this.SoNCCDuocHienThi);
                    cmd.Parameters.AddWithValue("@fetch", this.SoNCCDuocHienThi);

                    string index;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            index = "NCC" + (rowIndex++).ToString();
                            dgvDSNCC.Rows.Add(
                                index,
                                dr["MaNhaCC"].ToString(),
                                dr["TenNhaCC"].ToString(),
                                dr["DiaChi"].ToString(),
                                dr["SDT"].ToString(),
                                dr["Email"].ToString()
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
            LoadNhaCungCap();

            if (dgvDSNCC.RowCount <= 0)
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            subfrmNhaCungCap ncc = new subfrmNhaCungCap(this);
            ncc.btnSua.Enabled = false;
            ncc.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy dữ liệu và thêm vào sub form
                subfrmNhaCungCap ncc = new subfrmNhaCungCap(this);
                ncc.btnSua.Enabled = true;

                ncc.txtMaNhaCC.Text = dgvDSNCC.CurrentRow.Cells["MaNhaCC"].Value.ToString();
                ncc.txtTenNhaCC.Text = dgvDSNCC.CurrentRow.Cells["TenNhaCC"].Value.ToString();
                ncc.txtDiaChi.Text = dgvDSNCC.CurrentRow.Cells["DiaChi"].Value.ToString();
                ncc.txtSDT.Text = dgvDSNCC.CurrentRow.Cells["SDT"].Value.ToString();
                ncc.txtEmail.Text = dgvDSNCC.CurrentRow.Cells["Email"].Value.ToString();

                ncc.btnSua.Enabled = true;
                ncc.btnThem.Enabled = false;

                //Các thuộc tính không được sửa
                ncc.txtMaNhaCC.Enabled = false;

                ncc.Show();
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
                dg = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();

                        //Xóa trong ChiTietPhieuNhap
                        string deleteChiTietPhieuNhap = "DELETE FROM ChiTietPhieuNhap WHERE MaPhieuNhap IN (SELECT MaPhieuNhap FROM PhieuNhap WHERE MaNhaCC = @MaNhaCC);";
                        using (SqlCommand cmd = new SqlCommand(deleteChiTietPhieuNhap, cn))
                        {
                            cmd.Parameters.AddWithValue("@MaNhaCC", dgvDSNCC.CurrentRow.Cells["MaNhaCC"].Value.ToString());
                            cmd.ExecuteNonQuery();
                        }

                        //Xóa trong PhieuNhap
                        string deletePhieuNhap = "DELETE FROM PhieuNhap WHERE MaNhaCC = @MaNhaCC";
                        using (SqlCommand cmd = new SqlCommand(deletePhieuNhap, cn))
                        {
                            cmd.Parameters.AddWithValue("@MaNhaCC", dgvDSNCC.CurrentRow.Cells["MaNhaCC"].Value.ToString());
                            cmd.ExecuteNonQuery();
                        }

                        //Xóa trong NhaCungCap
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM NhaCungCap WHERE MaNhaCC = @MaNhaCC", cn))
                        {
                            cmd.Parameters.AddWithValue("@MaNhaCC", dgvDSNCC.CurrentRow.Cells["MaNhaCC"].Value.ToString());
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                ThongBao("Xóa nhà cung cấp thành công!", frmThongBao.enmType.Success);
                                LoadNhaCungCap();
                            }
                            else
                            {
                                ThongBao("Xóa nhà cung cấp thất bại!", frmThongBao.enmType.Error);
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
                LoadNhaCungCap();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (this.TrangHienTai > 1)
            {
                this.TrangHienTai--;
                LoadNhaCungCap();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.TrangHienTai < this.TongTrang)
            {
                this.TrangHienTai++;
                LoadNhaCungCap();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (this.TrangHienTai < this.TongTrang)
            {
                this.TrangHienTai = this.TongTrang;
                LoadNhaCungCap();
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
                //Đếm số lượng nhà cung cấp
                string where = "ncc.MaNhaCC LIKE '%' + @search + '%' OR ncc.TenNhaCC LIKE '%' + @search + '%' OR ncc.DiaChi LIKE '%' + @search + '%' OR ncc.SDT LIKE '%' + @search + '%' OR ncc.Email LIKE '%' + @search + '%'";
                string query = $"SELECT COUNT(*) FROM NhaCungCap AS ncc WHERE {where}";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@search", $"{txtSearch.Text}");
                    this.TongNCC = (int)cmd.ExecuteScalar();

                    int TongTrang = (int)Math.Ceiling((double)this.TongNCC / this.SoNCCDuocHienThi);
                    this.TongTrang = TongTrang == 0 ? 1 : TongTrang;
                }

                //Thêm nhà cung cấp vào bảng
                string query2 = $"SELECT ncc.MaNhaCC, ncc.TenNhaCC, ncc.DiaChi, ncc.SDT, ncc.Email FROM NhaCungCap AS ncc WHERE (ncc.MaNhaCC LIKE '%' + @search + '%' OR ncc.TenNhaCC LIKE '%' + @search + '%' OR ncc.DiaChi LIKE '%' + @search + '%' OR ncc.SDT LIKE '%' + @search + '%' OR ncc.Email LIKE '%' + @search + '%') ORDER BY ncc.MaNhaCC {asc} OFFSET @offset ROWS FETCH NEXT @fetch ROWS ONLY;";
                using (SqlCommand cmd = new SqlCommand(query2, cn))
                {
                    int rowIndex = (this.TrangHienTai - 1) * this.SoNCCDuocHienThi;
                    dgvDSNCC.Rows.Clear();

                    cmd.Parameters.AddWithValue("@search", txtSearch.Text);
                    cmd.Parameters.AddWithValue("@offset", (this.TrangHienTai - 1) * this.SoNCCDuocHienThi);
                    cmd.Parameters.AddWithValue("@fetch", this.SoNCCDuocHienThi);

                    string index;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            index = "NCC" + (rowIndex++).ToString();
                            dgvDSNCC.Rows.Add(
                                index,
                                dr["MaNhaCC"].ToString(),
                                dr["TenNhaCC"].ToString(),
                                dr["DiaChi"].ToString(),
                                dr["SDT"].ToString(),
                                dr["Email"].ToString()
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