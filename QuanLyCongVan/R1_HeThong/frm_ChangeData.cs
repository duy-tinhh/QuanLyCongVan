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
using System.Data.OleDb;

namespace QuanLyCongVan
{
    public partial class frm_ChangeData : DevExpress.XtraEditors.XtraForm
    {
        public frm_ChangeData()
        {
            InitializeComponent();
        }
        Class.csMD5 MD5 = new Class.csMD5();
        Class.csChangeData New = new Class.csChangeData();
        Class.csDataAccess Old = new Class.csDataAccess();
        private void frm_Login_Load(object sender, EventArgs e)
        {
        }  

        private void buttonEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                txtThuMuc.Text = f.SelectedPath.ToString();
            }
        }
        private DataTable ExcuteSQL(string sql, OleDbConnection con)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand(sql, con);
            OleDbDataAdapter dad = new OleDbDataAdapter(cmd);
            dad.Fill(dt); 
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return dt;
        }
        private void bChuyen_Click(object sender, EventArgs e)
        {
            try
            {

                OleDbConnection con = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + txtThuMuc.Text + "\\Data_QLCV\\QLCV.MDB;Jet OLEDB:Database Password=P@ssw0rd87;");


                #region
                DataTable dt = new DataTable();

                //CANBOKY
                labelControl4.Text = "CANBOKY";
                this.Refresh();
                this.Invalidate();
                //New.DELETE_CANBOKY();
                New.Open();
                dt = ExcuteSQL("SELECT * FROM CANBOKY", con);
                pro.EditValue = 0;
                pro.Properties.Step = 1;
                pro.Properties.PercentView = true;
                pro.Properties.Maximum = dt.Rows.Count;
                pro.Properties.Minimum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ID = dt.Rows[i]["ID"].ToString();
                    string Name = dt.Rows[i]["Name"].ToString();
                    string Description = dt.Rows[i]["Description"].ToString();
                    bool Active = Convert.ToBoolean(dt.Rows[i]["Active"].ToString());
                    New.INSERT_CANBOKY(ID, Name, Description, Active);

                    pro.PerformStep();
                    pro.Update();
                }
                New.Close();

                //CANBOXULY
                labelControl4.Text = "CANBOXULY";
                this.Refresh();
                this.Invalidate();
                New.DELETE_CANBOXULY();
                New.Open();
                dt = ExcuteSQL("SELECT * FROM CANBOXULY", con);
                pro.EditValue = 0;
                pro.Properties.Step = 1;
                pro.Properties.PercentView = true;
                pro.Properties.Maximum = dt.Rows.Count;
                pro.Properties.Minimum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ID = dt.Rows[i]["ID"].ToString();
                    string Name = dt.Rows[i]["Name"].ToString();
                    string Description = dt.Rows[i]["Description"].ToString();
                    bool Active = Convert.ToBoolean(dt.Rows[i]["Active"].ToString());
                    string DonViXuLy = dt.Rows[i]["DonViXuLy"].ToString();
                    string MADV = dt.Rows[i]["MADV"].ToString();
                    New.INSERT_CANBOXULY(ID, Name, Description, Active, DonViXuLy, MADV);
                    pro.PerformStep();
                    pro.Update();
                }
                New.Close();


                //CQBANHANH
                labelControl4.Text = "CQBANHANH";
                this.Refresh();
                this.Invalidate();
                New.DELETE_CQBANHANH();
                New.Open();
                dt = ExcuteSQL("SELECT * FROM CQBANHANH", con);
                pro.EditValue = 0;
                pro.Properties.Step = 1;
                pro.Properties.PercentView = true;
                pro.Properties.Maximum = dt.Rows.Count;
                pro.Properties.Minimum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ID = dt.Rows[i]["ID"].ToString();
                    string Name = dt.Rows[i]["Name"].ToString();
                    string Description = dt.Rows[i]["Description"].ToString();
                    bool Active = Convert.ToBoolean(dt.Rows[i]["Active"].ToString());
                    New.INSERT_CQBANHANH(ID, Name, Description, Active);

                    pro.PerformStep();
                    pro.Update();
                }
                New.Close();

                //CQNHANCV
                labelControl4.Text = "CQNHANCV";
                this.Refresh();
                this.Invalidate();
                New.DELETE_CQNHANCV();
                New.Open();
                dt = ExcuteSQL("SELECT * FROM CQNHANCV", con);
                pro.EditValue = 0;
                pro.Properties.Step = 1;
                pro.Properties.PercentView = true;
                pro.Properties.Maximum = dt.Rows.Count;
                pro.Properties.Minimum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ID = dt.Rows[i]["ID"].ToString();
                    string Name = dt.Rows[i]["Name"].ToString();
                    string Description = dt.Rows[i]["Description"].ToString();
                    bool Active = Convert.ToBoolean(dt.Rows[i]["Active"].ToString());
                    New.INSERT_CQNHANCV(ID, Name, Description, Active);

                    pro.PerformStep();
                    pro.Update();
                }
                New.Close();

                //DANHBA
                labelControl4.Text = "DANHBA";
                this.Refresh();
                this.Invalidate();
                New.DELETE_DANHBA();
                New.Open();
                dt = ExcuteSQL("SELECT * FROM DANHBA", con);
                pro.EditValue = 0;
                pro.Properties.Step = 1;
                pro.Properties.PercentView = true;
                pro.Properties.Maximum = dt.Rows.Count;
                pro.Properties.Minimum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int ID = Convert.ToInt16(dt.Rows[i]["ID"].ToString());
                    string TEN = dt.Rows[i]["TEN"].ToString();
                    string DIACHI = dt.Rows[i]["DIACHI"].ToString();
                    string COQUAN = dt.Rows[i]["COQUAN"].ToString();
                    string EMAIL = dt.Rows[i]["EMAIL"].ToString();
                    string DIENTHOAI = dt.Rows[i]["DIENTHOAI"].ToString();
                    string FAX = dt.Rows[i]["FAX"].ToString();
                    string YAHOO = dt.Rows[i]["YAHOO"].ToString();
                    string SKYPE = dt.Rows[i]["SKYPE"].ToString();
                    string TAIKHOAN = dt.Rows[i]["TAIKHOAN"].ToString();
                    string NGANHANG = dt.Rows[i]["NGANHANG"].ToString();
                    string USER_ID = dt.Rows[i]["USER_ID"].ToString();
                    DateTime NGAYSINH = Convert.ToDateTime(dt.Rows[i]["NGAYSINH"].ToString());
                    New.INSERT_DANHBA(ID, TEN, DIACHI, COQUAN, EMAIL, DIENTHOAI, FAX, YAHOO, SKYPE, TAIKHOAN, NGANHANG, USER_ID, NGAYSINH);

                    pro.PerformStep();
                    pro.Update();
                }
                New.Close();

                //DANHBACQ
                labelControl4.Text = "DANHBACQ";
                this.Refresh();
                this.Invalidate();
                New.DELETE_DANHBACQ();
                New.Open();
                dt = ExcuteSQL("SELECT * FROM DANHBACQ", con);
                pro.EditValue = 0;
                pro.Properties.Step = 1;
                pro.Properties.PercentView = true;
                pro.Properties.Maximum = dt.Rows.Count;
                pro.Properties.Minimum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ID = dt.Rows[i]["ID"].ToString();
                    string TEN = dt.Rows[i]["TEN"].ToString();
                    string DIACHI = dt.Rows[i]["DIACHI"].ToString();
                    string COQUAN = dt.Rows[i]["COQUAN"].ToString();
                    string EMAIL = dt.Rows[i]["EMAIL"].ToString();
                    string DIENTHOAI = dt.Rows[i]["DIENTHOAI"].ToString();
                    string FAX = dt.Rows[i]["FAX"].ToString();
                    string YAHOO = dt.Rows[i]["YAHOO"].ToString();
                    string SKYPE = dt.Rows[i]["SKYPE"].ToString();
                    string TAIKHOAN = dt.Rows[i]["TAIKHOAN"].ToString();
                    string NGANHANG = dt.Rows[i]["NGANHANG"].ToString();
                    New.INSERT_DANHBACQ(ID, TEN, DIACHI, COQUAN, EMAIL, DIENTHOAI, FAX, YAHOO, SKYPE, TAIKHOAN, NGANHANG);

                    pro.PerformStep();
                    pro.Update();
                }
                New.Close();


                //DVXULY
                labelControl4.Text = "DVXULY";
                this.Refresh();
                this.Invalidate();
                New.DELETE_DVXULY();
                New.Open();
                dt = ExcuteSQL("SELECT * FROM DVXULY", con);
                pro.EditValue = 0;
                pro.Properties.Step = 1;
                pro.Properties.PercentView = true;
                pro.Properties.Maximum = dt.Rows.Count;
                pro.Properties.Minimum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ID = dt.Rows[i]["ID"].ToString();
                    string Name = dt.Rows[i]["Name"].ToString();
                    string Description = dt.Rows[i]["Description"].ToString();
                    bool Active = Convert.ToBoolean(dt.Rows[i]["Active"].ToString());
                    New.INSERT_DVXULY(ID, Name, Description, Active);

                    pro.PerformStep();
                    pro.Update();
                }
                New.Close();
                #endregion

                //LOAIVANBAN
                labelControl4.Text = "LOAIVANBAN";
                this.Refresh();
                this.Invalidate();
                New.DELETE_LOAIVANBAN();
                New.Open();
                dt = ExcuteSQL("SELECT * FROM LOAIVANBAN", con);
                pro.EditValue = 0;
                pro.Properties.Step = 1;
                pro.Properties.PercentView = true;
                pro.Properties.Maximum = dt.Rows.Count;
                pro.Properties.Minimum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ID = dt.Rows[i]["ID"].ToString();
                    string Name = dt.Rows[i]["Name"].ToString();
                    string Description = dt.Rows[i]["Description"].ToString();
                    bool Active = Convert.ToBoolean(dt.Rows[i]["Active"].ToString());
                    int Sort = 0;
                    New.INSERT_LOAIVANBAN(ID, Name, Description, Active, Sort);

                    pro.PerformStep();
                    pro.Update();
                }
                New.Close();


                //NHATKYLAMVIEC
                labelControl4.Text = "NHATKYLAMVIEC";
                this.Refresh();
                this.Invalidate();
                New.DELETE_NHATKYLAMVIEC();
                New.Open();
                dt = ExcuteSQL("SELECT * FROM NHATKYLAMVIEC", con);
                pro.EditValue = 0;
                pro.Properties.Step = 1;
                pro.Properties.PercentView = true;
                pro.Properties.Maximum = dt.Rows.Count;
                pro.Properties.Minimum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int ID = Convert.ToInt16(dt.Rows[i]["ID"].ToString());
                    DateTime NGAY = Convert.ToDateTime(dt.Rows[i]["NGAY"].ToString());
                    DateTime BATDAU = Convert.ToDateTime(dt.Rows[i]["BATDAU"].ToString());
                    DateTime KETTHUC = Convert.ToDateTime(dt.Rows[i]["KETTHUC"].ToString());
                    string MANV = dt.Rows[i]["MANV"].ToString();
                    string HOTEN = dt.Rows[i]["HOTEN"].ToString();
                    string NOIDUNG = dt.Rows[i]["NOIDUNG"].ToString();
                    string GHICHU = dt.Rows[i]["GHICHU"].ToString();
                    bool TRANGTHAI = Convert.ToBoolean(dt.Rows[i]["TRANGTHAI"].ToString());
                    DateTime NGAYTAO = Convert.ToDateTime(dt.Rows[i]["NGAYTAO"].ToString());
                    DateTime NGAYSUA = Convert.ToDateTime(dt.Rows[i]["NGAYSUA"].ToString());
                    bool XOA = Convert.ToBoolean(dt.Rows[i]["XOA"].ToString());
                    New.INSERT_NHATKYLAMVIEC(ID, NGAY, BATDAU, KETTHUC, MANV, HOTEN, NOIDUNG, GHICHU, TRANGTHAI, NGAYTAO, NGAYSUA, XOA);

                    pro.PerformStep();
                    pro.Update();
                }
                New.Close();

                //SYS_USER
                labelControl4.Text = "SYS_USER";
                this.Refresh();
                this.Invalidate();
                New.DELETE_SYS_USER();
                New.Open();
                dt = ExcuteSQL("SELECT * FROM SYS_USER", con);
                pro.EditValue = 0;
                pro.Properties.Step = 1;
                pro.Properties.PercentView = true;
                pro.Properties.Maximum = dt.Rows.Count;
                pro.Properties.Minimum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ID = dt.Rows[i]["ID"].ToString();
                    string PASS = dt.Rows[i]["PASS"].ToString();
                    string USER_ID = dt.Rows[i]["USER_ID"].ToString();
                    string USER_NAME = dt.Rows[i]["USER_NAME"].ToString();
                    string USER_CREATE = dt.Rows[i]["USER_CREATE"].ToString();
                    DateTime DATE_CREATE;
                    try
                    {
                        DATE_CREATE = Convert.ToDateTime(dt.Rows[i]["DATE_CREATE"].ToString());
                    }
                    catch
                    {
                        DATE_CREATE = DateTime.Now;
                    }
                    bool ACTIVE = Convert.ToBoolean(dt.Rows[i]["ACTIVE"].ToString());
                    string Type = dt.Rows[i]["Type"].ToString();
                    string Group_ID = "QT";
                    New.INSERT_SYS_USER(ID, PASS, USER_ID, USER_NAME, USER_CREATE, DATE_CREATE, ACTIVE, Type, Group_ID);

                    pro.PerformStep();
                    pro.Update();
                }
                New.Close();

                //SYS_USER_R
                labelControl4.Text = "SYS_USER_R";
                this.Refresh();
                this.Invalidate();
                New.DELETE_SYS_USER_R();
                New.Open();
                dt = ExcuteSQL("SELECT * FROM SYS_USER_R", con);
                pro.EditValue = 0;
                pro.Properties.Step = 1;
                pro.Properties.PercentView = true;
                pro.Properties.Maximum = dt.Rows.Count;
                pro.Properties.Minimum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string USERID = dt.Rows[i]["USERID"].ToString();
                    if (USERID != "admin")
                    {
                        bool Rule1 = Convert.ToBoolean(dt.Rows[i]["Rule1"].ToString());
                        bool Rule2 = Convert.ToBoolean(dt.Rows[i]["Rule2"].ToString());
                        bool Rule3 = Convert.ToBoolean(dt.Rows[i]["Rule3"].ToString());
                        bool Rule4 = Convert.ToBoolean(dt.Rows[i]["Rule4"].ToString());
                        bool Rule5 = Convert.ToBoolean(dt.Rows[i]["Rule5"].ToString());
                        bool Rule6 = Convert.ToBoolean(dt.Rows[i]["Rule6"].ToString());
                        bool Rule7 = Convert.ToBoolean(dt.Rows[i]["Rule7"].ToString());
                        bool Rule8 = Convert.ToBoolean(dt.Rows[i]["Rule8"].ToString());
                        bool Rule9 = Convert.ToBoolean(dt.Rows[i]["Rule9"].ToString());
                        bool Rule10 = Convert.ToBoolean(dt.Rows[i]["Rule10"].ToString());
                        bool Rule11 = Convert.ToBoolean(dt.Rows[i]["Rule11"].ToString());
                        bool Rule12 = Convert.ToBoolean(dt.Rows[i]["Rule12"].ToString());
                        bool Rule13 = Convert.ToBoolean(dt.Rows[i]["Rule13"].ToString());
                        bool Rule14 = Convert.ToBoolean(dt.Rows[i]["Rule14"].ToString());
                        bool Rule15 = Convert.ToBoolean(dt.Rows[i]["Rule15"].ToString());
                        bool Rule16 = false;
                        bool Rule17 = false;
                        bool Rule18 = false;
                        bool Rule19 = false;
                        bool Rule20 = false;
                        bool Rule21 = false;
                        bool Rule22 = false;
                        bool Rule23 = false;
                        bool Rule24 = false;
                        bool Rule25 = false;
                        bool Rule26 = false;
                        bool Rule27 = false;
                        bool Rule28 = false;
                        bool Rule29 = false;
                        bool Rule30 = false; New.INSERT_SYS_USER_R(USERID, Rule1, Rule2, Rule3, Rule4, Rule5, Rule6, Rule7, Rule8, Rule9, Rule10, Rule11, Rule12, Rule13, Rule14, Rule15, Rule16, Rule17, Rule18, Rule19, Rule20, Rule21, Rule22, Rule23, Rule24, Rule25, Rule26, Rule27, Rule28, Rule29, Rule30);
                    }
                    else
                    {
                        bool Rule1 = Convert.ToBoolean(dt.Rows[i]["Rule1"].ToString());
                        bool Rule2 = Convert.ToBoolean(dt.Rows[i]["Rule2"].ToString());
                        bool Rule3 = Convert.ToBoolean(dt.Rows[i]["Rule3"].ToString());
                        bool Rule4 = Convert.ToBoolean(dt.Rows[i]["Rule4"].ToString());
                        bool Rule5 = Convert.ToBoolean(dt.Rows[i]["Rule5"].ToString());
                        bool Rule6 = Convert.ToBoolean(dt.Rows[i]["Rule6"].ToString());
                        bool Rule7 = Convert.ToBoolean(dt.Rows[i]["Rule7"].ToString());
                        bool Rule8 = Convert.ToBoolean(dt.Rows[i]["Rule8"].ToString());
                        bool Rule9 = Convert.ToBoolean(dt.Rows[i]["Rule9"].ToString());
                        bool Rule10 = Convert.ToBoolean(dt.Rows[i]["Rule10"].ToString());
                        bool Rule11 = Convert.ToBoolean(dt.Rows[i]["Rule11"].ToString());
                        bool Rule12 = Convert.ToBoolean(dt.Rows[i]["Rule12"].ToString());
                        bool Rule13 = Convert.ToBoolean(dt.Rows[i]["Rule13"].ToString());
                        bool Rule14 = Convert.ToBoolean(dt.Rows[i]["Rule14"].ToString());
                        bool Rule15 = Convert.ToBoolean(dt.Rows[i]["Rule15"].ToString());
                        bool Rule16 = true;
                        bool Rule17 = true;
                        bool Rule18 = true;
                        bool Rule19 = true;
                        bool Rule20 = true;
                        bool Rule21 = true;
                        bool Rule22 = true;
                        bool Rule23 = true;
                        bool Rule24 = true;
                        bool Rule25 = true;
                        bool Rule26 = true;
                        bool Rule27 = true;
                        bool Rule28 = true;
                        bool Rule29 = true;
                        bool Rule30 = true; 
                        New.INSERT_SYS_USER_R(USERID, Rule1, Rule2, Rule3, Rule4, Rule5, Rule6, Rule7, Rule8, Rule9, Rule10, Rule11, Rule12, Rule13, Rule14, Rule15, Rule16, Rule17, Rule18, Rule19, Rule20, Rule21, Rule22, Rule23, Rule24, Rule25, Rule26, Rule27, Rule28, Rule29, Rule30);                    
                    }

                    pro.PerformStep();
                    pro.Update();
                }
                New.Close();

                #region
                //CONGVANDEN
                labelControl4.Text = "CONGVANDEN";
                this.Refresh();
                this.Invalidate();
                New.DELETE_CONGVANDEN();
                New.Open();
                dt = ExcuteSQL("SELECT * FROM CONGVANDEN", con);
                pro.EditValue = 0;
                pro.Properties.Step = 1;
                pro.Properties.PercentView = true;
                pro.Properties.Maximum = dt.Rows.Count;
                pro.Properties.Minimum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ID = dt.Rows[i]["ID"].ToString();
                    DataTable dt2 = ExcuteSQL("SELECT * FROM CONGVANDEN WHERE ID = " + ID, con);
                    if (dt2.Rows.Count > 0)
                    {
                        string MA = System.Guid.NewGuid().ToString();
                        int SOCV = Convert.ToInt16(dt2.Rows[0]["SOCV"].ToString());
                        string KYHIEU = dt2.Rows[0]["KYHIEU"].ToString();
                        string ID_LOAIVANBAN = dt2.Rows[0]["ID_LOAIVANBAN"].ToString();
                        string ID_CQBANHANH = dt2.Rows[0]["ID_CQBANHANH"].ToString();
                        string ID_CQNHANCV = "";
                        string ID_DVXULY = "";
                        string ID_CANBOKY = "";
                        string ID_CANBOXULY = dt2.Rows[0]["ID_CANBOXULY"].ToString();
                        DateTime NGAYKY = Convert.ToDateTime(dt2.Rows[0]["NGAYKY"].ToString());
                        DateTime NGAYNHAN = Convert.ToDateTime(dt2.Rows[0]["NGAYNHAN"].ToString());
                        string NOIDUNG = dt2.Rows[0]["NOIDUNG"].ToString();
                        string TIENDO = dt2.Rows[0]["TIENDO"].ToString();
                        string THUMUC = "\\CongVanDen\\Nam_" + NGAYKY.Year + "\\" + ID;
                        string PHEDUYET = dt2.Rows[0]["PHEDUYET"].ToString();
                        int TRANGTHAI = Convert.ToInt16(dt2.Rows[0]["TRANGTHAI"].ToString());
                        DateTime NGAYHETHAN = Convert.ToDateTime(dt2.Rows[0]["NGAYHETHAN"].ToString());
                        string GHICHU = dt2.Rows[0]["GHICHU"].ToString();
                        int SOBAN = 0;
                        string DUAN = "";
                        string VITRILUU = "";
                        string THBAOQUAN = "";
                        DateTime BATDAU = NGAYKY;
                        string KETTHUC = "";
                        string MANV = ThamSoHeThong.MaNhanVien;
                        string TENNV = ThamSoHeThong.TenNhanVien;
                        string LOAI = "NGUOITAO";
                        bool DAXEM = true;
                        DateTime NGAYXEM = NGAYKY;
                        int SAPXEP = -1;
                        int BANSAO = 0;
                        string DOMAT = "Bình thường";
                        string EMAIL = "";
                        bool SENDEMAIL = false;
                        ////Lưu dòng đầu tiên là người tạo công văn
                        New.INSERT_CONGVANDEN(MA, ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, LOAI, DAXEM, NGAYXEM, SAPXEP, BANSAO, DOMAT, EMAIL, SENDEMAIL);
                        ////Lưu các dòng có nhân viên dc giao xử lý
                        DataTable dt3 = ExcuteSQL("SELECT * FROM CONGVANDEN_NHANVIEN WHERE ID = " + ID,con);
                        for (int j = 0; j < dt3.Rows.Count; j++)
                        {
                            MA = System.Guid.NewGuid().ToString();
                            MANV = dt3.Rows[j]["ID_CANBOXULY"].ToString();
                            TENNV = dt3.Rows[j]["NAME"].ToString();
                            DAXEM = true;
                            NGAYXEM = NGAYNHAN;
                            SAPXEP = j; LOAI = "NGUOIXEM";
                            New.INSERT_CONGVANDEN(MA, ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, LOAI, DAXEM, NGAYXEM, SAPXEP, BANSAO, DOMAT, EMAIL, SENDEMAIL);
                        }
                        ////Update lại trạng thái xem, xử lý trường hợp nhân viên tạo cũng là nhân viên xử lý sẽ không group được, sẽ tạo ra 2 dòng công văn
                        New.UPDATE_CONGVANDEN_DAXEM("CONGVANDEN",ID, ThamSoHeThong.MaNhanVien);
                        this.Refresh();
                        this.Invalidate();
                    }

                    pro.PerformStep();
                    pro.Update();
                }
                New.Close();


                //FILE_CVDEN
                labelControl4.Text = "FILE_CVDEN";
                this.Refresh();
                this.Invalidate();
                New.DELETE_FILE_CVDEN();
                New.Open();
                dt = ExcuteSQL("SELECT * FROM FILE_CVDEN", con);
                pro.EditValue = 0;
                pro.Properties.Step = 1;
                pro.Properties.PercentView = true;
                pro.Properties.Maximum = dt.Rows.Count;
                pro.Properties.Minimum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        string ID = System.Guid.NewGuid().ToString();
                        string MACV = dt.Rows[i]["MACV"].ToString();
                        string LOAICV = dt.Rows[i]["LOAICV"].ToString();
                        string LOAIFILE = dt.Rows[i]["LOAIFILE"].ToString();
                        string THUMUC = dt.Rows[i]["THUMUC"].ToString();
                        string TAPTIN = dt.Rows[i]["FILE"].ToString();
                        DateTime NGAY = Convert.ToDateTime(dt.Rows[i]["NGAY"].ToString());
                        string GHICHU = dt.Rows[i]["GHICHU"].ToString();
                        byte[] FILEBYTE;
                        string F = txtThuMuc.Text + THUMUC + TAPTIN;
                        using (var stream = new FileStream(F, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = new BinaryReader(stream))
                            {
                                FILEBYTE = reader.ReadBytes((int)stream.Length);
                            }
                        }
                        string DUNGLUONG = "";
                        string MD5 = "";
                        string NGUOITAO = "admin";
                        New.INSERT_FILE_CVDEN(ID, MACV, LOAICV, LOAIFILE, THUMUC, TAPTIN, NGAY, GHICHU, FILEBYTE, DUNGLUONG, MD5, NGUOITAO);

                    }
                    catch { }
                    pro.PerformStep();
                    pro.Update();
                }
                New.Close();


                //CONGVANDI
                labelControl4.Text = "CONGVANDI";
                this.Refresh();
                this.Invalidate();
                New.DELETE_CONGVANDI();
                New.Open();
                dt = ExcuteSQL("SELECT * FROM CONGVANDI", con);
                pro.EditValue = 0;
                pro.Properties.Step = 1;
                pro.Properties.PercentView = true;
                pro.Properties.Maximum = dt.Rows.Count;
                pro.Properties.Minimum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ID = dt.Rows[i]["ID"].ToString();
                    DataTable dt2 = ExcuteSQL("SELECT * FROM CONGVANDEN WHERE ID = " + ID, con);
                    if (dt2.Rows.Count > 0)
                    {
                        string MA = System.Guid.NewGuid().ToString();
                        int SOCV = Convert.ToInt16(dt2.Rows[0]["SOCV"].ToString());
                        string KYHIEU = dt2.Rows[0]["KYHIEU"].ToString();
                        string ID_LOAIVANBAN = dt2.Rows[0]["ID_LOAIVANBAN"].ToString();
                        string ID_CQBANHANH = dt2.Rows[0]["ID_CQBANHANH"].ToString();
                        string ID_CQNHANCV = "";
                        string ID_DVXULY = "";
                        string ID_CANBOKY = dt2.Rows[0]["ID_CANBOXULY"].ToString();
                        string ID_CANBOXULY = dt2.Rows[0]["ID_CANBOXULY"].ToString();
                        DateTime NGAYKY = Convert.ToDateTime(dt2.Rows[0]["NGAYKY"].ToString());
                        DateTime NGAYNHAN = Convert.ToDateTime(dt2.Rows[0]["NGAYNHAN"].ToString());
                        string NOIDUNG = dt2.Rows[0]["NOIDUNG"].ToString();
                        string TIENDO = dt2.Rows[0]["TIENDO"].ToString();
                        string THUMUC = "\\CongVanDen\\Nam_" + NGAYKY.Year + "\\" + ID;
                        string PHEDUYET = dt2.Rows[0]["PHEDUYET"].ToString();
                        int TRANGTHAI = Convert.ToInt16(dt2.Rows[0]["TRANGTHAI"].ToString());
                        DateTime NGAYHETHAN = Convert.ToDateTime(dt2.Rows[0]["NGAYHETHAN"].ToString());
                        string GHICHU = dt2.Rows[0]["GHICHU"].ToString();
                        int SOBAN = 0;
                        string DUAN = "";
                        string VITRILUU = "";
                        string THBAOQUAN = "";
                        DateTime BATDAU = NGAYKY;
                        string KETTHUC = "";
                        string MANV = ThamSoHeThong.MaNhanVien;
                        string TENNV = ThamSoHeThong.TenNhanVien;
                        string LOAI = "NGUOITAO";
                        bool DAXEM = true;
                        DateTime NGAYXEM = NGAYKY;
                        int SAPXEP = -1;
                        int BANSAO = 0;
                        string DOMAT = "Bình thường";
                        string EMAIL = "";
                        bool SENDEMAIL = false;
                        ////Lưu dòng đầu tiên là người tạo công văn
                        New.INSERT_CONGVANDI(MA, ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, LOAI, DAXEM, NGAYXEM, SAPXEP, BANSAO, DOMAT, EMAIL, SENDEMAIL);
                        ////Lưu các dòng có nhân viên dc giao xử lý
                        DataTable dt3 = ExcuteSQL("SELECT * FROM CONGVANDI_DONVI WHERE ID = " + ID, con);
                        for (int j = 0; j < dt3.Rows.Count; j++)
                        {
                            MA = System.Guid.NewGuid().ToString();
                            MANV = dt3.Rows[j]["ID_DVXULY"].ToString();
                            TENNV = dt3.Rows[j]["NAME"].ToString();
                            DAXEM = true;
                            NGAYXEM = NGAYNHAN;
                            SAPXEP = j; LOAI = "NGUOIXEM";
                            New.INSERT_CONGVANDI(MA, ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, LOAI, DAXEM, NGAYXEM, SAPXEP, BANSAO, DOMAT, EMAIL, SENDEMAIL);
                        }
                        ////Update lại trạng thái xem, xử lý trường hợp nhân viên tạo cũng là nhân viên xử lý sẽ không group được, sẽ tạo ra 2 dòng công văn
                        New.UPDATE_CONGVANDEN_DAXEM("CONGVANDI", ID, ThamSoHeThong.MaNhanVien);
                    }
                    pro.PerformStep();
                    pro.Update();
                }
                New.Close();

                #endregion


                //FILE_CVDI
                labelControl4.Text = "FILE_CVDI";
                this.Refresh();
                this.Invalidate();
                New.DELETE_FILE_CVDI();
                New.Open();
                dt = ExcuteSQL("SELECT * FROM FILE_CVDI", con);
                pro.EditValue = 0;
                pro.Properties.Step = 1;
                pro.Properties.PercentView = true;
                pro.Properties.Maximum = dt.Rows.Count;
                pro.Properties.Minimum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        string ID = System.Guid.NewGuid().ToString();
                        string MACV = dt.Rows[i]["MACV"].ToString();
                        string LOAICV = dt.Rows[i]["LOAICV"].ToString();
                        string LOAIFILE = dt.Rows[i]["LOAIFILE"].ToString();
                        string THUMUC = dt.Rows[i]["THUMUC"].ToString();
                        string TAPTIN = dt.Rows[i]["FILE"].ToString();
                        DateTime NGAY = Convert.ToDateTime(dt.Rows[i]["NGAY"].ToString());
                        string GHICHU = dt.Rows[i]["GHICHU"].ToString();
                        byte[] FILEBYTE;
                        string F = txtThuMuc.Text + THUMUC + TAPTIN;
                        using (var stream = new FileStream(F, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = new BinaryReader(stream))
                            {
                                FILEBYTE = reader.ReadBytes((int)stream.Length);
                            }
                        }
                        string DUNGLUONG = "";
                        string MD5 = "";
                        string NGUOITAO = "admin";
                        New.INSERT_FILE_CVDI(ID, MACV, LOAICV, LOAIFILE, THUMUC, TAPTIN, NGAY, GHICHU, FILEBYTE, DUNGLUONG, MD5, NGUOITAO);
                    }
                    catch { }
                    pro.PerformStep();
                    pro.Update();
                }
                New.Close(); DevExpress.XtraEditors.XtraMessageBox.Show("Thực hiện thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Lỗi khi thực hiện !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}