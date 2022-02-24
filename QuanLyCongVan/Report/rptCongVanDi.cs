using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace QuanLyCongVan
{
    public partial class rptCongVanDi : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCongVanDi()
        {
            InitializeComponent();
        }        
        Class.csThongTinDonVi Info = new Class.csThongTinDonVi();
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
            dsCongVanDen1.DataCongVan.Merge(Data);

            var dr = dsCongVanDen1.DataThongTin.NewRow();
            dr["TENCONGVAN"] = TENCONGVAN;
            dr["TUNGAY"] = TUNGAY;
            dr["DENNGAY"] = DENNGAY;
            dr["THOIGIAN"] = THOIGIAN;
            dr["HOMNAY"] = DateTime.Now;
            dsCongVanDen1.DataThongTin.Rows.Add(dr);

            DataTable dt = Info.GetData2();
            dsCongVanDen1.DataCoQuan.Merge(dt);
        }

    }
}
