using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraGrid.Columns;

namespace QuanLyCongVan.NhatKyLamViec
{
    public partial class frm_NhatKyLamViec : DevExpress.XtraEditors.XtraForm
    {
        public frm_NhatKyLamViec()
        {
            InitializeComponent();
        }
        Class.csDatetime Date = new Class.csDatetime();
        Class.csLookupEdit Lookuptedit = new Class.csLookupEdit();
        Class.csNhatKyLamViec NhatKyLamViec = new Class.csNhatKyLamViec();
        Class.csMD5 MD5 = new Class.csMD5();


        private void LoadData()
        {
            try
            {
                DateTime dt1 = dtp1.DateTime;
                DateTime dt2 = dtp2.DateTime.AddDays(1).AddSeconds(-1);
                grcCongVan.DataSource = NhatKyLamViec.SELECT_NHATKYLAMVIEC_TIME(ThamSoHeThong.MaNhanVien, dt1, dt2);
            }
            catch
            {
            }
        }
        public void frm_Button_Clicked(object sender, EventArgs e)
        {
            this.bTim_Click(bTim, EventArgs.Empty);
        }
        private void LoadDataCQBanHanh()
        {
            Lookuptedit.ReposGridLookUpEdit("NHANVIEN", rpNhanVien, "HOTEN", "MANV");
        }
        private void DateList()
        {
            cbChon.Properties.DataSource = Date.DanhMucDate();
            cbChon.Properties.DisplayMember = "Name";
            cbChon.Properties.ValueMember = "ID";
            cbChon.EditValue = 3; 
        }
        private void frm_CongVanDen_Load(object sender, EventArgs e)
        {
            DateList();
            LoadDataCQBanHanh(); 
            LoadData();
        }

        private void grvCongVan_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Info.IsRowIndicator)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        
        private void bTim_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadData();
            Cursor.Current = Cursors.Default;
        }        

        private void bSua_Click(object sender, EventArgs e)
        {
            try
            {
                //frm_ThemTraoDoi ThemCongVanDen = new frm_ThemTraoDoi();
                //ThemCongVanDen.Button_Clicked += new EventHandler(frm_Button_Clicked);
                //ThemCongVanDen.MACV = Convert.ToDecimal(grvCongVan.GetRowCellValue(grvCongVan.FocusedRowHandle, "MACV").ToString());
                //ThemCongVanDen.ShowDialog();
            }
            catch
            {
            }
        }


        private void bIn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("MA", typeof(decimal));
                dt.Columns.Add("NGAY", typeof(DateTime));
                dt.Columns.Add("GIO", typeof(string));
                dt.Columns.Add("BATDAU", typeof(DateTime));
                dt.Columns.Add("KETTHUC", typeof(DateTime));
                dt.Columns.Add("NOIDUNG", typeof(string));
                dt.Columns.Add("GHICHU", typeof(string));
                decimal ID;
                DateTime NGAY;
                string GIO = "";
                DateTime BATDAU;
                DateTime KETTHUC;
                string NOIDUNG = "";
                string GHICHU = "";
                for (int i = 0; i < grvCongVan.RowCount; i++)
                {
                    ID = Convert.ToDecimal(grvCongVan.GetRowCellValue(i, "ID").ToString());
                    NGAY = Convert.ToDateTime(grvCongVan.GetRowCellValue(i, "NGAY").ToString());
                    BATDAU = Convert.ToDateTime(grvCongVan.GetRowCellValue(i, "BATDAU").ToString());
                    KETTHUC = Convert.ToDateTime(grvCongVan.GetRowCellValue(i, "KETTHUC").ToString());
                    GIO = BATDAU.Hour.ToString("00") +"h" + BATDAU.Minute.ToString("00") + " - " + KETTHUC.Hour.ToString("00") + "h" + KETTHUC.Minute.ToString("00");
                    NOIDUNG = grvCongVan.GetRowCellValue(i, "NOIDUNG").ToString();
                    GHICHU = grvCongVan.GetRowCellValue(i, "GHICHU").ToString();
                    dt.Rows.Add(ID, NGAY, GIO, BATDAU, KETTHUC, NOIDUNG, GHICHU);
                }
                frm_Print_NK NhatKyLamViec = new frm_Print_NK { DataSource = dt };
                NhatKyLamViec.NhatKyLamViec.TENCONGVAN = "NHẬT KÝ LÀM VIỆC";
                NhatKyLamViec.NhatKyLamViec.TUNGAY = dtp1.DateTime;
                NhatKyLamViec.NhatKyLamViec.DENNGAY = dtp2.DateTime;
                NhatKyLamViec.NhatKyLamViec.THOIGIAN = "Tháng " + dtp1.DateTime.Month + "/" + dtp1.DateTime.Year;
                NhatKyLamViec.ShowDialog();
            }
            catch { }
        }
        
        private void bXuat_Click(object sender, EventArgs e)
        {
            ExportToXLS XLS = new ExportToXLS();
            XLS.ToXLS(grvCongVan);
        }
              
        private void grcCongVan_DoubleClick(object sender, EventArgs e)
        {
            bSua_Click(sender, e);
        }
        private void cbChon_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            Date.NgayThangNam(cbChon.EditValue.ToString(), dtp1, dtp2);
        }
        private void cbChon_EditValueChanged(object sender, EventArgs e)
        {
            Date.NgayThangNam(cbChon.EditValue.ToString(), dtp1, dtp2);
        }

        private void bThem_Click(object sender, EventArgs e)
        {
            frm_ThemNK ThemNK = new frm_ThemNK();
            ThemNK.Button_Clicked += new EventHandler(bTim_Click);
            ThemNK.ShowDialog();
        }

        private void bXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thật sự muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    decimal ID = Convert.ToDecimal(grvCongVan.GetRowCellValue(grvCongVan.FocusedRowHandle, colMa).ToString());
                    NhatKyLamViec.DELETE_NHATKYLAMVIEC(ID);
                    bTim_Click(sender, e);
                }
            }
            catch { }
        }
    }
}
