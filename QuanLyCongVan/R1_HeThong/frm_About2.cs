using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32;

namespace QuanLyCongVan
{
    public partial class frm_About2 : DevExpress.XtraEditors.XtraForm
    {
        public frm_About2()
        {
            InitializeComponent();
        }
        public event EventHandler Button_Clicked;
        private void frm_About_Load(object sender, EventArgs e)
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int X = ((screenWidth - pictureEdit2.Width) /2);
            pictureEdit2.Location = new System.Drawing.Point(X, 40);
            //int X_Text = X + 30;
            //int Y_Text = 340;
            //int YY_Text = 18;
            //lbDVCQ.Location = new System.Drawing.Point(X_Text, Y_Text);
            //lbDVSD.Location = new System.Drawing.Point(X_Text, Y_Text + YY_Text);
            //lbDC.Location = new System.Drawing.Point(X_Text, Y_Text + YY_Text * 2);
            //lbDT.Location = new System.Drawing.Point(X_Text, Y_Text + YY_Text * 3);
            //labelControl2.Location = new System.Drawing.Point(X_Text, Y_Text + YY_Text * 4);
            //hyperLinkEdit2.Location = new System.Drawing.Point(X_Text+46, Y_Text + YY_Text * 3-3);
            //hyperLinkEdit1.Location = new System.Drawing.Point(X_Text+43, Y_Text + YY_Text * 4-3);

            int W_Button = bTKDI.Width + bTKDEN.Width + bCVDen.Width + bCVDi.Width + bbBiennhan .Width + 15 * 4;//* 4 là 4 khoảng cách giữa các nút
            int X_Button = (screenWidth - W_Button) / 2;
            bCVDen.Location = new System.Drawing.Point(X_Button, 205);
            bCVDi.Location = new System.Drawing.Point(X_Button + 12 + bTKDI.Width, 205);
            bTKDEN.Location = new System.Drawing.Point(X_Button + (12 * 2) + bTKDI.Width * 2, 205);
            bTKDI.Location = new System.Drawing.Point(X_Button + (12 * 3) + bTKDI.Width * 3, 205);
            bbBiennhan.Location = new System.Drawing.Point(X_Button + (12 * 4) + bbBiennhan.Width * 4, 205);

            X = ((screenWidth - labelControl1.Width) / 2);
            labelControl1.Location = new System.Drawing.Point(X, 161);
            X = ((screenWidth - layoutControl1.Width) / 2) + 30;
            layoutControl1.Location = new System.Drawing.Point(X, 57);

            pictureEdit1.Image = ThamSoHeThong.LOGO;
            X = ((screenWidth - pictureEdit2.Width) / 2);
            X = X + 20;
            pictureEdit1.Location = new System.Drawing.Point(X, 62);

            lbDVCQ2.Text = ThamSoHeThong.DONVICHUQUAN.ToUpper();
            lbDVSD2.Text = ThamSoHeThong.DONVISUDUNG.ToUpper();
        }

        private void bCVDen_Click(object sender, EventArgs e)
        {
            if (ThamSoHeThong.TrangThaiLogin == true)
            {
                ThamSoHeThong.FormOpen = "CVDEN";
                if (this.Button_Clicked != null)
                    this.Button_Clicked(sender, e);
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng đăng nhập !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void nCVDi_Click(object sender, EventArgs e)
        {
            if (ThamSoHeThong.TrangThaiLogin == true)
            {
                ThamSoHeThong.FormOpen = "CVDI";
                if (this.Button_Clicked != null)
                    this.Button_Clicked(sender, e);
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng đăng nhập !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void bTKHS_Click(object sender, EventArgs e)
        {
            if (ThamSoHeThong.TrangThaiLogin == true)
            {
                ThamSoHeThong.FormOpen = "TKDEN";
                if (this.Button_Clicked != null)
                    this.Button_Clicked(sender, e);
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng đăng nhập !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void bQLHS_Click(object sender, EventArgs e)
        {
            if (ThamSoHeThong.TrangThaiLogin == true)
            {
                ThamSoHeThong.FormOpen = "TKDI";
                if (this.Button_Clicked != null)
                    this.Button_Clicked(sender, e);
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng đăng nhập !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bbBiennhan_Click(object sender, EventArgs e)
        {
            if (ThamSoHeThong.TrangThaiLogin == true)
            {
                ThamSoHeThong.FormOpen = "BNHS";
                if (this.Button_Clicked != null)
                    this.Button_Clicked(sender, e);
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng đăng nhập !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }       
    }
}