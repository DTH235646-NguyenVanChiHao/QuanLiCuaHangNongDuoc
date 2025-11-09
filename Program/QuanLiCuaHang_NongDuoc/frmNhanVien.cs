using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCuaHang_NongDuoc
{
    public partial class frmNhanVien : Form
    {


        //Kết nối sql
        DBConnection db = new DBConnection();

        //Phân Trang
        private int TrangHIenTai = 1;
        private int TongTrang = 1;
        private int SoNVDuocHienThi = 10;
        private int TongNV = 1;



        public frmNhanVien()
        {
            InitializeComponent();

            //load nhân viên
            LoadNhanVien();


        }

        public void ThongBao(string msg, frmThongBao.enmType type)
        {
            frmThongBao frm = new frmThongBao();
            frm.showAlert(msg, type);
        }



        private void HienThiSoTrang()
        {
            int TongTrang = (int)Math.Round((double)this.TongNV / this.SoNVDuocHienThi);

            lblTongTrang.Text = TongTrang == 0? "1" : TongTrang.ToString();
            lblTrangHienTai.Text = this.TrangHIenTai.ToString();
        }

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

        public void LoadNhanVien()
        {
            // txtTimKiemNV = "" => Hiển thị tất cả
            // ngược lại sẽ tìm kiếm 

            //Lấy dữ liệu từ database và hiển thị lên datagridview
            using (SqlConnection cn = db.GetConnection())
            {
                cn.Open();
                //Đém số lượng nhân viên = kết hợp tất cả các cột -> chỉ cần search là ra hết
                string where = @"
        nv.MaNhanVien LIKE @search 
        OR nv.TenNhanVien LIKE @search 
        OR nv.Email LIKE @search 
        OR nv.TrangThaiTaiKhoan LIKE @search ";
                string query = $"select count(*) from NhanVien as nv where {where}";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text  + "%");
                    this.TongNV = (int) cmd.ExecuteScalar();

                    int TongTrang = (int)Math.Round((double)this.TongNV / this.SoNVDuocHienThi);
                    this.TongTrang = TongTrang == 0?1:TongTrang;
                }

                //Thêm nhân viên vào bảng 
                string query2 = $"SELECT nv.MaNhanVien,  nv.TenNhanVien, nv.Email,   vt.VaiTro,   nv.TrangThaiTaiKhoan FROM NhanVien AS nv INNER JOIN VaiTro AS vt  ON nv.MaVaiTro = vt.MaVaiTro WHERE (nv.MaNhanVien LIKE '%' + @search + '%' OR    nv.TenNhanVien LIKE '%' + @search + '%' OR     nv.Email LIKE '%' + @search + '%' OR    vt.VaiTro LIKE '%' + @search + '%' OR\r\n     nv.TrangThaiTaiKhoan LIKE '%' + @search + '%')\r\nORDER BY nv.MaNhanVien DESC\r\nOFFSET @offset ROWS\r\nFETCH NEXT @fetch ROWS ONLY;";
                using (SqlCommand cmd = new SqlCommand(query2, cn))
                {
                    //Reset lại số lượng nhân viên hiển thị
                    // trang ht -1 = 0 => vi tri ban dau , sau do tiep dtuc
                    int rowIndex = (this.TrangHIenTai - 1) * this.SoNVDuocHienThi;
                    dgvDSNV.Rows.Clear();



                    //
                    cmd.Parameters.AddWithValue("@search", txtSearch.Text);

                    //Số trang bị bỏ qua
                    cmd.Parameters.AddWithValue("@offset", (this.TrangHIenTai - 1) * this.SoNVDuocHienThi);

                    //Số trang sẽ hiển thị
                    cmd.Parameters.AddWithValue("@fetch", this.SoNVDuocHienThi);
                    string index;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            index ="NV" + (rowIndex++).ToString() ;
                            dgvDSNV.Rows.Add(
                                index,
                                dr["MaNhanVien"].ToString(),
                                dr["TenNhanVien"].ToString(),
                                dr["Email"].ToString(),
                                dr["VaiTro"].ToString(),
                                dr["TrangThaiTaiKhoan"].ToString()
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
            LoadNhanVien();

            if (dgvDSNV.RowCount <= 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            subfrmNhanVien nv = new subfrmNhanVien(this);
            nv.btnSua.Enabled = false;
            nv.Show();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy dữ liệuv và thêm vào sub form
                subfrmNhanVien nv = new subfrmNhanVien(this);
                nv.btnSua.Enabled = true;

                nv.txtMaNhanVien.Text = dgvDSNV.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                nv.txtTenNV.Text = dgvDSNV.CurrentRow.Cells["TenNhanVien"].Value.ToString();
                nv.txtEmail.Text = dgvDSNV.CurrentRow.Cells["Email"].Value.ToString();

                //Không hiển thị mật khẩu cũ

                nv.cbbVaiTro.Text = dgvDSNV.CurrentRow.Cells["VaiTro"].Value.ToString();
                nv.cbbTrangThai.Text = dgvDSNV.CurrentRow.Cells["TrangThaiTaiKhoan"].Value.ToString();
              

                nv.btnSua.Enabled = true;
                nv.btnThem.Enabled = false;

                //Các thuộc tính không được sửa
                nv.txtMaNhanVien.Enabled = false;
              

                
                nv.Show();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try {

                DialogResult dg;
                dg = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    using (SqlConnection cn = db.GetConnection())
                    {
                         cn.Open();
                        //Xoa trong chitietphieunhap
                        string deleteChiTietPhieuNhap = "delete from ChiTietPhieuNhap where MaPhieuNhap IN (Select MaPhieuNhap from PhieuNhap where MaNhanVien =  @MaNV);";
                        using (SqlCommand cmd = new SqlCommand(deleteChiTietPhieuNhap, cn))
                        {
                            cmd.Parameters.AddWithValue("@MaNV", dgvDSNV.CurrentRow.Cells["MaNhanVien"].Value.ToString());
                            cmd.ExecuteNonQuery();

                        }
                        //xoá trong phiếu nhập
                        string deletePhieuNhap = "DELETE FROM PhieuNhap WHERE MaNhanVien =  @MaNV";
                        using (SqlCommand cmd = new SqlCommand(deletePhieuNhap, cn))
                        {
                            cmd.Parameters.AddWithValue("@MaNV", dgvDSNV.CurrentRow.Cells["MaNhanVien"].Value.ToString());
                            cmd.ExecuteNonQuery();

                        }

                        //Xoa trong ChiTietHoaDon
                        string deleteChiTietHD = "DELETE FROM ChiTietHoaDon\r\nWHERE MaHD IN (\r\n    SELECT MaHD\r\n    FROM HoaDon\r\n    WHERE MaNhanVien = @MaNV);";
                        using (SqlCommand cmd = new SqlCommand(deleteChiTietHD, cn))
                        {
                            cmd.Parameters.AddWithValue("@MaNV", dgvDSNV.CurrentRow.Cells["MaNhanVien"].Value.ToString());
                            cmd.ExecuteNonQuery();
                        
                        }
                        //Xoa trong HoaDon
                        string deleteHoaDon = "DELETE FROM HoaDon WHERE MaNhanVien =  @MaNV";
                        using (SqlCommand cmd = new SqlCommand(deleteHoaDon, cn))
                        {
                            cmd.Parameters.AddWithValue("@MaNV", dgvDSNV.CurrentRow.Cells["MaNhanVien"].Value.ToString());
                            cmd.ExecuteNonQuery();
                       
                        }
                        //Xoa trong NhanVien
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM NhanVien WHERE MaNhanVien = @MaNV", cn))
                            {
                                cmd.Parameters.AddWithValue("@MaNV", dgvDSNV.CurrentRow.Cells["MaNhanVien"].Value.ToString());
                                int result = cmd.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    ThongBao("Xóa nhân viên thành công!", frmThongBao.enmType.Success);
                                    LoadNhanVien();
                                }
                                else
                                {
                                    ThongBao("Xóa nhân viên thất bại!", frmThongBao.enmType.Error);
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
            //Tải nhân viên đã có cập nhật nút chuyển trang
            if(this.TrangHIenTai > 1) {                 
                this.TrangHIenTai = 1;
                LoadNhanVien();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if(this.TrangHIenTai > 1)
            {          
                this.TrangHIenTai--;
                LoadNhanVien();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(this.TrangHIenTai < this.TongTrang)
            {
                              
                this.TrangHIenTai++;
                LoadNhanVien(); 
            }

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if(this.TrangHIenTai < this.TongTrang)
            {
                this.TrangHIenTai = this.TongTrang;
                LoadNhanVien();
            }
        }

        public bool toggle = false;
        private void btnSort_Click(object sender, EventArgs e)
        {
            toggle = !toggle;
            bool ascending = toggle;
            string asc =""; 
            if (ascending)
            {
                asc = "asc";
            }
            else
            {
                asc = "desc";
            }
            using (SqlConnection cn = db.GetConnection())
            {
                cn.Open();
                //Đém số lượng nhân viên = kết hợp tất cả các cột -> chỉ cần search là ra hết
                string where = "nv.MaNhanVien LIKE  '%' + @search + '%' OR nv.TenNhanVien LIKE '%' + @search + '%' OR nv.Email LIKE '%' + @search + '%'  OR nv.TrangThaiTaiKhoan LIKE '%' + @search + '%'";
                string query = $"select count(*) from NhanVien as nv where {where}";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@search", $"{txtSearch.Text}");
                    this.TongNV = (int)cmd.ExecuteScalar();

                    int TongTrang = (int)Math.Round((double)this.TongNV / this.SoNVDuocHienThi);
                    this.TongTrang = TongTrang == 0 ? 1 : TongTrang;
                }

                //Thêm nhân viên vào bảng 
                string query2 = $"SELECT nv.MaNhanVien,  nv.TenNhanVien, nv.Email,   vt.VaiTro,   nv.TrangThaiTaiKhoan FROM NhanVien AS nv INNER JOIN VaiTro AS vt  ON nv.MaVaiTro = vt.MaVaiTro WHERE (nv.MaNhanVien LIKE '%' + @search + '%' OR    nv.TenNhanVien LIKE '%' + @search + '%' OR     nv.Email LIKE '%' + @search + '%' OR    vt.VaiTro LIKE '%' + @search + '%' OR\r\n     nv.TrangThaiTaiKhoan LIKE '%' + @search + '%')\r\nORDER BY nv.MaNhanVien "+ asc +" OFFSET @offset ROWS\r\nFETCH NEXT @fetch ROWS ONLY;";
                using (SqlCommand cmd = new SqlCommand(query2, cn))
                {
                    //Reset lại số lượng nhân viên hiển thị
                    // trang ht -1 = 0 => vi tri ban dau , sau do tiep dtuc
                    int rowIndex = (this.TrangHIenTai - 1) * this.SoNVDuocHienThi;
                    dgvDSNV.Rows.Clear();



                    //
                    cmd.Parameters.AddWithValue("@search", txtSearch.Text);

                    //Số trang bị bỏ qua
                    cmd.Parameters.AddWithValue("@offset", (this.TrangHIenTai - 1) * this.SoNVDuocHienThi);

                    //Số trang sẽ hiển thị
                    cmd.Parameters.AddWithValue("@fetch", this.SoNVDuocHienThi);
                    string index;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            index = "NV" + (rowIndex++).ToString();
                            dgvDSNV.Rows.Add(
                                index,
                                dr["MaNhanVien"].ToString(),
                                dr["TenNhanVien"].ToString(),
                                dr["Email"].ToString(),
                                dr["VaiTro"].ToString(),
                                dr["TrangThaiTaiKhoan"].ToString()
                                );

                        }
                    }
                }
                HienThiSoTrang();
                CapNhatNutChuyenTrang();

            }



        }

        private void dgvDSNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblTrangHienTai_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblTongTrang_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
