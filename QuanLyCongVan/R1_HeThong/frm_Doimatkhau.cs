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
    public partial class frm_Doimatkhau : DevExpress.XtraEditors.XtraForm
    {
        public frm_Doimatkhau()
        {
            InitializeComponent();
        }
        Class.csLogin Login = new Class.csLogin();
        Class.csMD5 MD5 = new Class.csMD5();
        private string _User = null;
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }
        private void frm_Danhnhap_Load(object sender, EventArgs e)
        {

        }

        private void bLuu_Click(object sender, EventArgs e)
        {
            if (txtMKold.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập password cũ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtNKnew.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập password mới !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtNKnew2.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập lại password mới !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtNKnew.Text != txtNKnew2.Text)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Nhập khẩu nhập lại không đúng. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string Username = User;
                string Pass = MD5.MD5(txtMKold.Text + Username);
                DataTable dt = Login.GetLogin(Username, Pass);
                if (dt.Rows.Count > 0)
                {
                    string PassNew = MD5.MD5(txtNKnew.Text + Username);
                    Login.UpdateLogin(Username, PassNew);
                    DevExpress.XtraEditors.XtraMessageBox.Show("Thay đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    txtMKold.Text = "";
                    txtNKnew.Text = "";
                    txtNKnew2.Text = "";
                    txtMKold.Focus();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Mật khẩu cũ không đúng! Vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void bThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }
    }
}