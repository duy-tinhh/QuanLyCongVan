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
    public partial class frm_DanhBaCaNhan : DevExpress.XtraEditors.XtraForm
    {
        public frm_DanhBaCaNhan()
        {
            InitializeComponent();
        }
        Class.csDanhBa Doitac = new Class.csDanhBa();
        Class.csMD5 MD5 = new Class.csMD5();
        public void LoadData()
        {
            gridDoitac.DataSource = Doitac.GetData(lbUser.Text);
        }
        private void bThem_Click(object sender, EventArgs e)
        {
            LoadData();
            txtMa.Properties.ReadOnly = false;
            txtMa.Text = Doitac.AUTO_ID().ToString();
            txtTen.Text = "";
            txtDiachi.Text = "";
            txtTenCQ.Text = "";
            txtDienthoai.Text = "";
            txtEmail.Text = "";
            txtTaikhoan.Text = "";
            txtFax.Text = "";
            txtNganhang.Text = "";
            txtNickyahoo.Text = "";
            txtNickskype.Text = "";
            txtTen.Focus();
        }

        private void frm_Doitac_list_Load(object sender, EventArgs e)
        {
            txtNgaySinh.DateTime = DateTime.Now;
            txtMa.Text = Doitac.AUTO_ID().ToString();
            string USER_ID = "";
            XmlTextReader reader = new XmlTextReader("AccountLogin.xml");
            XmlNodeType type;
            while (reader.Read())
            {
                type = reader.NodeType;
                if (type == XmlNodeType.Element)
                {
                    if (reader.Name == "User")
                    {
                        reader.Read();
                        USER_ID = MD5.GMMD5(reader.Value);
                    }
                }
            }
            reader.Close();
            lbUser.Text = USER_ID;
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
                    Doitac.DELETE_DB(ID);
                    gridView1.DeleteSelectedRows();
                    bThem_Click(sender, e);
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
                txtTen.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN").ToString();
                txtTenCQ.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "COQUAN").ToString();
                txtDiachi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DIACHI").ToString();
                txtDienthoai.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DIENTHOAI").ToString();
                txtFax.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FAX").ToString();
                txtEmail.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "EMAIL").ToString();
                txtNickyahoo.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YAHOO").ToString();
                txtNickskype.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SKYPE").ToString();
                txtTaikhoan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TAIKHOAN").ToString();
                txtNganhang.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGANHANG").ToString();
                txtNgaySinh.DateTime = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAYSINH").ToString());
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
                itemAdd.Click += new EventHandler(bThem_Click);
                menu.Items.Add(itemAdd);
                DXMenuItem itemEdit = new DXMenuItem(" Sửa");
                itemEdit.Image = imageCollection1.Images["Group.ico"];
                itemEdit.Click += new EventHandler(bSua_Click);
                menu.Items.Add(itemEdit);
                DXMenuItem itemDelete = new DXMenuItem(" Xóa");
                itemDelete.Image = imageCollection1.Images["Delete.ico"];
                itemDelete.Click += new EventHandler(bXoa_Click);
                menu.Items.Add(itemDelete);
                DXMenuItem itemReload = new DXMenuItem(" Refesh");
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
        private void bLuu_Click(object sender, EventArgs e)
        {
            if (txtMa.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập mã !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMa.Focus();
            }
            else if (txtTen.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập tên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenCQ.Focus();
            }
            else
            {
                string ID = txtMa.Text;
                string TEN = txtTen.Text;
                string DIACHI = txtDiachi.Text;
                string COQUAN = txtTenCQ.Text;
                string EMAIL = txtEmail.Text;
                string DIENTHOAI = txtDienthoai.Text;
                string FAX = txtFax.Text;
                string YAHOO = txtNickyahoo.Text;
                string SKYPE = txtNickskype.Text;
                string TAIKHOAN = txtTaikhoan.Text;
                string NGANHANG = txtNganhang.Text;
                string USER_ID = lbUser.Text;
                DateTime NGAYSINH = txtNgaySinh.DateTime;
                if(txtMa.Properties.ReadOnly == false)
                {
                    Doitac.INSERT_DB(ID, TEN, DIACHI, COQUAN, EMAIL, DIENTHOAI, FAX, YAHOO, SKYPE, TAIKHOAN, NGANHANG, USER_ID, NGAYSINH);
                }
                else
                {
                    Doitac.UPDATE_DB(ID, TEN, DIACHI, COQUAN, EMAIL, DIENTHOAI, FAX, YAHOO, SKYPE, TAIKHOAN, NGANHANG, USER_ID, NGAYSINH);
                }
                bThem_Click(sender, e);
            }
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNgaySinh_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
