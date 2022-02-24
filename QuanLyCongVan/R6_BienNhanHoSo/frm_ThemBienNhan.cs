using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Xml;
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Core;

namespace QuanLyCongVan.R6_BienNhanHoSo
{
    public partial class frm_ThemBienNhan : DevExpress.XtraEditors.XtraForm
    {
        public frm_ThemBienNhan()
        {
            InitializeComponent();
        }

        Class.csDatetime Date = new Class.csDatetime();
        Class.csBienNhan CongVan = new Class.csBienNhan();
        Class.csCanBoXuLy CanBoXuLy = new Class.csCanBoXuLy();
        Class.csLookupEdit Lookuptedit = new Class.csLookupEdit();
        Class.csViTriLuu ViTriLuu = new Class.csViTriLuu();
        Class.csMD5 MD5 = new Class.csMD5();   

        public event EventHandler Button_Clicked;
        private string _ID_CongVan = "";
        public string ID_CongVan
        {
            get { return _ID_CongVan; }
            set { _ID_CongVan = value; }
        }

        public void frm_Button_Clicked(object sender, EventArgs e)
        {
            Lookuptedit.LookupEdit("NHANVIEN", txtNguoiNhan, "Name", "ID");
        }
        private void frm_ThemCongVanDen_Load(object sender, EventArgs e)
        {
            try
            {
                Lookuptedit.LookupEdit("NHANVIEN", txtNguoiNhan, "Name", "ID");
                if (ID_CongVan == "")
                {
                    txtMaBN.Value = CongVan.AUTO_ID();
                    dtNgayNhan.DateTime = DateTime.Now;
                    txtNguoiNhan.EditValue = ThamSoHeThong.MaNhanVien;
                    txtMaBN.Focus();
                }
                else
                {
                    txtMaBN.Properties.ReadOnly = true;
                    txtMaBN.Text = ID_CongVan;
                    DataTable dt = CongVan.SELECT_BIENNHAN(ID_CongVan); 
                    if (dt.Rows.Count > 0)
                    {
                        txtSoBN.Text = dt.Rows[0]["SOBN"].ToString();
                        txtSoBan.Value = Convert.ToDecimal(dt.Rows[0]["SOBAN"].ToString()); 
                        dtNgayNhan.DateTime = Convert.ToDateTime(dt.Rows[0]["NGAYNHAN"].ToString());
                        txtNguoiNhan.EditValue = dt.Rows[0]["MANV"].ToString();  
                        txtChucVu.EditValue = dt.Rows[0]["CHUCVU"].ToString();  
                        txtNguoiGui.EditValue = dt.Rows[0]["NGUOIGUI"].ToString();
                        txtNoiDung.Text = dt.Rows[0]["NOIDUNG"].ToString();
                        txtGhiChu.Text = dt.Rows[0]["GHICHU"].ToString();
                        txtDiachi.Text = dt.Rows[0]["DIACHI"].ToString();                   
                    }
                }
            }
            catch
            {
            }
        }

