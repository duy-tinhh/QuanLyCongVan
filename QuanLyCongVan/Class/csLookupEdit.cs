using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using DevExpress.ExpressApp.Win.Editors;
using System.IO;
using System.Windows.Forms;
namespace QuanLyCongVan.Class
{
    public class csLookupEdit
    {
        SqlConnection con = new SqlConnection(clsConnection.sConnection);
        public void Open()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void Close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        csCongVanDen CongVanDen = new csCongVanDen();
        csCongVanDi CongVanDi = new csCongVanDi();
        public DataTable SELECT_DM_CQBANHANH()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, Name FROM CQBANHANH ORDER BY Name ASC";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        public DataTable SELECT_DM_CQNHANCV()
        {
            DataTable dt = new DataTable();
            string s = "SELECT ID, Name FROM CQNHANCV ORDER BY Name ASC";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            return dt;
        }
        public DataTable SELECT_DM_LOAIVANBAN()
        {
            DataTable dt = new DataTable();
            string s = "SELECT ID, Name FROM LOAIVANBAN ORDER BY Name ASC";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            return dt;
        }
        public DataTable SELECT_DM_NHANVIEN()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, Name FROM CANBOXULY ORDER BY ID ASC";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        public DataTable SELECT_DM_CANBOKY()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, Name FROM CANBOKY ORDER BY ID ASC";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }

        public DataTable SELECT_DM_GIAIDOAN()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, Name FROM GIAIDOAN ORDER BY Sort ASC";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        public DataTable SELECT_DM_PHONGBAN()
        {
            DataTable dt = new DataTable();
            string s = "";//SELECT MAPHONGBAN, TENPHONGBAN FROM DM_PHONGBAN ORDER BY MAPHONGBAN ASC";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            return dt;
        }
        // Select TRANGTHAI
        public DataTable TrangThaiCongVan()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, Name FROM TRANGTHAI";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        // Select THBAOQUAN
        public DataTable SELECT_THBAOQUAN()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, Name FROM THBAOQUAN";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }

        // Select THBAOQUAN
        public DataTable SELECT_NVQS_DS()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, Name FROM NVQS_DS";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }

        // Select THBAOQUAN
        public DataTable SELECT_TODANPHO()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, Name FROM TODANPHO";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }

        // Select THBAOQUAN
        public DataTable SELECT_KHUPHO()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, Name FROM KHUPHO";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }

        // Select THBAOQUAN
        public DataTable SELECT_CSKV()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, Name FROM CSKV";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }

