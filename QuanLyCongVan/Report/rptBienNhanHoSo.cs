using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace QuanLyCongVan.Report
{
    public partial class rptBienNhanHoSo : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBienNhanHoSo()
        {
            InitializeComponent();
        }
        private DataTable data;
        public DataTable Data
        {
            get { return data; }
            set { data = value; }
        }
        public void LoadData()
        {
            dsBNHS1.DataCongVan.Merge(Data);
            Class.csThongTinDonVi Info = new Class.csThongTinDonVi();
            DataTable dt = Info.GetData2();
            dsBNHS1.DataCoQuan.Merge(dt);
        }
    }
}
