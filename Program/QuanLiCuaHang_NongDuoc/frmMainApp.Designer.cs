using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLiCuaHang_NongDuoc
{
    public partial class frmMainApp : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panel1;
        private Panel panel2;
        private Button btnTrangChu;
        private Button btnHoaDon;
        private Button btnPhieuNhap;
        private Button btnSanPham;
        private Button btnNhaCC;
        private Button btnKhachHang;
        private Button btnDangXuat;

      

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlActive = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnNhaCC = new System.Windows.Forms.Button();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.btnPhieuNhap = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTimeRendering = new System.Windows.Forms.Label();
            this.lblDateRendering = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNamePage = new System.Windows.Forms.Label();
            this.pnlContentPages = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnLichSu = new System.Windows.Forms.Button();
            this.picBoxUserAvatar = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Chartreuse;
            this.panel1.Controls.Add(this.lblEmail);
            this.panel1.Controls.Add(this.lblUsername);
            this.panel1.Controls.Add(this.picBoxUserAvatar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 42);
            this.panel1.TabIndex = 0;
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(602, 21);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "Email";
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(601, 2);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(83, 20);
            this.lblUsername.TabIndex = 7;
            this.lblUsername.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Chartreuse;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lí Nông Dược";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.btnLichSu);
            this.panel2.Controls.Add(this.pnlActive);
            this.panel2.Controls.Add(this.btnDangXuat);
            this.panel2.Controls.Add(this.btnKhachHang);
            this.panel2.Controls.Add(this.btnNhaCC);
            this.panel2.Controls.Add(this.btnSanPham);
            this.panel2.Controls.Add(this.btnPhieuNhap);
            this.panel2.Controls.Add(this.btnHoaDon);
            this.panel2.Controls.Add(this.btnTrangChu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 42);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(147, 434);
            this.panel2.TabIndex = 1;
            // 
            // pnlActive
            // 
            this.pnlActive.BackColor = System.Drawing.Color.Tomato;
            this.pnlActive.Location = new System.Drawing.Point(138, 47);
            this.pnlActive.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlActive.Name = "pnlActive";
            this.pnlActive.Size = new System.Drawing.Size(7, 38);
            this.pnlActive.TabIndex = 7;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.SystemColors.Window;
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnDangXuat.Location = new System.Drawing.Point(0, 402);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(147, 32);
            this.btnDangXuat.TabIndex = 0;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.BackColor = System.Drawing.SystemColors.Window;
            this.btnKhachHang.FlatAppearance.BorderSize = 0;
            this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhachHang.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnKhachHang.Location = new System.Drawing.Point(2, 270);
            this.btnKhachHang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(109, 29);
            this.btnKhachHang.TabIndex = 1;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.UseVisualStyleBackColor = false;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnNhaCC
            // 
            this.btnNhaCC.BackColor = System.Drawing.SystemColors.Window;
            this.btnNhaCC.FlatAppearance.BorderSize = 0;
            this.btnNhaCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhaCC.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhaCC.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnNhaCC.Location = new System.Drawing.Point(-1, 223);
            this.btnNhaCC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNhaCC.Name = "btnNhaCC";
            this.btnNhaCC.Size = new System.Drawing.Size(84, 29);
            this.btnNhaCC.TabIndex = 2;
            this.btnNhaCC.Text = "Nhà CC";
            this.btnNhaCC.UseVisualStyleBackColor = false;
            this.btnNhaCC.Click += new System.EventHandler(this.btnNhaCC_Click);
            // 
            // btnSanPham
            // 
            this.btnSanPham.BackColor = System.Drawing.SystemColors.Window;
            this.btnSanPham.FlatAppearance.BorderSize = 0;
            this.btnSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSanPham.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSanPham.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnSanPham.Location = new System.Drawing.Point(0, 176);
            this.btnSanPham.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(101, 29);
            this.btnSanPham.TabIndex = 3;
            this.btnSanPham.Text = "Sản phẩm";
            this.btnSanPham.UseVisualStyleBackColor = false;
            this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click);
            // 
            // btnPhieuNhap
            // 
            this.btnPhieuNhap.BackColor = System.Drawing.SystemColors.Window;
            this.btnPhieuNhap.FlatAppearance.BorderSize = 0;
            this.btnPhieuNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhieuNhap.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnPhieuNhap.Location = new System.Drawing.Point(-1, 135);
            this.btnPhieuNhap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPhieuNhap.Name = "btnPhieuNhap";
            this.btnPhieuNhap.Size = new System.Drawing.Size(111, 29);
            this.btnPhieuNhap.TabIndex = 4;
            this.btnPhieuNhap.Text = "Phiếu nhập";
            this.btnPhieuNhap.UseVisualStyleBackColor = false;
            this.btnPhieuNhap.Click += new System.EventHandler(this.btnPhieuNhap_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.BackColor = System.Drawing.SystemColors.Window;
            this.btnHoaDon.FlatAppearance.BorderSize = 0;
            this.btnHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDon.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnHoaDon.Location = new System.Drawing.Point(0, 91);
            this.btnHoaDon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(91, 29);
            this.btnHoaDon.TabIndex = 5;
            this.btnHoaDon.Text = "Hóa đơn";
            this.btnHoaDon.UseVisualStyleBackColor = false;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.BackColor = System.Drawing.SystemColors.Window;
            this.btnTrangChu.FlatAppearance.BorderSize = 0;
            this.btnTrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangChu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrangChu.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnTrangChu.Location = new System.Drawing.Point(-1, 47);
            this.btnTrangChu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(102, 29);
            this.btnTrangChu.TabIndex = 6;
            this.btnTrangChu.Text = "Trang chủ";
            this.btnTrangChu.UseVisualStyleBackColor = false;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lblTimeRendering);
            this.panel3.Controls.Add(this.lblDateRendering);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lblNamePage);
            this.panel3.Location = new System.Drawing.Point(160, 52);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(555, 41);
            this.panel3.TabIndex = 2;
            // 
            // lblTimeRendering
            // 
            this.lblTimeRendering.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimeRendering.AutoSize = true;
            this.lblTimeRendering.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeRendering.Location = new System.Drawing.Point(428, 13);
            this.lblTimeRendering.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimeRendering.Name = "lblTimeRendering";
            this.lblTimeRendering.Size = new System.Drawing.Size(43, 20);
            this.lblTimeRendering.TabIndex = 6;
            this.lblTimeRendering.Text = "Time";
            // 
            // lblDateRendering
            // 
            this.lblDateRendering.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDateRendering.AutoSize = true;
            this.lblDateRendering.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateRendering.Location = new System.Drawing.Point(201, 12);
            this.lblDateRendering.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDateRendering.Name = "lblDateRendering";
            this.lblDateRendering.Size = new System.Drawing.Size(52, 20);
            this.lblDateRendering.TabIndex = 5;
            this.lblDateRendering.Text = "Date: ";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(374, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(147, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date: ";
            // 
            // lblNamePage
            // 
            this.lblNamePage.AutoSize = true;
            this.lblNamePage.BackColor = System.Drawing.Color.White;
            this.lblNamePage.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamePage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNamePage.Location = new System.Drawing.Point(2, 7);
            this.lblNamePage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNamePage.Name = "lblNamePage";
            this.lblNamePage.Size = new System.Drawing.Size(113, 25);
            this.lblNamePage.TabIndex = 2;
            this.lblNamePage.Text = "Name Page";
            // 
            // pnlContentPages
            // 
            this.pnlContentPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContentPages.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlContentPages.Location = new System.Drawing.Point(160, 106);
            this.pnlContentPages.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlContentPages.Name = "pnlContentPages";
            this.pnlContentPages.Size = new System.Drawing.Size(555, 362);
            this.pnlContentPages.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnLichSu
            // 
            this.btnLichSu.BackColor = System.Drawing.SystemColors.Window;
            this.btnLichSu.FlatAppearance.BorderSize = 0;
            this.btnLichSu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLichSu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLichSu.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnLichSu.Location = new System.Drawing.Point(-8, 319);
            this.btnLichSu.Margin = new System.Windows.Forms.Padding(2);
            this.btnLichSu.Name = "btnLichSu";
            this.btnLichSu.Size = new System.Drawing.Size(109, 29);
            this.btnLichSu.TabIndex = 8;
            this.btnLichSu.Text = "Lịch Sử";
            this.btnLichSu.UseVisualStyleBackColor = false;
            this.btnLichSu.Click += new System.EventHandler(this.btnLichSu_Click);
            // 
            // picBoxUserAvatar
            // 
            this.picBoxUserAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxUserAvatar.BackColor = System.Drawing.Color.Chartreuse;
            this.picBoxUserAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picBoxUserAvatar.Image = global::QuanLiCuaHang_NongDuoc.Properties.Resources.user;
            this.picBoxUserAvatar.Location = new System.Drawing.Point(557, 2);
            this.picBoxUserAvatar.Margin = new System.Windows.Forms.Padding(2);
            this.picBoxUserAvatar.Name = "picBoxUserAvatar";
            this.picBoxUserAvatar.Size = new System.Drawing.Size(41, 34);
            this.picBoxUserAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxUserAvatar.TabIndex = 1;
            this.picBoxUserAvatar.TabStop = false;
            this.picBoxUserAvatar.Click += new System.EventHandler(this.picBoxUserAvatar_Click);
            // 
            // frmMainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 476);
            this.Controls.Add(this.pnlContentPages);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmMainApp";
            this.Text = "Quản lý cửa hàng nông dược";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainApp_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserAvatar)).EndInit();
            this.ResumeLayout(false);

        }
        private PictureBox picBoxUserAvatar;
        private Panel panel3;
        private Label label1;
        private Label lblTimeRendering;
        private Label lblDateRendering;
        private Label label3;
        private Label label2;
        private Label lblNamePage;
        private Label lblEmail;
        private Label lblUsername;
        private Panel pnlActive;
        private Panel pnlContentPages;
        private Timer timer1;
        private Button btnLichSu;
    }
}
