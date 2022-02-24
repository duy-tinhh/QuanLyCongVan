using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;
using System.IO;
using Microsoft.SqlServer.Management.Common;
using System.Collections.Specialized;
using System.Data.Sql;
using System.Xml;
using System.Reflection;

namespace QuanLyCongVan
{
    public partial class frm_Connect : DevExpress.XtraEditors.XtraForm
    {
        public frm_Connect()
        {
            InitializeComponent();
        }
        Class.csMD5 MD5 = new Class.csMD5();
        private void frm_Login_Load(object sender, EventArgs e)
        {
        }
        public DataTable LoadServerName()
        {
            return SmoApplication.EnumAvailableSqlServers();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdgTaikhoan.SelectedIndex == 0)
            {
                txtTaikhoan.Enabled = false;
                txtMatkhau.Enabled = false;
            }
            else
            {
                txtTaikhoan.Enabled = true;
                txtMatkhau.Enabled = true;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frm_Login Login = new frm_Login();
            this.Hide();
            this.Dispose();
            Login.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string connect = "";
                string NameServer = "";
                string NameData = "";
                string Folder = txtThuMuc.Text;
                if (rdgTaikhoan.SelectedIndex == 0)
                {
                    NameServer = comboBox1.Text;
                    NameData = comboBox2.Text;
                    connect = "Data Source=" + NameServer + ";Initial Catalog=" + NameData + ";Integrated Security=True;";
                }
                else
                {
                    NameServer = comboBox1.Text;
                    NameData = comboBox2.Text;
                    string User = txtTaikhoan.Text;
                    string Matkhau = txtMatkhau.Text;
                    connect = "Data Source=" + NameServer + ";Initial Catalog=" + NameData + ";User Id =" + User + "; Password = " + Matkhau + "; Integrated Security = false;";
                }
                connect = MD5.MHMD5(connect);
                //Tao file xml chuoi ket noi
                DataTable dt1 = new DataTable();
                dt1.TableName = "String";
                DataColumn dc1 = new DataColumn("Connect");
                DataColumn dc2 = new DataColumn("Server");
                DataColumn dc3 = new DataColumn("DataSource");
                DataColumn dc4 = new DataColumn("Folder");
                dt1.Columns.Add(dc1);
                dt1.Columns.Add(dc2);
                dt1.Columns.Add(dc3);
                dt1.Columns.Add(dc4);
                dt1.Rows.Add(connect, NameServer, NameData, Folder);
                DataSet ds = new DataSet();
                ds.DataSetName = "ConnectString";
                ds.Tables.Add(dt1);
                ds.WriteXml("ConnectString.xml");
                DevExpress.XtraEditors.XtraMessageBox.Show("Lưu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Lưu thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void frm_Connect_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "File(*.mdf)|*.mdf";
            if (f.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string file = f.FileName;
                    string name = file.Substring(0, file.Length - 4) + "_log.ldf";
                    string DatabaseName = System.IO.Path.GetFileName(f.FileName.Substring(0, file.Length - 4));

                    Server SqlServer = new Server(@".\SQLEXPRESS");
                    ServerConnection SqlServerConnection = SqlServer.ConnectionContext;
                    SqlServerConnection.LoginSecure = true;
                    SqlServerConnection.DatabaseName = "master";

                    Database NewDatabase = new Database(SqlServer, DatabaseName);
                    FileGroup DatabaseFileGroup = new FileGroup(NewDatabase, "PRIMARY");
                    NewDatabase.FileGroups.Add(DatabaseFileGroup);
                    DataFile DatabaseDataFile = new DataFile(DatabaseFileGroup, DatabaseName);
                    DatabaseFileGroup.Files.Add(DatabaseDataFile);
                    DatabaseDataFile.FileName = file;
                    LogFile DatabaseLogFile = new LogFile(NewDatabase, DatabaseName + "_log");
                    NewDatabase.LogFiles.Add(DatabaseLogFile);
                    DatabaseLogFile.FileName = name;
                    StringCollection DatabaseFilesCollection = new StringCollection();

                    DatabaseFilesCollection.Add(DatabaseDataFile.FileName);
                    DatabaseFilesCollection.Add(DatabaseLogFile.FileName);

                    SqlServer.AttachDatabase(DatabaseName, DatabaseFilesCollection);
                    DevExpress.XtraEditors.XtraMessageBox.Show("Attach dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Có lỗi trong việc attach data!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (comboBox1.Items.Count == 0)
            {
                comboBox1.Items.Clear();
                string myServer = Environment.MachineName;
                DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
                for (int i = 0; i < servers.Rows.Count; i++)
                {
                    comboBox1.Items.Add(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);

                    //Code dung local hay lan
                    //if (myServer == servers.Rows[i]["ServerName"].ToString())
                    //{
                    //    if ((servers.Rows[i]["InstanceName"] as string) != null)
                    //    {
                    //        comboBox1.Visibility = Visibility.Visible;
                    //        comboBox1.Items.Add(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);
                    //    }
                    //    else
                    //    {
                    //        comboBox1.Visibility = Visibility.Visible;
                    //        comboBox1.Items.Add(servers.Rows[i]["ServerName"]);
                    //    }
                    //}
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //comboBox1.Items.Clear();
            string ServerName = comboBox1.Text;
            string User = txtTaikhoan.Text;
            string Pass = txtMatkhau.Text;
            string con = "";
            if (rdgTaikhoan.EditValue.ToString() == "1")
            {
                con = "Data Source=" + ServerName + ";Initial Catalog=master;Integrated Security=True;";
            }
            else
            {
                con = "Data Source=" + ServerName + ";Initial Catalog=master;User Id=" + User + ";Password=" + Pass + ";Integrated Security=False;";
                
            }
            SqlConnection cnn = new SqlConnection(con);
            try
            {
                cnn.Open();
                string s = "select * from sysdatabases where dbid > 4 order by name asc";
                DataSet dt = new DataSet();
                SqlDataAdapter ds = new SqlDataAdapter(s, cnn);
                ds.Fill(dt);
                comboBox2.DataSource = dt.Tables[0];
                comboBox2.DisplayMember = "name";
                comboBox2.ValueMember = "name";
            }
            catch
            {
                Cursor.Current = Cursors.Default;
                DevExpress.XtraEditors.XtraMessageBox.Show("Có lỗi trong việc kết nối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Cursor.Current = Cursors.Default;
        }

        private void buttonEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                txtThuMuc.Text = f.SelectedPath.ToString();
            }
        }

        private string GetNetworkFolders(FolderBrowserDialog oFolderBrowserDialog)
        {
            if (rdgTaikhoan.SelectedIndex == 1)
            {
                Type type = oFolderBrowserDialog.GetType();
                FieldInfo fieldInfo = type.GetField("rootFolder", BindingFlags.NonPublic | BindingFlags.Instance);
                fieldInfo.SetValue(oFolderBrowserDialog, 18);
                if (oFolderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    return oFolderBrowserDialog.SelectedPath.ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                FolderBrowserDialog f = new FolderBrowserDialog();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    return f.SelectedPath.ToString();
                }
            }
            return "";
        }
    }
}