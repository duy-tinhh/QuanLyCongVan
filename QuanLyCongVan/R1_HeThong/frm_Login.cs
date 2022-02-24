using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Xml;
using Microsoft.Win32;
using System.Threading;

namespace QuanLyCongVan
{
    public partial class frm_Login : DevExpress.XtraEditors.XtraForm
    {
        public frm_Login()
        {
            InitializeComponent();
        }
        Class.csLogin Login = new Class.csLogin();
        Class.csMD5 MD5 = new Class.csMD5();
        Class.csUser Adduser = new Class.csUser();

        public event EventHandler Button_Clicked;
        private bool _AutoLogin = true;
        public bool AutoLogin
        {
            get { return _AutoLogin; }
            set { _AutoLogin = value; }
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
            try
            {     
                //Doc file xml
                string Des1 = Application.StartupPath + "\\AccountLogin.xml";
                if (File.Exists(Des1))
                {
                    bool Active = false;
                    string User = "";
                    string Pass = "";
                    bool Auto = false;
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
                                User = MD5.GMMD5(reader.Value);
                            }
                            if (reader.Name == "Pass")
                            {
                                reader.Read();
                                Pass = MD5.GMMD5(reader.Value);
                            }
                            if (reader.Name == "Active")
                            {
                                reader.Read();
                                Active = Convert.ToBoolean(reader.Value);
                            }
                            if (reader.Name == "Auto")
                            {
                                reader.Read();
                                Auto = Convert.ToBoolean(reader.Value);
                                break;
                            }
                        }
                    }
                    reader.Close();
                    if (Active == true)
                    {
                        txtTen.Text = User;
                        txtMatkhau.Text = Pass;
                        ckGhinho.Checked = Active;
                        ckAuto.Checked = Auto;
                        this.Refresh();
                        this.Invalidate();
                        if ((AutoLogin == true)&&(ckAuto.Checked==true))
                        {
                            bDN_Click(sender, e);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void bThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bDN_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string Username = txtTen.Text;
                string Password = txtMatkhau.Text;
                string Pass = MD5.MD5(Password + Username);
                DataTable dt = Login.GetLogin(Username, Pass);
                if (dt.Rows.Count > 0)
                {
                    //Tao file xml 
                    DataTable dt1 = new DataTable();
                    dt1.TableName = "Account";
                    dt1.Columns.Add("User", typeof(string));
                    dt1.Columns.Add("Pass", typeof(string));
                    dt1.Columns.Add("Active", typeof(string));
                    dt1.Columns.Add("Auto", typeof(string));
                    string UserN = MD5.MHMD5(Username);
                    string PassN = MD5.MHMD5(Password);
                    string Active = ckGhinho.Checked.ToString();
                    string Auto = ckAuto.Checked.ToString();
                    if (Active == "True")
                    {
                        dt1.Rows.Add(UserN, PassN, Active, Auto);
                    }
                    else
                    {
                        dt1.Rows.Add("", "", "False", "False");
                    }
                    DataSet ds = new DataSet();
                    ds.DataSetName = "Login";
                    ds.Tables.Add(dt1);
                    ds.WriteXml("AccountLogin.xml");
                    
                    ThamSoHeThong.TenDangNhap = Username;
                    ThamSoHeThong.TenNhanVien = dt.Rows[0]["USER_NAME"].ToString();
                    ThamSoHeThong.MaNhanVien = dt.Rows[0]["USER_ID"].ToString();
                    ThamSoHeThong.LoaiNhanVien = dt.Rows[0]["Type"].ToString();
                    ThamSoHeThong.NhomQuyenNV = dt.Rows[0]["Group_ID"].ToString(); 
                    ThamSoHeThong.Table_Rule = Adduser.SELECT_SYS_USER_FORM_ID2(ThamSoHeThong.NhomQuyenNV);
                    ThamSoHeThong.PhongBan = Login.TenPhongBan(ThamSoHeThong.MaNhanVien);
                    ThamSoHeThong.TenMayTinh = SystemInformation.ComputerName;
                    if (this.Button_Clicked != null)
                        this.Button_Clicked(sender, e);
                    this.Close();
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    txtMatkhau.Text = "";
                    txtMatkhau.Focus();
                }
            }
            catch(Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frm_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void txtMatkhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                bDN_Click(sender, e);
            }
        }


        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtMatkhau.Text == "")
                {
                    txtMatkhau.Focus();
                }
                else
                {
                    bDN_Click(sender, e);
                }
            }
        }

        private void bTuyChinh_Click(object sender, EventArgs e)
        {
            frm_Connect Connect = new frm_Connect();
            this.Hide();
            Connect.ShowDialog();
        }
        private void RegisterInStartup(bool isChecked)
        {
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (isChecked)
                {
                    // Đăng ký stratup cùng Windows
                    registryKey.SetValue("QuanLyCongVan", Directory.GetCurrentDirectory() + "\\QuanLyCongVan.exe");
                }
                else
                {
                    // Hủy đăng ký
                    registryKey.DeleteValue("QuanLyCongVan");
                }
            }
            catch
            {
            }
        }

        private void ckAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAuto.Checked == true)
            {
                ckGhinho.Checked = true;
            }
        }

        private void ckGhinho_CheckedChanged(object sender, EventArgs e)
        {
            if (ckGhinho.Checked == false)
            {
                ckAuto.Checked = false;
            }
        }
    }
}