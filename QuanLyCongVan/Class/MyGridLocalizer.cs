using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Localization;  

namespace QuanLyCongVan.Class
{
    class MyGridLocalizer: GridLocalizer
    {
        public override string GetLocalizedString(GridStringId id)
        {
            if (id == GridStringId.MenuColumnClearAllSorting)
                return "Xoá sắp sếp";
            if (id == GridStringId.CustomizationBands)
                return "Nhóm";
            if (id == GridStringId.CustomizationColumns)
                return "Cột";
            if (id == GridStringId.MenuGroupPanelClearGrouping)
                return "Xoá gom nhóm";
            if (id == GridStringId.MenuColumnSortGroupBySummaryMenu)
                return "Tổng theo nhóm";
            if (id == GridStringId.MenuColumnGroupIntervalMenu)
                return "Nhóm thời gian";
            if (id == GridStringId.MenuColumnGroupIntervalDay)
                return "Ngày";
            if (id == GridStringId.MenuColumnGroupIntervalMonth)
                return "Tháng";
            if (id == GridStringId.MenuColumnGroupIntervalYear)
                return "Năm";
            if (id == GridStringId.MenuColumnGroupIntervalSmart)
                return "Chi tiết";
            if (id == GridStringId.MenuColumnBandCustomization)
                return "Tuỳ chỉnh cột";
            if (id == GridStringId.MenuColumnResetGroupSummarySort)
                return "Xoá sắp xếp nhóm";
            if (id == GridStringId.MenuColumnSumSummaryTypeDescription)
                return "Sắp xếp theo";
            if (id == GridStringId.FindControlFindButton)
                return "Tìm";
            if (id == GridStringId.FindControlClearButton)
                return "Xoá";
            if (id == GridStringId.GridGroupPanelText)
                return "Kéo và thả cột vào đây để gom nhóm dữ liệu";
            if (id == GridStringId.MenuColumnSortAscending)
                return "Sắp xếp tăng dần";
            if (id == GridStringId.MenuColumnSortDescending)
                return "Sắp xếp giảm dần";
            if (id == GridStringId.MenuColumnClearSorting)
                return "Bỏ sắp xếp";
            if (id == GridStringId.MenuColumnGroup)
                return "Gom nhóm theo cột này";
            if (id == GridStringId.MenuGroupPanelShow)
                return "Hiện hộp gom nhóm";
            if (id == GridStringId.MenuGroupPanelHide)
                return "Ẩn hộp gom nhóm";
            if (id == GridStringId.MenuGroupPanelFullExpand)
                return "Mở tất cả các nhóm";
            if (id == GridStringId.MenuGroupPanelFullCollapse)
                return "Thu tất cả các nhóm";
            if (id == GridStringId.MenuColumnUnGroup)
                return "Bỏ gom nhóm";
            if (id == GridStringId.MenuColumnRemoveColumn)
                return "Ẩn cột này";
            if (id == GridStringId.MenuColumnShowColumn)
                return "Hiện cột này";
            if (id == GridStringId.MenuColumnColumnCustomization)
                return "Tùy chỉnh cột";
            if (id == GridStringId.CustomizationCaption)
                return "Tùy chỉnh cột";
            if (id == GridStringId.FindNullPrompt)
                return "Nhập thông tin cần tìm ...";
            if (id == GridStringId.MenuColumnFindFilterHide)
                return "Ẩn tìm kiếm nâng cao";
            if (id == GridStringId.MenuColumnFindFilterShow)
                return "Hiện tìm kiếm nâng cao";
            if (id == GridStringId.CustomizationFormColumnHint)
                return "Kéo và thả cột vào đây để tùy chỉnh";
            if (id == GridStringId.MenuColumnBestFit)
                return "Căn chỉnh";
            if (id == GridStringId.MenuColumnBestFitAllColumns)
                return "Căn chỉnh tất cả";
            if (id == GridStringId.MenuColumnFilterEditor)
                return "Cài đặt lọc";
            if (id == GridStringId.PopupFilterCustom)
                return "(Tùy chọn)";
            if (id == GridStringId.PopupFilterAll)
                return "(Tất cả)";
            if (id == GridStringId.FilterPanelCustomizeButton)
                return "Sửa lọc";
            if (id == GridStringId.FilterBuilderCaption)
                return "Cài đặt lọc";
            if (id == GridStringId.FilterBuilderOkButton)
                return "Đồng ý";
            if (id == GridStringId.FilterBuilderApplyButton)
                return "Áp dụng";
            if (id == GridStringId.FilterBuilderCancelButton)
                return "Hủy bỏ";
            if (id == GridStringId.MenuColumnAutoFilterRowShow)
                return "Hiện dòng lọc tự động";
            if (id == GridStringId.MenuColumnAutoFilterRowHide)
                return "Ẩn dòng lọc tự động";
            if (id == GridStringId.MenuColumnFilterMode)
                return "Chế độ lọc";
            if (id == GridStringId.MenuColumnFilterModeDisplayText)
                return "Văn bản";
            if (id == GridStringId.MenuColumnFilterModeValue)
                return "Giá trị";
            if (id == GridStringId.CustomFilterDialogCancelButton)
                return "Hủy bỏ";
            if (id == GridStringId.CustomFilterDialogCaption)
                return "Hiển thị những hàng có:";
            if (id == GridStringId.CustomFilterDialogEmptyOperator)
                return "(Chọn phép toán)";
            if (id == GridStringId.CustomFilterDialogEmptyValue)
                return "(Điền giá trị)";
            if (id == GridStringId.CustomFilterDialogFormCaption)
                return "Tùy chọn lọc tự động";
            if (id == GridStringId.CustomFilterDialogOkButton)
                return "Đồng ý";
            if (id == GridStringId.CustomFilterDialogRadioAnd)
                return "Và";
            if (id == GridStringId.CustomFilterDialogRadioOr)
                return "Hoặc";
            return base.GetLocalizedString(id);
        }
        
    }
}
