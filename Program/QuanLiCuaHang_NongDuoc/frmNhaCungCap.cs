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

        public frmNhaCungCap()
        {
            InitializeComponent();
            this.LoadNhaCungCap();
        }

        public void ThongBao(string msg, frmThongBao.enmType type)
        {
            frmThongBao f = new frmThongBao();
            f.showAlert(msg, type);
        }

        //Tải nhà cung cấp
        public void LoadNhaCungCap()
        {
            using (SqlConnection cn = db.GetConnection())
            {
                cn.Open();
                int index = 1;

                //Xóa dữ liệu cũ để tránh trùng lặp
                dgvDSNCC.Rows.Clear();

                string query2 = @"SELECT ncc.MaNhaCC, ncc.TenNhaCC, ncc.DiaChi, ncc.SDT, ncc.Email 
                                  FROM NhaCC AS ncc 
                                  WHERE (ncc.MaNhaCC LIKE '%' + @search + '%' 
                                         OR ncc.TenNhaCC LIKE '%' + @search + '%' 
                                         OR ncc.DiaChi LIKE '%' + @search + '%' 
                                         OR ncc.SDT LIKE '%' + @search + '%' 
                                         OR ncc.Email LIKE '%' + @search + '%') 
                                  ORDER BY ncc.MaNhaCC DESC;";

                using (SqlCommand cmd = new SqlCommand(query2, cn))
                {
                    cmd.Parameters.AddWithValue("@search", txtSearch.Text.Trim());
                        
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            dgvDSNCC.Rows.Add(
                                index++,
                                dr["MaNhaCC"].ToString(),
                                dr["TenNhaCC"].ToString(),
                                dr["DiaChi"].ToString(),
                                dr["SDT"].ToString(),
                                dr["Email"].ToString()
                            );
                        }
                    }
                }
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
                //Lấy dữ liệu và thêm vào sub form
                subfrmNhaCungCap ncc = new subfrmNhaCungCap(this);
                ncc.btnSua.Enabled = true;

                ncc.txtMaNhaCC.Text = dgvDSNCC.CurrentRow.Cells["MaNhaCC"].Value.ToString();
                ncc.txtTenNhaCC.Text = dgvDSNCC.CurrentRow.Cells["TenNhaCC"].Value.ToString();
                ncc.txtDiaChi.Text = dgvDSNCC.CurrentRow.Cells["DiaChi"].Value.ToString();
                ncc.txtSDT.Text = dgvDSNCC.CurrentRow.Cells["SDT"].Value.ToString();
                ncc.txtEmail.Text = dgvDSNCC.CurrentRow.Cells["Email"].Value.ToString();

                ncc.btnSua.Enabled = true;
                ncc.btnThem.Enabled = false;

                //Không cho phép sửa mã
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
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM NhaCC WHERE MaNhaCC = @MaNhaCC", cn))
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

        public bool toggle = false;
        private void btnSort_Click(object sender, EventArgs e)
        {
            toggle = !toggle;
            bool ascending = toggle;
            string asc = ascending ? "ASC" : "DESC";

            using (SqlConnection cn = db.GetConnection())
            {
                cn.Open();
                dgvDSNCC.Rows.Clear();
                int index = 1;

                string query2 = $@"SELECT ncc.MaNhaCC, ncc.TenNhaCC, ncc.DiaChi, ncc.SDT, ncc.Email 
                                   FROM NhaCC AS ncc 
                                   WHERE (ncc.MaNhaCC LIKE '%' + @search + '%' 
                                          OR ncc.TenNhaCC LIKE '%' + @search + '%' 
                                          OR ncc.DiaChi LIKE '%' + @search + '%' 
                                          OR ncc.SDT LIKE '%' + @search + '%' 
                                          OR ncc.Email LIKE '%' + @search + '%') 
                                   ORDER BY ncc.MaNhaCC " + asc + ";";

                using (SqlCommand cmd = new SqlCommand(query2, cn))
                {
                    cmd.Parameters.AddWithValue("@search", txtSearch.Text.Trim());

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            dgvDSNCC.Rows.Add(
                                index++,
                                dr["MaNhaCC"].ToString(),
                                dr["TenNhaCC"].ToString(),
                                dr["DiaChi"].ToString(),
                                dr["SDT"].ToString(),
                                dr["Email"].ToString()
                            );
                        }
                    }
                }
            }
        }
    }
}
