using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;
using System.IO;

namespace QuanLyCongVan
{
    public partial class frm_VaiTro : DevExpress.XtraEditors.XtraForm
    {
        public frm_VaiTro()
        {
            InitializeComponent();
        }
        public event EventHandler Button_Clicked;
        private string _ID_Truyen = "";
        public string ID_Truyen
        {
            get { return _ID_Truyen; }
            set { _ID_Truyen = value; }
        }
        Class.csUser Adduser = new Class.csUser();
        Class.csVaitro CongVan = new Class.csVaitro();
        private void ucLoaiVanban_Load(object sender, EventArgs e)
        {
            if (ID_Truyen != "")
            {
                DataTable dt = CongVan.SELECT_SYS_USER_GROUP_ID(ID_Truyen);
                txtMa.Properties.ReadOnly = true;
                txtMa.Text = ID_Truyen;
                txtTen.Text = dt.Rows[0]["Group_Name"].ToString();
                txtGhichu.Text = dt.Rows[0]["Description"].ToString();
                ckTrangthai.Checked = Convert.ToBoolean(dt.Rows[0]["Active"].ToString());
            }
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            if (txtMa.Properties.ReadOnly == true)
            {
                bLuu.Enabled = true;
                layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                string ID = txtMa.Text;
                DataTable dt = CongVan.SELECT_SYS_USER_GROUP_ID(ID);
                if (dt.Rows.Count > 0)
                {
                    bLuu.Enabled = false;
                    layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    bLuu.Enabled = true;
                    layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
            }
        }

        
        private void bLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtMa.Properties.ReadOnly == false) && (ThamSoHeThong.Quyen("frm_Phanquyen", "sAdd") == false))
                    return;
                if ((txtMa.Properties.ReadOnly == true) && (ThamSoHeThong.Quyen("frm_Phanquyen", "sEdit") == false))
                    return;
                if (txtMa.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập mã !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMa.Focus();
                }
                else if (txtTen.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập tên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string Group_ID = txtMa.Text;
                    string Group_Name = txtTen.Text;
                    string Description = txtGhichu.Text;
                    bool Active = ckTrangthai.Checked;
                    if (txtMa.Properties.ReadOnly == false)
                    {
                        CongVan.INSERT_SYS_USER_GROUP(Group_ID, Group_Name, Description, Active);
                    }
                    else
                    {
                        CongVan.UPDATE_SYS_USER_GROUP(Group_ID, Group_Name, Description, Active);
                    }
                    Adduser.FORM_RULE();
                    if (this.Button_Clicked != null)
                        this.Button_Clicked(sender, e);
                    Cursor.Current = Cursors.Default;
                    this.Close();    
                }
            }
            catch
            {
            }
        }

        private void bXoa_Click(object sender, EventArgs e)
        {            
            this.Close();            
        }
    }
}
