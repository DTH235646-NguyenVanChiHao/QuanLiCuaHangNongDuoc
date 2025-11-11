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
    public partial class frmLichSuPhieuNhap : Form
    {
        //Db
        DBConnection db = new DBConnection();

        public frmLichSuPhieuNhap()
        {
            InitializeComponent();

            // Khởi tạo giá trị mặc định cho DateTimePicker
            dtpTuNgay.Value = DateTime.Now.AddMonths(-1); // 1 tháng trước
            dtpDenNgay.Value = DateTime.Now; // Hôm nay

            LoadPhieuNhap();
            CapNhatThongKe();
        }

        public void ThongBao(string msg, frmThongBao.enmType type)
        {
            frmThongBao f = new frmThongBao();
            f.showAlert(msg, type);
        }

        public void LoadPhieuNhap()
        {
            // Load dữ liệu phiếu nhập vào DataGridView theo khoảng thời gian
            using (SqlConnection cn = db.GetConnection())
            {
                cn.Open();
                string query = @"
                    SELECT 
                        pn.MaPhieuNhap,
                        pn.NgayNhap,
                        nv.MaNhanVien,
                        nv.TenNhanVien,
                        ncc.MaNhaCC,
                        ncc.TenNhaCC,
                        sp.MaSP,
                        sp.TenSP,
                        ct.SoLuong,
                        sp.GiaMua,
                        ct.ThanhTien
                    FROM PhieuNhap pn
                    INNER JOIN ChiTietPhieuNhap ct ON pn.MaPhieuNhap = ct.MaPhieuNhap
                    LEFT JOIN NhanVien nv ON pn.MaNhanVien = nv.MaNhanVien
                    LEFT JOIN NhaCC ncc ON pn.MaNhaCC = ncc.MaNhaCC
                    LEFT JOIN SanPham sp ON ct.MaSP = sp.MaSP
                    WHERE CAST(pn.NgayNhap AS DATE) BETWEEN @TuNgay AND @DenNgay
                    ORDER BY pn.NgayNhap DESC";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Thêm tham số tìm kiếm theo ngày
                    cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                    cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date);

                    // Reset DataGridView
                    dgvPhieuNhap.Rows.Clear();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            dgvPhieuNhap.Rows.Add(
                                dr["MaPhieuNhap"].ToString(),
                                Convert.ToDateTime(dr["NgayNhap"]).ToString("dd/MM/yyyy HH:mm"),
                                dr["MaNhanVien"] != DBNull.Value ? dr["MaNhanVien"].ToString() : "",
                                dr["TenNhanVien"] != DBNull.Value ? dr["TenNhanVien"].ToString() : "",
                                dr["MaNhaCC"] != DBNull.Value ? dr["MaNhaCC"].ToString() : "",
                                dr["TenNhaCC"] != DBNull.Value ? dr["TenNhaCC"].ToString() : "",
                                dr["MaSP"] != DBNull.Value ? dr["MaSP"].ToString() : "",
                                dr["TenSP"] != DBNull.Value ? dr["TenSP"].ToString() : "",
                                dr["SoLuong"] != DBNull.Value ? dr["SoLuong"].ToString() : "0",
                                dr["GiaMua"] != DBNull.Value ? dr["GiaMua"].ToString(): "1",
                                dr["ThanhTien"] != DBNull.Value ? string.Format("{0:N0}", dr["ThanhTien"]) : "0"
                            );
                        }
                    }
                }
            }

            // Cập nhật thống kê sau khi load
            CapNhatThongKe();
        }

        private void CapNhatThongKe()
        {
            // Tính tổng số phiếu nhập và tổng chi phí
            int tongPhieuNhap = 0;
            decimal tongChiPhi = 0;

            HashSet<string> uniquePhieuNhap = new HashSet<string>();

            foreach (DataGridViewRow row in dgvPhieuNhap.Rows)
            {
                if (row.Cells["MaPhieuNhap"].Value != null)
                {
                    string maPhieuNhap = row.Cells["MaPhieuNhap"].Value.ToString();

                    // Đếm số phiếu nhập unique
                    if (!uniquePhieuNhap.Contains(maPhieuNhap))
                    {
                        uniquePhieuNhap.Add(maPhieuNhap);
                    }

                    // Tính tổng chi phí
                    if (row.Cells["ThanhTien"].Value != null)
                    {
                        string thanhTienStr = row.Cells["ThanhTien"].Value.ToString().Replace(",", "");
                        decimal thanhTien = 0;
                        if (decimal.TryParse(thanhTienStr, out thanhTien))
                        {
                            tongChiPhi += thanhTien;
                        }
                    }
                }
            }

            tongPhieuNhap = uniquePhieuNhap.Count;

            // Hiển thị thông tin
            lblTongPhieuNhap.Text = tongPhieuNhap.ToString();
            lblTongChiPhi.Text = string.Format("{0:N0} VNĐ", tongChiPhi);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                subfrmLichSuPhieuNhap ls = new subfrmLichSuPhieuNhap(this);
                ls.LoadComboBoxNhaCC();
                ls.LoadComboBoxNhanVien();

                ls.btnSua.Enabled = true;
                ls.btnThem.Enabled = false;

                DataGridViewRow dr = dgvPhieuNhap.SelectedRows[0];

                ls.txtMaPhieuNhap.Text = dr.Cells["MaPhieuNhap"].Value.ToString();

                string ngayNhapStr = dr.Cells["NgayNhap"].Value.ToString();
                ls.dtpNgayNhap.Value = DateTime.Parse(ngayNhapStr);

                ls.cbbMaNhanVien.SelectedValue = dr.Cells["MaNhanVien"].Value.ToString();
                ls.cbbMaNhaCC.SelectedValue = dr.Cells["MaNhaCC"].Value.ToString();
                ls.txtMaSP.Text = dr.Cells["MaSP"].Value.ToString();

                ls.txtSoLuong.Text = dr.Cells["SoLuong"].Value.ToString();

                string thanhTienStr = dr.Cells["ThanhTien"].Value.ToString().Replace(",", "");
                ls. txtThanhTien.Text = thanhTienStr;
                ls.Show();

               
            }
            catch (Exception ex)
            {
                ThongBao("Lỗi sửa phiếu nhập: " + ex.Message, frmThongBao.enmType.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhieuNhap.CurrentRow == null)
                {
                    ThongBao("Vui lòng chọn phiếu nhập cần xóa!", frmThongBao.enmType.Warning);
                    return;
                }

                DialogResult dg = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa phiếu nhập này?\n\nLưu ý: Thao tác này sẽ xóa toàn bộ chi tiết phiếu nhập!",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (dg == DialogResult.Yes)
                {
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();

                        string maPhieuNhap = dgvPhieuNhap.CurrentRow.Cells["MaPhieuNhap"].Value.ToString();

                      
                           
                                // Bước 1: Lấy danh sách sản phẩm và số lượng từ chi tiết phiếu nhập
                                string getProductsQuery = "SELECT MaSP, SoLuong FROM ChiTietPhieuNhap WHERE MaPhieuNhap = @MaPhieuNhap";
                                List<Tuple<string, int>> products = new List<Tuple<string, int>>();

                                using (SqlCommand cmd = new SqlCommand(getProductsQuery, cn))
                                {
                                    cmd.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap);
                                    using (SqlDataReader reader = cmd.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            string maSP = reader["MaSP"].ToString();
                                            int soLuong = Convert.ToInt32(reader["SoLuong"]);
                                            products.Add(new Tuple<string, int>(maSP, soLuong));
                                        }
                                    }
                                }

                                // Bước 2: Cập nhật lại số lượng sản phẩm trong kho (trừ đi số lượng đã nhập)
                                foreach (var product in products)
                                {
                                    string updateStockQuery = @"
                                        UPDATE SanPham 
                                        SET SoLuongConLai = SoLuongConLai - @SoLuong 
                                        WHERE MaSP = @MaSP";

                                    using (SqlCommand cmd = new SqlCommand(updateStockQuery, cn))
                                    {
                                        cmd.Parameters.AddWithValue("@MaSP", product.Item1);
                                        cmd.Parameters.AddWithValue("@SoLuong", product.Item2);
                                        cmd.ExecuteNonQuery();
                                    }
                                }

                                // Bước 3: Xóa chi tiết phiếu nhập
                                string deleteCTPN = "DELETE FROM ChiTietPhieuNhap WHERE MaPhieuNhap = @MaPhieuNhap";
                                using (SqlCommand cmd = new SqlCommand(deleteCTPN, cn))
                                {
                                    cmd.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap);
                                    cmd.ExecuteNonQuery();
                                }

                                // Bước 4: Xóa phiếu nhập
                                string deletePN = "DELETE FROM PhieuNhap WHERE MaPhieuNhap = @MaPhieuNhap";
                                using (SqlCommand cmd = new SqlCommand(deletePN, cn))
                                {
                                    cmd.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap);
                                    cmd.ExecuteNonQuery();
                                }


                                ThongBao("Xóa phiếu nhập thành công!", frmThongBao.enmType.Success);
                                LoadPhieuNhap();
                           
                        
                    }
                }
            }
            catch (Exception ex)
            {
                ThongBao("Lỗi xóa phiếu nhập: " + ex.Message, frmThongBao.enmType.Error);
            }
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            // Kiểm tra logic ngày
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                ThongBao("Ngày bắt đầu không được lớn hơn ngày kết thúc!", frmThongBao.enmType.Warning);
                dtpTuNgay.Value = dtpDenNgay.Value;
                return;
            }

            LoadPhieuNhap();
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            // Kiểm tra logic ngày
            if (dtpDenNgay.Value < dtpTuNgay.Value)
            {
                ThongBao("Ngày kết thúc không được nhỏ hơn ngày bắt đầu!", frmThongBao.enmType.Warning);
                dtpDenNgay.Value = dtpTuNgay.Value;
                return;
            }

            LoadPhieuNhap();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            subfrmLichSuPhieuNhap ls = new subfrmLichSuPhieuNhap(this);
            ls.btnThem.Enabled = true;
            ls.btnSua.Enabled = false;

            ls.Show();
        }
    }
}