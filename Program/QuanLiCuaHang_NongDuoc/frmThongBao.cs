using QuanLiCuaHang_NongDuoc.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCuaHang_NongDuoc
{
    public partial class frmThongBao : Form
    {
        public frmThongBao()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        public enum enmAction { 
            wait,
            start,
            close
        }

        public enum enmType
        { 
            Success,
            Warning,
            Error,
            Info
        }
        private frmThongBao.enmAction action;

        private int x, y;

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 5000;
                    action = enmAction.close;
                    break;
                case frmThongBao.enmAction.start:
                    //Xuất hiện dần dần và ảnh hiện từ từ từ phải sang trái
                    this.timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else {
                        if (this.Opacity == 1.0) {
                            action = frmThongBao.enmAction.wait;
                        }
                    }
                    break;

                case enmAction.close:
                    //Biến mất dần từ trái qua phải
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0) { 
                        this.Hide();
                        timer1.Stop();
                    }
                    break;
            }
        }

        public void showAlert(string message, enmType type) {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++) {
                i++;   
            }

            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
            switch (type) { 
                case enmType.Success:
                    //this.pictureBox1.Image = Resources
                    this.BackColor = Color.SeaGreen;
                    break;

                case enmType.Error:
                    //
                    this.BackColor = Color.Red;
                    break;
                case enmType.Warning:
                    //
                   this.BackColor = Color.Yellow;
                    break;

            
            }
            this.lblMessage.Text = message;
            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }
    }
}
