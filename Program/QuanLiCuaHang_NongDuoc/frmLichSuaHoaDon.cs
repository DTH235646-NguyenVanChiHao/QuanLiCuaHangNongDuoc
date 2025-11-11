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

            // Khởi tạo giá trị mặc định cho DateTimePicker
            dtpTuNgay.Value = DateTime.Now.AddMonths(-1); // 1 tháng trước
            dtpDenNgay.Value = DateTime.Now; // Hôm nay

            LoadHoaDon();
            CapNhatThongKe();
        }

        public void ThongBao(string msg, frmThongBao.enmType type)
        {
            frmThongBao f = new frmThongBao();
            f.showAlert(msg, type);
        }

        public void LoadHoaDon()
        {
            // Load dữ liệu hóa đơn vào DataGridView theo khoảng thời gian
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
                    WHERE CAST(hd.NgayNhap AS DATE) BETWEEN @TuNgay AND @DenNgay
                    ORDER BY hd.NgayNhap DESC";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Thêm tham số tìm kiếm theo ngày
                    cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                    cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date);

                    //reset
                    dgvHoaDon.Rows.Clear();

                    //using
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            dgvHoaDon.Rows.Add(
                             dr["MaHD"].ToString(),
                             Convert.ToDateTime(dr["NgayNhap"]).ToString("dd/MM/yyyy HH:mm"),
                             dr["MaNhanVien"] != DBNull.Value ? dr["MaNhanVien"].ToString() : "",
                             dr["TenNhanVien"] != DBNull.Value ? dr["TenNhanVien"].ToString() : "",
                             dr["PhanTramGiam"] != DBNull.Value ? dr["PhanTramGiam"].ToString() + "%" : "0%",
                             dr["MaSP"] != DBNull.Value ? dr["MaSP"].ToString() : "",
                             dr["TenSP"] != DBNull.Value ? dr["TenSP"].ToString() : "",
                             dr["GiaBan"] != DBNull.Value ? string.Format("{0:N0}", dr["GiaBan"]) : "",
                             dr["SoLuong"] != DBNull.Value ? dr["SoLuong"].ToString() : "",
                             dr["ThanhTien"] != DBNull.Value ? string.Format("{0:N0}", dr["ThanhTien"]) : "",
                             dr["MaKH"] != DBNull.Value ? dr["MaKH"].ToString() : "",
                             dr["TenKH"] != DBNull.Value ? dr["TenKH"].ToString() : "Khách lẻ",
                             dr["SDT"] != DBNull.Value ? dr["SDT"].ToString() : ""
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
            // Tính tổng số hóa đơn và tổng doanh thu
            int tongHoaDon = 0;
            decimal tongDoanhThu = 0;

            HashSet<string> uniqueHoaDon = new HashSet<string>();

            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.Cells["MaHD"].Value != null)
                {
                    string maHD = row.Cells["MaHD"].Value.ToString();

                    // Đếm số hóa đơn unique
                    if (!uniqueHoaDon.Contains(maHD))
                    {
                        uniqueHoaDon.Add(maHD);
                    }

                    // Tính tổng doanh thu
                    if (row.Cells["ThanhTien"].Value != null)
                    {
                        decimal thanhTien = 0;

                        //Kiểm tra có ép kiểu được không : nếu được thì ép vào giá trị vào thành tiền
                        if (decimal.TryParse(row.Cells["ThanhTien"].Value.ToString(), out thanhTien))
                        {
                            tongDoanhThu += thanhTien;
                        }
                    }
                }
            }

            tongHoaDon = uniqueHoaDon.Count;

            // Hiển thị thông tin
            lblTongHoaDon.Text = tongHoaDon.ToString();

            //tự động thêm dấu phân cách hàng nghìn
            //N0 có nghĩa là không hiển thị phần thập phân (làm tròn đến số nguyên gần nhất).
            lblTongDoanhThu.Text = string.Format("{0:N0} VNĐ", tongDoanhThu);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra có dòng nào được chọn không
                if (dgvHoaDon.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một hóa đơn để sửa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy dữ liệu và thêm vào sub form
                subfrmLichSuHoaDon ls = new subfrmLichSuHoaDon(this);
                ls.GetMaNhanVien();
                ls.GetMaSP();
                


                    ls.txtMaHD.Text = dgvHoaDon.CurrentRow.Cells["MaHD"].Value.ToString();

                    // Sửa: Convert sang DateTime trước khi gán
                    ls.dtpNgayNhap.Value = Convert.ToDateTime(dgvHoaDon.CurrentRow.Cells["NgayNhap"].Value);

                    // Sửa: Dùng Text thay vì SelectedValue
                    ls.cbbTenNV.SelectedValue = dgvHoaDon.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                

                // Có thể thêm các trường khác nếu cần
                ls.txtPhanTramGiam.Text = dgvHoaDon.CurrentRow.Cells["PhanTramGiam"].Value.ToString();
                ls.cbbTenSP.SelectedValue = dgvHoaDon.CurrentRow.Cells["MaSP"].Value.ToString();
                ls.txtSoLuong.Text = dgvHoaDon.CurrentRow.Cells["SoLuong"].Value.ToString();
                ls.txtThanhTien.Text = dgvHoaDon.CurrentRow.Cells["ThanhTien"].Value.ToString();
                ls.txtMaKH.Text = dgvHoaDon.CurrentRow.Cells["MaKH"].Value.ToString();
                ls.txtTenKhachHang.Text = dgvHoaDon.CurrentRow.Cells["TenKH"].Value.ToString();
                ls.txtSDT.Text = dgvHoaDon.CurrentRow.Cells["SDT"].Value.ToString();

                ls.btnSua.Enabled = true;
                ls.btnThem.Enabled = false;


                ls.txtMaKH.Enabled = true;
                ls.txtTenKhachHang.Enabled = true;

                // Các thuộc tính không được sửa
                ls.txtMaHD.Enabled = false;
                

                ls.ShowDialog(); // Dùng ShowDialog() thay vì Show() để form con chạy modal
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHoaDon.CurrentRow == null)
                {
                    ThongBao("Vui lòng chọn hóa đơn cần xóa!", frmThongBao.enmType.Warning);
                    return;
                }

                DialogResult dg;
                dg = MessageBox.Show("Bạn có muốn xóa hóa đơn này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dg == DialogResult.Yes)
                {
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();

                        string maHD = dgvHoaDon.CurrentRow.Cells["MaHD"].Value.ToString();

                        
                                // Xóa chi tiết hóa đơn
                                string deleteCTHD = "DELETE FROM ChiTietHoaDon WHERE MaHD = @MaHD";
                                using (SqlCommand cmd = new SqlCommand(deleteCTHD, cn))
                                {
                                    cmd.Parameters.AddWithValue("@MaHD", maHD);
                                    cmd.ExecuteNonQuery();
                                }

                                // Xóa hóa đơn
                                string deleteHD = "DELETE FROM HoaDon WHERE MaHD = @MaHD";
                                using (SqlCommand cmd = new SqlCommand(deleteHD, cn))
                                {
                                    cmd.Parameters.AddWithValue("@MaHD", maHD);
                                    cmd.ExecuteNonQuery();
                                }

                               
                               

                                ThongBao("Xóa hóa đơn thành công!", frmThongBao.enmType.Success);
                                LoadHoaDon();
                            
                        
                    }
                }
            }
            catch (Exception ex)
            {
                ThongBao("Lỗi xóa hóa đơn: " + ex.Message, frmThongBao.enmType.Error);
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

            LoadHoaDon();
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

            LoadHoaDon();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            subfrmLichSuHoaDon hd = new subfrmLichSuHoaDon(this);
            hd.btnThem.Enabled = true;
            hd.btnSua.Enabled = false;

           
            hd.Show();
        }
    }
}