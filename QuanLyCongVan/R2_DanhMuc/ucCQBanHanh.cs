using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;
using System.IO;

namespace QuanLyCongVan.DanhMuc
{
    public partial class ucCQBanHanh : DevExpress.XtraEditors.XtraForm
    {
        public ucCQBanHanh()
        {
            InitializeComponent();
        }
        public event EventHandler Button_Clicked;
        private bool _trangthai = false;
        public bool Trangthai
        {
            get { return _trangthai; }
            set { _trangthai = value; }
        }
        Class.csCQBanHanh CongVan = new Class.csCQBanHanh();
        void Refesh()
        {
            try
            {
                grcData.DataSource = CongVan.SELECT_CQBANHANH();
            }
            catch
            {
            }
        }

        private void ucLoaiVanban_Load(object sender, EventArgs e)
        {
            if (Trangthai == true)
            {
                bXoa.Text = "Đóng";
            }
            Refesh();
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            if (txtMa.Properties.ReadOnly == true)
            {
                bLuu.Enabled = true;
                layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                string ID = txtMa.Text;
                bool TrangThai = CongVan.SELECT_CQBANHANH_ID(ID);
                if (TrangThai == true)
                {
                    bLuu.Enabled = false;
                    layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    bLuu.Enabled = true;
                    layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
            }
        }

        private void grvData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Info.IsRowIndicator)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btLammoi_Click(object sender, EventArgs e)
        {
            Refesh();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            txtMa.Properties.ReadOnly = false;
            txtMa.Text = "";
            txtTen.Text = "";
            txtGhichu.Text = "";
            ckTrangthai.Checked = true;
            txtMa.Focus();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (ThamSoHeThong.Quyen("ucCQBanHanh", "sDelete") == false)
                    return;
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thật sự muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string ID = grvData.GetRowCellValue(grvData.FocusedRowHandle, colID).ToString();
                    if (CongVan.CHECK_CQBANHANH(ID, "CONGVANDEN") == true)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Thông tin đã sử dụng không thể xoá !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (CongVan.CHECK_CQBANHANH(ID, "CONGVANDI") == true)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Thông tin đã sử dụng không thể xoá !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        CongVan.DELETE_CQBANHANH(ID);
                        Refesh();
                    }
                }
            }
            catch { }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                txtMa.Properties.ReadOnly = true;
                txtMa.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, colID).ToString();
                txtTen.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, colName).ToString();
                txtGhichu.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, colDescription).ToString();
                ckTrangthai.Checked = Convert.ToBoolean(grvData.GetRowCellValue(grvData.FocusedRowHandle, colTrangthai).ToString());
            }
            catch
            { }
        }

        private void btIn_Click(object sender, EventArgs e)
        {
            if (ThamSoHeThong.Quyen("ucCQBanHanh", "sPrint") == false)
                return;
            grvData.ShowRibbonPrintPreview();
        }

        private void btXuat_Click(object sender, EventArgs e)
        {
            if (ThamSoHeThong.Quyen("ucCQBanHanh", "sExport") == false)
                return;
            ExportToXLS XLS = new ExportToXLS();
            XLS.ToXLS(grvData);
        }

        private void bLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtMa.Properties.ReadOnly == false) && (ThamSoHeThong.Quyen("ucCQBanHanh", "sAdd") == false))
                    return;
                if ((txtMa.Properties.ReadOnly == true) && (ThamSoHeThong.Quyen("ucCQBanHanh", "sEdit") == false))
                    return;
                if (txtMa.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập mã !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMa.Focus();
                }
                else if (txtTen.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập tên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                }
                else
                {
                    string ID = txtMa.Text;
                    string Name = txtTen.Text;
                    string Description = txtGhichu.Text;
                    bool Active = ckTrangthai.Checked;
                    if (txtMa.Properties.ReadOnly == false)
                    {
                        CongVan.INSERT_CQBANHANH(ID, Name, Description, Active);
                    }
                    else
                    {
                        CongVan.UPDATE_CQBANHANH(ID, Name, Description, Active);

                    }
                    Refesh();
                    bXoa_Click(sender, e);
                    if (this.Button_Clicked != null)
                        this.Button_Clicked(sender, e);
                }
            }
            catch
            {
            }
        }

        private void bXoa_Click(object sender, EventArgs e)
        {
            if (bXoa.Text != "Đóng")
            {
                txtMa.Properties.ReadOnly = false;
                txtMa.Text = "";
                txtTen.Text = "";
                txtGhichu.Text = "";
                ckTrangthai.Checked = true;
                txtMa.Focus();
            }
            else
            {
                this.Close();
            }
        }

        private void grvData_Click(object sender, EventArgs e)
        {
            btSua_Click(sender, e);
        }

        private void grvData_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                GridViewMenu menu = e.Menu as GridViewMenu;
                menu.Items.Clear();
                DXMenuItem itemAdd = new DXMenuItem(" Thêm                ");
                itemAdd.Image = imageCollection1.Images["Add.ico"];
                itemAdd.Click += new EventHandler(btThem_Click);
                menu.Items.Add(itemAdd);
                DXMenuItem itemEdit = new DXMenuItem(" Sửa");
                itemEdit.Image = imageCollection1.Images["Group.ico"];
                itemEdit.Click += new EventHandler(btSua_Click);
                menu.Items.Add(itemEdit);
                DXMenuItem itemDelete = new DXMenuItem(" Xóa");
                itemDelete.Image = imageCollection1.Images["Delete.ico"];
                itemDelete.Click += new EventHandler(btXoa_Click);
                menu.Items.Add(itemDelete);
                DXMenuItem itemReload = new DXMenuItem(" Refesh");
                itemReload.Image = imageCollection1.Images["Refresh.ico"];
                itemReload.Click += new EventHandler(btLammoi_Click);
                menu.Items.Add(itemReload);
                DXMenuItem itemPrint = new DXMenuItem(" In");
                itemPrint.Image = imageCollection1.Images["Print.ico"];
                itemPrint.Click += new EventHandler(btIn_Click);
                menu.Items.Add(itemPrint);
                DXMenuItem itemExport = new DXMenuItem(" Xuất");
                itemExport.Image = imageCollection1.Images["excel.ico"];
                itemExport.Click += new EventHandler(btXuat_Click);
                menu.Items.Add(itemExport);
            }
        }
    }
}
