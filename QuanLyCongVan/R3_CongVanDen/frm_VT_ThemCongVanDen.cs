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

namespace QuanLyCongVan.VT_CongVanDen
{
    public partial class frm_VT_ThemCongVanDen : DevExpress.XtraEditors.XtraForm
    {
        public frm_VT_ThemCongVanDen()
        {
            InitializeComponent();
        }

        Class.csDatetime Date = new Class.csDatetime();
        Class.csCongVanDen CongVan = new Class.csCongVanDen();
        Class.csCanBoXuLy CanBoXuLy = new Class.csCanBoXuLy();
        Class.csLookupEdit Lookuptedit = new Class.csLookupEdit();
        Class.csViTriLuu ViTriLuu = new Class.csViTriLuu();
        Class.csMD5 MD5 = new Class.csMD5();   

        public event EventHandler Button_Clicked;
        private decimal _ID_CongVan = 0;
        public decimal ID_CongVan
        {
            get { return _ID_CongVan; }
            set { _ID_CongVan = value; }
        }

        //Biến lưu lại người tạo công văn đầu tiên
        string MANV_TAOCV = "";
        string TENNV_TAOCV = "";
        DateTime NGAYTAO_TAOCV;

        public void frm_Button_Clicked(object sender, EventArgs e)
        {
            LoadDataCQBanHanh();
        }
        private void LoadDA()
        {
            try
            {
                Lookuptedit.LookupEdit("THBAOQUAN", txtTHBaoQuan, "Name", "ID");
                Lookuptedit.LookupEdit("TRANGTHAI", txtTrangThai, "Name", "ID");
                txtTHBaoQuan.EditValue = "1";
                txtTrangThai.EditValue = "1";

                DataTable dt = ViTriLuu.SELECT_VITRILUU();
                txtViTriLuu.Properties.DataSource = dt;
                txtViTriLuu.Properties.DisplayMember = "Name";
                txtViTriLuu.Properties.ValueMember = "ID";
                txtViTriLuu.EditValue = dt.Rows[0]["ID"].ToString();
            }
            catch
            {
            }
        }

