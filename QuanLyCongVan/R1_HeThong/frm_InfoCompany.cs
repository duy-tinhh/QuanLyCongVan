using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace QuanLyCongVan
{
    public partial class frm_InfoCompany : DevExpress.XtraEditors.XtraForm
    {
        public frm_InfoCompany()
        {
            InitializeComponent();
        }

        Class.csThongTinDonVi Info = new Class.csThongTinDonVi();
        bool Bien = false;
        private void frm_InfoCompany_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Info.GetData2();
                if (dt.Rows.Count > 0)
                {
                    Bien = true;
                    txtChuQuan.Text = dt.Rows[0]["DONVICHUQUAN"].ToString();
                    txtTen.Text = dt.Rows[0]["DONVISUDUNG"].ToString();
                    txtDiachi.Text = dt.Rows[0]["DIACHI"].ToString();
                    txtDienthoai.Text = dt.Rows[0]["SODT"].ToString();
                    txtFax.Text = dt.Rows[0]["FAX"].ToString();
                    txtEmail.Text = dt.Rows[0]["EMAIL"].ToString();
                    txtWebsite.Text = dt.Rows[0]["WEBSITE"].ToString();
                    txtTinh.Text = dt.Rows[0]["TINH"].ToString();
                    txtGhichu.Text = dt.Rows[0]["GHICHU"].ToString();
                    txtXa.Text = dt.Rows[0]["XAPHUONG"].ToString();
                    txtHuyen.Text = dt.Rows[0]["HUYENQUAN"].ToString();
                    byte[] b = Info.GetPic();
                    MemoryStream mem = new MemoryStream(b);
                    picLogo.Image = Image.FromStream(mem);
                }
            }
            catch { }
        }

        private void bLuu_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if ((Bien == false) && (ThamSoHeThong.Quyen("frm_InfoCompany", "sAdd") == false))
                    return;
                if ((Bien == true) && (ThamSoHeThong.Quyen("frm_InfoCompany", "sEdit") == false))
                    return;
                if (txtChuQuan.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập đơn vị chủ quản !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtChuQuan.Focus();
                }
                else if (txtTen.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập đơn vị sử dụng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                }
                else if (txtDiachi.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập địa chỉ đơn vị sử dụng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDiachi.Focus();
                }
                else if (picLogo.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng thêm logo !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    picLogo.LoadImage();
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    int ID = 1;
                    string DONVICHUQUAN = txtChuQuan.Text;
                    string DONVISUDUNG = txtTen.Text;
                    string DIACHI = txtDiachi.Text;
                    string SODT = txtDienthoai.Text;
                    string FAX = txtFax.Text;
                    string EMAIL = txtEmail.Text;
                    string WEBSITE = txtWebsite.Text;
                    string TINH = txtTinh.Text;
                    string GHICHU = txtGhichu.Text;
                    string MADV = System.Guid.NewGuid().ToString();
                    string XAPHUONG = txtXa.Text;
                    string HUYENQUAN = txtHuyen.Text;

                    MemoryStream mstr = new MemoryStream();
                    picLogo.Image.Save(mstr, picLogo.Image.RawFormat);
                    byte[] LOGO = mstr.GetBuffer();
                    if (Bien == false)
                    {
                        Info.INSERT_THONGTINDONVI(ID, DONVICHUQUAN, DONVISUDUNG, DIACHI, SODT, FAX, EMAIL, WEBSITE, TINH, GHICHU, LOGO, XAPHUONG, HUYENQUAN);
                    }
                    else
                    {
                        Info.UPDATE_THONGTINDONVI(ID, DONVICHUQUAN, DONVISUDUNG, DIACHI, SODT, FAX, EMAIL, WEBSITE, TINH, GHICHU, LOGO, XAPHUONG, HUYENQUAN);
                    }
                    Cursor.Current = Cursors.Default;
                    DevExpress.XtraEditors.XtraMessageBox.Show("Thông tin đã được lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch { }
        }

        private void bThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}