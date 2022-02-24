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

namespace QuanLyCongVan.VT_CongVanDi
{
    public partial class frm_VT_CongVanDi_TK : DevExpress.XtraEditors.XtraForm
    {
        public frm_VT_CongVanDi_TK()
        {
            InitializeComponent();
        }
        Class.csDatetime Date = new Class.csDatetime();
        Class.ConfigApp Config = new Class.ConfigApp();
        Class.csCongVanDi CongVan = new Class.csCongVanDi();
        Class.csLookupEdit Lookuptedit = new Class.csLookupEdit();

        void LoadData()
        {
            try
            {
                DateTime dt1 = dtp1.DateTime;
                DateTime dt2 = dtp2.DateTime.AddDays(1).AddSeconds(-1);
                grcCongVan.DataSource = CongVan.SELECT_CONGVAN_TIME(dt1, dt2);
            }
            catch
            {
            }
        }
        public void frm_Button_Clicked(object sender, EventArgs e)
        {
            this.bTim_Click(bTim, EventArgs.Empty);
        }
        void LoadDataCQBanHanh()
        {
            Lookuptedit.ReposLookUpEdit("TRANGTHAI", rpTrangThai, "Name", "ID");
            Lookuptedit.ReposGridLookUpEdit("CANBOKY", rpCanBoKy, "Name", "ID");
            Lookuptedit.ReposGridLookUpEdit("LOAIVANBAN", rpLoaiVanBan, "Name", "ID");
            Lookuptedit.LookupEdit("CANBOKY", txtNguoiKy, "Name", "ID");
            Lookuptedit.LookupEdit("LOAIVANBAN", txtLoaiVB, "Name", "ID");
        }

