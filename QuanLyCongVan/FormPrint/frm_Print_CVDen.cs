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
    public partial class frm_Print_CVDen : DevExpress.XtraEditors.XtraForm
    {
        public frm_Print_CVDen()
        {
            InitializeComponent();
        }
        private rptCongVanDen1 _CongVanDen = new rptCongVanDen1();
        public rptCongVanDen1 CongVanDen
        {
            get { return _CongVanDen; }
            set { _CongVanDen = value; }
        }

        private void frm_Print_CVDen_Load(object sender, EventArgs e)
        {
            CongVanDen.LoadData();
            documentViewer1.PrintingSystem = CongVanDen.PrintingSystem;
            CongVanDen.CreateDocument();
        }
    }
}