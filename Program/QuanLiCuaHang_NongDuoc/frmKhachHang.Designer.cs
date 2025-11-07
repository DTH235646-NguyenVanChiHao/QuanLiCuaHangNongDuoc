namespace QuanLiCuaHang_NongDuoc
{
    partial class frmKhachHang
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
            this.label6 = new System.Windows.Forms.Label();
            this.lblTongTrang = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTrangHienTai = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDSKH = new System.Windows.Forms.DataGridView();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.SoTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKH)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(709, 285);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Tổng trang";
            // 
            // lblTongTrang
            // 
            this.lblTongTrang.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTongTrang.AutoSize = true;
            this.lblTongTrang.Location = new System.Drawing.Point(693, 285);
            this.lblTongTrang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongTrang.Name = "lblTongTrang";
            this.lblTongTrang.Size = new System.Drawing.Size(14, 13);
            this.lblTongTrang.TabIndex = 27;
            this.lblTongTrang.Text = "#";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(665, 285);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "của";
            // 
            // lblTrangHienTai
            // 
            this.lblTrangHienTai.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTrangHienTai.AutoSize = true;
            this.lblTrangHienTai.Location = new System.Drawing.Point(649, 285);
            this.lblTrangHienTai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTrangHienTai.Name = "lblTrangHienTai";
            this.lblTrangHienTai.Size = new System.Drawing.Size(14, 13);
            this.lblTrangHienTai.TabIndex = 25;
            this.lblTrangHienTai.Text = "#";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(612, 285);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Trang";
            // 
            // dgvDSKH
            // 
            this.dgvDSKH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDSKH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSKH.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSKH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSKH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoTT,
            this.MaKH,
            this.TenKH,
            this.DiaChi,
            this.Email,
            this.TrangThai,
            this.SDT});
            this.dgvDSKH.Location = new System.Drawing.Point(9, 37);
            this.dgvDSKH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDSKH.MultiSelect = false;
            this.dgvDSKH.Name = "dgvDSKH";
            this.dgvDSKH.RowHeadersVisible = false;
            this.dgvDSKH.RowHeadersWidth = 62;
            this.dgvDSKH.RowTemplate.Height = 28;
            this.dgvDSKH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSKH.Size = new System.Drawing.Size(757, 237);
            this.dgvDSKH.TabIndex = 23;
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFirst.BackColor = System.Drawing.Color.LightGray;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Location = new System.Drawing.Point(303, 278);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(33, 27);
            this.btnFirst.TabIndex = 14;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrev.BackColor = System.Drawing.Color.LightGray;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Location = new System.Drawing.Point(341, 278);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(33, 27);
            this.btnPrev.TabIndex = 16;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNext.BackColor = System.Drawing.Color.LightGray;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(383, 278);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(33, 27);
            this.btnNext.TabIndex = 18;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLast.BackColor = System.Drawing.Color.LightGray;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Location = new System.Drawing.Point(421, 278);
            this.btnLast.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(33, 27);
            this.btnLast.TabIndex = 20;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(613, 7);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(155, 25);
            this.txtSearch.TabIndex = 22;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSort
            // 
            this.btnSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSort.FlatAppearance.BorderSize = 0;
            this.btnSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSort.ForeColor = System.Drawing.Color.White;
            this.btnSort.Location = new System.Drawing.Point(485, 7);
            this.btnSort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(117, 26);
            this.btnSort.TabIndex = 21;
            this.btnSort.Text = "Sắp xếp";
            this.btnSort.UseVisualStyleBackColor = false;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(181, 7);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 26);
            this.btnXoa.TabIndex = 19;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(94, 7);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 26);
            this.btnSua.TabIndex = 17;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(7, 7);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 26);
            this.btnThem.TabIndex = 15;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // SoTT
            // 
            this.SoTT.HeaderText = "Khách hàng thứ";
            this.SoTT.MinimumWidth = 8;
            this.SoTT.Name = "SoTT";
            // 
            // MaKH
            // 
            this.MaKH.HeaderText = "Mã Khách Hàng";
            this.MaKH.MinimumWidth = 8;
            this.MaKH.Name = "MaKH";
            // 
            // TenKH
            // 
            this.TenKH.HeaderText = "Tên Khách Hàng";
            this.TenKH.MinimumWidth = 8;
            this.TenKH.Name = "TenKH";
            // 
            // DiaChi
            // 
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.MinimumWidth = 8;
            this.DiaChi.Name = "DiaChi";
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 8;
            this.Email.Name = "Email";
            // 
            // TrangThai
            // 
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.MinimumWidth = 8;
            this.TrangThai.Name = "TrangThai";
            // 
            // SDT
            // 
            this.SDT.HeaderText = "SDT";
            this.SDT.MinimumWidth = 8;
            this.SDT.Name = "SDT";
            // 
            // frmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(773, 312);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTongTrang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTrangHienTai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDSKH);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmKhachHang";
            this.Text = "Khách Hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTongTrang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTrangHienTai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDSKH;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDT;
    }
}