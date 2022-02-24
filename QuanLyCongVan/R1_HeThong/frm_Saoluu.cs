using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;

namespace QuanLyCongVan
{
    public partial class frm_SaoLuu : DevExpress.XtraEditors.XtraForm
    {
        public frm_SaoLuu()
        {
            InitializeComponent();
        }
        Class.csData Data = new Class.csData();

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
                if ((ThamSoHeThong.Quyen("frm_SaoLuu", "sAdd") == false))
                    return;
                if ((ThamSoHeThong.Quyen("frm_SaoLuu", "sEdit") == false))
                    return;
                string ThuMuc = txtSaoluu.Text;
                string NoiLuu = ThuMuc + "\\Temp\\";
                //Xóa file zip trong thư mục
                if (Directory.Exists(NoiLuu))
                {
                    DirectoryInfo d = new DirectoryInfo(NoiLuu);
                    foreach (var file in d.GetFiles())
                    {
                        File.Delete(file.FullName);
                    }
                }


                string FileName = txtTenfile.Text;
                string FileBak = ThuMuc + "\\Temp\\" + FileName + ".bak";
                string FileZip = ThuMuc + "\\" + FileName + ".zip._temp";
                string FolderTemp = ThuMuc + "\\Temp";
                if (!Directory.Exists(FolderTemp))
                {
                    Directory.CreateDirectory(FolderTemp);
                    DirectoryInfo theFolder = new DirectoryInfo(FolderTemp);
                    theFolder.Attributes = FileAttributes.Hidden;//Cho ẩn
                }
                //Sao lưu trước
                Data.BACKUP_DATABASE(FileBak, GetFirstValue);
                //nén zip
                CreateSample(FileZip, "", FolderTemp);

                //xóa file bak
                File.Delete(FileBak);
                //Directory.Delete(FolderTemp);
                Cursor.Current = Cursors.Default;
                DevExpress.XtraEditors.XtraMessageBox.Show("Đã sao lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (SqlException ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }
        // - Nén file
        private void CompressRAR(string rar_file, string path_file)
        {
            try
            {
                ProcessStartInfo ps = new ProcessStartInfo();
                // - File chương trình nén và giải nén Winar
                ps.FileName = @"Rar.exe";
                // - Tham số truyền vào câu lệnh (vd: rar.exe a - trong đó a là tham số)
                // - rar_file: tên file nén | path_file: đường dẫn nguồn nén(file đc nén, thư mục đc nén)
                // - \" Thêm vào một dấu nháy kép ("")
                ps.Arguments = "a -r -ep1 \"" + rar_file + "\" \"" + path_file + "\"";
                ps.WindowStyle = ProcessWindowStyle.Hidden;     // - Ẩn cửa sổ nén
                // - Chạy câu lệnh nén
                Process proc = Process.Start(ps);
                // - Thoát sau khi nén xong
                proc.WaitForExit();
            }
            catch
            {
                }
        }
        // - Giải nén file
        private void ExtractRAR(string rar_file, string path_file)
        {
            ProcessStartInfo ps = new ProcessStartInfo();
            // - File chương trình nén và giải nén Winar
            ps.FileName = @"Rar.exe";
            // - Tham số truyền vào câu lệnh (vd: rar.exe x - trong đó x là tham số)
            // - rar_file: tên file nén | path_file: đường dẫn giải nén(file đc giải nén, thư mục đc giải nén)
            // - \" Thêm vào một dấu nháy kép ("")
            ps.Arguments = "x -y \"" + rar_file + "\" \"" + path_file + "\"";
            ps.WindowStyle = ProcessWindowStyle.Hidden;     // - Ẩn cửa sổ giải nén
            // - Chạy câu lệnh giải nén
            Process proc = Process.Start(ps);
            // - Thoát sau khi giải nén xong
            proc.WaitForExit();
        }


        ///Hàm tạo file nén create zip có pass
        public void CreateSample(string outPathname, string password, string folderName)
        {
            //outPathname: tên và đường dẫn lưu kết quả (ví dụ tên là ketqua.zip lưu ổ E, "E:\\ketqua.zip")
            //password: là password thiết lập cho file zip (ví dụ pass là "12345")
            //folderName: là đường dẫn folder dữ liệu (ví dụ có folder "data" ở ổ C, "C:\\data")
            //CreateSample("C:\\ketqua.zip", "12345", "C:\\data");
            //Chú ý nếu ketqua.zip đã tồn tại trong ổ E thì cần phải xóa bỏ file này thì mới tạo được
            FileStream fsOut = File.Create(outPathname);
            ZipOutputStream zipStream = new ZipOutputStream(fsOut);
            zipStream.SetLevel(3); //0-9,có 9 mức nén, mức 9 là cao nhất
            //zipStream.Password = password;
            int folderOffset = folderName.Length + (folderName.EndsWith("\\") ? 0 : 1);
            CompressFolder(folderName, zipStream, folderOffset);
            zipStream.IsStreamOwner = true;
            zipStream.Close();
        }
        private void CompressFolder(string path, ZipOutputStream zipStream, int folderOffset)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string filename in files)
            {
                FileInfo fi = new FileInfo(filename);
                string entryName = filename.Substring(folderOffset);
                entryName = ZipEntry.CleanName(entryName);
                ZipEntry newEntry = new ZipEntry(entryName);
                newEntry.DateTime = fi.LastWriteTime;
                newEntry.Size = fi.Length;
                zipStream.PutNextEntry(newEntry);
                byte[] buffer = new byte[4096];
                using (FileStream streamReader = File.OpenRead(filename))
                {
                    StreamUtils.Copy(streamReader, zipStream, buffer);
                }
                zipStream.CloseEntry();
            }
            string[] folders = Directory.GetDirectories(path);
            foreach (string folder in folders)
            {
                CompressFolder(folder, zipStream, folderOffset);
            }
        }
        private void bThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                txtSaoluu.Text = f.SelectedPath;
            }
        }

        private void frm_Saoluu_Load(object sender, EventArgs e)
        {
            txtTenfile.Text = "QLCV-" + DateTime.Now.ToString("ddMMyy-HHmmss");
            txtSaoluu.Text = "D:\\Data_QLCV";
        }

        private void txtSaoluu_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}