        // Select THBAOQUAN
        public DataTable SELECT_THUOCNHOM()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, Name FROM NVQS_NH";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        // Select THBAOQUAN
        public DataTable SELECT_PHANNHOM()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, Name FROM NVQS_DS";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        public DataTable SELECT_MUONTRA()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Rows.Add("MUON", "Đang mượn");
            dt.Rows.Add("TRA", "Đã trả");
            return dt;
        }
        public DataTable TrangThaiXem()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Rows.Add(0, "");
            dt.Rows.Add(1, "Đã xem");
            return dt;
        }
        public void LookupEdit(string Type, DevExpress.XtraEditors.LookUpEdit LookupEdit, string DisplayMember, string ValueMember)
        {
            DataTable dt = new DataTable();
            if(Type == "CQBANHANH")
            {
                dt = SELECT_DM_CQBANHANH();
            }
            else if (Type == "CQNHANCV")
            {
                dt = SELECT_DM_CQNHANCV();
            }
            else if (Type == "LOAIVANBAN")
            {
                dt = SELECT_DM_LOAIVANBAN();
            }
            else if (Type == "NHANVIEN")
            {
                dt = SELECT_DM_NHANVIEN();
            }
            else if (Type == "CANBOKY")
            {
                dt = SELECT_DM_CANBOKY();
            }
            else if (Type == "PHONGBAN")
            {
                dt = SELECT_DM_PHONGBAN();
            }
            else if (Type == "GIAIDOAN")
            {
                dt = SELECT_DM_GIAIDOAN();
            }
            else if (Type == "TRANGTHAI")
            {
                dt = TrangThaiCongVan();
            }
            else if (Type == "THBAOQUAN")
            {
                dt = SELECT_THBAOQUAN();
            }
            else if (Type == "MUONTRA")
            {
                dt = SELECT_MUONTRA();
            }
            else if (Type == "NVQS_DS")
            {
                dt = SELECT_NVQS_DS();
            }
            else if (Type == "TODANPHO")
            {
                dt = SELECT_TODANPHO();
            }
            else if (Type == "KHUPHO")
            {
                dt = SELECT_KHUPHO();
            }
            else if (Type == "CSKV")
            {
                dt = SELECT_CSKV();
            }
            dt.Rows.Add("", "");
            LookupEdit.Properties.DataSource = dt;
            LookupEdit.Properties.DisplayMember = DisplayMember;
            LookupEdit.Properties.ValueMember = ValueMember;
            LookupEdit.Properties.ShowFooter = false;
            LookupEdit.Properties.ShowHeader = false;
            LookupEdit.EditValue = "";
        }
        public void GridLookupEdit(string Type, DevExpress.XtraEditors.GridLookUpEdit GridLookupEdit, string DisplayMember, string ValueMember)
        {
            DataTable dt = new DataTable();
            if (Type == "CQBANHANH")
            {
                dt = SELECT_DM_CQBANHANH();
            }
            else if (Type == "CQNHANCV")
            {
                dt = SELECT_DM_CQNHANCV();
            }
            else if (Type == "LOAIVANBAN")
            {
                dt = SELECT_DM_LOAIVANBAN();
            }
            else if (Type == "NHANVIEN")
            {
                dt = SELECT_DM_NHANVIEN();
            }
            else if (Type == "CANBOKY")
            {
                dt = SELECT_DM_CANBOKY();
            }
            else if (Type == "PHONGBAN")
            {
                dt = SELECT_DM_PHONGBAN();
            }
            else
            {
                dt = TrangThaiCongVan();
            }
            dt.Rows.Add("", "");
            GridLookupEdit.Properties.DataSource = dt;
            GridLookupEdit.Properties.DisplayMember = DisplayMember;
            GridLookupEdit.Properties.ValueMember = ValueMember;
        }
        public void ReposLookUpEdit(string Type, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ReposLookUpEdit, string DisplayMember, string ValueMember)
        {
            DataTable dt = new DataTable();
            if (Type == "CQBANHANH")
            {
                dt = SELECT_DM_CQBANHANH();
            }
            else if (Type == "CQNHANCV")
            {
                dt = SELECT_DM_CQNHANCV();
            }
            else if (Type == "LOAIVANBAN")
            {
                dt = SELECT_DM_LOAIVANBAN();
            }
            else if (Type == "NHANVIEN")
            {
                dt = SELECT_DM_NHANVIEN();
            }
            else if (Type == "CANBOKY")
            {
                dt = SELECT_DM_CANBOKY();
            }
            else if (Type == "PHONGBAN")
            {
                dt = SELECT_DM_PHONGBAN();
            }
            else if (Type == "TRANGTHAI")
            {
                dt = TrangThaiCongVan();
            }
            else if (Type == "DAXEM")
            {
                dt = TrangThaiXem();
            }
            else if (Type == "THBAOQUAN")
            {
                dt = SELECT_THBAOQUAN();
            }
            else if (Type == "GIAIDOAN")
            {
                dt = SELECT_DM_GIAIDOAN();
            }
            else if (Type == "MUONTRA")
            {
                dt = SELECT_MUONTRA();
            }
            else if (Type == "NVQS_DS")
            {
                dt = SELECT_NVQS_DS();
            }
            else if (Type == "TODANPHO")
            {
                dt = SELECT_TODANPHO();
            }
            else if (Type == "KHUPHO")
            {
                dt = SELECT_KHUPHO();
            }
            else if (Type == "CSKV")
            {
                dt = SELECT_CSKV();
            }
            else if (Type == "THUOCNHOM")
            {
                dt = SELECT_THUOCNHOM();
            }
            else if (Type == "PHANNHOM")
            {
                dt = SELECT_PHANNHOM();
            }
            ReposLookUpEdit.DataSource = dt;
            ReposLookUpEdit.ShowFooter = false;
            ReposLookUpEdit.ShowHeader = false;
            ReposLookUpEdit.DisplayMember = DisplayMember;
            ReposLookUpEdit.ValueMember = ValueMember;
        }
        public void ReposGridLookUpEdit(string Type, DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit ReposGridLookUpEdit, string DisplayMember, string ValueMember)
        {
            DataTable dt = new DataTable();
            if (Type == "CQBANHANH")
            {
                dt = SELECT_DM_CQBANHANH();
            }
            else if (Type == "CQNHANCV")
            {
                dt = SELECT_DM_CQNHANCV();
            }
            else if (Type == "LOAIVANBAN")
            {
                dt = SELECT_DM_LOAIVANBAN();
            }
            else if (Type == "NHANVIEN")
            {
                dt = SELECT_DM_NHANVIEN();
            }
            else if (Type == "CANBOKY")
            {
                dt = SELECT_DM_CANBOKY();
            }
            else if (Type == "PHONGBAN")
            {
                dt = SELECT_DM_PHONGBAN();
            }
            else
            {
                dt = TrangThaiCongVan();
            }
            ReposGridLookUpEdit.DataSource = dt;
            ReposGridLookUpEdit.DisplayMember = DisplayMember;
            ReposGridLookUpEdit.ValueMember = ValueMember;
        }

        public void Open_File(DevExpress.XtraGrid.Views.Grid.GridView girdView)
        {
            try
            {
                int Dong = girdView.FocusedRowHandle;
                string TrangThai = girdView.GetRowCellValue(Dong, "MACV").ToString();
                string Folder = girdView.GetRowCellValue(Dong, "THUMUC").ToString();
                string TapTin = girdView.GetRowCellValue(Dong, "TAPTIN").ToString(); 
                if (TrangThai == "")
                {
                    System.Diagnostics.Process.Start(Folder+TapTin);
                }
                else
                {
                    string Path_MayCon = @"D:\QuanLyCongVan" + Folder + TapTin;
                    if (!File.Exists(Path_MayCon))
                    {
                        if (!Directory.Exists(@"D:\QuanLyCongVan" + Folder))
                        {
                            Directory.CreateDirectory(@"D:\QuanLyCongVan" + Folder);
                        }
                        File.Copy(ThamSoHeThong.ThuMucTapTin + Folder + TapTin, Path_MayCon);
                    }
                    System.Diagnostics.Process.Start(Path_MayCon);
                }
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Thực hiện thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
