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

namespace QuanLyCongVan.VT_CongVanDi
{
    public partial class frm_VT_ThemCongVanDi : DevExpress.XtraEditors.XtraForm
    {
        public frm_VT_ThemCongVanDi()
        {
            InitializeComponent(); 
        }

        Class.csDatetime Date = new Class.csDatetime();
        Class.csCongVanDi CongVan = new Class.csCongVanDi();
        Class.csCQNhanCV CQNhanCV = new Class.csCQNhanCV();
        Class.csLookupEdit Lookuptedit = new Class.csLookupEdit();

        public event EventHandler Button_Clicked;
        private decimal _ID_CongVan = 0;
        public decimal ID_CongVan
        {
            get { return _ID_CongVan; }
            set { _ID_CongVan = value; }
        }

        public void frm_Button_Clicked(object sender, EventArgs e)
        {
            LoadDataCQBanHanh();
        }
        public void DSTAPTIN()
        {
            DataTable dtData2 = new DataTable();
            dtData2.Columns.Add("ID", typeof(int));
            dtData2.Columns.Add("MACV", typeof(decimal));
            dtData2.Columns.Add("LOAIFILE", typeof(string));
            dtData2.Columns.Add("THUMUC", typeof(string));
            dtData2.Columns.Add("TAPTIN", typeof(string));
            gridControl1.DataSource = dtData2;

            DataTable dtData3 = new DataTable();
            dtData3.Columns.Add("ID", typeof(int));
            dtData3.Columns.Add("MACV", typeof(decimal));
            dtData3.Columns.Add("LOAIFILE", typeof(string));
            dtData3.Columns.Add("THUMUC", typeof(string));
            dtData3.Columns.Add("TAPTIN", typeof(string));
            gridControl2.DataSource = dtData3;

            DataTable dtData4 = new DataTable();
            dtData4.Columns.Add("ID", typeof(int));
            dtData4.Columns.Add("MACV", typeof(decimal));
            dtData4.Columns.Add("LOAIFILE", typeof(string));
            dtData4.Columns.Add("THUMUC", typeof(string));
            dtData4.Columns.Add("TAPTIN", typeof(string));
            gridControl3.DataSource = dtData4;
        }
        public void LoadDataCQBanHanh()
        {
            Lookuptedit.GridLookupEdit("LOAIVANBAN", txtLoaiVanBan, "Name", "ID");
            Lookuptedit.GridLookupEdit("CANBOKY", txtCBKy, "Name", "ID");
            grcData2.DataSource = CQNhanCV.SELECT_CQNHANCV();
            DataTable dtData1 = new DataTable();
            dtData1.Columns.Add("ID", typeof(string));
            dtData1.Columns.Add("Name", typeof(string));
            grcData1.DataSource = dtData1;
            DSTAPTIN();
            Lookuptedit.LookupEdit("TRANGTHAI", txtTrangThai, "Name", "ID");
            txtTrangThai.EditValue = "1";
        }
        private void frm_ThemCongVanDen_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataCQBanHanh();
                if (ID_CongVan == 0)
                {
                    dtpNgayKy.DateTime = DateTime.Now;
                    dtpNgayNhan.DateTime = DateTime.Now;
                    dtNgayHetHan.DateTime = DateTime.Now;
                    ckID.Checked = false;
                    txtMaCV.Value = CongVan.AUTO_ID();
                    txtSoCV.Focus();
                }
                else
                {
                    txtMaCV.Properties.ReadOnly = true;
                    txtMaCV.Value = ID_CongVan;
                    ckID.Checked = true;
                    DataTable dt = CongVan.SELECT_CONGVANDI(ID_CongVan);
                    txtKyHieu.Text = dt.Rows[0]["KYHIEU"].ToString();
                    txtSoCV.EditValue = dt.Rows[0]["SOCV"].ToString();
                    txtLoaiVanBan.EditValue = dt.Rows[0]["ID_LOAIVANBAN"].ToString();
                    txtCBKy.EditValue = dt.Rows[0]["ID_CANBOKY"].ToString();
                    dtpNgayKy.EditValue = Convert.ToDateTime(dt.Rows[0]["NGAYKY"].ToString());
                    dtpNgayNhan.EditValue = Convert.ToDateTime(dt.Rows[0]["NGAYNHAN"].ToString());
                    txtNoiDung.Text = dt.Rows[0]["NOIDUNG"].ToString();
                    txtTienDo.Text = dt.Rows[0]["TIENDO"].ToString();
                    txtPheDuyet.Text = dt.Rows[0]["PHEDUYET"].ToString();
                    txtTrangThai.EditValue = dt.Rows[0]["TRANGTHAI"].ToString();
                    dtNgayHetHan.DateTime = Convert.ToDateTime(dt.Rows[0]["NGAYHETHAN"].ToString());
                    txtGhiChu.Text = dt.Rows[0]["GHICHU"].ToString();
                    txtSoBan.EditValue = dt.Rows[0]["SOBAN"].ToString();
                    txtSoBanSao.Value = Convert.ToDecimal(dt.Rows[0]["BANSAO"].ToString());
                    txtDVST.Text = dt.Rows[0]["ID_CQBANHANH"].ToString();
                    txtDoMat.Text = dt.Rows[0]["DOMAT"].ToString();
                    gridControl1.DataSource = CongVan.SELECT_FILE_CVDI(ID_CongVan, "DI");
                    gridControl2.DataSource = CongVan.SELECT_FILE_CVDI(ID_CongVan, "VE");
                    gridControl3.DataSource = CongVan.SELECT_FILE_CVDI(ID_CongVan, "PD");
                    grcData1.DataSource = CongVan.SELECT_CONGVANDI_NHANVIENXULY(ID_CongVan);
                    grcData2.DataSource = CongVan.SELECT_CONGVANDI_NHANVIENXULY_NULL(ID_CongVan);  
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
                if ((txtMaCV.Properties.ReadOnly == false) && (ThamSoHeThong.Quyen("frm_CongVanDi_DS", "sAdd") == false))
                    return;
                if ((txtMaCV.Properties.ReadOnly == true) && (ThamSoHeThong.Quyen("frm_CongVanDi_DS", "sEdit") == false))
                    return;
                if (txtMaCV.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng điền mã công văn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaCV.Focus();
                }
                else if (txtKyHieu.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng điền ký hiệu công văn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKyHieu.Focus();
                }
                else if (txtCBKy.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng điền cán bộ ký công văn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    decimal ID = txtMaCV.Value;
                    decimal SOCV = txtSoCV.Value;
                    string KYHIEU = txtKyHieu.Text;
                    DateTime NGAYKY = dtpNgayKy.DateTime;
                    DateTime NGAYNHAN = dtpNgayNhan.DateTime;
                    string ID_LOAIVANBAN = txtLoaiVanBan.EditValue.ToString();
                    string ID_CQBANHANH = txtDVST.Text;
                    string ID_CQNHANCV = "";
                    string ID_DVXULY = "";
                    string ID_CANBOKY = txtCBKy.EditValue.ToString();
                    string NOIDUNG = txtNoiDung.Text;
                    string THUMUC = "\\CongVanDi\\Nam_" + dtpNgayKy.DateTime.Year + "\\" + ID;
                    string ID_CANBOXULY = txtCBKy.EditValue.ToString();
                    string TIENDO = txtTienDo.Text;
                    string PHEDUYET = txtPheDuyet.Text;
                    int TRANGTHAI = Convert.ToInt16(txtTrangThai.EditValue.ToString());
                    DateTime NGAYHETHAN = dtNgayHetHan.DateTime;
                    string GHICHU = txtGhiChu.Text;
                    int SOBAN = Convert.ToInt16(txtSoBan.Value);
                    string DUAN = "";// txtMaDA.EditValue.ToString();
                    string VITRILUU = "";//txtViTriLuu.EditValue.ToString();
                    string THBAOQUAN = "";//txtTHBaoQuan.EditValue.ToString();
                    DateTime BATDAU = NGAYHETHAN;//txtBatDau.DateTime;
                    string KETTHUC = "";//txtKetThuc.Text;
                    string MANV = "";//MANV_TAOCV;
                    string TENNV = "";//TENNV_TAOCV;
                    string LOAI = "NGUOITAO";
                    bool DAXEM = true;
                    DateTime NGAYXEM = NGAYHETHAN;//NGAYTAO_TAOCV;
                    int SAPXEP = -1;
                    string MA = System.Guid.NewGuid().ToString();
                    decimal BANSAO = txtSoBanSao.Value;
                    string DOMAT = txtDoMat.Text;

                    //Xóa công văn để lưu mới
                    CongVan.DELETE_CONGVANDI(ID);
                    //Lấy số công văn
                    if (txtMaCV.Properties.ReadOnly == false)
                    {
                        MANV = ThamSoHeThong.MaNhanVien;
                        TENNV = ThamSoHeThong.TenNhanVien;
                        NGAYXEM = DateTime.Now;
                        txtMaCV.Properties.ReadOnly = true;
                        ID = CongVan.AUTO_ID();
                        txtMaCV.Value = ID;
                    }
                    for (int i = 0; i < grvData1.RowCount; i++)
                    {
                        string Name = grvData1.GetRowCellValue(i, "Name").ToString();
                        ID_CQNHANCV += Name + ", ";
                    }
                    if (ID_CQNHANCV.Length > 2)
                    {
                        ID_CQNHANCV = ID_CQNHANCV.Remove(ID_CQNHANCV.Length - 2);
                    }
                    //Lưu dòng đầu tiên là người tạo công văn
                    CongVan.INSERT_CONGVANDI(MA, ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, LOAI, DAXEM, NGAYXEM, SAPXEP, BANSAO, DOMAT);
                    //Lưu các dòng có nhân viên dc giao xử lý
                    for (int i = 0; i < grvData1.RowCount; i++)
                    {
                        MA = System.Guid.NewGuid().ToString();
                        MANV = grvData1.GetRowCellValue(i, "ID").ToString();
                        TENNV = grvData1.GetRowCellValue(i, "Name").ToString();
                        DAXEM = true;
                        NGAYXEM = NGAYNHAN;
                        SAPXEP = i; LOAI = "NGUOIXEM";
                        CongVan.INSERT_CONGVANDI(MA, ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, LOAI, DAXEM, NGAYXEM, SAPXEP, BANSAO, DOMAT);
                    }
                    //Lưu file
                    LuuFileDatabase(gridView3, "DI");
                    LuuFileDatabase(gridView4, "VE");
                    LuuFileDatabase(gridView5, "PD");
                    //Update lại trạng thái xem, xử lý trường hợp nhân viên tạo cũng là nhân viên xử lý sẽ không group được, sẽ tạo ra 2 dòng công văn
                    CongVan.UPDATE_CONGVANDI_DAXEM(ID, ThamSoHeThong.MaNhanVien);

                    gridControl1.DataSource = CongVan.SELECT_FILE_CVDI(ID_CongVan, "DI");
                    gridControl2.DataSource = CongVan.SELECT_FILE_CVDI(ID_CongVan, "VE");
                    gridControl3.DataSource = CongVan.SELECT_FILE_CVDI(ID_CongVan, "PD");
                    if (this.Button_Clicked != null)
                        this.Button_Clicked(sender, e);
                    DevExpress.XtraEditors.XtraMessageBox.Show("Thực hiện thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor.Current = Cursors.Default;
                }
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Lưu thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LuuFileDatabase(DevExpress.XtraGrid.Views.Grid.GridView gridView, string LOAICV)
        {
            try
            {
                int Nam = dtpNgayKy.DateTime.Year;
                decimal MACV = txtMaCV.Value;
                string ThuMuc = ThamSoHeThong.ThuMucTapTin + "\\CongVanDi\\Nam_" + Nam + "\\" + MACV.ToString("0") + "\\";
                string ThuMucSave = "\\CongVanDi\\Nam_" + Nam + "\\" + MACV + "\\";
                DateTime NGAY = dtpNgayKy.DateTime;
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    string ID = gridView.GetRowCellValue(i, "ID").ToString();
                    if (ID == "")
                    {
                        ID = System.Guid.NewGuid().ToString();
                        string LOAIFILE = gridView.GetRowCellValue(i, "LOAIFILE").ToString();
                        string THUMUC = gridView.GetRowCellValue(i, "THUMUC").ToString();
                        string TAPTIN = gridView.GetRowCellValue(i, "TAPTIN").ToString();
                        string GHICHU = "";
                        byte[] FILEBYTE;
                        string DUNGLUONG = "";
                        string MD5 = "";
                        string NGUOITAO = ThamSoHeThong.MaNhanVien;
                        using (var stream = new FileStream(THUMUC + "\\" + TAPTIN, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = new BinaryReader(stream))
                            {
                                FILEBYTE = reader.ReadBytes((int)stream.Length);
                            }
                        }
                        CongVan.INSERT_FILE_CVDI(ID, MACV, LOAICV, LOAIFILE, ThuMucSave, TAPTIN, NGAY, GHICHU, FILEBYTE, DUNGLUONG, MD5, NGUOITAO);
                    }
                }
            }
            catch { }
        }

        private void bXoa_Click(object sender, EventArgs e)
        {
            ckID.Checked = false;
            txtMaCV.Value = CongVan.AUTO_ID();
            txtKyHieu.Text = "";
            txtKyHieu.Focus();
            dtpNgayKy.DateTime = DateTime.Now;
            dtpNgayNhan.DateTime = DateTime.Now;
            txtNoiDung.Text = "";
            txtTienDo.Text = "";
            txtSoBan.Value = 0;
            grcData2.DataSource = CQNhanCV.SELECT_CQNHANCV();
            DataTable dtData1 = new DataTable();
            dtData1.Columns.Add("ID", typeof(string));
            dtData1.Columns.Add("Name", typeof(string));
            grcData1.DataSource = dtData1;
            DSTAPTIN();
        }

        private void bThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bLeft_Click(object sender, EventArgs e)
        {
            try
            {
                if (bLeft.Enabled == true)
                {
                    if (grvData2.RowCount > 0)
                    {
                        grvData1.AddNewRow();
                        int i = grvData2.FocusedRowHandle;
                        int rowHandle = grvData1.GetRowHandle(grvData1.DataRowCount);
                        if (grvData1.IsNewItemRow(rowHandle))
                        {
                            var ID = grvData2.GetRowCellValue(i, "ID").ToString();
                            var Name = grvData2.GetRowCellValue(i, "Name").ToString();
                            grvData1.SetRowCellValue(rowHandle, "ID", ID);
                            grvData1.SetRowCellValue(rowHandle, "Name", Name);
                            grvData1.SetRowCellValue(rowHandle, "DAXEM", 0);
                            grvData2.DeleteSelectedRows();
                            grvData1.RefreshData();
                        }
                    }
                }
            }
            catch
            { }
        }

        private void bRight_Click(object sender, EventArgs e)
        {
            try
            {
                if (bRight.Enabled == true)
                {
                    if (grvData1.RowCount > 0)
                    {
                        grvData2.AddNewRow();
                        int i = grvData1.FocusedRowHandle;
                        int rowHandle = grvData2.GetRowHandle(grvData2.DataRowCount);
                        if (grvData2.IsNewItemRow(rowHandle))
                        {
                            var ID = grvData1.GetRowCellValue(i, "ID").ToString();
                            var Name = grvData1.GetRowCellValue(i, "Name").ToString();
                            grvData2.SetRowCellValue(rowHandle, "ID", ID);
                            grvData2.SetRowCellValue(rowHandle, "Name", Name);
                            grvData1.DeleteSelectedRows();
                            grvData2.RefreshData();
                        }
                    }
                }
            }
            catch
            { }
        }

        private void grcData1_DoubleClick(object sender, EventArgs e)
        {
            bRight_Click(sender, e);
        }
        private void grcData2_DoubleClick(object sender, EventArgs e)
        {
            bLeft_Click(sender, e);
        }

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Info.IsRowIndicator)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void ThemFile(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            try
            {
                OpenFileDialog save = new OpenFileDialog();
                if (save.ShowDialog() == DialogResult.OK)
                {
                    gridView.AddNewRow();
                    int rowHandle = gridView.GetRowHandle(gridView.DataRowCount);
                    if (gridView.IsNewItemRow(rowHandle))
                    {
                        string FileName = save.FileName;
                        string[] fileParts = FileName.Split('\\');
                        string File = fileParts[fileParts.Length - 1];
                        string Folder = FileName.Replace(File, "");
                        string[] LoaiFileID = FileName.Split('.');
                        string LOAIFILE = LoaiFileID[LoaiFileID.Length - 1];
                        gridView.SetRowCellValue(rowHandle, "THUMUC", Folder);
                        gridView.SetRowCellValue(rowHandle, "TAPTIN", File);
                        gridView.SetRowCellValue(rowHandle, "MACV", 0);
                        gridView.SetRowCellValue(rowHandle, "LOAIFILE", LOAIFILE);
                        gridView.RefreshData();
                    }
                }
            }
            catch
            {
            }
        }
        private void XoaFile(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc muốn xóa tập tin này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    string ID = gridView.GetRowCellValue(gridView.FocusedRowHandle, "ID").ToString();
                    if (ID != "")
                    {
                        CongVan.DELETE_FILE_CVDI_ID(ID);
                        gridView.DeleteSelectedRows();
                    }
                }
            }
            catch { }
        }
        private void MoThuMuc(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            try
            {
                if (txtMaCV.Value == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập mã công văn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //Lưu rồi thì mở thư mục tạm trên máy con
                    string THUMUC = gridView.GetRowCellValue(gridView.FocusedRowHandle, "THUMUC").ToString();
                    if (!Directory.Exists(ThamSoHeThong.ThuMucTapTin + THUMUC))
                    {
                        Directory.CreateDirectory(ThamSoHeThong.ThuMucTapTin + THUMUC);
                    }
                    System.Diagnostics.Process.Start(ThamSoHeThong.ThuMucTapTin + THUMUC);
                }
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Thực hiện thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void MoTapTin(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            try
            {
                string ID = gridView.GetRowCellValue(gridView.FocusedRowHandle, "ID").ToString();
                string TAPTIN = gridView.GetRowCellValue(gridView.FocusedRowHandle, "TAPTIN").ToString();
                string THUMUC = gridView.GetRowCellValue(gridView.FocusedRowHandle, "THUMUC").ToString();
                if (!Directory.Exists(ThamSoHeThong.ThuMucTapTin + THUMUC))
                {
                    Directory.CreateDirectory(ThamSoHeThong.ThuMucTapTin + THUMUC);
                }
                CongVan.databaseFileRead(ID, ThamSoHeThong.ThuMucTapTin + THUMUC + TAPTIN);
                if (File.Exists(ThamSoHeThong.ThuMucTapTin + THUMUC + TAPTIN))
                {
                    System.Diagnostics.Process.Start(ThamSoHeThong.ThuMucTapTin + THUMUC + TAPTIN);
                }
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Thực hiện thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void bbAddFile_Click(object sender, EventArgs e)
        {
            ThemFile(gridView3);
        }
        private void bbDelete_Click(object sender, EventArgs e)
        {
            XoaFile(gridView3);
        }
        private void bbOpenFolder_Click(object sender, EventArgs e)
        {
            MoThuMuc(gridView3);
        }
        private void bbOpenFile_Click(object sender, EventArgs e)
        {
            MoTapTin(gridView3);
        }


        private void bThemXL_Click(object sender, EventArgs e)
        {
            ThemFile(gridView4);
        }
        private void bXoaXL_Click(object sender, EventArgs e)
        {
            XoaFile(gridView4);
        }
        private void bMoThuMucXL_Click(object sender, EventArgs e)
        {
            MoThuMuc(gridView4);
        }
        private void bMoFileXL_Click(object sender, EventArgs e)
        {
            MoTapTin(gridView4);
        }


        private void bAddPD_Click(object sender, EventArgs e)
        {
            ThemFile(gridView5);
        }
        private void bDelPD_Click(object sender, EventArgs e)
        {
            XoaFile(gridView5);
        }
        private void bFolderPD_Click(object sender, EventArgs e)
        {
            MoThuMuc(gridView5);
        }
        private void bFilePD_Click(object sender, EventArgs e)
        {
            MoTapTin(gridView5);
        }


        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            MoTapTin(gridView3);
        }
        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            MoTapTin(gridView4);
        }
        private void gridControl3_DoubleClick(object sender, EventArgs e)
        {
            MoTapTin(gridView5);
        }



        private void bThemDV_Click(object sender, EventArgs e)
        {
            DanhMuc.ucCQNhanCV CoQuan = new DanhMuc.ucCQNhanCV();
            CoQuan.FormBorderStyle = FormBorderStyle.FixedDialog;
            CoQuan.StartPosition = FormStartPosition.CenterScreen;
            CoQuan.Button_Clicked += new EventHandler(frm_Button_Clicked);
            CoQuan.Width = 325;
            CoQuan.Height = 190;
            CoQuan.MaximizeBox = false;
            CoQuan.MinimizeBox = false;
            CoQuan.Trangthai = true;
            CoQuan.ShowDialog();
        }

        private void txtLoaiVanBan_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int index = txtLoaiVanBan.Properties.Buttons.IndexOf(e.Button);
            if (index == 1)
            {
                DanhMuc.ucLoaiVanban Loaivb = new DanhMuc.ucLoaiVanban();
                Loaivb.Button_Clicked += new EventHandler(frm_Button_Clicked);
                Loaivb.FormBorderStyle = FormBorderStyle.FixedDialog;
                Loaivb.StartPosition = FormStartPosition.CenterScreen;
                Loaivb.Width = 330;
                Loaivb.Height = 190;
                Loaivb.MaximizeBox = false;
                Loaivb.MinimizeBox = false;
                Loaivb.Trangthai = true;
                Loaivb.ShowDialog();
            }
        }

        private void txtCBKy_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int index = txtCBKy.Properties.Buttons.IndexOf(e.Button);
            if (index == 1)
            {
                DanhMuc.ucCanBoKy Loaivb = new DanhMuc.ucCanBoKy();
                Loaivb.Button_Clicked += new EventHandler(frm_Button_Clicked);
                Loaivb.FormBorderStyle = FormBorderStyle.FixedDialog;
                Loaivb.StartPosition = FormStartPosition.CenterScreen;
                Loaivb.Width = 325;
                Loaivb.Height = 190;
                Loaivb.MaximizeBox = false;
                Loaivb.MinimizeBox = false;
                Loaivb.Trangthai = true;
                Loaivb.ShowDialog();
            }
        }

    }
}