        public void DSNVXL()
        {
            DataTable dtData1 = new DataTable();
            dtData1.Columns.Add("MANV", typeof(string));
            dtData1.Columns.Add("TENNV", typeof(string));
            dtData1.Columns.Add("DAXEM", typeof(bool));
            dtData1.Columns.Add("NGAYXEM", typeof(DateTime));
            dtData1.Columns.Add("EMAIL", typeof(string));
            dtData1.Columns.Add("SENDMAIL", typeof(bool));
            grcData1.DataSource = dtData1;
            grcData2.DataSource = CanBoXuLy.SELECT_CANBOXULY();
            grvData2.BestFitColumns();
        }
        public void DSTAPTIN()
        {
            DataTable dtData2 = new DataTable();
            dtData2.Columns.Add("ID", typeof(string));
            dtData2.Columns.Add("MACV", typeof(decimal));
            dtData2.Columns.Add("LOAIFILE", typeof(string));
            dtData2.Columns.Add("THUMUC", typeof(string));
            dtData2.Columns.Add("TAPTIN", typeof(string));
            gridControl1.DataSource = dtData2;
            DataTable dtData3 = new DataTable();
            dtData3.Columns.Add("ID", typeof(string));
            dtData3.Columns.Add("MACV", typeof(decimal));
            dtData3.Columns.Add("LOAIFILE", typeof(string));
            dtData3.Columns.Add("THUMUC", typeof(string));
            dtData3.Columns.Add("TAPTIN", typeof(string));
            gridControl2.DataSource = dtData3;
            DataTable dtData4 = new DataTable();
            dtData4.Columns.Add("ID", typeof(string));
            dtData4.Columns.Add("MACV", typeof(decimal));
            dtData4.Columns.Add("LOAIFILE", typeof(string));
            dtData4.Columns.Add("THUMUC", typeof(string));
            dtData4.Columns.Add("TAPTIN", typeof(string));
            gridControl3.DataSource = dtData4;
        }
        public void LoadDataCQBanHanh()
        {
            DSNVXL();
            DSTAPTIN();
            Lookuptedit.LookupEdit("CANBOKY", txtNguoiDuyet, "Name", "ID");
            Lookuptedit.GridLookupEdit("CQBANHANH", txtCQBanHanh, "Name", "ID");
            Lookuptedit.GridLookupEdit("LOAIVANBAN", txtLoaiVanBan, "Name", "ID");
        }
        private void frm_ThemCongVanDen_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDA();
                LoadDataCQBanHanh();
                //Kiểm tra mã công văn
                if (ID_CongVan == 0)
                {
                    txtMaCV.Value = CongVan.AUTO_ID();
                    dtpNgayKy.DateTime = DateTime.Now;
                    dtpNgayNhan.DateTime = DateTime.Now;
                    txtNgayXuLy.DateTime = DateTime.Now;
                    txtBatDau.DateTime = DateTime.Now;
                    NGAYTAO_TAOCV = DateTime.Now;
                    txtMaCV.Focus();
                }
                else
                {
                    txtMaCV.Properties.ReadOnly = true;
                    txtMaCV.Value = ID_CongVan;
                    DataTable dt = CongVan.SELECT_CONGVANDEN(ID_CongVan); 
                    if (dt.Rows.Count > 0)
                    {
                        txtKyHieu.Text = dt.Rows[0]["KYHIEU"].ToString();
                        txtSoCV.EditValue = dt.Rows[0]["SOCV"].ToString();
                        txtLoaiVanBan.EditValue = dt.Rows[0]["ID_LOAIVANBAN"].ToString();
                        txtCQBanHanh.EditValue = dt.Rows[0]["ID_CQBANHANH"].ToString();
                        dtpNgayKy.DateTime = Convert.ToDateTime(dt.Rows[0]["NGAYKY"].ToString());
                        dtpNgayNhan.DateTime = Convert.ToDateTime(dt.Rows[0]["NGAYNHAN"].ToString());
                        txtNoiDung.Text = dt.Rows[0]["NOIDUNG"].ToString();
                        txtTienDo.Text = dt.Rows[0]["TIENDO"].ToString();
                        txtTrangThai.EditValue = dt.Rows[0]["TRANGTHAI"].ToString();
                        txtGhiChu.Text = dt.Rows[0]["GHICHU"].ToString();
                        txtSoBan.Value = Convert.ToDecimal(dt.Rows[0]["SOBAN"].ToString());
                        txtViTriLuu.EditValue = dt.Rows[0]["VITRILUU"].ToString();
                        txtTHBaoQuan.EditValue = dt.Rows[0]["THBAOQUAN"].ToString();
                        txtBatDau.DateTime = Convert.ToDateTime(dt.Rows[0]["BATDAU"].ToString());
                        txtKetThuc.Text = dt.Rows[0]["KETTHUC"].ToString();
                        txtNgayXuLy.DateTime = Convert.ToDateTime(dt.Rows[0]["NGAYHETHAN"].ToString());//
                        txtNguoiDuyet.EditValue = dt.Rows[0]["ID_CANBOXULY"].ToString();
                        txtPheduyet.Text = dt.Rows[0]["PHEDUYET"].ToString();
                        MANV_TAOCV = dt.Rows[0]["MANV"].ToString();
                        TENNV_TAOCV = dt.Rows[0]["TENNV"].ToString();
                        NGAYTAO_TAOCV = Convert.ToDateTime(dt.Rows[0]["NGAYXEM"].ToString());
                        //txtSoBanSao.Value = Convert.ToDecimal(dt.Rows[0]["BANSAO"].ToString());
                        txtDoMat.Text = dt.Rows[0]["DOMAT"].ToString();

                        gridControl1.DataSource = CongVan.SELECT_FILE_CVDEN(ID_CongVan, "DI");
                        gridControl2.DataSource = CongVan.SELECT_FILE_CVDEN(ID_CongVan, "VE");
                        gridControl3.DataSource = CongVan.SELECT_FILE_CVDEN(ID_CongVan, "PD");
                        grcData1.DataSource = CongVan.SELECT_CONGVANDEN_DUAN_NHANVIENXULY(ID_CongVan);
                        grcData2.DataSource = CongVan.SELECT_CONGVANDEN_DUAN_NHANVIENXULY_NULL(ID_CongVan);
                        grvData1.BestFitColumns();
                        grvData2.BestFitColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Thực hiện thất bại !" + Environment.NewLine + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtMaCV.Properties.ReadOnly == false) && (ThamSoHeThong.Quyen("frm_CongVanDen_DS", "sAdd") == false))
                    return;
                if ((txtMaCV.Properties.ReadOnly == true) && (ThamSoHeThong.Quyen("frm_CongVanDen_DS", "sEdit") == false))
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
                else if (txtLoaiVanBan.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng điền loại công văn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtCQBanHanh.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng điền cơ quan ban hành công văn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtNguoiDuyet.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng chọn người duyệt !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    decimal ID = txtMaCV.Value;
                    decimal SOCV = txtSoCV.Value;
                    string KYHIEU = txtKyHieu.Text;
                    string ID_LOAIVANBAN = txtLoaiVanBan.EditValue.ToString();
                    string ID_CQBANHANH = txtCQBanHanh.EditValue.ToString();
                    string ID_CQNHANCV = "";
                    string ID_DVXULY = "";
                    string ID_CANBOKY = "";
                    string ID_CANBOXULY = txtNguoiDuyet.EditValue.ToString();
                    DateTime NGAYKY = dtpNgayKy.DateTime;
                    DateTime NGAYNHAN = dtpNgayNhan.DateTime;
                    string NOIDUNG = txtNoiDung.Text;
                    string TIENDO = txtTienDo.Text;
                    string THUMUC = "\\CongVanDen\\Nam_" + dtpNgayKy.DateTime.Year + "\\" + ID;
                    string PHEDUYET = txtPheduyet.Text;
                    int TRANGTHAI = Convert.ToInt16(txtTrangThai.EditValue.ToString());
                    DateTime NGAYHETHAN = txtNgayXuLy.DateTime;
                    string GHICHU = txtGhiChu.Text;
                    int SOBAN = Convert.ToInt16(txtSoBan.Value);
                    string DUAN = "";
                    string VITRILUU = txtViTriLuu.EditValue.ToString();
                    string THBAOQUAN = txtTHBaoQuan.EditValue.ToString();
                    DateTime BATDAU = txtBatDau.DateTime;
                    string KETTHUC = txtKetThuc.Text;
                    string MANV = MANV_TAOCV;
                    string TENNV = TENNV_TAOCV;
                    string LOAI = "NGUOITAO";
                    bool DAXEM = true;
                    DateTime NGAYXEM = NGAYTAO_TAOCV;
                    int SAPXEP = -1;
                    string MA = System.Guid.NewGuid().ToString();
                    decimal BANSAO = 0;// txtSoBanSao.Value;
                    string DOMAT = txtDoMat.Text;
                    string EMAIL = "";
                    bool SENDEMAIL = false;

                    //Xóa công văn để lưu mới
                    CongVan.DELETE_CONGVAN(ID);
                    //Lấy số công văn
                    if (txtMaCV.Properties.ReadOnly == false)
                    {
                        MANV = ThamSoHeThong.MaNhanVien;
                        TENNV = ThamSoHeThong.TenNhanVien;
                        NGAYXEM = DateTime.Now;
                        ID = CongVan.AUTO_ID();
                        txtMaCV.Properties.ReadOnly = true;
                        txtMaCV.Value = ID;
                        //Lưu dòng đầu tiên là người tạo công văn
                        CongVan.INSERT_CONGVANDEN(MA, ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, LOAI, DAXEM, NGAYXEM, SAPXEP, BANSAO, DOMAT, EMAIL, SENDEMAIL);
                    }
                    else
                    {
                        CongVan.UPDATE_CONGVANDEN(ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, LOAI, DAXEM, NGAYXEM, SAPXEP, BANSAO, DOMAT, EMAIL, SENDEMAIL);
                    }
                    
                    //Lưu các dòng có nhân viên dc giao xử lý
                    for (int i = 0; i < grvData1.RowCount; i++)
                    {
                        MA = System.Guid.NewGuid().ToString();
                        MANV = grvData1.GetRowCellValue(i, "MANV").ToString();
                        TENNV = grvData1.GetRowCellValue(i, "TENNV").ToString();
                        ID_DVXULY += TENNV + ", ";
                        DAXEM = Convert.ToBoolean(grvData1.GetRowCellValue(i, "DAXEM").ToString());
                        NGAYXEM = Convert.ToDateTime(grvData1.GetRowCellValue(i, "NGAYXEM").ToString());
                        SAPXEP = i; LOAI = "NGUOIXEM";
                        EMAIL = grvData1.GetRowCellValue(i, "EMAIL").ToString();
                        SENDEMAIL = false;//Trang thái gui email
                        CongVan.INSERT_CONGVANDEN(MA, ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, LOAI, DAXEM, NGAYXEM, SAPXEP, BANSAO, DOMAT, EMAIL, SENDEMAIL);
                    }

                    if(ID_DVXULY.Length >2)
                        ID_DVXULY = ID_DVXULY.Substring(0, ID_DVXULY.Length-2);

                    CongVan.UPDATE_CONGVANDEN_ID_DVXULY(ID, ID_DVXULY);
                    //Lưu file
                    LuuFileDatabase(gridView3, "DI");
                    LuuFileDatabase(gridView4, "VE");
                    LuuFileDatabase(gridView5, "PD");

                    //Update lại trạng thái xem, xử lý trường hợp nhân viên tạo cũng là nhân viên xử lý sẽ không group được, sẽ tạo ra 2 dòng công văn
                    CongVan.UPDATE_CONGVANDEN_DUAN_DAXEM(ID, ThamSoHeThong.MaNhanVien);

                    gridControl1.DataSource = CongVan.SELECT_FILE_CVDEN(ID, "DI");
                    gridControl2.DataSource = CongVan.SELECT_FILE_CVDEN(ID, "VE");
                    gridControl3.DataSource = CongVan.SELECT_FILE_CVDEN(ID, "PD");
                    if (this.Button_Clicked != null)
                        this.Button_Clicked(sender, e);
                    DevExpress.XtraEditors.XtraMessageBox.Show("Thực hiện thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor.Current = Cursors.Default;
                }
            }
            catch(Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Thực hiện thất bại !" + Environment.NewLine + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LuuFileDatabase(DevExpress.XtraGrid.Views.Grid.GridView gridView, string LOAICV)
        {
            try
            {
                int Nam = dtpNgayKy.DateTime.Year;
                decimal MACV = txtMaCV.Value;
                string ThuMuc = ThamSoHeThong.ThuMucTapTin + "\\CongVanDen\\Nam_" + Nam + "\\" + MACV.ToString("0") + "\\";
                string ThuMucSave = "\\CongVanDen\\Nam_" + Nam + "\\" + MACV + "\\";
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
                        CongVan.INSERT_FILE_CVDEN(ID, MACV, LOAICV, LOAIFILE, ThuMucSave, TAPTIN, NGAY, GHICHU, FILEBYTE, DUNGLUONG, MD5, NGUOITAO);
                    }
                }
            }
            catch { }
        }

        private void bThem_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaCV.Properties.ReadOnly = false;
                txtMaCV.Value = CongVan.AUTO_ID();
                txtSoCV.Focus();
                dtpNgayKy.DateTime = DateTime.Now;
                dtpNgayNhan.DateTime = DateTime.Now;
                txtNoiDung.Text = "";
                txtTienDo.Text = "";
                txtKyHieu.Text = "";
                txtPheduyet.Text = "";
                txtGhiChu.Text = "";
                DSNVXL();
                DSTAPTIN();
            }
            catch { }
        }

