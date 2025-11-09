using System;
using System.Windows.Forms;
using System.Drawing;

namespace QuanLiCuaHang_NongDuoc
{
    partial class subfrmLichSuHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelMaHD = new System.Windows.Forms.Label();
            this.labelNgayNhap = new System.Windows.Forms.Label();
            this.labelTenNV = new System.Windows.Forms.Label();
            this.labelMaNV = new System.Windows.Forms.Label();
            this.labelPhanTramGiam = new System.Windows.Forms.Label();
            this.labelMaSP = new System.Windows.Forms.Label();
            this.labelSoLuong = new System.Windows.Forms.Label();
            this.labelThanhTien = new System.Windows.Forms.Label();
            this.labelMaKH = new System.Windows.Forms.Label();
            this.labelTenKH = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.txtPhanTramGiam = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.cbbMaNhanVien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.cbbMaSP = new System.Windows.Forms.ComboBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGiaTien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LawnGreen;
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 48);
            this.panel1.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(318, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(411, 48);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Chi tiết lịch sử hoá đơn";
            // 
            // labelMaHD
            // 
            this.labelMaHD.AutoSize = true;
            this.labelMaHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelMaHD.Location = new System.Drawing.Point(15, 65);
            this.labelMaHD.Name = "labelMaHD";
            this.labelMaHD.Size = new System.Drawing.Size(126, 25);
            this.labelMaHD.TabIndex = 1;
            this.labelMaHD.Text = "Mã hoá đơn";
            // 
            // labelNgayNhap
            // 
            this.labelNgayNhap.AutoSize = true;
            this.labelNgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelNgayNhap.Location = new System.Drawing.Point(516, 62);
            this.labelNgayNhap.Name = "labelNgayNhap";
            this.labelNgayNhap.Size = new System.Drawing.Size(116, 25);
            this.labelNgayNhap.TabIndex = 3;
            this.labelNgayNhap.Text = "Ngày nhập";
            // 
            // labelTenNV
            // 
            this.labelTenNV.AutoSize = true;
            this.labelTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelTenNV.Location = new System.Drawing.Point(516, 120);
            this.labelTenNV.Name = "labelTenNV";
            this.labelTenNV.Size = new System.Drawing.Size(150, 25);
            this.labelTenNV.TabIndex = 5;
            this.labelTenNV.Text = "Tên nhân viên";
            // 
            // labelMaNV
            // 
            this.labelMaNV.AutoSize = true;
            this.labelMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelMaNV.Location = new System.Drawing.Point(15, 117);
            this.labelMaNV.Name = "labelMaNV";
            this.labelMaNV.Size = new System.Drawing.Size(142, 25);
            this.labelMaNV.TabIndex = 7;
            this.labelMaNV.Text = "Mã nhân viên";
            // 
            // labelPhanTramGiam
            // 
            this.labelPhanTramGiam.AutoSize = true;
            this.labelPhanTramGiam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelPhanTramGiam.Location = new System.Drawing.Point(516, 356);
            this.labelPhanTramGiam.Name = "labelPhanTramGiam";
            this.labelPhanTramGiam.Size = new System.Drawing.Size(162, 25);
            this.labelPhanTramGiam.TabIndex = 9;
            this.labelPhanTramGiam.Text = "Phần trăm giảm";
            // 
            // labelMaSP
            // 
            this.labelMaSP.AutoSize = true;
            this.labelMaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelMaSP.Location = new System.Drawing.Point(15, 315);
            this.labelMaSP.Name = "labelMaSP";
            this.labelMaSP.Size = new System.Drawing.Size(142, 25);
            this.labelMaSP.TabIndex = 11;
            this.labelMaSP.Text = "Mã sản phẩm";
            // 
            // labelSoLuong
            // 
            this.labelSoLuong.AutoSize = true;
            this.labelSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelSoLuong.Location = new System.Drawing.Point(15, 356);
            this.labelSoLuong.Name = "labelSoLuong";
            this.labelSoLuong.Size = new System.Drawing.Size(98, 25);
            this.labelSoLuong.TabIndex = 13;
            this.labelSoLuong.Text = "Số lượng";
            // 
            // labelThanhTien
            // 
            this.labelThanhTien.AutoSize = true;
            this.labelThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelThanhTien.Location = new System.Drawing.Point(526, 397);
            this.labelThanhTien.Name = "labelThanhTien";
            this.labelThanhTien.Size = new System.Drawing.Size(115, 25);
            this.labelThanhTien.TabIndex = 15;
            this.labelThanhTien.Text = "Thành tiền";
            // 
            // labelMaKH
            // 
            this.labelMaKH.AutoSize = true;
            this.labelMaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelMaKH.Location = new System.Drawing.Point(12, 242);
            this.labelMaKH.Name = "labelMaKH";
            this.labelMaKH.Size = new System.Drawing.Size(160, 25);
            this.labelMaKH.TabIndex = 20;
            this.labelMaKH.Text = "Mã khách hàng";
            // 
            // labelTenKH
            // 
            this.labelTenKH.AutoSize = true;
            this.labelTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelTenKH.Location = new System.Drawing.Point(516, 243);
            this.labelTenKH.Name = "labelTenKH";
            this.labelTenKH.Size = new System.Drawing.Size(168, 25);
            this.labelTenKH.TabIndex = 21;
            this.labelTenKH.Text = "Tên khách hàng";
            // 
            // txtMaHD
            // 
            this.txtMaHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaHD.Location = new System.Drawing.Point(220, 65);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(290, 26);
            this.txtMaHD.TabIndex = 2;
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(706, 62);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(290, 26);
            this.dtpNgayNhap.TabIndex = 4;
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenNhanVien.Enabled = false;
            this.txtTenNhanVien.Location = new System.Drawing.Point(706, 116);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.Size = new System.Drawing.Size(290, 26);
            this.txtTenNhanVien.TabIndex = 8;
            // 
            // txtPhanTramGiam
            // 
            this.txtPhanTramGiam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhanTramGiam.Location = new System.Drawing.Point(706, 358);
            this.txtPhanTramGiam.Name = "txtPhanTramGiam";
            this.txtPhanTramGiam.Size = new System.Drawing.Size(290, 26);
            this.txtPhanTramGiam.TabIndex = 10;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoLuong.Location = new System.Drawing.Point(220, 355);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(290, 26);
            this.txtSoLuong.TabIndex = 14;
            this.txtSoLuong.TextChanged += new System.EventHandler(this.txtSoLuong_TextChanged);
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThanhTien.Location = new System.Drawing.Point(706, 396);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(290, 26);
            this.txtThanhTien.TabIndex = 16;
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenKhachHang.Enabled = false;
            this.txtTenKhachHang.Location = new System.Drawing.Point(706, 241);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(290, 26);
            this.txtTenKhachHang.TabIndex = 23;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.LawnGreen;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnThem.Location = new System.Drawing.Point(670, 465);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(150, 60);
            this.btnThem.TabIndex = 17;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Yellow;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnSua.Location = new System.Drawing.Point(837, 465);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(150, 60);
            this.btnSua.TabIndex = 18;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // cbbMaNhanVien
            // 
            this.cbbMaNhanVien.FormattingEnabled = true;
            this.cbbMaNhanVien.Location = new System.Drawing.Point(220, 117);
            this.cbbMaNhanVien.Name = "cbbMaNhanVien";
            this.cbbMaNhanVien.Size = new System.Drawing.Size(290, 28);
            this.cbbMaNhanVien.TabIndex = 19;
            this.cbbMaNhanVien.SelectedIndexChanged += new System.EventHandler(this.cbbMaNhanVien_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(516, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "Tên Sản phẩm";
            // 
            // txtTenSP
            // 
            this.txtTenSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenSP.Enabled = false;
            this.txtTenSP.Location = new System.Drawing.Point(706, 312);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(290, 26);
            this.txtTenSP.TabIndex = 25;
            // 
            // cbbMaSP
            // 
            this.cbbMaSP.FormattingEnabled = true;
            this.cbbMaSP.Location = new System.Drawing.Point(220, 312);
            this.cbbMaSP.Name = "cbbMaSP";
            this.cbbMaSP.Size = new System.Drawing.Size(290, 28);
            this.cbbMaSP.TabIndex = 26;
            this.cbbMaSP.SelectedIndexChanged += new System.EventHandler(this.cbbMaSP_SelectedIndexChanged);
            // 
            // txtMaKH
            // 
            this.txtMaKH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaKH.Enabled = false;
            this.txtMaKH.Location = new System.Drawing.Point(220, 242);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(290, 26);
            this.txtMaKH.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(15, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 28;
            this.label2.Text = "Giá tiền";
            // 
            // txtGiaTien
            // 
            this.txtGiaTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGiaTien.Enabled = false;
            this.txtGiaTien.Location = new System.Drawing.Point(220, 399);
            this.txtGiaTien.Name = "txtGiaTien";
            this.txtGiaTien.Size = new System.Drawing.Size(290, 26);
            this.txtGiaTien.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 25);
            this.label3.TabIndex = 30;
            this.label3.Text = "Số điện thoại";
            // 
            // txtSDT
            // 
            this.txtSDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSDT.Location = new System.Drawing.Point(220, 188);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(290, 26);
            this.txtSDT.TabIndex = 31;
            this.txtSDT.TextChanged += new System.EventHandler(this.txtSDT_TextChanged);
            // 
            // subfrmLichSuHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 537);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGiaTien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaKH);
            this.Controls.Add(this.cbbMaSP);
            this.Controls.Add(this.txtTenSP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenKhachHang);
            this.Controls.Add(this.labelMaKH);
            this.Controls.Add(this.labelTenKH);
            this.Controls.Add(this.cbbMaNhanVien);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelMaHD);
            this.Controls.Add(this.txtMaHD);
            this.Controls.Add(this.labelNgayNhap);
            this.Controls.Add(this.dtpNgayNhap);
            this.Controls.Add(this.labelTenNV);
            this.Controls.Add(this.labelMaNV);
            this.Controls.Add(this.txtTenNhanVien);
            this.Controls.Add(this.labelPhanTramGiam);
            this.Controls.Add(this.txtPhanTramGiam);
            this.Controls.Add(this.labelMaSP);
            this.Controls.Add(this.labelSoLuong);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.labelThanhTien);
            this.Controls.Add(this.txtThanhTien);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "subfrmLichSuHoaDon";
            this.Text = "Chi tiết lịch sử hoá đơn";
            this.Load += new System.EventHandler(this.subfrmLichSuHoaDon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTitle;

        private System.Windows.Forms.Label labelMaHD;
        private System.Windows.Forms.Label labelNgayNhap;
        private System.Windows.Forms.Label labelTenNV;
        private System.Windows.Forms.Label labelMaNV;
        private System.Windows.Forms.Label labelPhanTramGiam;
        private System.Windows.Forms.Label labelMaSP;
        private System.Windows.Forms.Label labelSoLuong;
        private System.Windows.Forms.Label labelThanhTien;
        private System.Windows.Forms.Label labelMaKH;
        private System.Windows.Forms.Label labelTenKH;

        public System.Windows.Forms.TextBox txtMaHD;
        public System.Windows.Forms.DateTimePicker dtpNgayNhap;
        public System.Windows.Forms.TextBox txtTenNhanVien;
        public System.Windows.Forms.TextBox txtPhanTramGiam;
        public System.Windows.Forms.TextBox txtSoLuong;
        public System.Windows.Forms.TextBox txtThanhTien;
        public System.Windows.Forms.TextBox txtTenKhachHang;

        public System.Windows.Forms.Button btnThem;
        public System.Windows.Forms.Button btnSua;
        public System.Windows.Forms.ComboBox cbbMaNhanVien;
        private Label label1;
        public TextBox txtTenSP;
        public ComboBox cbbMaSP;
        public TextBox txtMaKH;
        private Label label2;
        public TextBox txtGiaTien;
        private Label label3;
        public TextBox txtSDT;
    }
}
