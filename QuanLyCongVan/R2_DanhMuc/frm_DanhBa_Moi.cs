using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraEditors;

namespace QuanLyCongVan
{
    public partial class frm_DanhBa_Moi : DevExpress.XtraEditors.XtraForm
    {
        public frm_DanhBa_Moi()
        {
            InitializeComponent();
        }
        public event EventHandler Button_Clicked;
        Class.csDanhBa Doitac = new Class.csDanhBa();
        Class.csMD5 MD5 = new Class.csMD5();
        private string _getFirstValue = null;
        public string GetFirstValue
        {
            get{return _getFirstValue;}
            set{_getFirstValue = value;}
        }

        public void xoatextbox()
        {
            ckQuanly.Checked = false;
            txtMa.Text = Doitac.AUTO_ID().ToString();
            txtTen.Text = "";
            txtDiachi.Text = "";
            txtCoquan.Text = "";
            txtDienthoai.Text = "";
            txtEmail.Text = "";
            txtTaikhoan.Text = "";
            txtFax.Text = "";
            txtNganhang.Text = "";
            txtNickyahoo.Text = "";
            txtNickskype.Text = "";
            txtTen.Focus();
        }       

        private void bThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Doitac_Load(object sender, EventArgs e)
        {
            if (GetFirstValue != null)
            {
                ckQuanly.Checked = true;
                txtMa.Text = GetFirstValue;
                DataTable dt = Doitac.GetDataID(GetFirstValue);
                txtTen.Text = dt.Rows[0][1].ToString();
                txtDiachi.Text = dt.Rows[0][2].ToString();
                txtCoquan.Text = dt.Rows[0][3].ToString();
                txtEmail.Text = dt.Rows[0][4].ToString();
                txtDienthoai.Text = dt.Rows[0][5].ToString();
                txtFax.Text = dt.Rows[0][6].ToString();
                txtNickyahoo.Text = dt.Rows[0][7].ToString();
                txtNickskype.Text = dt.Rows[0][8].ToString();
                txtTaikhoan.Text = dt.Rows[0][9].ToString();
                txtNganhang.Text = dt.Rows[0][10].ToString();
                txtNgaySinh.DateTime = Convert.ToDateTime(dt.Rows[0][12].ToString());
            }
            else
            {
                ckQuanly.Checked = false;
                txtNgaySinh.DateTime = DateTime.Now;
                txtMa.Text = Doitac.AUTO_ID().ToString();
                txtTen.Focus();
            }
        }
        private void bLuu_Click(object sender, EventArgs e)
        {
            if (txtTen.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập tên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTen.Focus();
            }
            else
            {
                string ID = txtMa.Text;
                string TEN = txtTen.Text;
                string DIACHI = txtDiachi.Text;
                string COQUAN = txtCoquan.Text;
                string EMAIL = txtEmail.Text;
                string DIENTHOAI = txtDienthoai.Text;
                string FAX = txtFax.Text;
                string YAHOO = txtNickyahoo.Text;
                string SKYPE = txtNickskype.Text;
                string TAIKHOAN = txtTaikhoan.Text;
                string NGANHANG = txtNganhang.Text;
                bool ACTIVE = ckQuanly.Checked;
                string USER_ID = "";
                DateTime NGAYSINH = txtNgaySinh.DateTime;
                XmlTextReader reader = new XmlTextReader("AccountLogin.xml");
                XmlNodeType type;
                while (reader.Read())
                {
                    type = reader.NodeType;
                    if (type == XmlNodeType.Element)
                    {
                        if (reader.Name == "User")
                        {
                            reader.Read();
                            USER_ID = MD5.GMMD5(reader.Value);
                        }
                    }
                }
                reader.Close();
                if (ckQuanly.Checked == false)
                {
                    Doitac.INSERT_DB(ID, TEN, DIACHI, COQUAN, EMAIL, DIENTHOAI, FAX, YAHOO, SKYPE, TAIKHOAN, NGANHANG, USER_ID, NGAYSINH);                    
                }
                else
                {
                    Doitac.UPDATE_DB(ID, TEN, DIACHI, COQUAN, EMAIL, DIENTHOAI, FAX, YAHOO, SKYPE, TAIKHOAN, NGANHANG, USER_ID, NGAYSINH);
                    
                }
                if (this.Button_Clicked != null)
                    this.Button_Clicked(sender, e);
                xoatextbox();
            }
        }
    }
}