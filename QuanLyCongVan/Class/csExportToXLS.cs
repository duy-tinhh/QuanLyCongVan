using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.IO;
using DevExpress.XtraPrinting;

namespace QuanLyCongVan
{
    public class ExportToXLS
    {
        public void ToXLS(DevExpress.XtraGrid.Views.Grid.GridView grdView)
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx";
                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        string exportFilePath = saveDialog.FileName;
                        string fileExtenstion = new FileInfo(exportFilePath).Extension;
                        switch (fileExtenstion)
                        {
                            case ".xls":
                                {
                                    XlsExportOptions xlOptions = new DevExpress.XtraPrinting.XlsExportOptions(DevExpress.XtraPrinting.TextExportMode.Text);
                                    ((DevExpress.XtraGrid.Views.Grid.GridView)grdView).ExportToXls(exportFilePath, xlOptions);
                                    break;
                                }
                            case ".xlsx":
                                {
                                    XlsxExportOptions xlOptions = new DevExpress.XtraPrinting.XlsxExportOptions(DevExpress.XtraPrinting.TextExportMode.Text);
                                    ((DevExpress.XtraGrid.Views.Grid.GridView)grdView).ExportToXlsx(exportFilePath, xlOptions);
                                    break;
                                }
                            default:
                                break;
                        }
                        if (File.Exists(exportFilePath))
                        {
                            if (DevExpress.XtraEditors.XtraMessageBox.Show("Đã xuất file thành công, bạn có muốn mở file ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                System.Diagnostics.Process.Start(exportFilePath);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Có lỗi trong quá trình xuất file ! Lỗi " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ToPDF(DevExpress.XtraGrid.Views.Grid.GridView girdView)
        {
            SaveFileDialog Dialog = new SaveFileDialog { };
            Dialog.Filter = "PDF (*.pdf)|*.pdf";
            Dialog.Title = "Save an PDF File";
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    girdView.ExportToPdf(Dialog.FileName);
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("Đã xuất file thành công, bạn có muốn mở file ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Process.Start(Dialog.FileName);
                    }
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Có lỗi trong quá trình xuất file ! Lỗi " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
