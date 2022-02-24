using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCongVan
{
    public static class ThamSoHeThong
    {
        public static bool TrangThaiLogin = false;
        public static string FormOpen; //Form mở từ giới thiệu
        public static string TenDangNhap;
        public static string MaNhanVien;
        public static string TenNhanVien;
        public static string LoaiNhanVien;
        public static string NhomQuyenNV;
        public static string PhongBan;

        public static string TenMayTinh;
        public static string ThuMucTapTin;
        public static string ServerName;
        public static string DatabaseName;
        public static string VersionApp;
        public static string LicenseApp;

        public static string DONVICHUQUAN;
        public static string DONVISUDUNG;
        public static string DIACHI;
        public static string XAPHUONG;
        public static string HUYENQUAN;
        public static string TINH;
        public static string SODT;
        public static string FAX;
        public static string WEBSITE;
        public static string EMAIL;
        public static string TAX;
        public static Image LOGO;

        public static string Server;
        public static int Port;
        public static bool SSL;
        public static string Account;
        public static string Password;

        public static string MessageBox_Title = "Thông báo";
        public static string Project_ID = "2c7d417459774cd19a0d";
        public static string Project_Name = "2c7d417459774cd19a0d";
        public static string KeyRegedit = "Quan Ly Cong Van";
        public static string NameApp = "Quan Ly Cong Van";
        public static string File_exe = "QuanLyCongVan";
        public static string AppName = "Phần mềm quản lý công văn";
        public static string Path_Temp = Application.StartupPath + @"\UpdateFile\";
        public static string LinkVideoYoutube_PhanQuyen = @"https://www.youtube.com/watch?v=PI5mZPcMbS0";
        public static string ListMaMay = "Y54RU0ZAS";

        public static DataTable Table_Rule;
        public static bool Quyen(string Form_ID, string Rule)
        {
            bool Rule2 = false;
            if (ThamSoHeThong.TenDangNhap != "admin")
            {
                DataTable dt = ThamSoHeThong.Table_Rule.AsEnumerable().Where(row => row.Field<String>("Form_ID") == Form_ID).CopyToDataTable();
                if (dt.Rows.Count > 0)
                    Rule2 = Convert.ToBoolean(dt.Rows[0][Rule].ToString());
            }
            else
            {
                Rule2 = true;
            }
            if ((Rule2 == false) && (Rule == "sAdd"))
                DevExpress.XtraEditors.XtraMessageBox.Show("Bạn không có quyền thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if ((Rule2 == false) && (Rule == "sDelete"))
                DevExpress.XtraEditors.XtraMessageBox.Show("Bạn không có quyền xoá !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if ((Rule2 == false) && (Rule == "sEdit"))
                DevExpress.XtraEditors.XtraMessageBox.Show("Bạn không có quyền sửa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if ((Rule2 == false) && (Rule == "sPrint"))
                DevExpress.XtraEditors.XtraMessageBox.Show("Bạn không có quyền in !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if ((Rule2 == false) && (Rule == "sExport"))
                DevExpress.XtraEditors.XtraMessageBox.Show("Bạn không có quyền xuất !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return Rule2;
        }
    }
}
