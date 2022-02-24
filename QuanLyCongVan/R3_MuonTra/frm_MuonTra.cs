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

namespace QuanLyCongVan.MuonTra
{
    public partial class frm_MuonTra : DevExpress.XtraEditors.XtraForm
    {
        public frm_MuonTra()
        {
            InitializeComponent();
        }
        Class.csDatetime Date = new Class.csDatetime();
        Class.csLookupEdit Lookuptedit = new Class.csLookupEdit();
        Class.csMuonTra MuonTra = new Class.csMuonTra();
        Class.csMD5 MD5 = new Class.csMD5();


        private void LoadData()
        {
            try
            {
                DateTime dt1 = dtp1.DateTime;
                DateTime dt2 = dtp2.DateTime.AddDays(1).AddSeconds(-1);
                grcCongVan.DataSource = MuonTra.SELECT_MUONTRA_TIME(dt1, dt2);
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
            Lookuptedit.ReposGridLookUpEdit("NHANVIEN", rpNhanVien, "Name", "ID");
            Lookuptedit.ReposLookUpEdit("MUONTRA", rpTrangThai, "Name", "ID");
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
                MuonTra.frm_ThemMT ThemMT = new MuonTra.frm_ThemMT();
                ThemMT.Button_Clicked += new EventHandler(bTim_Click);
                ThemMT.MA = Convert.ToDecimal(grvCongVan.GetRowCellValue(grvCongVan.FocusedRowHandle, "MA").ToString());
                ThemMT.ShowDialog();
            }
            catch
            {
            }
        }

        private void bIn_Click(object sender, EventArgs e)
        {
            grvCongVan.ShowRibbonPrintPreview();
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
            MuonTra.frm_ThemMT ThemMT = new MuonTra.frm_ThemMT();
            ThemMT.Button_Clicked += new EventHandler(bTim_Click);
            ThemMT.ShowDialog();
        }

        private void bXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thật sự muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    decimal MA = Convert.ToDecimal(grvCongVan.GetRowCellValue(grvCongVan.FocusedRowHandle, "MA").ToString());
                    MuonTra.DELETE_MUONTRA(MA);
                    bTim_Click(sender, e);
                }
            }
            catch { }
        }

        private void grvCongVan_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.Landscape = true;
            pb.PageSettings.TopMargin = 50;
            pb.PageSettings.BottomMargin = 50;
            pb.PageSettings.LeftMargin = 50;
            pb.PageSettings.RightMargin = 50;
        }
    }
}
