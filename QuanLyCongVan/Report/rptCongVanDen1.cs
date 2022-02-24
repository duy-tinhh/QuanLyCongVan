using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace QuanLyCongVan
{
    public partial class rptCongVanDen1 : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCongVanDen1()
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
            dsCongVanDen1.DataCongVan1.Merge(Data);
        }

    }
}
