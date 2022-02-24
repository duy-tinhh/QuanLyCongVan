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
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;

namespace QuanLyCongVan.R6_BienNhanHoSo
{
    public partial class frm_BienNhanHoSo_DS : DevExpress.XtraEditors.XtraForm
    {
        public frm_BienNhanHoSo_DS()
        {
            InitializeComponent();
        }
        Class.ConfigApp Config = new Class.ConfigApp();
        Class.csDatetime Date = new Class.csDatetime();
        Class.csBienNhan CongVan = new Class.csBienNhan();
        Class.csCQBanHanh CQBanHanh = new Class.csCQBanHanh();
        Class.csLoaiVanBan LoaiVanBan = new Class.csLoaiVanBan();
        Class.csCanBoXuLy CanBoXuLy = new Class.csCanBoXuLy();
        Class.csLookupEdit Lookuptedit = new Class.csLookupEdit();
        Class.csMD5 MD5 = new Class.csMD5();

        void item_Click(object sender, EventArgs e)
        {
            dropDownButton1.Text = ((DXMenuItem)sender).Caption;
            LoadData(dropDownButton1.Text);
        }
        string Nam = "Năm ";
        string Tatca_name = "Tất cả";
        string Top20_name = "Top 20";
        string Top50_name = "Top 50";
        string Top100_name = "Top 100";
        void LoadNam()
        {
            int NamDauTien = 2010;
            int NamCuoiCung = DateTime.Now.Year + 5;
            int SoNam = NamCuoiCung - NamDauTien + 1;
            DXPopupMenu menu = new DXPopupMenu();
            menu.Items.Add(new DXMenuItem(Tatca_name));
            menu.Items.Add(new DXMenuItem(Top20_name));
            menu.Items.Add(new DXMenuItem(Top50_name));
            menu.Items.Add(new DXMenuItem(Top100_name));
            for (int i = 0; i < SoNam; i++)
            {
                menu.Items.Add(new DXMenuItem(Nam + (NamCuoiCung - i)));
            }
            dropDownButton1.DropDownControl = menu;
            foreach (DXMenuItem item in menu.Items)
                item.Click += item_Click;
            string Value = Config.Set_DropDownButton(this.Name);
            if (Value == "")
                dropDownButton1.Text = menu.Items[0].Caption;
            else
                dropDownButton1.Text = Value;
        }
        void LoadData(string Name)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                if (Name == Tatca_name)
                {
                    dt = CongVan.SELECT_BIENNHAN_ALL();                    
                }
                else if (Name == Top20_name || Name == Top50_name || Name == Top100_name)
                {
                    int Top = Convert.ToInt16(Name.Replace("Top ", ""));
                    dt = CongVan.SELECT_BIENNHAN_TOP(Top);                    
                }
                else
                {
                    int NamTimKiem = Convert.ToInt16(Name.Replace(Nam, ""));
                    dt = CongVan.SELECT_BIENNHAN(NamTimKiem);                   
                }
                grcCongVan.DataSource = dt;
                Cursor.Current = Cursors.Default;
            }
            catch
            {
            }
        }
        public void frm_Button_Clicked(object sender, EventArgs e)
        {
            this.bRefesh_Click(bRefesh, EventArgs.Empty);
        }
        void LoadDataCQBanHanh()
        {
            Lookuptedit.ReposGridLookUpEdit("NHANVIEN", rpCanBoXuLy, "Name", "ID");
        }
        private void frm_CongVanDen_Load(object sender, EventArgs e)
        {
            LoadNam();
            LoadDataCQBanHanh();
            LoadData(dropDownButton1.Text);
            Config.Load_View(this.Name, grvCongVan);
        }

        private void grvCongVan_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Info.IsRowIndicator)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void bRefesh_Click(object sender, EventArgs e)
        {
            LoadData(dropDownButton1.Text);
        }

        private void bThem_Click(object sender, EventArgs e)
        {
            if (ThamSoHeThong.Quyen("frm_BienNhanHoSo_DS", "sAdd") == false)
                return;
            R6_BienNhanHoSo.frm_ThemBienNhan form = new R6_BienNhanHoSo.frm_ThemBienNhan();
            form.Button_Clicked += new EventHandler(frm_Button_Clicked);
            form.ShowDialog();            
        }

        private void bSua_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = grvCongVan.GetRowCellValue(grvCongVan.FocusedRowHandle, "ID").ToString();
                R6_BienNhanHoSo.frm_ThemBienNhan ThemCongVanDen = new R6_BienNhanHoSo.frm_ThemBienNhan();
                ThemCongVanDen.ID_CongVan = ID;
                ThemCongVanDen.Button_Clicked += new EventHandler(frm_Button_Clicked);
                ThemCongVanDen.ShowDialog();
            }
            catch
            {
            }
        }

        private void bXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (ThamSoHeThong.Quyen("frm_BienNhanHoSo_DS", "sDelete") == false)
                    return;
                string Name = grvCongVan.GetRowCellValue(grvCongVan.FocusedRowHandle, "SOBN").ToString();                
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thật sự muốn xóa biên nhận số " + Name + "  ?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information)== System.Windows.Forms.DialogResult.Yes)
                {
                    string ID = grvCongVan.GetRowCellValue(grvCongVan.FocusedRowHandle, "ID").ToString();
                    CongVan.DELETE_BIENNHAN(ID);
                    grvCongVan.DeleteSelectedRows();
                }                
            }
            catch { }
        }

        private void bIn_Click(object sender, EventArgs e)
        {
            if (ThamSoHeThong.Quyen("frm_BienNhanHoSo_DS", "sPrint") == false)
                return;
            grvCongVan.ShowRibbonPrintPreview();
        }

        private void bXuat_Click(object sender, EventArgs e)
        {
            if (ThamSoHeThong.Quyen("frm_BienNhanHoSo_DS", "sExport") == false)
                return;
            ExportToXLS XLS = new ExportToXLS();
            XLS.ToXLS(grvCongVan);
        }
       
        private void grcCongVan_DoubleClick(object sender, EventArgs e)
        {
            bSua_Click(sender, e);
        }

        private void grvCongVan_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                GridViewMenu menu = e.Menu as GridViewMenu;
                menu.Items.Clear();

                DXMenuItem itemAdd = new DXMenuItem(" Thêm");
                itemAdd.Image = imageCollection1.Images["Add.ico"];
                itemAdd.Click += new EventHandler(bThem_Click);
                menu.Items.Add(itemAdd);

                DXMenuItem itemPrint = new DXMenuItem(" Xem");
                itemPrint.Image = imageCollection1.Images["Edit.ico"];
                itemPrint.Click += new EventHandler(bSua_Click);
                menu.Items.Add(itemPrint);

                DXMenuItem itemDelete = new DXMenuItem(" Xóa");
                itemDelete.Image = imageCollection1.Images["Delete.ico"];
                itemDelete.Click += new EventHandler(bXoa_Click);
                menu.Items.Add(itemDelete);

                DXMenuItem itemReload = new DXMenuItem(" Refresh");
                itemReload.Image = imageCollection1.Images["Refresh.ico"];
                itemReload.Click += new EventHandler(bRefesh_Click);
                menu.Items.Add(itemReload);
            }
        }

        private void frm_VT_CongVanDen_DS_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.Set_View(this.Name, grvCongVan);
            Config.Get_DropDownButton(this.Name, dropDownButton1.Text);
        }
    }
}
