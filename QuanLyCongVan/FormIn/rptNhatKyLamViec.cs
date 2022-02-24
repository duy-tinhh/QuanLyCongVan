using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace QuanLyCongVan
{
    public partial class rptNhatKyLamViec : DevExpress.XtraReports.UI.XtraReport
    {
        public rptNhatKyLamViec()
        {
            InitializeComponent();
        }
        Class.csThongTinDonVi Info = new Class.csThongTinDonVi();
        Class.csMD5 MD5 = new Class.csMD5();
        private DataTable data;
        public DataTable Data
        {
            get { return data; }
            set { data = value; }
        }
        private string _TENCONGVAN = "";
        public string TENCONGVAN
        {
            get { return _TENCONGVAN; }
            set { _TENCONGVAN = value; }
        }
        private DateTime _TUNGAY;
        public DateTime TUNGAY
        {
            get { return _TUNGAY; }
            set { _TUNGAY = value; }
        }
        private DateTime _DENNGAY;
        public DateTime DENNGAY
        {
            get { return _DENNGAY; }
            set { _DENNGAY = value; }
        }
        private string _THOIGIAN = "";
        public string THOIGIAN
        {
            get { return _THOIGIAN; }
            set { _THOIGIAN = value; }
        }

        public void LoadData()
        {
            dsNhatKyLamViec1.DataCongVan.Merge(Data);

            var dr = dsNhatKyLamViec1.DataThongTin.NewRow();
            dr["TENCONGVAN"] = TENCONGVAN;
            dr["TUNGAY"] = TUNGAY;
            dr["DENNGAY"] = DENNGAY;
            dr["THOIGIAN"] = THOIGIAN;
            dr["HOMNAY"] = DateTime.Now;
            dr["HOTEN"] = ThamSoHeThong.TenNhanVien;
            dsNhatKyLamViec1.DataThongTin.Rows.Add(dr);

            DataTable dt = Info.GetData2();
            var dr1 = dsNhatKyLamViec1.DataCoQuan.NewRow();
            dr1["DONVICHUQUAN"] = dt.Rows[0]["DONVICHUQUAN"].ToString();
            dr1["DONVISUDUNG"] = dt.Rows[0]["DONVISUDUNG"].ToString();
            dr1["DIACHI"] = dt.Rows[0]["DIACHI"].ToString();
            dr1["SODT"] = dt.Rows[0]["SODT"];
            dr1["FAX"] = dt.Rows[0]["FAX"];
            dr1["EMAIL"] = dt.Rows[0]["EMAIL"];
            dr1["WEBSITE"] = dt.Rows[0]["WEBSITE"];
            dr1["TINH"] = dt.Rows[0]["TINH"];
            dr1["GHICHU"] = dt.Rows[0]["GHICHU"];
            dsNhatKyLamViec1.DataCoQuan.Rows.Add(dr1);
        }

    }
}
