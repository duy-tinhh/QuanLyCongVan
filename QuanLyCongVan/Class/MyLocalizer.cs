using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;

namespace QuanLyCongVan.Class
{
    class MyLocalizer : Localizer
    {
        public override string GetLocalizedString(StringId id)
        {
            if (id == StringId.XtraMessageBoxNoButtonText) return "Không";
            if (id == StringId.XtraMessageBoxYesButtonText) return "Có";

            if (id == StringId.XtraMessageBoxAbortButtonText) return "Huỷ bỏ";
            if (id == StringId.XtraMessageBoxCancelButtonText) return "Huỷ bỏ";

            if (id == StringId.XtraMessageBoxOkButtonText) return "Đồng ý";
            if (id == StringId.XtraMessageBoxRetryButtonText) return "Thử lại";
            if (id == StringId.DateEditToday) return "Hôm nay";
            if (id == StringId.PictureEditMenuCopy) return "Sao chép";
            return base.GetLocalizedString(id);
        }
    }
}
