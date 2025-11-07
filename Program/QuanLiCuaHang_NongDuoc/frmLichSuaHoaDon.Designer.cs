namespace QuanLiCuaHang_NongDuoc
{
    partial class frmLichSuaHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTongHoaDon = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ChiTiet = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhuongThucThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnXoa);
            this.pnlTop.Controls.Add(this.btnSua);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.pnlTop.Size = new System.Drawing.Size(800, 48);
            this.pnlTop.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(637, 8);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(155, 25);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(523, 11);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(113, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm kiếm nhanh:";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Controls.Add(this.lblTongDoanhThu);
            this.pnlBottom.Controls.Add(this.label4);
            this.pnlBottom.Controls.Add(this.lblTongHoaDon);
            this.pnlBottom.Controls.Add(this.label3);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 371);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(800, 39);
            this.pnlBottom.TabIndex = 2;
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.lblTongDoanhThu.Location = new System.Drawing.Point(668, 10);
            this.lblTongDoanhThu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(19, 21);
            this.lblTongDoanhThu.TabIndex = 3;
            this.lblTongDoanhThu.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label4.Location = new System.Drawing.Point(543, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tổng doanh thu: ";
            // 
            // lblTongHoaDon
            // 
            this.lblTongHoaDon.AutoSize = true;
            this.lblTongHoaDon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTongHoaDon.Location = new System.Drawing.Point(133, 10);
            this.lblTongHoaDon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongHoaDon.Name = "lblTongHoaDon";
            this.lblTongHoaDon.Size = new System.Drawing.Size(19, 21);
            this.lblTongHoaDon.TabIndex = 1;
            this.lblTongHoaDon.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label3.Location = new System.Drawing.Point(13, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tổng hóa đơn:  ";
            // 
            // ChiTiet
            // 
            this.ChiTiet.FillWeight = 70F;
            this.ChiTiet.HeaderText = "Chi tiết";
            this.ChiTiet.MinimumWidth = 8;
            this.ChiTiet.Name = "ChiTiet";
            this.ChiTiet.ReadOnly = true;
            this.ChiTiet.Text = "Xem";
            this.ChiTiet.UseColumnTextForButtonValue = true;
            // 
            // TrangThai
            // 
            this.TrangThai.FillWeight = 90F;
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.MinimumWidth = 8;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            // 
            // PhuongThucThanhToan
            // 
            this.PhuongThucThanhToan.HeaderText = "PTTT";
            this.PhuongThucThanhToan.MinimumWidth = 8;
            this.PhuongThucThanhToan.Name = "PhuongThucThanhToan";
            this.PhuongThucThanhToan.ReadOnly = true;
            // 
            // TongTien
            // 
            this.TongTien.FillWeight = 90F;
            this.TongTien.HeaderText = "Tổng tiền";
            this.TongTien.MinimumWidth = 8;
            this.TongTien.Name = "TongTien";
            this.TongTien.ReadOnly = true;
            // 
            // TenNhanVien
            // 
            this.TenNhanVien.FillWeight = 110F;
            this.TenNhanVien.HeaderText = "Nhân viên";
            this.TenNhanVien.MinimumWidth = 8;
            this.TenNhanVien.Name = "TenNhanVien";
            this.TenNhanVien.ReadOnly = true;
            // 
            // TenKhachHang
            // 
            this.TenKhachHang.FillWeight = 120F;
            this.TenKhachHang.HeaderText = "Khách hàng";
            this.TenKhachHang.MinimumWidth = 8;
            this.TenKhachHang.Name = "TenKhachHang";
            this.TenKhachHang.ReadOnly = true;
            // 
            // NgayLap
            // 
            this.NgayLap.FillWeight = 90F;
            this.NgayLap.HeaderText = "Ngày lập";
            this.NgayLap.MinimumWidth = 8;
            this.NgayLap.Name = "NgayLap";
            this.NgayLap.ReadOnly = true;
            // 
            // MaHoaDon
            // 
            this.MaHoaDon.FillWeight = 80F;
            this.MaHoaDon.HeaderText = "Mã HĐ";
            this.MaHoaDon.MinimumWidth = 8;
            this.MaHoaDon.Name = "MaHoaDon";
            this.MaHoaDon.ReadOnly = true;
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHoaDon.ColumnHeadersHeight = 45;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHoaDon,
            this.NgayLap,
            this.TenKhachHang,
            this.TenNhanVien,
            this.TongTien,
            this.PhuongThucThanhToan,
            this.TrangThai,
            this.ChiTiet});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHoaDon.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDon.EnableHeadersVisualStyles = false;
            this.dgvHoaDon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.dgvHoaDon.Location = new System.Drawing.Point(0, 48);
            this.dgvHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.RowHeadersWidth = 62;
            this.dgvHoaDon.RowTemplate.Height = 40;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(800, 362);
            this.dgvHoaDon.TabIndex = 1;
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnXoa.BackColor = System.Drawing.Color.Red;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatAppearance.BorderSize = 2;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(112, 4);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 36);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSua.BackColor = System.Drawing.Color.Gold;
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FlatAppearance.BorderSize = 2;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(1, 4);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 36);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // frmLichSuaHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(800, 410);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmLichSuaHoaDon";
            this.Text = "Lịch Sử Hóa Đơn";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblTongHoaDon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewButtonColumn ChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhuongThucThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHoaDon;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
    }
}