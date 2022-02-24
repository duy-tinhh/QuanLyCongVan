using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32;

namespace QuanLyCongVan
{
    public partial class frm_About : DevExpress.XtraEditors.XtraForm
    {
        public frm_About()
        {
            InitializeComponent();
        }

        private void bThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_About_Load(object sender, EventArgs e)
        {
            Class.csMD5 MD5 = new Class.csMD5();
            labelControl5.Text = "Phiên bản: " + MD5.VersionApp();
        }
        
    }
}