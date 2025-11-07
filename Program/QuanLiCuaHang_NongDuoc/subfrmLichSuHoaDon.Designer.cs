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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();

            this.labelMaHD = new System.Windows.Forms.Label();
            this.labelNgayNhap = new System.Windows.Forms.Label();
            this.labelNhanVien = new System.Windows.Forms.Label();
            this.labelKhachHang = new System.Windows.Forms.Label();
            this.labelGiamGia = new System.Windows.Forms.Label();

            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.cbbNhanVien = new System.Windows.Forms.ComboBox();
            this.cbbKhachHang = new System.Windows.Forms.ComboBox();
            this.txtPhanTramGiam = new System.Windows.Forms.TextBox();

            this.dgvChiTietHD = new System.Windows.Forms.DataGridView();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();

            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHD)).BeginInit();
            this.SuspendLayout();

            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Orange;
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Size = new System.Drawing.Size(850, 50);
            this.panelHeader.TabIndex = 0;

            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(300, 5);
            this.labelTitle.Text = "Chi tiết hóa đơn";

            // 
            // labelMaHD
            // 
            this.labelMaHD.AutoSize = true;
            this.labelMaHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelMaHD.Location = new System.Drawing.Point(20, 70);
            this.labelMaHD.Text = "Mã hóa đơn:";

            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(160, 70);
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(180, 26);

            // 
            // labelNgayNhap
            // 
            this.labelNgayNhap.AutoSize = true;
            this.labelNgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelNgayNhap.Location = new System.Drawing.Point(20, 110);
            this.labelNgayNhap.Text = "Ngày nhập:";

            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(160, 110);
            this.dtpNgayNhap.Size = new System.Drawing.Size(180, 26);

            // 
            // labelNhanVien
            // 
            this.labelNhanVien.AutoSize = true;
            this.labelNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelNhanVien.Location = new System.Drawing.Point(400, 70);
            this.labelNhanVien.Text = "Tên nhân viên:";

            // 
            // cbbNhanVien
            // 
            this.cbbNhanVien.Location = new System.Drawing.Point(560, 70);
            this.cbbNhanVien.Size = new System.Drawing.Size(250, 28);

            // 
            // labelKhachHang
            // 
            this.labelKhachHang.AutoSize = true;
            this.labelKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelKhachHang.Location = new System.Drawing.Point(400, 110);
            this.labelKhachHang.Text = "Tên khách hàng:";

            // 
            // cbbKhachHang
            // 
            this.cbbKhachHang.Location = new System.Drawing.Point(560, 110);
            this.cbbKhachHang.Size = new System.Drawing.Size(250, 28);

            // 
            // labelGiamGia
            // 
            this.labelGiamGia.AutoSize = true;
            this.labelGiamGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelGiamGia.Location = new System.Drawing.Point(20, 150);
            this.labelGiamGia.Text = "Giảm giá (%):";

            // 
            // txtPhanTramGiam
            // 
            this.txtPhanTramGiam.Location = new System.Drawing.Point(160, 150);
            this.txtPhanTramGiam.Size = new System.Drawing.Size(180, 26);

            // 
            // dgvChiTietHD
            // 
            this.dgvChiTietHD.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHD.Location = new System.Drawing.Point(25, 200);
            this.dgvChiTietHD.Name = "dgvChiTietHD";
            this.dgvChiTietHD.RowHeadersWidth = 51;
            this.dgvChiTietHD.RowTemplate.Height = 24;
            this.dgvChiTietHD.Size = new System.Drawing.Size(790, 300);
            this.dgvChiTietHD.TabIndex = 12;

            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.LawnGreen;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThem.Location = new System.Drawing.Point(100, 520);
            this.btnThem.Size = new System.Drawing.Size(120, 45);
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;

            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Gold;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSua.Location = new System.Drawing.Point(240, 520);
            this.btnSua.Size = new System.Drawing.Size(120, 45);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;

            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Tomato;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnXoa.Location = new System.Drawing.Point(380, 520);
            this.btnXoa.Size = new System.Drawing.Size(120, 45);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;

            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLuu.Location = new System.Drawing.Point(520, 520);
            this.btnLuu.Size = new System.Drawing.Size(120, 45);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;

            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.LightGray;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThoat.Location = new System.Drawing.Point(660, 520);
            this.btnThoat.Size = new System.Drawing.Size(120, 45);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;

            // 
            // subfrmLichSuHoaDon
            // 
            this.ClientSize = new System.Drawing.Size(850, 600);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvChiTietHD);
            this.Controls.Add(this.txtPhanTramGiam);
            this.Controls.Add(this.labelGiamGia);
            this.Controls.Add(this.cbbKhachHang);
            this.Controls.Add(this.labelKhachHang);
            this.Controls.Add(this.cbbNhanVien);
            this.Controls.Add(this.labelNhanVien);
            this.Controls.Add(this.dtpNgayNhap);
            this.Controls.Add(this.labelNgayNhap);
            this.Controls.Add(this.txtMaHD);
            this.Controls.Add(this.labelMaHD);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Text = "Chi tiết hóa đơn";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelMaHD;
        private System.Windows.Forms.Label labelNgayNhap;
        private System.Windows.Forms.Label labelNhanVien;
        private System.Windows.Forms.Label labelKhachHang;
        private System.Windows.Forms.Label labelGiamGia;

        public System.Windows.Forms.TextBox txtMaHD;
        public System.Windows.Forms.DateTimePicker dtpNgayNhap;
        public System.Windows.Forms.ComboBox cbbNhanVien;
        public System.Windows.Forms.ComboBox cbbKhachHang;
        public System.Windows.Forms.TextBox txtPhanTramGiam;

        public System.Windows.Forms.DataGridView dgvChiTietHD;
        public System.Windows.Forms.Button btnThem;
        public System.Windows.Forms.Button btnSua;
        public System.Windows.Forms.Button btnXoa;
        public System.Windows.Forms.Button btnLuu;
        public System.Windows.Forms.Button btnThoat;
    }
}
