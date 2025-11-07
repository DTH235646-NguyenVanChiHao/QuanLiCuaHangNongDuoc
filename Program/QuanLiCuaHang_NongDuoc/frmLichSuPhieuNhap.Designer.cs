namespace QuanLiCuaHang_NongDuoc
{
    partial class frmLichSuPhieuNhap
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvPhieuNhap = new System.Windows.Forms.DataGridView();
            this.MaPhieuNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhaCungCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiTiet = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblTongChiPhi = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTongPhieuNhap = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).BeginInit();
            this.pnlBottom.SuspendLayout();
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
            this.txtSearch.Location = new System.Drawing.Point(635, 14);
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
            this.lblSearch.Location = new System.Drawing.Point(519, 18);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(113, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm kiếm nhanh:";
            // 
            // dgvPhieuNhap
            // 
            this.dgvPhieuNhap.AllowUserToAddRows = false;
            this.dgvPhieuNhap.AllowUserToDeleteRows = false;
            this.dgvPhieuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuNhap.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhieuNhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhieuNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvPhieuNhap.ColumnHeadersHeight = 45;
            this.dgvPhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhieuNhap,
            this.NgayNhap,
            this.NhaCungCap,
            this.TenNhanVien,
            this.TongTien,
            this.TrangThai,
            this.GhiChu,
            this.ChiTiet});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(199)))), ((int)(((byte)(132)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhieuNhap.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuNhap.EnableHeadersVisualStyles = false;
            this.dgvPhieuNhap.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.dgvPhieuNhap.Location = new System.Drawing.Point(0, 48);
            this.dgvPhieuNhap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPhieuNhap.MultiSelect = false;
            this.dgvPhieuNhap.Name = "dgvPhieuNhap";
            this.dgvPhieuNhap.ReadOnly = true;
            this.dgvPhieuNhap.RowHeadersVisible = false;
            this.dgvPhieuNhap.RowHeadersWidth = 62;
            this.dgvPhieuNhap.RowTemplate.Height = 40;
            this.dgvPhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuNhap.Size = new System.Drawing.Size(800, 362);
            this.dgvPhieuNhap.TabIndex = 1;
            // 
            // MaPhieuNhap
            // 
            this.MaPhieuNhap.FillWeight = 80F;
            this.MaPhieuNhap.HeaderText = "Mã PN";
            this.MaPhieuNhap.MinimumWidth = 8;
            this.MaPhieuNhap.Name = "MaPhieuNhap";
            this.MaPhieuNhap.ReadOnly = true;
            // 
            // NgayNhap
            // 
            this.NgayNhap.FillWeight = 90F;
            this.NgayNhap.HeaderText = "Ngày nhập";
            this.NgayNhap.MinimumWidth = 8;
            this.NgayNhap.Name = "NgayNhap";
            this.NgayNhap.ReadOnly = true;
            // 
            // NhaCungCap
            // 
            this.NhaCungCap.FillWeight = 130F;
            this.NhaCungCap.HeaderText = "Nhà cung cấp";
            this.NhaCungCap.MinimumWidth = 8;
            this.NhaCungCap.Name = "NhaCungCap";
            this.NhaCungCap.ReadOnly = true;
            // 
            // TenNhanVien
            // 
            this.TenNhanVien.FillWeight = 110F;
            this.TenNhanVien.HeaderText = "Nhân viên";
            this.TenNhanVien.MinimumWidth = 8;
            this.TenNhanVien.Name = "TenNhanVien";
            this.TenNhanVien.ReadOnly = true;
            // 
            // TongTien
            // 
            this.TongTien.FillWeight = 90F;
            this.TongTien.HeaderText = "Tổng tiền";
            this.TongTien.MinimumWidth = 8;
            this.TongTien.Name = "TongTien";
            this.TongTien.ReadOnly = true;
            // 
            // TrangThai
            // 
            this.TrangThai.FillWeight = 90F;
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.MinimumWidth = 8;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            // 
            // GhiChu
            // 
            this.GhiChu.FillWeight = 120F;
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.MinimumWidth = 8;
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
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
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Controls.Add(this.lblTongChiPhi);
            this.pnlBottom.Controls.Add(this.label4);
            this.pnlBottom.Controls.Add(this.lblTongPhieuNhap);
            this.pnlBottom.Controls.Add(this.label3);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 371);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(800, 39);
            this.pnlBottom.TabIndex = 2;
            // 
            // lblTongChiPhi
            // 
            this.lblTongChiPhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongChiPhi.AutoSize = true;
            this.lblTongChiPhi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongChiPhi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblTongChiPhi.Location = new System.Drawing.Point(668, 10);
            this.lblTongChiPhi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongChiPhi.Name = "lblTongChiPhi";
            this.lblTongChiPhi.Size = new System.Drawing.Size(19, 21);
            this.lblTongChiPhi.TabIndex = 3;
            this.lblTongChiPhi.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(569, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tổng chi phí: ";
            // 
            // lblTongPhieuNhap
            // 
            this.lblTongPhieuNhap.AutoSize = true;
            this.lblTongPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongPhieuNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblTongPhieuNhap.Location = new System.Drawing.Point(152, 10);
            this.lblTongPhieuNhap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongPhieuNhap.Name = "lblTongPhieuNhap";
            this.lblTongPhieuNhap.Size = new System.Drawing.Size(19, 21);
            this.lblTongPhieuNhap.TabIndex = 1;
            this.lblTongPhieuNhap.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tổng phiếu nhập:  ";
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
            this.btnXoa.Location = new System.Drawing.Point(112, 6);
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
            this.btnSua.Location = new System.Drawing.Point(1, 6);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 36);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // frmLichSuPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(800, 410);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.dgvPhieuNhap);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmLichSuPhieuNhap";
            this.Text = "Lịch Sử Phiếu Nhập";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvPhieuNhap;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblTongPhieuNhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTongChiPhi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhieuNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewButtonColumn ChiTiet;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
    }
}