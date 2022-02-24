using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyCongVan
{
    public partial class frm_Phuchoi : DevExpress.XtraEditors.XtraForm
    {
        public frm_Phuchoi()
        {
            InitializeComponent();
        }
        Class.csData Data = new Class.csData();
        Class.csMD5 MD5 = new Class.csMD5();

        private string _getFirstValue = null;
        public string GetFirstValue
        {
            get { return _getFirstValue; }
            set { _getFirstValue = value; }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string Phuchoi = txtPhuchoi.Text;
                if ((ThamSoHeThong.Quyen("frm_PhucHoi", "sAdd") == false))
                    return;
                if ((ThamSoHeThong.Quyen("frm_PhucHoi", "sEdit") == false))
                    return;
                if (Phuchoi != "")
                {
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc chắn cần phục hồi dữ liệu !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc chắn cần phục hồi dữ liệu, xin xác nhận lại lần nữa !" + Environment.NewLine + Environment.NewLine + "Việc phục hồi lại dữ liệu sẽ làm mất dữ liệu hiện tại, lưu ý khi thao tác.", "Xác nhận lần 2" + Environment.NewLine, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            Data.RESTORE_DATABASE(Phuchoi, GetFirstValue);
                            Cursor.Current = Cursors.Default;
                            DevExpress.XtraEditors.XtraMessageBox.Show("Đã phục hồi dữ liệu thành công. Ứng dụng cần khởi động lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Restart();
                        }
                    }
                }
            }
            catch
            {
                Data.RESTORE_DATABASE_ERROR(GetFirstValue);
                DevExpress.XtraEditors.XtraMessageBox.Show("Phục hồi dữ liệu thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhuchoi_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                OpenFileDialog save = new OpenFileDialog();
                save.Filter = "File(*.bak)|*.bak";
                save.InitialDirectory = "D:\\Data_QLCV";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    txtPhuchoi.Text = save.FileName;
                }
            }
            catch
            {
            }
        }

        private void frm_Phuchoi_Load(object sender, EventArgs e)
        {

        }
    }
}