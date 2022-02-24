using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLyCongVan
{
    public partial class frm_Adduser : DevExpress.XtraEditors.XtraForm
    {
        public frm_Adduser()
        {
            InitializeComponent(); 
        }
        public event EventHandler Button_Clicked;
        Class.csUser Adduser = new Class.csUser();
        Class.csMD5 MD5 = new Class.csMD5();
        private string _getFirstValue = null;
        public string GetFirstValue
        {
            get { return _getFirstValue; }
            set { _getFirstValue = value; }
        } 
        public void LoadNV()
        {
            txtNhanvien.Properties.DataSource = Adduser.SELECT();
            txtNhanvien.Properties.DisplayMember = "Name";
            txtNhanvien.Properties.ValueMember = "ID";
            txtNhomquyen.Properties.DataSource = Adduser.SELECT_GROUP();
            txtNhomquyen.Properties.DisplayMember = "Group_Name";
            txtNhomquyen.Properties.ValueMember = "Group_ID";
        }
        private void frm_Adduser_Load(object sender, EventArgs e)
        {
            LoadNV();
            ckQuanly.Checked = true;
            if (GetFirstValue != null)
            {
                txtuser.Properties.ReadOnly = true;
                txtuser.Text = GetFirstValue;
                DataTable dt = Adduser.SELECT_ID(GetFirstValue);
                txtNhanvien.EditValue = dt.Rows[0]["USER_ID"].ToString();
                ckQuanly.Checked = Convert.ToBoolean(dt.Rows[0]["ACTIVE"].ToString());
                txtNhomquyen.EditValue = dt.Rows[0]["Group_ID"].ToString();
            } 
        }

        private void bLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtuser.Properties.ReadOnly == false) && (ThamSoHeThong.Quyen("frm_Phanquyen", "sAdd") == false))
                    return;
                if ((txtuser.Properties.ReadOnly == true) && (ThamSoHeThong.Quyen("frm_Phanquyen", "sEdit") == false))
                    return;
                if (txtMatkhau.Text == "" || txtMatkhau2.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập lại mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMatkhau.Focus();
                }
                else if (txtNhanvien.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng chọn nhân viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNhanvien.Properties.ImmediatePopup = true;
                }
                else if (txtuser.Text != null)
                {
                    string ID = txtuser.Text;
                    string Matkhau = txtMatkhau.Text;
                    string PASS = MD5.MD5(Matkhau + ID);
                    string USER_ID = txtNhanvien.EditValue.ToString();
                    string USER_NAME = txtNhanvien.Text;
                    string USER_CREATE = ThamSoHeThong.TenDangNhap;
                    DateTime DATE_CREATE = DateTime.Now;
                    bool ACTIVE = ckQuanly.Checked;
                    string Type = "NV";
                    string Group_ID = txtNhomquyen.EditValue.ToString();
                    Adduser.Open();
                    if (txtuser.Properties.ReadOnly == false)
                    {
                        Adduser.INSERT_SYS_USER(ID, PASS, USER_ID, USER_NAME, USER_CREATE, DATE_CREATE, ACTIVE, Type, Group_ID);
                        txtuser.Properties.ReadOnly = true;
                    }
                    else
                    {
                        Adduser.UPDATE_SYS_USER(ID, PASS, USER_ID, USER_NAME, ACTIVE, Type, Group_ID);
                        txtuser.Properties.ReadOnly = false;
                    }
                    Adduser.Close();
                    txtuser.Properties.ReadOnly = false;
                    txtuser.Text = "";
                    txtMatkhau.Text = "";
                    txtMatkhau2.Text = "";
                    DevExpress.XtraEditors.XtraMessageBox.Show("Đã lưu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (this.Button_Clicked != null)
                        this.Button_Clicked(sender, e);
                    txtuser.Focus();
                }
            }
            catch
            {
                Adduser.Close();
                DevExpress.XtraEditors.XtraMessageBox.Show("Lưu thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Adduser.Close();
            }

        }

        private void bThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMatkhau2_TextChanged(object sender, EventArgs e)
        {
            if (txtMatkhau.Text != txtMatkhau2.Text)
            {
                bLuu.Enabled = false;
                layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                bLuu.Enabled = true;
                layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void txtMatkhau_TextChanged(object sender, EventArgs e)
        {
            if (txtMatkhau.Text != txtMatkhau2.Text)
            {
                bLuu.Enabled = false;
                layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                bLuu.Enabled = true;
                layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {
            if (txtuser.Properties.ReadOnly == true)
            {
                bLuu.Enabled = true;
                layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                string User = txtuser.Text;
                DataTable dt = Adduser.SELECT_ID(User);
                if (dt.Rows.Count > 0)
                {
                    bLuu.Enabled = false;
                    layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    bLuu.Enabled = true;
                    layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
            }
        }
    }
}