using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLyCongVan
{
    public partial class frm_Print_Chitiet : DevExpress.XtraEditors.XtraForm
    {
        public frm_Print_Chitiet()
        {
            InitializeComponent();
        }
        public DataTable DataSource{set;get;}
        private Report.rptBienNhanHoSo _CongVanDen = new Report.rptBienNhanHoSo();
        public Report.rptBienNhanHoSo report
        {
            get { return _CongVanDen; }
            set { _CongVanDen = value; }
        }

        private void frm_Print_CVDen_Load(object sender, EventArgs e)
        {
            report.LoadData();
            documentViewer1.PrintingSystem = report.PrintingSystem;
            report.CreateDocument();
        }
    }
}