        void DateList()
        {
            cbChon.Properties.DataSource = Date.DanhMucDate();
            cbChon.Properties.DisplayMember = "Name";
            cbChon.Properties.ValueMember = "ID";
            cbChon.EditValue = 3; 
        }
        private void frm_CongVanDen_Load(object sender, EventArgs e)
        {
            Config.Load_View(this.Name, grvCongVan);
            DateList();
            LoadDataCQBanHanh();
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

        private void bThem_Click(object sender, EventArgs e)
        {
            VT_CongVanDi.frm_VT_ThemCongVanDi ThemCongVanDi = new VT_CongVanDi.frm_VT_ThemCongVanDi();
            ThemCongVanDi.Button_Clicked += new EventHandler(frm_Button_Clicked);
            ThemCongVanDi.ShowDialog();
        }

        private void bSua_Click(object sender, EventArgs e)
        {
            if (ThamSoHeThong.Quyen("frm_CongVanDi_TK", "sExport") == false)
                return;
            ExportToXLS XLS = new ExportToXLS();
            XLS.ToPDF(grvCongVan);
        }

        private void bXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (ThamSoHeThong.Quyen("frm_CongVanDi_TK", "sDelete") == false)
                    return;
                string Name = grvCongVan.GetRowCellValue(grvCongVan.FocusedRowHandle, colKyhieu).ToString();
                decimal ID = Convert.ToDecimal(grvCongVan.GetRowCellValue(grvCongVan.FocusedRowHandle, "ID").ToString());
                DialogResult result = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thật sự muốn xóa công văn ký hiệu " + Name + "  ?" + Environment.NewLine + Environment.NewLine + "Chọn \"Có\": xóa công văn và các tập tin công văn." + Environment.NewLine + "Chọn \"Không\": chỉ xóa công văn." + Environment.NewLine + "Chọn \"Hủy\": hủy thao tác xóa.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    CongVan.DELETE_CONGVANDI(ID);
                    string THUMUC = "";
                    string FILE = "";
                    DataTable dt = CongVan.SELECT_FILE_CVDI(ID);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        THUMUC = dt.Rows[i]["THUMUC"].ToString();
                        FILE = dt.Rows[i]["TAPTIN"].ToString();
                        if (File.Exists(ThamSoHeThong.ThuMucTapTin + THUMUC + FILE))
                        {
                            File.Delete(ThamSoHeThong.ThuMucTapTin + THUMUC + FILE);
                        }
                    }
                    grvCongVan.DeleteSelectedRows();
                    CongVan.DELETE_FILE_CVDI(ID);
                    Directory.Delete(ThamSoHeThong.ThuMucTapTin + THUMUC);
                }
                else if (result == DialogResult.No)
                {
                    CongVan.DELETE_CONGVANDI(ID);                    
                    CongVan.DELETE_FILE_CVDI(ID);
                    grvCongVan.DeleteSelectedRows();
                }
            }
            catch { }
        }

        private void bIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ThamSoHeThong.Quyen("frm_CongVanDi_TK", "sPrint") == false)
                    return;
                DataTable dt = new DataTable();
                dt.Columns.Add("MACV", typeof(string));
                dt.Columns.Add("KYHIEU", typeof(string));
                dt.Columns.Add("NGAYKY", typeof(DateTime));
                dt.Columns.Add("NGAYNHAN", typeof(DateTime));
                dt.Columns.Add("ID_LOAIVANBAN", typeof(string));
                dt.Columns.Add("ID_CANBOKY", typeof(string));
                dt.Columns.Add("NOIDUNG", typeof(string));
                dt.Columns.Add("ID_CQNHANCV", typeof(string));
                dt.Columns.Add("TRANGTHAI", typeof(string));
                string MACV;
                string KYHIEU;
                DateTime NGAYKY;
                DateTime NGAYNHAN;
                string ID_LOAIVANBAN;
                string ID_CANBOKY;
                string NOIDUNG;
                string ID_CQNHANCV;
                string TRANGTHAI;
                for (int i = 0; i < grvCongVan.RowCount; i++)
                {
                    MACV = grvCongVan.GetRowCellDisplayText(i, "ID").ToString();
                    KYHIEU = grvCongVan.GetRowCellDisplayText(i, "KYHIEU").ToString();
                    NGAYKY = Convert.ToDateTime(grvCongVan.GetRowCellDisplayText(i, "NGAYKY").ToString());
                    NGAYNHAN = Convert.ToDateTime(grvCongVan.GetRowCellDisplayText(i, "NGAYNHAN").ToString());
                    ID_LOAIVANBAN = grvCongVan.GetRowCellDisplayText(i, "ID_CQBANHANH").ToString();
                    ID_CANBOKY = grvCongVan.GetRowCellDisplayText(i, "ID_CANBOKY").ToString();
                    NOIDUNG = grvCongVan.GetRowCellDisplayText(i, "NOIDUNG").ToString();
                    ID_CQNHANCV = grvCongVan.GetRowCellDisplayText(i, "ID_CQNHANCV").ToString();
                    TRANGTHAI = grvCongVan.GetRowCellDisplayText(i, "GHICHU").ToString();
                    dt.Rows.Add(MACV, KYHIEU, NGAYKY, NGAYNHAN, ID_LOAIVANBAN, ID_CANBOKY, NOIDUNG, ID_CQNHANCV, TRANGTHAI);
                }
                frm_Print_CVDi CongVanDen = new frm_Print_CVDi { DataSource = dt };
                string TieuDe = "SỔ GHI CÔNG VĂN ĐI";
                CongVanDen.CongVanDen.TENCONGVAN = TieuDe;
                CongVanDen.CongVanDen.TUNGAY = dtp1.DateTime;
                CongVanDen.CongVanDen.DENNGAY = dtp2.DateTime;
                CongVanDen.CongVanDen.THOIGIAN = "Từ ngày " + dtp1.DateTime.ToString("dd/MM/yyyy") + " đến ngày " + dtp2.DateTime.ToString("dd/MM/yyyy");
                CongVanDen.ShowDialog();
            }
            catch { }
        }

        private void bXuat_Click(object sender, EventArgs e)
        {
            if (ThamSoHeThong.Quyen("frm_CongVanDi_TK", "sExport") == false)
                return;
            ExportToXLS XLS = new ExportToXLS();
            XLS.ToXLS(grvCongVan);
        }

        private void bMoThuMuc_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = grvCongVan.GetRowCellValue(grvCongVan.FocusedRowHandle, colThumuc).ToString();
                System.Diagnostics.Process.Start(ThamSoHeThong.ThuMucTapTin + Name);
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Không tìm thấy thư mục !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       
        private void grcCongVan_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                decimal ID = Convert.ToDecimal(grvCongVan.GetRowCellValue(grvCongVan.FocusedRowHandle, "ID").ToString());
                VT_CongVanDi.frm_VT_ThemCongVanDi ThemCongVanDi = new VT_CongVanDi.frm_VT_ThemCongVanDi();
                ThemCongVanDi.ID_CongVan = ID;
                ThemCongVanDi.Button_Clicked += new EventHandler(frm_Button_Clicked);
                ThemCongVanDi.ShowDialog();
            }
            catch
            {
            }
        }

        private void cbChon_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            Date.NgayThangNam(cbChon.EditValue.ToString(), dtp1, dtp2);
        }

        private void cbChon_EditValueChanged(object sender, EventArgs e)
        {
            Date.NgayThangNam(cbChon.EditValue.ToString(), dtp1, dtp2);
        }

        private void txtLoaiVB_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            try
            {
                string LoaiVB = txtLoaiVB.EditValue.ToString();
                string CQBH = txtNguoiKy.EditValue.ToString();
                string NoiDung = txtNoidung.Text;
                string ChuoiTim = "";
                if (LoaiVB != "")
                {
                    ChuoiTim = "[ID_LOAIVANBAN] = '" + LoaiVB + "' AND ";
                }
                if (CQBH != "")
                {
                    ChuoiTim += "[ID_CANBOKY] = '" + CQBH + "' AND ";
                }
                if (NoiDung != "")
                {
                    ChuoiTim += "Contains([NOIDUNG],'" + NoiDung + "') AND ";
                }
                if (ChuoiTim.Length > 6)
                {
                    ChuoiTim = ChuoiTim.Remove(ChuoiTim.Length - 5);
                }
                grvCongVan.Columns["ID_LOAIVANBAN"].FilterInfo = new ColumnFilterInfo(ChuoiTim);
            }
            catch
            {
            }
        }

        private void txtNguoiKy_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            try
            {
                string LoaiVB = txtLoaiVB.EditValue.ToString();
                string CQBH = txtNguoiKy.EditValue.ToString();
                string NoiDung = txtNoidung.Text;
                string ChuoiTim = "";
                if (LoaiVB != "")
                {
                    ChuoiTim = "[ID_LOAIVANBAN] = '" + LoaiVB + "' AND ";
                }
                if (CQBH != "")
                {
                    ChuoiTim += "[ID_CANBOKY] = '" + CQBH + "' AND ";
                }
                if (NoiDung != "")
                {
                    ChuoiTim += "Contains([NOIDUNG],'" + NoiDung + "') AND ";
                }
                if (ChuoiTim.Length > 6)
                {
                    ChuoiTim = ChuoiTim.Remove(ChuoiTim.Length - 5);
                }
                grvCongVan.Columns["ID_LOAIVANBAN"].FilterInfo = new ColumnFilterInfo(ChuoiTim);
            }
            catch
            {
            }
        }

        private void txtNoiDung_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string LoaiVB = txtLoaiVB.EditValue.ToString();
                string CQBH = txtNguoiKy.EditValue.ToString();
                string NoiDung = txtNoidung.Text;
                string ChuoiTim = "";
                if (LoaiVB != "")
                {
                    ChuoiTim = "[ID_LOAIVANBAN] = '" + LoaiVB + "' AND ";
                }
                if (CQBH != "")
                {
                    ChuoiTim += "[ID_CANBOKY] = '" + CQBH + "' AND ";
                }
                if (NoiDung != "")
                {
                    ChuoiTim += "Contains([NOIDUNG],'" + NoiDung + "') AND ";
                }
                if (ChuoiTim.Length > 6)
                {
                    ChuoiTim = ChuoiTim.Remove(ChuoiTim.Length - 5);
                }
                grvCongVan.Columns["ID_LOAIVANBAN"].FilterInfo = new ColumnFilterInfo(ChuoiTim);
            }
            catch
            {
            }
        }

        private void frm_VT_CongVanDi_TK_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.Set_View(this.Name, grvCongVan);
        }
    }
}
