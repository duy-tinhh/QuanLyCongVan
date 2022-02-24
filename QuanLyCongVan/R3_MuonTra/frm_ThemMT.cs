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

namespace QuanLyCongVan.MuonTra
{
    public partial class frm_ThemMT : DevExpress.XtraEditors.XtraForm
    {
        public frm_ThemMT()
        {
            InitializeComponent();
        }

        Class.csLookupEdit Lookuptedit = new Class.csLookupEdit();
        Class.csMuonTra MuonTra = new Class.csMuonTra();
        
        public event EventHandler Button_Clicked;

        private decimal _MA = 0;
        public decimal MA
        {
            get { return _MA; }
            set { _MA = value; }
        }
        bool TrangThaiLuu = false;
        private void LoadData()
        {
            Lookuptedit.LookupEdit("MUONTRA", txtTrangThai, "Name", "ID");
            Lookuptedit.GridLookupEdit("NHANVIEN", txtNhanVien, "Name", "ID");
            Lookuptedit.GridLookupEdit("NHANVIEN", txtNhanVien1, "Name", "ID");
            txtNhanVien.EditValue = "";
            txtNhanVien1.EditValue = "";
            txtTrangThai.EditValue = "MUON";
            txtNgayMuon.DateTime = DateTime.Now;
            txtNgayTra.DateTime = DateTime.Now;
        }
                        
        private void frm_ThemCongVanDen_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                LoadData();
                if (MA == 0)
                {
                    TrangThaiLuu = false;
                    txtMa.Value = MuonTra.AUTO_ID();
                    txtNhanVien.EditValue = ThamSoHeThong.MaNhanVien;
                }
                else
                {
                    TrangThaiLuu = true;
                    txtMa.Value = MA;
                    DataTable dt = MuonTra.SELECT_MUONTRA_MA(MA);
                    txtMa.Value = Convert.ToDecimal(dt.Rows[0]["MA"].ToString());
                    txtMacv.Text = dt.Rows[0]["MACV"].ToString();
                    txtNoiDung.Text = dt.Rows[0]["NOIDUNG"].ToString();
                    txtNgayMuon.DateTime = Convert.ToDateTime(dt.Rows[0]["NGAYMUON"].ToString());
                    txtNgayTra.DateTime = Convert.ToDateTime(dt.Rows[0]["NGAYTRA"].ToString());
                    txtNhanVien.EditValue = dt.Rows[0]["NGUOIMUON"].ToString();
                    txtNhanVien1.EditValue = dt.Rows[0]["NGUOITRA"].ToString();
                    txtGhichu.Text = dt.Rows[0]["GHICHU"].ToString();
                    txtTrangThai.EditValue = dt.Rows[0]["TRANGTHAI"].ToString();
                    txtNgayCV.DateTime = Convert.ToDateTime(dt.Rows[0]["NGAYCV"].ToString());
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
                if (txtMa.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng điền mã !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMa.Focus();
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    decimal MA = txtMa.Value;
                    string MACV = txtMacv.Text;
                    string NOIDUNG = txtNoiDung.Text;
                    DateTime NGAYMUON = txtNgayMuon.DateTime;
                    DateTime NGAYTRA = txtNgayTra.DateTime;
                    string NGUOIMUON = txtNhanVien.EditValue.ToString();
                    string NGUOITRA = txtNhanVien1.EditValue.ToString();
                    string GHICHU = txtGhichu.Text;
                    string TRANGTHAI = txtTrangThai.EditValue.ToString();
                    DateTime NGAYCV = txtNgayCV.DateTime;
                    if (TrangThaiLuu == false)
                    {
                        MuonTra.INSERT_MUONTRA(MA, MACV, NOIDUNG, NGAYMUON, NGAYTRA, NGUOIMUON, NGUOITRA, GHICHU, TRANGTHAI, NGAYCV);
                        TrangThaiLuu = true;
                    }
                    else
                    {
                        MuonTra.UPDATE_MUONTRA(MA, MACV, NOIDUNG, NGAYMUON, NGAYTRA, NGUOIMUON, NGUOITRA, GHICHU, TRANGTHAI, NGAYCV);
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
            TrangThaiLuu = false;
            txtMa.Value = MuonTra.AUTO_ID();
            txtNoiDung.Text = "";
            txtGhichu.Text = "";
        }        
    }
}