using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Menu;

namespace QuanLyCongVan
{
    public partial class frm_Phanquyen : DevExpress.XtraEditors.XtraForm
    {
        public frm_Phanquyen()
        {
            InitializeComponent();
        }

        Class.csUser Adduser = new Class.csUser();
        Class.csVaitro CongVan = new Class.csVaitro();
        private void Getdata()
        {
            try
            {
                rpType.DataSource = Adduser.SELECT_SYS_USER_GROUP();
                rpType.DisplayMember = "Group_Name";
                rpType.ValueMember = "Group_ID";
            }
            catch
            {
            }
        }
        private void DATAGRID()
        {
            try
            {
                grdPhanquyen.DataSource = Adduser.SELECT_RULE_2();
                gridNhomQuyen.DataSource = Adduser.SELECT_SYS_USER_GROUP();
                gridView1.BestFitColumns();
            }
            catch
            {
            }
        }
        public void frm_Button_Clicked(object sender, EventArgs e)
        {
            this.bRefesh_Click(bRefesh, EventArgs.Empty);
        }
        private void frm_Phanquyen_Load(object sender, EventArgs e)
        {
            Getdata(); 
            DATAGRID();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Info.IsRowIndicator)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void bThem_Click(object sender, EventArgs e)
        {
            if (ThamSoHeThong.Quyen("frm_Phanquyen", "sAdd") == false)
                return;
            frm_Adduser Add_user = new frm_Adduser();
            Add_user.Button_Clicked += new EventHandler(frm_Button_Clicked);
            Add_user.ShowDialog();
        }

