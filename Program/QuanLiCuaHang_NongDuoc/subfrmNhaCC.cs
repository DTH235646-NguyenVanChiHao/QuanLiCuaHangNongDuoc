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
    public partial class subfrmNhaCungCap : Form
    {
        //Connect sql server
        DBConnection db = new DBConnection();

        //Dùng để tái kích hoạt form tải lại table()
        frmNhaCungCap ncc;

        public subfrmNhaCungCap(frmNhaCungCap nhacungcap)
        {
            InitializeComponent();
            this.ncc = nhacungcap;

            //Mặc định nút thêm được kích hoạt, nút sửa bị vô hiệu hóa
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = false;
        }

        public void ThongBao(string msg, frmThongBao.enmType type)
        {
            frmThongBao f = new frmThongBao();
            f.showAlert(msg, type);
        }

        public bool KiemTraGiaTriNhap()
        {
            if (txtMaNhaCC.Text == "" || txtTenNhaCC.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
        }

        public void clear()
        {
            txtMaNhaCC.Text = "";
            txtTenNhaCC.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";

            btnThem.Enabled = true;
            btnSua.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraGiaTriNhap())
                    return;

                DialogResult dg = MessageBox.Show("Bạn có chắc muốn thêm nhà cung cấp này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();
                        using (SqlCommand cmd = cn.CreateCommand())
                        {
                            // ✅ Nếu MaNhaCC là tự tăng (IDENTITY), hãy bỏ dòng MaNhaCC khỏi INSERT
                            cmd.CommandText = @"INSERT INTO NhaCC (MaNhaCC, TenNhaCC, DiaChi, SDT, Email)
                                                VALUES (@MaNhaCC, @TenNhaCC, @DiaChi, @SDT, @Email)";

                            cmd.Parameters.AddWithValue("@MaNhaCC", txtMaNhaCC.Text);
                            cmd.Parameters.AddWithValue("@TenNhaCC", txtTenNhaCC.Text);
                            cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                            cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                            cmd.ExecuteNonQuery();
                        }
                        clear();
                        this.Close();
                        this.ncc.LoadNhaCungCap();
                        this.ThongBao("Thêm nhà cung cấp thành công!", frmThongBao.enmType.Success);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraGiaTriNhap())
                    return;

                DialogResult dg = MessageBox.Show("Bạn có chắc muốn sửa nhà cung cấp này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    using (SqlConnection cn = db.GetConnection())
                    {
                        cn.Open();
                        using (SqlCommand cmd = cn.CreateCommand())
                        {
                            cmd.CommandText = @"UPDATE NhaCC
                                                SET TenNhaCC = @TenNhaCC, DiaChi = @DiaChi, SDT = @SDT, Email = @Email
                                                WHERE MaNhaCC = @MaNhaCC";

                            cmd.Parameters.AddWithValue("@MaNhaCC", txtMaNhaCC.Text);
                            cmd.Parameters.AddWithValue("@TenNhaCC", txtTenNhaCC.Text);
                            cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                            cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                            cmd.ExecuteNonQuery();
                        }
                        clear();
                        this.Close();
                        this.ncc.LoadNhaCungCap();
                        this.ThongBao("Sửa nhà cung cấp thành công!", frmThongBao.enmType.Success);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