        private void bLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtMaBN.Properties.ReadOnly == false) && (ThamSoHeThong.Quyen("frm_BienNhanHoSo_DS", "sAdd") == false))
                    return;
                if ((txtMaBN.Properties.ReadOnly == true) && (ThamSoHeThong.Quyen("frm_BienNhanHoSo_DS", "sEdit") == false))
                    return;
                if (txtMaBN.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng điền mã biên nhận !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaBN.Focus();
                }
                else if (txtSoBN.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng điền số biên nhận !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoBN.Focus();
                }
                else if (txtNguoiNhan.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng chọn người nhận công văn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNguoiNhan.Focus();
                }
                else if (txtNguoiGui.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng điền người gửi công văn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNguoiGui.Focus();
                }
                else if (txtNoiDung.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng điền nội dung !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNoiDung.Focus();
                }
                else
                {
                    decimal ID = txtMaBN.Value;
                    string SOBN = txtSoBN.Text;
                    DateTime NGAYNHAN = dtNgayNhan.DateTime;
                    decimal SOBAN = txtSoBan.Value;
                    string MANV = txtNguoiNhan.EditValue.ToString();
                    string TENNV = txtNguoiNhan.Text;
                    string CHUCVU = txtChucVu.Text.Trim();
                    string NGUOIGUI = txtNguoiGui.Text.Trim();
                    string NOIDUNG = txtNoiDung.Text.Trim();
                    string GHICHU = txtGhiChu.Text.Trim();
                    string NGUOITAO = ThamSoHeThong.TenDangNhap;
                    DateTime NGAYTAO = DateTime.Now;
                    string NGUOISUA = ThamSoHeThong.TenDangNhap;
                    DateTime NGAYSUA = DateTime.Now;
                    bool TRANGTHAI = true;
                    string DIACHI = txtDiachi.Text.Trim();
                    if (txtMaBN.Properties.ReadOnly == false)
                    {
                        CongVan.INSERT_BIENNHAN(ID, SOBN, NGAYNHAN, SOBAN, MANV, TENNV, CHUCVU, NGUOIGUI, NOIDUNG, GHICHU, NGUOITAO, NGAYTAO, NGUOISUA, NGAYSUA, TRANGTHAI, DIACHI);
                    }
                    else
                    {
                        CongVan.UPDATE_BIENNHAN(ID, SOBN, NGAYNHAN, SOBAN, MANV, TENNV, CHUCVU, NGUOIGUI, NOIDUNG, GHICHU, NGUOISUA, NGAYSUA, TRANGTHAI, DIACHI);
                    }
                    if (this.Button_Clicked != null)
                        this.Button_Clicked(sender, e);
                    DevExpress.XtraEditors.XtraMessageBox.Show("Thực hiện thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Thực hiện thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void bThem_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaBN.Properties.ReadOnly = false;
                txtMaBN.Value = CongVan.AUTO_ID();
                dtNgayNhan.DateTime = DateTime.Now;
                txtNoiDung.Text = "";
                txtSoBN.Text = "";
                txtGhiChu.Text = "";
                txtDiachi.Text = "";
            }
            catch { }
        }

        private void bThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void txtMaCV_TextChanged(object sender, EventArgs e)
        {
            if (txtMaBN.Properties.ReadOnly == true)
            {
                bLuu.Enabled = true;
            }
            else
            {
                string ID = txtMaBN.Text;
                DataTable dt = CongVan.SELECT_BIENNHAN(ID);
                if (dt.Rows.Count > 0)
                {
                    bLuu.Enabled = false;
                }
                else
                {
                    bLuu.Enabled = true;
                }
            }
        }
        
        private void bIN_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(decimal));
                dt.Columns.Add("SOBN", typeof(string));
                dt.Columns.Add("NGAYNHAN", typeof(DateTime));
                dt.Columns.Add("SOBAN", typeof(decimal));
                dt.Columns.Add("TENNV", typeof(string));
                dt.Columns.Add("CHUCVU", typeof(string));
                dt.Columns.Add("NGUOIGUI", typeof(string));
                dt.Columns.Add("NOIDUNG", typeof(string));
                dt.Columns.Add("GHICHU", typeof(string));
                dt.Columns.Add("NGAY", typeof(string));
                dt.Columns.Add("DIACHI", typeof(string));
                decimal ID = txtMaBN.Value;
                string SOBN = txtSoBN.Text;
                DateTime NGAYNHAN = dtNgayNhan.DateTime;
                decimal SOBAN = txtSoBan.Value;
                string TENNV = txtNguoiNhan.Text;
                string CHUCVU = txtChucVu.Text;
                string NGUOIGUI = txtNguoiGui.Text;
                string NOIDUNG = txtNoiDung.Text;
                string GHICHU = txtGhiChu.Text;
                string NGAY = ThamSoHeThong.XAPHUONG + ", ngày " + NGAYNHAN.ToString("dd") + " tháng " + NGAYNHAN.ToString("MM") + " năm " + NGAYNHAN.ToString("yyyy");
                string DIACHI = txtDiachi.Text;
                dt.Rows.Add(ID, SOBN, NGAYNHAN, SOBAN, TENNV, CHUCVU, NGUOIGUI, NOIDUNG, GHICHU, NGAY, DIACHI);
                frm_Print_Chitiet form = new frm_Print_Chitiet();
                form.report.Data = dt;
                form.ShowDialog();
            }
            catch
            {
            }
        }
    }
}