        private void bLuu_Click(object sender, EventArgs e)
        {
            if (ThamSoHeThong.Quyen("frm_Phanquyen", "sEdit") == false)
                return;
            if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thật sự muốn lưu sự thay đổi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    Adduser.Open();
                    for (int i = 0; i < gridView3.RowCount; i++)
                    {
                        string Group_ID = gridView3.GetRowCellValue(i, "Group_ID").ToString();
                        string Form_ID = gridView3.GetRowCellValue(i, "Form_ID").ToString();
                        bool All = Convert.ToBoolean(gridView3.GetRowCellValue(i, "sAll").ToString());
                        bool See = Convert.ToBoolean(gridView3.GetRowCellValue(i, "sSee").ToString());
                        bool Add = Convert.ToBoolean(gridView3.GetRowCellValue(i, "sAdd").ToString());
                        bool Delete = Convert.ToBoolean(gridView3.GetRowCellValue(i, "sDelete").ToString());
                        bool Edit = Convert.ToBoolean(gridView3.GetRowCellValue(i, "sEdit").ToString());
                        bool Print = Convert.ToBoolean(gridView3.GetRowCellValue(i, "sPrint").ToString());
                        bool Export = Convert.ToBoolean(gridView3.GetRowCellValue(i, "sExport").ToString());
                        Adduser.UPDATE_SYS_USER_FORM(Group_ID, Form_ID, All, See, Add, Delete, Edit, Print, Export);
                    }
                    ThamSoHeThong.Table_Rule = Adduser.SELECT_SYS_USER_FORM_ID2(ThamSoHeThong.NhomQuyenNV);
                    Adduser.Close();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Đã lưu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Có lỗi trong việc thực hiện !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void bXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (ThamSoHeThong.Quyen("frm_Phanquyen", "sDelete") == false)
                    return;
                string ID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();
                if (ID == "admin")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Bạn không thể xoá tài khoản quản trị !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thật sự muốn xóa tài khoản '" + ID + "' ?" , "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Adduser.DELETE_USER_RULE(ID);
                        Adduser.DELETE_USER_RULE_ID(ID);
                        DATAGRID();
                    }
                }
            }
            catch
            {
            }
        }

        private void bSua_Click(object sender, EventArgs e)
        {
            grdPhanquyen_DoubleClick(sender, e);
        }

        private void bRefesh_Click(object sender, EventArgs e)
        {
            DATAGRID();
        }

        private void bIn_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
        }

        private void bXuat_Click(object sender, EventArgs e)
        {
            ExportToXLS XLS = new ExportToXLS();
            XLS.ToXLS(gridView1);
        }

        private void grdPhanquyen_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                frm_Adduser Adduser = new frm_Adduser();
                Adduser.GetFirstValue = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();
                Adduser.Button_Clicked += new EventHandler(frm_Button_Clicked);
                Adduser.ShowDialog();
            }
            catch
            {
            }
        }


        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                GridViewMenu menu = e.Menu as GridViewMenu;//user-group-new.ico
                menu.Items.Clear();
                DXMenuItem itemAddTK = new DXMenuItem(" Thêm tài khoản");
                itemAddTK.Image = imageCollection1.Images["Add.ico"];
                itemAddTK.Click += new EventHandler(bThem_Click);
                menu.Items.Add(itemAddTK);
                DXMenuItem itemEdit = new DXMenuItem(" Sửa tài khoản");
                itemEdit.Image = imageCollection1.Images["Group.ico"];
                itemEdit.Click += new EventHandler(bSua_Click);
                menu.Items.Add(itemEdit);

                DXMenuItem itemDelete = new DXMenuItem(" Xóa tài khoản");
                itemDelete.Image = imageCollection1.Images["Delete.ico"];
                itemDelete.Click += new EventHandler(bXoa_Click);
                menu.Items.Add(itemDelete);
                DXMenuItem itemReload = new DXMenuItem(" Refresh");
                itemReload.Image = imageCollection1.Images["Refresh.ico"];
                itemReload.Click += new EventHandler(bRefesh_Click);
                menu.Items.Add(itemReload);
                DXMenuItem itemPrint = new DXMenuItem(" In");
                itemPrint.Image = imageCollection1.Images["Print.ico"];
                itemPrint.Click += new EventHandler(bIn_Click);
                menu.Items.Add(itemPrint);
                DXMenuItem itemExport = new DXMenuItem(" Xuất ");
                itemExport.Image = imageCollection1.Images["excel.ico"];
                itemExport.Click += new EventHandler(bXuat_Click);
                menu.Items.Add(itemExport);
            }
        }

        private void bThemNhom_Click(object sender, EventArgs e)
        {
            if (ThamSoHeThong.Quyen("frm_Phanquyen", "sAdd") == false)
                return;
            frm_VaiTro form = new frm_VaiTro();
            form.Button_Clicked += new EventHandler(frm_Button_Clicked);
            form.ShowDialog();            
        }

        private void bSuaNhom_Click(object sender, EventArgs e)
        {
            frm_VaiTro form = new frm_VaiTro();
            form.ID_Truyen = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Group_ID").ToString();
            form.Button_Clicked += new EventHandler(frm_Button_Clicked);
            form.ShowDialog();
        }
        private void bXoaNhom_Click(object sender, EventArgs e)
        {
            try
            {
                if (ThamSoHeThong.Quyen("frm_Phanquyen", "sDelete") == false)
                    return;
                string Group_ID = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Group_ID").ToString();
                if (Group_ID == "QT")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Bạn không thể nhóm tài khoản quản trị !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thật sự muốn xóa nhóm tài khoản '" + Group_ID + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Adduser.DELETE_SYS_USER_FORM(Group_ID);
                        Adduser.DELETE_SYS_USER_GROUP_ID(Group_ID);
                        DATAGRID();
                    }
                }
            }
            catch
            {
            }
        }

        private void gridView2_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                GridViewMenu menu = e.Menu as GridViewMenu;//user-group-new.ico
                menu.Items.Clear();
                DXMenuItem itemAddTK = new DXMenuItem(" Thêm nhóm");
                itemAddTK.Image = imageCollection1.Images["Add.ico"];
                itemAddTK.Click += new EventHandler(bThemNhom_Click);
                menu.Items.Add(itemAddTK);
                DXMenuItem itemEdit = new DXMenuItem(" Sửa nhóm");
                itemEdit.Image = imageCollection1.Images["Group.ico"];
                itemEdit.Click += new EventHandler(bSuaNhom_Click);
                menu.Items.Add(itemEdit);
                DXMenuItem itemDelete = new DXMenuItem(" Xóa nhóm");
                itemDelete.Image = imageCollection1.Images["Delete.ico"];
                itemDelete.Click += new EventHandler(bXoaNhom_Click);
                menu.Items.Add(itemDelete);
                DXMenuItem itemReload = new DXMenuItem(" Refresh");
                itemReload.Image = imageCollection1.Images["Refresh.ico"];
                itemReload.Click += new EventHandler(bRefesh_Click);
                menu.Items.Add(itemReload);
                DXMenuItem itemPrint = new DXMenuItem(" In");
                itemPrint.Image = imageCollection1.Images["Print.ico"];
                itemPrint.Click += new EventHandler(bIn_Click);
                menu.Items.Add(itemPrint);
                DXMenuItem itemExport = new DXMenuItem(" Xuất ");
                itemExport.Image = imageCollection1.Images["excel.ico"];
                itemExport.Click += new EventHandler(bXuat_Click);
                menu.Items.Add(itemExport);
            }
        }

        private void gridNhomQuyen_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string Group_ID = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Group_ID").ToString();
                gridControl2.DataSource = Adduser.SELECT_SYS_USER_FORM_ID(Group_ID);
            }
            catch
            {
            }
        }

        private void rpCheckRule_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckEdit ck = gridView3.ActiveEditor as CheckEdit;
                bool Active = ck.Checked;
                int Dong = gridView3.FocusedRowHandle;
                gridView3.SetRowCellValue(Dong, "sSee", Active);
                gridView3.SetRowCellValue(Dong, "sAdd", Active);
                gridView3.SetRowCellValue(Dong, "sDelete", Active);
                gridView3.SetRowCellValue(Dong, "sEdit", Active);
                gridView3.SetRowCellValue(Dong, "sPrint", Active);
                gridView3.SetRowCellValue(Dong, "sExport", Active);
            }
            catch
            {
            }
        }

        private void bHelp_Click(object sender, EventArgs e)
        {
           // System.Diagnostics.Process.Start(ThamSoHeThong.LinkVideoYoutube_PhanQuyen);
        }
    }
}