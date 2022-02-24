using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;

namespace QuanLyCongVan
{
    public partial class frm_DanhBaCoQuan : DevExpress.XtraEditors.XtraForm
    {
        public frm_DanhBaCoQuan()
        {
            InitializeComponent();
        }
        Class.csDanhBa DanhBa = new Class.csDanhBa();
        Class.csMD5 MD5 = new Class.csMD5();
        public void LoadData()
        {
            gridDoitac.DataSource = DanhBa.SELECT_DANHBACQ();
        }

        private void frm_Doitac_list_Load(object sender, EventArgs e)
        {            
            LoadData();
        }

        private void bIn_Click(object sender, EventArgs e)
        {
            gridView1.ShowRibbonPrintPreview();
        }

        private void bRefesh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void bXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thật sự muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string ID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();
                    DanhBa.DELETE_DBCQ(ID);
                    gridView1.DeleteSelectedRows();
                }
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Lỗi khi thực hiện !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bSua_Click(object sender, EventArgs e)
        {
            try
            {
                txtMa.Properties.ReadOnly = true;
                txtMa.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();
                txtTenCQ.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN").ToString();
                txtDiachi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DIACHI").ToString();
                txtDienThoai.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DIENTHOAI").ToString();
                txtFax.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FAX").ToString();
                txtEmail.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "EMAIL").ToString();
            }
            catch
            {
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Info.IsRowIndicator)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            bSua_Click(sender, e);
        }

        private void bXuat_Click(object sender, EventArgs e)
        {
            ExportToXLS XLS = new ExportToXLS();
            XLS.ToXLS(gridView1);
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                GridViewMenu menu = e.Menu as GridViewMenu;
                menu.Items.Clear();
                DXMenuItem itemAdd = new DXMenuItem(" Thêm                ");
                itemAdd.Image = imageCollection1.Images["Add.ico"];
                itemAdd.Click += new EventHandler(bNhapMoi_Click);
                menu.Items.Add(itemAdd);
                DXMenuItem itemEdit = new DXMenuItem(" Sửa");
                itemEdit.Image = imageCollection1.Images["Group.ico"];
                itemEdit.Click += new EventHandler(bSua_Click);
                menu.Items.Add(itemEdit);
                DXMenuItem itemDelete = new DXMenuItem(" Xóa");
                itemDelete.Image = imageCollection1.Images["Delete.ico"];
                itemDelete.Click += new EventHandler(bXoa_Click);
                menu.Items.Add(itemDelete);
                DXMenuItem itemReload = new DXMenuItem(" Làm mới");
                itemReload.Image = imageCollection1.Images["Refresh.ico"];
                itemReload.Click += new EventHandler(bRefesh_Click);
                menu.Items.Add(itemReload);
                DXMenuItem itemPrint = new DXMenuItem(" In");
                itemPrint.Image = imageCollection1.Images["Print.ico"];
                itemPrint.Click += new EventHandler(bIn_Click);
                menu.Items.Add(itemPrint);
                DXMenuItem itemExport = new DXMenuItem(" Xuất");
                itemExport.Image = imageCollection1.Images["excel.ico"];
                itemExport.Click += new EventHandler(bXuat_Click);
                menu.Items.Add(itemExport);
            }
        }

        private void bNhapMoi_Click(object sender, EventArgs e)
        {
            bRefesh_Click(sender, e);
            txtMa.Properties.ReadOnly = false;
            txtMa.Text = "";
            txtMa.Focus();
            txtTenCQ.Text = "";
            txtDiachi.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            txtFax.Text = "";
        }

        private void bLuu_Click(object sender, EventArgs e)
        {
            if (txtMa.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập mã !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMa.Focus();
            }
            else if (txtTenCQ.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập tên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenCQ.Focus();
            }
            else
            {
                string ID = txtMa.Text;
                string TEN = txtTenCQ.Text;
                string DIACHI = txtDiachi.Text;
                string COQUAN = "";
                string EMAIL = txtEmail.Text;
                string DIENTHOAI = txtDienThoai.Text;
                string FAX = txtFax.Text;
                string YAHOO = "";
                string SKYPE = "";
                string TAIKHOAN = "";
                string NGANHANG = "";
                if (txtMa.Properties.ReadOnly == false)
                {
                    DanhBa.INSERT_DBCQ(ID, TEN, DIACHI, COQUAN, EMAIL, DIENTHOAI, FAX, YAHOO, SKYPE, TAIKHOAN, NGANHANG);
                }
                else
                {
                    DanhBa.UPDATE_DBCQ(ID, TEN, DIACHI, COQUAN, EMAIL, DIENTHOAI, FAX, YAHOO, SKYPE, TAIKHOAN, NGANHANG);

                }
                bNhapMoi_Click(sender, e);
            }
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            if (txtMa.Properties.ReadOnly == true)
            {
                bLuu.Enabled = true;
                layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                string ID = txtMa.Text;
                DataTable dt = DanhBa.SELECT_DANHBACQ_ID(ID);
                if (dt.Rows.Count > 0)
                {
                    bLuu.Enabled = false;
                    layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    bLuu.Enabled = true;
                    layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
