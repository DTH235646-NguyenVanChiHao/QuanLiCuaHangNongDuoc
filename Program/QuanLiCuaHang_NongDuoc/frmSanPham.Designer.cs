namespace QuanLiCuaHang_NongDuoc
{
    partial class frmSanPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.dgvDSSP = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTrangHienTai = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTongTrang = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTongSanPham = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoTaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaMua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongConLai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSP)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(7, 6);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 26);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "➕ Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(93, 6);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 26);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "✏️ Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(180, 6);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 26);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "🗑️ Xoá";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnSort
            // 
            this.btnSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnSort.FlatAppearance.BorderSize = 0;
            this.btnSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSort.ForeColor = System.Drawing.Color.White;
            this.btnSort.Location = new System.Drawing.Point(407, 6);
            this.btnSort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(93, 26);
            this.btnSort.TabIndex = 3;
            this.btnSort.Text = "⇅ Sắp xếp";
            this.btnSort.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.Location = new System.Drawing.Point(612, 9);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(154, 27);
            this.txtSearch.TabIndex = 5;
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(559, 12);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(67, 19);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "Tìm kiếm:";
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFirst.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFirst.Location = new System.Drawing.Point(243, 278);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(33, 27);
            this.btnFirst.TabIndex = 6;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = false;
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrev.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrev.Location = new System.Drawing.Point(280, 278);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(33, 27);
            this.btnPrev.TabIndex = 7;
            this.btnPrev.Text = "◀";
            this.btnPrev.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNext.Location = new System.Drawing.Point(317, 278);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(33, 27);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "▶";
            this.btnNext.UseVisualStyleBackColor = false;
            // 
            // btnLast
            // 
            this.btnLast.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLast.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLast.Location = new System.Drawing.Point(355, 278);
            this.btnLast.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(33, 27);
            this.btnLast.TabIndex = 9;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = false;
            // 
            // dgvDSSP
            // 
            this.dgvDSSP.AllowUserToAddRows = false;
            this.dgvDSSP.AllowUserToDeleteRows = false;
            this.dgvDSSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDSSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSSP.BackgroundColor = System.Drawing.Color.White;
            this.dgvDSSP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSSP.ColumnHeadersHeight = 40;
            this.dgvDSSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.TenSP,
            this.MoTaSP,
            this.GiaMua,
            this.GiaBan,
            this.SoLuongConLai,
            this.DonViTinh,
            this.TrangThai});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDSSP.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDSSP.EnableHeadersVisualStyles = false;
            this.dgvDSSP.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.dgvDSSP.Location = new System.Drawing.Point(8, 39);
            this.dgvDSSP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDSSP.MultiSelect = false;
            this.dgvDSSP.Name = "dgvDSSP";
            this.dgvDSSP.ReadOnly = true;
            this.dgvDSSP.RowHeadersVisible = false;
            this.dgvDSSP.RowHeadersWidth = 62;
            this.dgvDSSP.RowTemplate.Height = 35;
            this.dgvDSSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSSP.Size = new System.Drawing.Size(757, 231);
            this.dgvDSSP.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(413, 284);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Trang";
            // 
            // lblTrangHienTai
            // 
            this.lblTrangHienTai.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTrangHienTai.AutoSize = true;
            this.lblTrangHienTai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrangHienTai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTrangHienTai.Location = new System.Drawing.Point(449, 284);
            this.lblTrangHienTai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTrangHienTai.Name = "lblTrangHienTai";
            this.lblTrangHienTai.Size = new System.Drawing.Size(14, 15);
            this.lblTrangHienTai.TabIndex = 12;
            this.lblTrangHienTai.Text = "1";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(464, 284);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "của";
            // 
            // lblTongTrang
            // 
            this.lblTongTrang.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTongTrang.AutoSize = true;
            this.lblTongTrang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTongTrang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTongTrang.Location = new System.Drawing.Point(490, 284);
            this.lblTongTrang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongTrang.Name = "lblTongTrang";
            this.lblTongTrang.Size = new System.Drawing.Size(14, 15);
            this.lblTongTrang.TabIndex = 14;
            this.lblTongTrang.Text = "1";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(505, 284);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "tổng trang";
            // 
            // lblTongSanPham
            // 
            this.lblTongSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongSanPham.AutoSize = true;
            this.lblTongSanPham.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTongSanPham.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTongSanPham.Location = new System.Drawing.Point(99, 284);
            this.lblTongSanPham.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongSanPham.Name = "lblTongSanPham";
            this.lblTongSanPham.Size = new System.Drawing.Size(14, 15);
            this.lblTongSanPham.TabIndex = 18;
            this.lblTongSanPham.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(8, 284);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Tổng sản phẩm: ";
            // 
            // MaSP
            // 
            this.MaSP.HeaderText = "Mã SP";
            this.MaSP.MinimumWidth = 8;
            this.MaSP.Name = "MaSP";
            this.MaSP.ReadOnly = true;
            // 
            // TenSP
            // 
            this.TenSP.HeaderText = "Tên SP";
            this.TenSP.MinimumWidth = 8;
            this.TenSP.Name = "TenSP";
            this.TenSP.ReadOnly = true;
            // 
            // MoTaSP
            // 
            this.MoTaSP.HeaderText = "Mô Tả SP";
            this.MoTaSP.MinimumWidth = 8;
            this.MoTaSP.Name = "MoTaSP";
            this.MoTaSP.ReadOnly = true;
            // 
            // GiaMua
            // 
            this.GiaMua.HeaderText = "Giá Mua";
            this.GiaMua.MinimumWidth = 8;
            this.GiaMua.Name = "GiaMua";
            this.GiaMua.ReadOnly = true;
            // 
            // GiaBan
            // 
            this.GiaBan.HeaderText = "Giá Bán";
            this.GiaBan.MinimumWidth = 8;
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.ReadOnly = true;
            // 
            // SoLuongConLai
            // 
            this.SoLuongConLai.HeaderText = "SL Còn Lại";
            this.SoLuongConLai.MinimumWidth = 8;
            this.SoLuongConLai.Name = "SoLuongConLai";
            this.SoLuongConLai.ReadOnly = true;
            // 
            // DonViTinh
            // 
            this.DonViTinh.HeaderText = "Đơn Vị Tính";
            this.DonViTinh.MinimumWidth = 8;
            this.DonViTinh.Name = "DonViTinh";
            this.DonViTinh.ReadOnly = true;
            // 
            // TrangThai
            // 
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.MinimumWidth = 8;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            // 
            // frmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(773, 312);
            this.Controls.Add(this.lblTongSanPham);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTongTrang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTrangHienTai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDSSP);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmSanPham";
            this.Text = "Quản lý Sản Phẩm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.DataGridView dgvDSSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTrangHienTai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTongTrang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTongSanPham;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoTaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaMua;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongConLai;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
    }
}