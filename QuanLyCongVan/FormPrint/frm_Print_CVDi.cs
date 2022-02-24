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
    public partial class frm_Print_CVDi : DevExpress.XtraEditors.XtraForm
    {
        public frm_Print_CVDi()
        {
            InitializeComponent();
        }
        public DataTable DataSource{set;get;}
        private rptCongVanDi _CongVanDen = new rptCongVanDi();
        public rptCongVanDi CongVanDen
        {
            get { return _CongVanDen; }
            set { _CongVanDen = value; }
        }

        private void frm_Print_CVDen_Load(object sender, EventArgs e)
        {
            CongVanDen.Data = (DataTable)DataSource;
            CongVanDen.LoadData();
            documentViewer1.PrintingSystem = CongVanDen.PrintingSystem;
            CongVanDen.CreateDocument();
        }
    }
}