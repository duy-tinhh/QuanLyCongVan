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

namespace QuanLyCongVan.VT_CongVanDen
{
    public partial class frm_VT_CongVanDen_TK : DevExpress.XtraEditors.XtraForm
    {
        public frm_VT_CongVanDen_TK()
        {
            InitializeComponent();
        }
        Class.csDatetime Date = new Class.csDatetime();
        Class.csCongVanDen CongVan = new Class.csCongVanDen();
        Class.csLookupEdit Lookuptedit = new Class.csLookupEdit();
        Class.ConfigApp Config = new Class.ConfigApp();

        void LoadData()
        {
            try
            {
                DateTime dt1 = dtp1.DateTime;
                DateTime dt2 = dtp2.DateTime.AddDays(1).AddSeconds(-1); 
                if ((ThamSoHeThong.NhomQuyenNV != "QT") && (ThamSoHeThong.NhomQuyenNV != "VT"))
                {
                    grcCongVan.DataSource = CongVan.SELECT_CONGVAN_MANV_TIME(ThamSoHeThong.MaNhanVien, dt1, dt2);
                }
                else
                {
                    grcCongVan.DataSource = CongVan.SELECT_CONGVAN_ADMIN_TIME(dt1, dt2);
                }
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
            DataTable dtCQBH = new DataTable();
            dtCQBH.Columns.Add("ID", typeof(string));
            dtCQBH.Columns.Add("Name", typeof(string));
            dtCQBH.Columns.Add("Description", typeof(string));
            dtCQBH.Columns.Add("Active", typeof(bool));
            dtCQBH.Rows.Add("", "", "", false);
            DataTable dtCQBH2 = Lookuptedit.SELECT_DM_CQBANHANH();
            dtCQBH.Merge(dtCQBH2);
            txtCQBH.Properties.DataSource = dtCQBH;
            txtCQBH.EditValue = "";

            DataTable dtLVB = new DataTable();
            dtLVB.Columns.Add("ID", typeof(string));
            dtLVB.Columns.Add("Name", typeof(string));
            dtLVB.Columns.Add("Description", typeof(string));
            dtLVB.Columns.Add("Active", typeof(bool));
            dtLVB.Rows.Add("", "", "", false);

            DataTable dtLVB2 = Lookuptedit.SELECT_DM_LOAIVANBAN();
            dtLVB.Merge(dtLVB2);
            txtLoaiVB.Properties.DataSource = dtLVB;
            txtLoaiVB.EditValue = "";

            Lookuptedit.ReposLookUpEdit("TRANGTHAI", rpTrangThai, "Name", "ID");
            Lookuptedit.ReposGridLookUpEdit("CANBOKY", rpCanBoXuLy, "Name", "ID");
            Lookuptedit.ReposGridLookUpEdit("LOAIVANBAN", rpLoaiVanBan, "Name", "ID");
            Lookuptedit.ReposGridLookUpEdit("CQBANHANH", rpCQBanHanh, "Name", "ID");
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
            VT_CongVanDen.frm_VT_ThemCongVanDen ThemCongVanDen = new VT_CongVanDen.frm_VT_ThemCongVanDen();
            ThemCongVanDen.Button_Clicked += new EventHandler(frm_Button_Clicked);
            ThemCongVanDen.ShowDialog();
        }

        private void bSua_Click(object sender, EventArgs e)
        {
            try
            {
                decimal ID = Convert.ToDecimal(grvCongVan.GetRowCellValue(grvCongVan.FocusedRowHandle, "ID").ToString());
                CongVan.UPDATE_CONGVANDEN_DUAN_DAXEM(ID, ThamSoHeThong.MaNhanVien);
                grvCongVan.SetRowCellValue(grvCongVan.FocusedRowHandle, "DAXEM", true);
                grvCongVan.RefreshRow(grvCongVan.FocusedRowHandle);
                VT_CongVanDen.frm_VT_ThemCongVanDen ThemCongVanDen = new VT_CongVanDen.frm_VT_ThemCongVanDen();
                ThemCongVanDen.ID_CongVan = ID;
                ThemCongVanDen.Button_Clicked += new EventHandler(frm_Button_Clicked);
                ThemCongVanDen.ShowDialog();
            }
            catch
            {
            }
        }

        private void bXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (ThamSoHeThong.Quyen("frm_CongVanDen_TK", "sDelete") == false)
                    return;
                string Name = grvCongVan.GetRowCellValue(grvCongVan.FocusedRowHandle, colKyhieu).ToString();
                decimal ID = Convert.ToDecimal(grvCongVan.GetRowCellValue(grvCongVan.FocusedRowHandle, "ID").ToString());
                DialogResult result = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thật sự muốn xóa công văn ký hiệu " + Name + "  ?" + Environment.NewLine + Environment.NewLine + "Chọn \"Có\": xóa công văn và các tập tin công văn." + Environment.NewLine + "Chọn \"Không\": chỉ xóa công văn." + Environment.NewLine + "Chọn \"Hủy\": hủy thao tác xóa.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    CongVan.DELETE_CONGVAN_ALL(ID);
                    string THUMUC = "";
                    string FILE = "";
                    DataTable dt = CongVan.SELECT_FILE_CVDEN(ID);
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
                    CongVan.DELETE_FILE_CVDEN(ID);
                    Directory.Delete(ThamSoHeThong.ThuMucTapTin + THUMUC);
                }
                else if (result == DialogResult.No)
                {
                    CongVan.DELETE_CONGVAN_ALL(ID);    
                    CongVan.DELETE_FILE_CVDEN(ID);
                    grvCongVan.DeleteSelectedRows();
                }
            }
            catch { }
        }

        private void bIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ThamSoHeThong.Quyen("frm_CongVanDen_TK", "sPrint") == false)
                    return;
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(decimal));
                dt.Columns.Add("SOCV", typeof(decimal));
                dt.Columns.Add("KYHIEU", typeof(string));
                dt.Columns.Add("NGAYKY", typeof(DateTime));
                dt.Columns.Add("NGAYNHAN", typeof(DateTime));
                dt.Columns.Add("ID_LOAIVANBAN", typeof(string));
                dt.Columns.Add("ID_CQBANHANH", typeof(string));
                dt.Columns.Add("NOIDUNG", typeof(string));
                dt.Columns.Add("ID_CANBOXULY", typeof(string));
                dt.Columns.Add("ID_DVXULY", typeof(string));
                dt.Columns.Add("PHEDUYET", typeof(string));
                decimal ID;
                decimal SOCV;
                string KYHIEU = "";
                DateTime NGAYKY;
                DateTime NGAYNHAN;
                string ID_LOAIVANBAN = "";
                string ID_CQBANHANH = "";
                string NOIDUNG = "";
                string ID_CANBOXULY = "";
                string ID_DVXULY = "";
                string PHEDUYET = "";
                for (int i = 0; i < grvCongVan.RowCount; i++)
                {
                    ID = Convert.ToDecimal(grvCongVan.GetRowCellValue(i, "ID").ToString());
                    SOCV = Convert.ToDecimal(grvCongVan.GetRowCellValue(i, "SOCV").ToString());
                    KYHIEU = grvCongVan.GetRowCellDisplayText(i, "KYHIEU").ToString();
                    NGAYKY = Convert.ToDateTime(grvCongVan.GetRowCellValue(i, "NGAYKY").ToString());
                    NGAYNHAN = Convert.ToDateTime(grvCongVan.GetRowCellValue(i, "NGAYNHAN").ToString());
                    ID_LOAIVANBAN = grvCongVan.GetRowCellDisplayText(i, "ID_LOAIVANBAN").ToString();
                    ID_CQBANHANH = grvCongVan.GetRowCellDisplayText(i, "ID_CQBANHANH").ToString();
                    NOIDUNG = grvCongVan.GetRowCellDisplayText(i, "NOIDUNG").ToString();
                    ID_CANBOXULY = grvCongVan.GetRowCellDisplayText(i, "ID_CANBOXULY").ToString();
                    ID_DVXULY = grvCongVan.GetRowCellDisplayText(i, "ID_DVXULY").ToString();
                    PHEDUYET = grvCongVan.GetRowCellDisplayText(i, "PHEDUYET").ToString();
                    dt.Rows.Add(ID, SOCV, KYHIEU, NGAYKY, NGAYNHAN, ID_LOAIVANBAN, ID_CQBANHANH, NOIDUNG, ID_CANBOXULY, ID_DVXULY, PHEDUYET);
                }
                frm_Print_CVDen CongVanDen = new frm_Print_CVDen();
                CongVanDen.CongVanDen.Data = dt;
                CongVanDen.ShowDialog();
            }
            catch { }
        }

        private void bXuat_Click(object sender, EventArgs e)
        {
            if (ThamSoHeThong.Quyen("frm_CongVanDen_TK", "sExport") == false)
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

        private void bXuatPDF_Click(object sender, EventArgs e)
        {
            if (ThamSoHeThong.Quyen("frm_CongVanDen_TK", "sExport") == false)
                return;
            ExportToXLS XLS = new ExportToXLS();
            XLS.ToPDF(grvCongVan);
        }

        private void txtLoaiVB_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            try
            {
                string LoaiVB = txtLoaiVB.EditValue.ToString();
                string CQBH = txtCQBH.EditValue.ToString();
                string NoiDung = txtNoidung.Text;
                string ChuoiTim = "";
                if (LoaiVB != "")
                {
                    ChuoiTim = "[ID_LOAIVANBAN] = '" + LoaiVB + "' AND ";
                }
                if (CQBH != "")
                {
                    ChuoiTim += "[ID_CQBANHANH] = '" + CQBH + "' AND ";
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

        private void txtCQBH_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            try
            {
                string LoaiVB = txtLoaiVB.EditValue.ToString();
                string CQBH = txtCQBH.EditValue.ToString();
                string NoiDung = txtNoidung.Text;
                string ChuoiTim = "";
                if (LoaiVB != "")
                {
                    ChuoiTim = "[ID_LOAIVANBAN] = '" + LoaiVB + "' AND ";
                }
                if (CQBH != "")
                {
                    ChuoiTim += "[ID_CQBANHANH] = '" + CQBH + "' AND ";
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
        private void txtNoidung_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string LoaiVB = txtLoaiVB.EditValue.ToString();
                string CQBH = txtCQBH.EditValue.ToString();
                string NoiDung = txtNoidung.Text;
                string ChuoiTim = "";
                if (LoaiVB != "")
                {
                    ChuoiTim = "[ID_LOAIVANBAN] = '" + LoaiVB + "' AND ";
                }
                if (CQBH != "")
                {
                    ChuoiTim += "[ID_CQBANHANH] = '" + CQBH + "' AND ";
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

        private void frm_VT_CongVanDen_TK_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.Set_View(this.Name, grvCongVan);
        }
    }
}
