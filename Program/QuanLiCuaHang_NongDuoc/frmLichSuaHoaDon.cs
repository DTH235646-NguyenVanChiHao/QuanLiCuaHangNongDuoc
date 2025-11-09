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
    public partial class frmLichSuaHoaDon : Form
    {

        //Db
        DBConnection db = new DBConnection();

        public frmLichSuaHoaDon()
        {
            InitializeComponent();
            LoadHoaDon();
        }

        public void ThongBao(string msg, frmThongBao.enmType type)
        {
            frmThongBao f = new frmThongBao();
            f.showAlert(msg, type);
        }

        public void LoadHoaDon()
        {
            // Load dữ liệu hóa đơn vào DataGridView
            using (SqlConnection cn = db.GetConnection())
            {
                                cn.Open();
                string query = @"
                    SELECT 
                        hd.MaHD,
                        hd.NgayNhap,    
                        nv.MaNhanVien,
                        nv.TenNhanVien,
                        hd.PhanTramGiam,
                        sp.MaSP,
                        sp.TenSP,
                        sp.GiaBan,
                        ct.SoLuong,
                        ct.ThanhTien,
                        kh.MaKH,
                        kh.TenKH,
                        kh.SDT
                    FROM HoaDon hd
                    INNER JOIN ChiTietHoaDon as ct ON hd.MaHD = ct.MaHD
                    LEFT JOIN NhanVien nv ON hd.MaNhanVien = nv.MaNhanVien
                    LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                    LEFT JOIN SanPham sp ON sp.MaSP = ct.MaSP
                    WHERE hd.MaHD LIKE @MaHD
                    ORDER BY hd.NgayNhap DESC";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {

                    //reset
                    dgvHoaDon.Rows.Clear();


                    //
                    cmd.Parameters.AddWithValue("@MaHD", '%' +txtSearch.Text+'%');

                    //using
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            dgvHoaDon.Rows.Add(
                             dr["MaHD"].ToString(),
                             dr["NgayNhap"].ToString(),
                             dr["MaNhanVien"] != DBNull.Value ? "MaNhanVien".ToString() : "",
                             dr["TenNhanVien"] != DBNull.Value ? dr["TenNhanVien"].ToString() : "",
                             dr["PhanTramGiam"] != DBNull.Value ? dr["PhanTramGiam"].ToString() : "",
                             dr["MaSP"] != DBNull.Value ? dr["MaSP"].ToString() : "",
                             dr["TenSP"] != DBNull.Value ? dr["TenSP"].ToString() : "",
                             dr["GiaBan"] != DBNull.Value ? dr["SDT"].ToString() : "",
                             dr["SoLuong"] != DBNull.Value ? dr["SoLuong"].ToString() : "",
                             dr["ThanhTien"] != DBNull.Value ? dr["ThanhTien"].ToString() : "",
                             dr["MaKH"] != DBNull.Value ? dr["MaKH"].ToString() : "",
                             dr["TenKH"] != DBNull.Value ? dr["TenKH"].ToString() : "",
                             dr["SDT"] != DBNull.Value ? dr["SDT"].ToString() : ""
                        );
                        }
                    }

                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // ✅ Truyền row vào constructor
                subfrmLichSuHoaDon ls = new subfrmLichSuHoaDon(this, dgvHoaDon.CurrentRow);
                ls.Show();
            }
            catch (Exception ex)
            {
                ThongBao("Lỗi sửa hóa đơn: " + ex.Message, frmThongBao.enmType.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try {
                DialogResult dg;
                dg = MessageBox.Show("Bạn có muốn xoá hoá đơn này không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dg == DialogResult.Yes) {
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();
                        //xoá chi tiết hoá đơn
                        string deleteCTHD = "Delete from ChiTietHoaDon where MaHD = @MaHD";
                        using (SqlCommand cmd = new SqlCommand(deleteCTHD, cn))
                        {
                            cmd.Parameters.AddWithValue("@MaHD", dgvHoaDon.CurrentRow.Cells["MaHD"].Value.ToString());
                            cmd.ExecuteNonQuery();
                        }
                        ///xoá hoá đơn
                        ///
                        string deleteHD = "delete from HoaDon where MaHD = @MaHD";
                        using (SqlCommand cmd = new SqlCommand(deleteHD, cn))
                        {
                            cmd.Parameters.AddWithValue("@MaHD", dgvHoaDon.CurrentRow.Cells["MaHD"].Value.ToString());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    this.LoadHoaDon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xoá: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadHoaDon();
            if(dgvHoaDon.RowCount <= 0)
            {
                ThongBao("Không tìm thấy hóa đơn!", frmThongBao.enmType.Info);
            }
        }
    }
}
