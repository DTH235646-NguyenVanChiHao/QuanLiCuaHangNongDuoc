using System;
using System.Windows.Forms;
using System.Drawing;

namespace QuanLiCuaHang_NongDuoc
{
    partial class subfrmLichSuPhieuNhap
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
            this.labelMaPhieuNhap = new System.Windows.Forms.Label();
            this.labelNgayNhap = new System.Windows.Forms.Label();
            this.labelMaNV = new System.Windows.Forms.Label();
            this.labelMaNhaCC = new System.Windows.Forms.Label();
            this.labelMaSP = new System.Windows.Forms.Label();
            this.labelTenSP = new System.Windows.Forms.Label();
            this.labelSoLuong = new System.Windows.Forms.Label();
            this.labelThanhTien = new System.Windows.Forms.Label();
            this.labelGiaMua = new System.Windows.Forms.Label();
            this.txtMaPhieuNhap = new System.Windows.Forms.TextBox();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.txtGiaMua = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.cbbMaNhanVien = new System.Windows.Forms.ComboBox();
            this.cbbMaNhaCC = new System.Windows.Forms.ComboBox();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
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
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(290, 5);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(460, 48);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Chi tiết lịch sử phiếu nhập";
            // 
            // labelMaPhieuNhap
            // 
            this.labelMaPhieuNhap.AutoSize = true;
            this.labelMaPhieuNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelMaPhieuNhap.Location = new System.Drawing.Point(15, 65);
            this.labelMaPhieuNhap.Name = "labelMaPhieuNhap";
            this.labelMaPhieuNhap.Size = new System.Drawing.Size(155, 25);
            this.labelMaPhieuNhap.TabIndex = 1;
            this.labelMaPhieuNhap.Text = "Mã phiếu nhập";
            // 
            // labelNgayNhap
            // 
            this.labelNgayNhap.AutoSize = true;
            this.labelNgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelNgayNhap.Location = new System.Drawing.Point(516, 65);
            this.labelNgayNhap.Name = "labelNgayNhap";
            this.labelNgayNhap.Size = new System.Drawing.Size(116, 25);
            this.labelNgayNhap.TabIndex = 3;
            this.labelNgayNhap.Text = "Ngày nhập";
            // 
            // labelMaNV
            // 
            this.labelMaNV.AutoSize = true;
            this.labelMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelMaNV.Location = new System.Drawing.Point(15, 120);
            this.labelMaNV.Name = "labelMaNV";
            this.labelMaNV.Size = new System.Drawing.Size(150, 25);
            this.labelMaNV.TabIndex = 7;
            this.labelMaNV.Text = "Tên nhân viên";
            // 
            // labelMaNhaCC
            // 
            this.labelMaNhaCC.AutoSize = true;
            this.labelMaNhaCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelMaNhaCC.Location = new System.Drawing.Point(516, 123);
            this.labelMaNhaCC.Name = "labelMaNhaCC";
            this.labelMaNhaCC.Size = new System.Drawing.Size(133, 25);
            this.labelMaNhaCC.TabIndex = 9;
            this.labelMaNhaCC.Text = "Tên Nhà CC";
            // 
            // labelMaSP
            // 
            this.labelMaSP.AutoSize = true;
            this.labelMaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelMaSP.Location = new System.Drawing.Point(15, 230);
            this.labelMaSP.Name = "labelMaSP";
            this.labelMaSP.Size = new System.Drawing.Size(142, 25);
            this.labelMaSP.TabIndex = 13;
            this.labelMaSP.Text = "Mã sản phẩm";
            // 
            // labelTenSP
            // 
            this.labelTenSP.AutoSize = true;
            this.labelTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelTenSP.Location = new System.Drawing.Point(516, 230);
            this.labelTenSP.Name = "labelTenSP";
            this.labelTenSP.Size = new System.Drawing.Size(150, 25);
            this.labelTenSP.TabIndex = 15;
            this.labelTenSP.Text = "Tên sản phẩm";
            // 
            // labelSoLuong
            // 
            this.labelSoLuong.AutoSize = true;
            this.labelSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelSoLuong.Location = new System.Drawing.Point(15, 285);
            this.labelSoLuong.Name = "labelSoLuong";
            this.labelSoLuong.Size = new System.Drawing.Size(98, 25);
            this.labelSoLuong.TabIndex = 17;
            this.labelSoLuong.Text = "Số lượng";
            // 
            // labelThanhTien
            // 
            this.labelThanhTien.AutoSize = true;
            this.labelThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelThanhTien.Location = new System.Drawing.Point(516, 340);
            this.labelThanhTien.Name = "labelThanhTien";
            this.labelThanhTien.Size = new System.Drawing.Size(115, 25);
            this.labelThanhTien.TabIndex = 19;
            this.labelThanhTien.Text = "Thành tiền";
            // 
            // labelGiaMua
            // 
            this.labelGiaMua.AutoSize = true;
            this.labelGiaMua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelGiaMua.Location = new System.Drawing.Point(15, 340);
            this.labelGiaMua.Name = "labelGiaMua";
            this.labelGiaMua.Size = new System.Drawing.Size(92, 25);
            this.labelGiaMua.TabIndex = 21;
            this.labelGiaMua.Text = "Giá mua";
            // 
            // txtMaPhieuNhap
            // 
            this.txtMaPhieuNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaPhieuNhap.Location = new System.Drawing.Point(220, 65);
            this.txtMaPhieuNhap.Name = "txtMaPhieuNhap";
            this.txtMaPhieuNhap.Size = new System.Drawing.Size(290, 26);
            this.txtMaPhieuNhap.TabIndex = 2;
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(706, 65);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(290, 26);
            this.dtpNgayNhap.TabIndex = 4;
            // 
            // txtTenSP
            // 
            this.txtTenSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenSP.Location = new System.Drawing.Point(706, 230);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(290, 26);
            this.txtTenSP.TabIndex = 14;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoLuong.Location = new System.Drawing.Point(220, 285);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(290, 26);
            this.txtSoLuong.TabIndex = 18;
            this.txtSoLuong.Leave += new System.EventHandler(this.txtSoLuong_Leave);
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThanhTien.Enabled = false;
            this.txtThanhTien.Location = new System.Drawing.Point(706, 340);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(290, 26);
            this.txtThanhTien.TabIndex = 20;
            // 
            // txtGiaMua
            // 
            this.txtGiaMua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGiaMua.Enabled = false;
            this.txtGiaMua.Location = new System.Drawing.Point(220, 340);
            this.txtGiaMua.Name = "txtGiaMua";
            this.txtGiaMua.Size = new System.Drawing.Size(290, 26);
            this.txtGiaMua.TabIndex = 22;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(670, 395);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(150, 60);
            this.btnThem.TabIndex = 23;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Gold;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(837, 395);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(150, 60);
            this.btnSua.TabIndex = 24;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // cbbMaNhanVien
            // 
            this.cbbMaNhanVien.FormattingEnabled = true;
            this.cbbMaNhanVien.Location = new System.Drawing.Point(220, 120);
            this.cbbMaNhanVien.Name = "cbbMaNhanVien";
            this.cbbMaNhanVien.Size = new System.Drawing.Size(290, 28);
            this.cbbMaNhanVien.TabIndex = 8;
            // 
            // cbbMaNhaCC
            // 
            this.cbbMaNhaCC.FormattingEnabled = true;
            this.cbbMaNhaCC.Location = new System.Drawing.Point(706, 124);
            this.cbbMaNhaCC.Name = "cbbMaNhaCC";
            this.cbbMaNhaCC.Size = new System.Drawing.Size(290, 28);
            this.cbbMaNhaCC.TabIndex = 12;
            // 
            // txtMaSP
            // 
            this.txtMaSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaSP.Location = new System.Drawing.Point(220, 232);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(290, 26);
            this.txtMaSP.TabIndex = 25;
            this.txtMaSP.Leave += new System.EventHandler(this.txtMaSP_TextChanged);
            // 
            // subfrmLichSuPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 467);
            this.Controls.Add(this.txtMaSP);
            this.Controls.Add(this.cbbMaNhaCC);
            this.Controls.Add(this.cbbMaNhanVien);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtGiaMua);
            this.Controls.Add(this.labelGiaMua);
            this.Controls.Add(this.txtThanhTien);
            this.Controls.Add(this.labelThanhTien);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.labelSoLuong);
            this.Controls.Add(this.txtTenSP);
            this.Controls.Add(this.labelTenSP);
            this.Controls.Add(this.labelMaSP);
            this.Controls.Add(this.labelMaNhaCC);
            this.Controls.Add(this.labelMaNV);
            this.Controls.Add(this.dtpNgayNhap);
            this.Controls.Add(this.labelNgayNhap);
            this.Controls.Add(this.txtMaPhieuNhap);
            this.Controls.Add(this.labelMaPhieuNhap);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "subfrmLichSuPhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết lịch sử phiếu nhập";
            this.Load += new System.EventHandler(this.subfrmLichSuPhieuNhap_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelMaPhieuNhap;
        private System.Windows.Forms.Label labelNgayNhap;
        private System.Windows.Forms.Label labelMaNV;
        private System.Windows.Forms.Label labelMaNhaCC;
        private System.Windows.Forms.Label labelMaSP;
        private System.Windows.Forms.Label labelTenSP;
        private System.Windows.Forms.Label labelSoLuong;
        private System.Windows.Forms.Label labelThanhTien;
        private System.Windows.Forms.Label labelGiaMua;

        public System.Windows.Forms.TextBox txtMaPhieuNhap;
        public System.Windows.Forms.DateTimePicker dtpNgayNhap;
        public System.Windows.Forms.TextBox txtTenSP;
        public System.Windows.Forms.TextBox txtSoLuong;
        public System.Windows.Forms.TextBox txtThanhTien;
        public System.Windows.Forms.TextBox txtGiaMua;
        public System.Windows.Forms.Button btnThem;
        public System.Windows.Forms.Button btnSua;
        public System.Windows.Forms.ComboBox cbbMaNhanVien;
        public System.Windows.Forms.ComboBox cbbMaNhaCC;
        public TextBox txtMaSP;
    }
}