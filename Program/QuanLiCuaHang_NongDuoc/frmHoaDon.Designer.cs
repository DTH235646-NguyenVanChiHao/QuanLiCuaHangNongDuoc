<<<<<<< HEAD
﻿using System;

namespace QuanLiCuaHang_NongDuoc
=======
﻿namespace QuanLiCuaHang_NongDuoc
>>>>>>> 3316b5bb2ca6c031132a68e5c07e8d71446aa92a
{
    partial class frmHoaDon
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

<<<<<<< HEAD
=======
        #region Windows Form Designer generated code
>>>>>>> 3316b5bb2ca6c031132a68e5c07e8d71446aa92a

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
<<<<<<< HEAD
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.lblTong = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNhapSP = new System.Windows.Forms.TextBox();
            this.pnlHienThi = new System.Windows.Forms.Panel();
            this.pnlHienThiSP = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlHienThi.SuspendLayout();
            this.panel3.SuspendLayout();
=======
>>>>>>> 3316b5bb2ca6c031132a68e5c07e8d71446aa92a
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
<<<<<<< HEAD
            this.label1.Location = new System.Drawing.Point(156, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hoá đơn";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnThanhToan.Location = new System.Drawing.Point(15, 402);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(177, 47);
            this.btnThanhToan.TabIndex = 1;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnClear.Location = new System.Drawing.Point(219, 402);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(167, 47);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(15, 77);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(371, 319);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // lblTong
            // 
            this.lblTong.AutoSize = true;
            this.lblTong.Location = new System.Drawing.Point(156, 468);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(67, 27);
            this.lblTong.TabIndex = 3;
            this.lblTong.Text = "Tổng:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.lblTong);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnThanhToan);
            this.panel1.Location = new System.Drawing.Point(745, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 554);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tìm sản phẩm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 27);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bán Hàng";
            // 
            // txtNhapSP
            // 
            this.txtNhapSP.Location = new System.Drawing.Point(171, 42);
            this.txtNhapSP.Name = "txtNhapSP";
            this.txtNhapSP.Size = new System.Drawing.Size(202, 35);
            this.txtNhapSP.TabIndex = 7;
            // 
            // pnlHienThi
            // 
            this.pnlHienThi.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHienThi.Controls.Add(this.pnlHienThiSP);
            this.pnlHienThi.Controls.Add(this.panel3);
            this.pnlHienThi.Location = new System.Drawing.Point(-3, 108);
            this.pnlHienThi.Name = "pnlHienThi";
            this.pnlHienThi.Size = new System.Drawing.Size(742, 488);
            this.pnlHienThi.TabIndex = 8;
            // 
            // pnlHienThiSP
            // 
            this.pnlHienThiSP.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlHienThiSP.Location = new System.Drawing.Point(3, 68);
            this.pnlHienThiSP.Name = "pnlHienThiSP";
            this.pnlHienThiSP.Size = new System.Drawing.Size(736, 417);
            this.pnlHienThiSP.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(20, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(713, 51);
            this.panel3.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(283, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Danh sách hóa đơn";
            // 
            // frmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1156, 608);
            this.Controls.Add(this.pnlHienThi);
            this.Controls.Add(this.txtNhapSP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHoaDon";
            this.Text = "Hoá Đơn";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlHienThi.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
=======
            this.label1.Location = new System.Drawing.Point(230, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hoá đơn";
            // 
            // frmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Name = "frmHoaDon";
            this.Text = "Hoá Đơn";
>>>>>>> 3316b5bb2ca6c031132a68e5c07e8d71446aa92a
            this.ResumeLayout(false);
            this.PerformLayout();

        }

<<<<<<< HEAD
        // Khai báo các biến thành viên (đặt ở đầu lớp frmHoaDon)
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNhapSP;
        private System.Windows.Forms.Panel pnlHienThi;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlHienThiSP;
=======
        #endregion

        private System.Windows.Forms.Label label1;
>>>>>>> 3316b5bb2ca6c031132a68e5c07e8d71446aa92a
    }
}