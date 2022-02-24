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
    public partial class frm_Print_NK : DevExpress.XtraEditors.XtraForm
    {
        public frm_Print_NK()
        {
            InitializeComponent();
        }
        public DataTable DataSource{set;get;}
        private rptNhatKyLamViec _NhatKyLamViec = new rptNhatKyLamViec();
        public rptNhatKyLamViec NhatKyLamViec
        {
            get { return _NhatKyLamViec; }
            set { _NhatKyLamViec = value; }
        }

        private void frm_Print_CVDen_Load(object sender, EventArgs e)
        {
            NhatKyLamViec.Data = (DataTable)DataSource;
            NhatKyLamViec.LoadData();
            documentViewer1.PrintingSystem = NhatKyLamViec.PrintingSystem;
            NhatKyLamViec.CreateDocument();
        }
    }
}