        private void bThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Thêm nhân viên xử lý
        private void bLeft_Click(object sender, EventArgs e)
        {
            try
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
                        var Email = grvData2.GetRowCellValue(i, "Email").ToString();

                        grvData1.SetRowCellValue(rowHandle, "MANV", ID);
                        grvData1.SetRowCellValue(rowHandle, "TENNV", Name);
                        grvData1.SetRowCellValue(rowHandle, "DAXEM", false);
                        grvData1.SetRowCellValue(rowHandle, "NGAYXEM", DateTime.Now);
                        grvData1.SetRowCellValue(rowHandle, "EMAIL", Email);
                        grvData1.SetRowCellValue(rowHandle, "SENDMAIL", false);
                        grvData2.DeleteSelectedRows();
                        grvData1.RefreshData();
                    }
                    grvData1.BestFitColumns();
                }
            }
            catch
            { }
        }
        private void bRight_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData1.RowCount > 0)
                {
                    grvData2.AddNewRow();
                    int i = grvData1.FocusedRowHandle;
                    int rowHandle = grvData2.GetRowHandle(grvData2.DataRowCount);
                    if (grvData2.IsNewItemRow(rowHandle))
                    {
                        var ID = grvData1.GetRowCellValue(i, "MANV").ToString();
                        var Name = grvData1.GetRowCellValue(i, "TENNV").ToString();
                        var Email = grvData1.GetRowCellValue(i, "EMAIL").ToString();
                        grvData2.SetRowCellValue(rowHandle, "ID", ID);
                        grvData2.SetRowCellValue(rowHandle, "Name", Name);
                        grvData2.SetRowCellValue(rowHandle, "Email", Email);
                        grvData1.DeleteSelectedRows();
                        grvData2.RefreshData();
                    }
                    grvData2.BestFitColumns();
                }
            }
            catch
            { }
        }
        private void grcData2_DoubleClick(object sender, EventArgs e)
        {
            if (bLeft.Enabled == true)
            {
                bLeft_Click(sender, e);
            }
        }
        private void grcData1_DoubleClick(object sender, EventArgs e)
        {
            if (bRight.Enabled == true)
            {
                bRight_Click(sender, e);
            }
        }

        public void ThemFile(DevExpress.XtraGrid.Views.Grid.GridView gridView)
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
        public void XoaFile(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc muốn xóa tập tin này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    string ID = gridView.GetRowCellValue(gridView.FocusedRowHandle, "ID").ToString();
                    if (ID != "")
                    {
                        CongVan.DELETE_FILE_CVDEN_ID(ID);
                        gridView.DeleteSelectedRows();
                    }
                }
            }
            catch { }
        }
        public void MoThuMuc(DevExpress.XtraGrid.Views.Grid.GridView gridView)
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
        public void MoTapTin(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            try
            {
                string ID = gridView.GetRowCellValue(gridView.FocusedRowHandle, "ID").ToString();
                string TAPTIN = gridView.GetRowCellValue(gridView.FocusedRowHandle, "TAPTIN").ToString();
                string THUMUC = gridView.GetRowCellValue(gridView.FocusedRowHandle, "THUMUC").ToString();
                if (ID != "")
                {
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
                else
                {
                    System.Diagnostics.Process.Start(THUMUC + TAPTIN);
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

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Info.IsRowIndicator)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
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

        private void txtCQBanHanh_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int index = txtCQBanHanh.Properties.Buttons.IndexOf(e.Button);
            if (index == 1)
            {
                DanhMuc.ucCQBanHanh Loaivb = new DanhMuc.ucCQBanHanh();
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
        
        private void txtMaCV_TextChanged(object sender, EventArgs e)
        {
            if (txtMaCV.Properties.ReadOnly == true)
            {
                bLuu.Enabled = true;
                dxErrorProvider1.SetError(txtMaCV, "");
            }
            else
            {
                decimal ID = txtMaCV.Value;
                DataTable dt = CongVan.SELECT_CONGVANDEN(ID);
                if (dt.Rows.Count > 0)
                {
                    bLuu.Enabled = false;
                    dxErrorProvider1.SetError(txtMaCV, "Mã này đã tồn tại !");
                }
                else
                {
                    bLuu.Enabled = true;
                    dxErrorProvider1.SetError(txtMaCV, "");
                }
            }
        }
        
        private void bIN_Click(object sender, EventArgs e)
        {
            //frm_Print_Chitiet CongVanDen = new frm_Print_Chitiet();
            //CongVanDen.CongVanDen.MaCV = txtMaCV.Text;
            //CongVanDen.CongVanDen.SoCV = txtMaCV.Text;
            //CongVanDen.CongVanDen.NgayKy = dtpNgayKy.DateTime;
            //CongVanDen.CongVanDen.NgayNhan = dtpNgayNhan.DateTime;
            //CongVanDen.CongVanDen.CQBH = txtCQBanHanh.Text;
            //CongVanDen.CongVanDen.Noidung = txtNoiDung.Text;
            //CongVanDen.CongVanDen.Kyhieu = txtKyHieu.Text;
            //CongVanDen.ShowDialog();
        }

        private void bGuiEmail_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtMaCV.Properties.ReadOnly == false)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Thực hiện thao tác lưu trước khi gửi mail !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int Nam = dtpNgayKy.DateTime.Year;
                    string PathZip = "";

                    for (int i = 0; i < gridView3.RowCount; i++)
                    {
                        string ID = gridView3.GetRowCellValue(i, "ID").ToString();
                        string TAPTIN = gridView3.GetRowCellValue(i, "TAPTIN").ToString();
                        string THUMUC = gridView3.GetRowCellValue(i, "THUMUC").ToString();
                        if (ID != "")
                        {
                            if (!Directory.Exists(ThamSoHeThong.ThuMucTapTin + THUMUC))
                            {
                                Directory.CreateDirectory(ThamSoHeThong.ThuMucTapTin + THUMUC);
                            }
                            CongVan.databaseFileRead(ID, ThamSoHeThong.ThuMucTapTin + THUMUC + TAPTIN);
                        }
                    }

                    for (int i = 0; i < gridView4.RowCount; i++)
                    {
                        string ID = gridView4.GetRowCellValue(i, "ID").ToString();
                        string TAPTIN = gridView4.GetRowCellValue(i, "TAPTIN").ToString();
                        string THUMUC = gridView4.GetRowCellValue(i, "THUMUC").ToString();
                        if (ID != "")
                        {
                            if (!Directory.Exists(ThamSoHeThong.ThuMucTapTin + THUMUC))
                            {
                                Directory.CreateDirectory(ThamSoHeThong.ThuMucTapTin + THUMUC);
                            }
                            CongVan.databaseFileRead(ID, ThamSoHeThong.ThuMucTapTin + THUMUC + TAPTIN);
                        }
                    }

                    for (int i = 0; i < gridView5.RowCount; i++)
                    {
                        string ID = gridView5.GetRowCellValue(i, "ID").ToString();
                        string TAPTIN = gridView5.GetRowCellValue(i, "TAPTIN").ToString();
                        string THUMUC = gridView5.GetRowCellValue(i, "THUMUC").ToString();
                        if (ID != "")
                        {
                            if (!Directory.Exists(ThamSoHeThong.ThuMucTapTin + THUMUC))
                            {
                                Directory.CreateDirectory(ThamSoHeThong.ThuMucTapTin + THUMUC);
                            }
                            CongVan.databaseFileRead(ID, ThamSoHeThong.ThuMucTapTin + THUMUC + TAPTIN);
                        }
                    }

                    string Path = ThamSoHeThong.ThuMucTapTin + "\\CongVanDen\\Nam_" + Nam + "\\" + txtMaCV.Text + "\\";
                    if (Directory.Exists(Path))
                    {
                        PathZip = ThamSoHeThong.ThuMucTapTin + "\\CongVanDen\\Nam_" + Nam + "\\" + txtMaCV.Text + ".zip";
                        if (File.Exists(PathZip))
                        {
                            File.Delete(PathZip);
                        }
                        CreateSample(PathZip, Path);
                    }
                    for (int i = 0; i < grvData1.RowCount; i++)
                    {
                        string Email = grvData1.GetRowCellValue(i, "EMAIL").ToString();
                        if (Email != "")
                        {
                            MD5.sendEMailThroughGmail2(Email, txtLoaiVanBan.Text + " " + txtKyHieu.Text.Trim() + " " + txtCQBanHanh.Text.Trim(), txtNoiDung.Text.Trim(), PathZip);
                        }
                    }
                    Cursor.Current = Cursors.Default;
                    DevExpress.XtraEditors.XtraMessageBox.Show("Gửi thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Gửi thất bại !" + Environment.NewLine + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #region///Hàm tạo file nén create zip có pass
        public void CreateSample(string outPathname, string folderName)
        {
            FileStream fsOut = File.Create(outPathname);
            ZipOutputStream zipStream = new ZipOutputStream(fsOut);
            zipStream.SetLevel(3); //0-9,có 9 mức nén, mức 9 là cao nhất
            //zipStream.Password = password;
            int folderOffset = folderName.Length + (folderName.EndsWith("\\") ? 0 : 1);
            CompressFolder(folderName, zipStream, folderOffset);
            zipStream.IsStreamOwner = true;
            zipStream.Close();
            zipStream.Dispose();
        }
        private void CompressFolder(string path, ZipOutputStream zipStream, int folderOffset)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string filename in files)
            {
                FileInfo fi = new FileInfo(filename);
                string entryName = filename.Substring(folderOffset);
                entryName = ZipEntry.CleanName(entryName);
                ZipEntry newEntry = new ZipEntry(entryName);
                newEntry.DateTime = fi.LastWriteTime;
                newEntry.Size = fi.Length;
                zipStream.PutNextEntry(newEntry);
                byte[] buffer = new byte[4096];
                using (FileStream streamReader = File.OpenRead(filename))
                {
                    StreamUtils.Copy(streamReader, zipStream, buffer);
                }
                zipStream.CloseEntry();
            }
            string[] folders = Directory.GetDirectories(path);
            foreach (string folder in folders)
            {
                CompressFolder(folder, zipStream, folderOffset);
            }
        }
        #endregion
    }
}