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

namespace QuanLyCongVan.NhatKyLamViec
{
    public partial class frm_ThemNK : DevExpress.XtraEditors.XtraForm
    {
        public frm_ThemNK()
        {
            InitializeComponent();
        }

        Class.csLookupEdit Lookuptedit = new Class.csLookupEdit();
        Class.csNhatKyLamViec CongVan = new Class.csNhatKyLamViec();
        
        public event EventHandler Button_Clicked;

        private decimal _MACV = 0;
        public decimal MACV
        {
            get { return _MACV; }
            set { _MACV = value; }
        }

        private void LoadData()
        {
            Lookuptedit.GridLookupEdit("NHANVIEN", txtNhanVien, "Name", "ID");
            txtNhanVien.EditValue = ThamSoHeThong.MaNhanVien;
        }
                        
        private void frm_ThemCongVanDen_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                LoadData();
                if (MACV == 0)
                {
                    ckID.Checked = false;
                    dtpNgay.DateTime = DateTime.Now;
                    timeStart.Time = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
                    timeEnd.Time = timeStart.Time.AddHours(1);
                    txtMaCV.Value = CongVan.AUTO_ID();
                    txtNhanVien.EditValue = ThamSoHeThong.MaNhanVien;
                }
                else
                {
                    ckID.Checked = true;
                    txtMaCV.Value = MACV;
                    DataTable dt = CongVan.SELECT_TRAODOI_MA(MACV);
                    txtMaCV.Value = Convert.ToDecimal(dt.Rows[0]["ID"].ToString());
                    txtNhanVien.EditValue = dt.Rows[0]["MANV"].ToString();
                    dtpNgay.EditValue = Convert.ToDateTime(dt.Rows[0]["NGAY"].ToString());
                    timeStart.Time = Convert.ToDateTime(dt.Rows[0]["BATDAU"].ToString());
                    timeEnd.Time = Convert.ToDateTime(dt.Rows[0]["KETTHUC"].ToString());
                    txtNoiDung.Text = dt.Rows[0]["NOIDUNG"].ToString();
                    txtGhichu.Text = dt.Rows[0]["GHICHU"].ToString();
                }
                Cursor.Current = Cursors.Default;
            }
            catch
            {
            }
        }

        private void bLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaCV.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng điền mã công văn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaCV.Focus();
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    decimal ID = txtMaCV.Value;
                    DateTime NGAY = dtpNgay.DateTime;
                    DateTime BATDAU = timeStart.Time;
                    DateTime KETTHUC = timeEnd.Time;
                    string MANV = txtNhanVien.EditValue.ToString();
                    string HOTEN = txtNhanVien.Text;
                    string NOIDUNG = txtNoiDung.Text;
                    string GHICHU = txtGhichu.Text;
                    bool TRANGTHAI = true;
                    DateTime NGAYTAO = DateTime.Now;
                    DateTime NGAYSUA = DateTime.Now;
                    bool XOA = false;
                  
                    if (ckID.Checked == false)
                    {
                        CongVan.INSERT_NHATKYLAMVIEC(ID, NGAY, BATDAU, KETTHUC, MANV, HOTEN, NOIDUNG, GHICHU, TRANGTHAI, NGAYTAO, NGAYSUA, XOA);
                        ckID.Checked = true;
                    }
                    else
                    {
                        CongVan.UPDATE_NHATKYLAMVIEC(ID, NGAY, BATDAU, KETTHUC, MANV, HOTEN, NOIDUNG, GHICHU, TRANGTHAI, NGAYSUA, XOA);                        
                    }
                    if (this.Button_Clicked != null)
                        this.Button_Clicked(sender, e);
                    bThem_Click(sender, e);
                    Cursor.Current = Cursors.Default;
                }
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Lưu thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }        

        private void bThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bThem_Click(object sender, EventArgs e)
        {
            ckID.Checked = false;
            dtpNgay.DateTime = DateTime.Now;
            timeStart.Time = timeEnd.Time;
            timeEnd.Time = timeStart.Time.AddHours(1);
            txtMaCV.Value = CongVan.AUTO_ID();
            txtNoiDung.Text = "";
            txtGhichu.Text = "";
        }        
    }
}