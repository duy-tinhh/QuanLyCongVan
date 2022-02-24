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
    public partial class ucCanBoXuLy : DevExpress.XtraEditors.XtraForm
    {
        public ucCanBoXuLy()
        {
            InitializeComponent();
        }
        Class.csCanBoXuLy CongVan = new Class.csCanBoXuLy();
        Class.csDVXuLy DVXuLy = new Class.csDVXuLy();
        Class.csKiemTraSoDT KiemTra = new Class.csKiemTraSoDT();
        void Refesh()
        {
            try
            {
                DataTable dt = DVXuLy.SELECT_DVXULY();
                txtCQBanHanh.Properties.DataSource = dt;
                txtCQBanHanh.Properties.DisplayMember = "Name";
                txtCQBanHanh.Properties.ValueMember = "ID";
                txtCQBanHanh.EditValue = dt.Rows[0][0].ToString();
                rpDonVi.DataSource = dt;
                rpDonVi.DisplayMember = "Name";
                rpDonVi.ValueMember = "ID";
                grcData.DataSource = CongVan.SELECT_CANBOXULY();
            }
            catch
            {
            }
        }

        private void ucLoaiVanban_Load(object sender, EventArgs e)
        {
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
                string ID = txtMa.Text.Trim();
                bool TrangThai = CongVan.SELECT_LOAIVANBAN_ID(ID);
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
                if (ThamSoHeThong.Quyen("ucCanBoXuLy", "sDelete") == false)
                    return;
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thật sự muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string ID = grvData.GetRowCellValue(grvData.FocusedRowHandle, colID).ToString();
                    bool TrangThaiDi = CongVan.CHECK_LOAIVANBAN_DI(ID);
                    bool TrangThaiDen = CongVan.CHECK_LOAIVANBAN_DEN(ID);
                    if ((TrangThaiDi == true) || (TrangThaiDen == true))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Thông tin đã sử dụng không thể xoá !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        CongVan.DELETE_CANBOXULY(ID);
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
                txtCQBanHanh.EditValue = grvData.GetRowCellValue(grvData.FocusedRowHandle, colDonvi).ToString();
                txtGhichu.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, colDescription).ToString();
                txtTel.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "Tel").ToString();
                txtEmail.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "Email").ToString();
                txtAddress.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "Address").ToString();
                ckTrangthai.Checked = Convert.ToBoolean(grvData.GetRowCellValue(grvData.FocusedRowHandle, colTrangthai).ToString());
            }
            catch
            { }
        }

        private void btIn_Click(object sender, EventArgs e)
        {
            if (ThamSoHeThong.Quyen("ucCanBoXuLy", "sPrint") == false)
                return;
            grvData.ShowRibbonPrintPreview();
        }

        private void btXuat_Click(object sender, EventArgs e)
        {
            if (ThamSoHeThong.Quyen("ucCanBoXuLy", "sExport") == false)
                return;
            ExportToXLS XLS = new ExportToXLS();
            XLS.ToXLS(grvData);
        }

        private void bLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtMa.Properties.ReadOnly == false) && (ThamSoHeThong.Quyen("ucCanBoXuLy", "sAdd") == false))
                    return;
                if ((txtMa.Properties.ReadOnly == true) && (ThamSoHeThong.Quyen("ucCanBoXuLy", "sEdit") == false))
                    return;
                if (txtMa.Text.Trim() == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập mã !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMa.Focus();
                }
                else if (txtTen.Text.Trim() == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập tên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Focus();
                }
                else if ((txtEmail.Text.Trim() != "") && (KiemTra.isValidEmail(txtEmail.Text.Trim()) == false))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập đúng email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();
                }
                else
                {
                    string ID = txtMa.Text.Trim();
                    string Name = txtTen.Text.Trim();
                    string DonViXuLy = txtCQBanHanh.EditValue.ToString();
                    string Description = txtGhichu.Text.Trim();
                    bool Active = ckTrangthai.Checked;
                    string MADV = "";
                    string Address = txtAddress.Text.Trim();
                    string Tel = txtTel.Text.Trim();
                    string Email = txtEmail.Text.Trim();
                    if (txtMa.Properties.ReadOnly == false)
                    {
                        CongVan.INSERT_CANBOXULY(ID, Name, Description, Active, DonViXuLy, MADV, Address, Tel, Email);
                    }
                    else
                    {
                        CongVan.UPDATE_CANBOXULY(ID, Name, Description, Active, DonViXuLy, MADV, Address, Tel, Email);
                    }
                    Refesh();
                    bXoa_Click(sender, e);
                }
            }
            catch
            {
            }
        }

        private void bXoa_Click(object sender, EventArgs e)
        {
            txtMa.Properties.ReadOnly = false;
            txtMa.Text = "";
            txtTen.Text = "";
            txtGhichu.Text = "";
            ckTrangthai.Checked = true;
            txtAddress.Text = "";
            txtTel.Text = "";
            txtEmail.Text = "";
            txtMa.Focus();
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
