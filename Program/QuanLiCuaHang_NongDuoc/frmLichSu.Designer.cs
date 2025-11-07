namespace QuanLiCuaHang_NongDuoc
{
    partial class frmLichSu
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlIndicator = new System.Windows.Forms.Panel();
            this.btnPhieuNhap = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.pnlIndicator);
            this.pnlTop.Controls.Add(this.btnPhieuNhap);
            this.pnlTop.Controls.Add(this.btnHoaDon);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(800, 52);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlIndicator
            // 
            this.pnlIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.pnlIndicator.Location = new System.Drawing.Point(0, 42);
            this.pnlIndicator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlIndicator.Name = "pnlIndicator";
            this.pnlIndicator.Size = new System.Drawing.Size(153, 3);
            this.pnlIndicator.TabIndex = 2;
            // 
            // btnPhieuNhap
            // 
            this.btnPhieuNhap.BackColor = System.Drawing.Color.White;
            this.btnPhieuNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhieuNhap.FlatAppearance.BorderSize = 0;
            this.btnPhieuNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPhieuNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnPhieuNhap.Location = new System.Drawing.Point(157, 0);
            this.btnPhieuNhap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPhieuNhap.Name = "btnPhieuNhap";
            this.btnPhieuNhap.Size = new System.Drawing.Size(153, 42);
            this.btnPhieuNhap.TabIndex = 1;
            this.btnPhieuNhap.Text = "📦 Phiếu Nhập";
            this.btnPhieuNhap.UseVisualStyleBackColor = false;
            this.btnPhieuNhap.Click += new System.EventHandler(this.btnPhieuNhap_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.BackColor = System.Drawing.Color.White;
            this.btnHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHoaDon.FlatAppearance.BorderSize = 0;
            this.btnHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoaDon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnHoaDon.Location = new System.Drawing.Point(0, 0);
            this.btnHoaDon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(153, 42);
            this.btnHoaDon.TabIndex = 0;
            this.btnHoaDon.Text = "🧾 Hóa Đơn";
            this.btnHoaDon.UseVisualStyleBackColor = false;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 52);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(800, 370);
            this.pnlContent.TabIndex = 1;
            // 
            // frmLichSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(800, 422);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmLichSu";
            this.Text = "Lịch Sử";
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnPhieuNhap;
        private System.Windows.Forms.Panel pnlIndicator;
        private System.Windows.Forms.Panel pnlContent;
    }
}