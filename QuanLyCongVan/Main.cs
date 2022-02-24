using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.UserSkins;
using DevExpress.XtraBars.Helpers;
using System.IO;
using System.Xml;
using Microsoft.Win32;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Reflection;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;

namespace QuanLyCongVan
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Main()
        {
            InitializeComponent();
        }
        Class.csCongVanDen CongVan = new Class.csCongVanDen();
        Class.csAddTable AddTable = new Class.csAddTable();
        Class.csData Data = new Class.csData();
        Class.csMD5 MD5 = new Class.csMD5();

        private bool checkAddForm(string Text)
        {
            bool add = true;
            if (MdiManager.Pages.Count > 0)
            {
                for (int i = 0; i < MdiManager.Pages.Count; i++)
                {
                    if (MdiManager.Pages[i].Text == Text)
                    {
                        add = false;
                        MdiManager.SelectedPage = MdiManager.Pages[i];
                        return add;
                    }
                }
            }
            return add;
        }

        private void ThongTinDonViSuDung()
        {
            Class.csThongTinDonVi Info = new Class.csThongTinDonVi();
            DataTable dt = Info.GetData2();
            ThamSoHeThong.DONVICHUQUAN = dt.Rows[0]["DONVICHUQUAN"].ToString();
            ThamSoHeThong.DONVISUDUNG = dt.Rows[0]["DONVISUDUNG"].ToString();
            ThamSoHeThong.DIACHI = dt.Rows[0]["DIACHI"].ToString();
            ThamSoHeThong.XAPHUONG = dt.Rows[0]["XAPHUONG"].ToString();
            ThamSoHeThong.HUYENQUAN = dt.Rows[0]["HUYENQUAN"].ToString();
            ThamSoHeThong.TINH = dt.Rows[0]["TINH"].ToString();
            ThamSoHeThong.SODT = dt.Rows[0]["SODT"].ToString();
            ThamSoHeThong.FAX = dt.Rows[0]["FAX"].ToString();
            ThamSoHeThong.WEBSITE = dt.Rows[0]["WEBSITE"].ToString();
            ThamSoHeThong.EMAIL = dt.Rows[0]["EMAIL"].ToString();
            byte[] b = Info.GetPic();
            MemoryStream mem = new MemoryStream(b);
            ThamSoHeThong.LOGO = Image.FromStream(mem);
        }
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                //Load giao diện
                string fileName = Application.StartupPath.ToString() + @"\Skin.txt";
                if (System.IO.File.Exists(fileName) == false)
                {
                    defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Springtime");
                }
                else
                {
                    StreamReader objRead = new StreamReader(fileName, false);
                    defaultLookAndFeel1.LookAndFeel.SetSkinStyle(objRead.ReadLine().ToString());
                    objRead.Close();
                }

                //Fix data SQL
                AddTable.EDIT_DATA();
                Ribbon.SelectedPage = rbTroGiup;
                txtTenServer.Caption = ThamSoHeThong.ServerName;
                lbDT.Caption = ThamSoHeThong.DatabaseName;

                ThongTinDonViSuDung();
                this.Refresh();
                this.Invalidate();
                frm_Login login = new frm_Login();
                login.AutoLogin = true;
                login.Button_Clicked += new EventHandler(frm_Button_Clicked);
                login.ShowDialog();
            }
            catch
            {
            }
        }

        public void frm_Button_Clicked(object sender, EventArgs e)
        {
            DangNhap();
        }
        private void DangNhap()
        {
            try
            {
                rbHeThong.Visible = true;
                rbDanhMuc.Visible = true;
                rbTienIch.Visible = true;
                rbCongVan.Visible = true;
                Ribbon.SelectedPage = rbCongVan;
                ribbonLogin.Visible = false;
                if (ThamSoHeThong.TenDangNhap != "admin")
                {
                    bbPhanQuyen.Enabled = ThamSoHeThong.Quyen("frm_Phanquyen", "sSee");
                    bbSaoLuu.Enabled = ThamSoHeThong.Quyen("frm_SaoLuu", "sSee");
                    bbPhucHoi.Enabled = ThamSoHeThong.Quyen("frm_PhucHoi", "sSee");
                    bbThongTin.Enabled = ThamSoHeThong.Quyen("frm_InfoCompany", "sSee");

                    bbDM_LoaiVB.Enabled = ThamSoHeThong.Quyen("ucLoaiVanban", "sSee");
                    bbDM_CQBH.Enabled = ThamSoHeThong.Quyen("ucCQBanHanh", "sSee");
                    bbDM_CQNCV.Enabled = ThamSoHeThong.Quyen("ucCQNhanCV", "sSee");
                    bbDM_DVXL.Enabled = ThamSoHeThong.Quyen("ucDVXuLy", "sSee");
                    bbDM_CBK.Enabled = ThamSoHeThong.Quyen("ucCanBoKy", "sSee");
                    bbDM_CBXL.Enabled = ThamSoHeThong.Quyen("ucCanBoXuLy", "sSee");
                    bbVTLuu.Enabled = ThamSoHeThong.Quyen("frm_ViTriLuu", "sSee");

                    bbVT_CVDen.Enabled = ThamSoHeThong.Quyen("frm_CongVanDen_DS", "sSee");
                    bbVT_CVDi.Enabled = ThamSoHeThong.Quyen("frm_CongVanDi_DS", "sSee");
                    bbSoanVB.Enabled = ThamSoHeThong.Quyen("frm_SoanVB", "sSee");
                    bbBiennhan.Enabled = ThamSoHeThong.Quyen("frm_BienNhanHoSo_DS", "sSee");
                    bbVT_MuonTra.Enabled = ThamSoHeThong.Quyen("frm_MuonTra", "sSee");
                    bbTK_CVDEN.Enabled = ThamSoHeThong.Quyen("frm_CongVanDen_TK", "sSee");
                    bbTK_CVDI.Enabled = ThamSoHeThong.Quyen("frm_CongVanDi_TK", "sSee");

                    bbNKLV.Enabled = ThamSoHeThong.Quyen("frm_NhatKyLamViec", "sSee");
                    bbDanhBaCQ.Enabled = ThamSoHeThong.Quyen("frm_DanhBaCoQuan", "sSee");
                    bbDanhba.Enabled = ThamSoHeThong.Quyen("frm_DanhBaCaNhan", "sSee");
                }
                else
                {
                    bbPhanQuyen.Enabled = true;
                    bbSaoLuu.Enabled = true;
                    bbPhucHoi.Enabled = true;
                    bbThongTin.Enabled = true;

                    bbDM_LoaiVB.Enabled = true;
                    bbDM_CQBH.Enabled = true;
                    bbDM_CQNCV.Enabled = true;
                    bbDM_DVXL.Enabled = true;
                    bbDM_CBK.Enabled = true;
                    bbDM_CBXL.Enabled = true;
                    bbVTLuu.Enabled = true;

                    bbVT_CVDen.Enabled = true;
                    bbVT_CVDi.Enabled = true;
                    bbSoanVB.Enabled = true; 
                    bbBiennhan.Enabled = true;
                    bbVT_MuonTra.Enabled = true;
                    bbTK_CVDEN.Enabled = true;
                    bbTK_CVDI.Enabled = true;

                    bbNKLV.Enabled = true;
                    bbDanhBaCQ.Enabled = true;
                    bbDanhba.Enabled = true;
                }
                ThamSoHeThong.TrangThaiLogin = true;
                if (checkAddForm("Bàn làm việc"))
                {
                    frm_About2 CongVanDen = new frm_About2();
                    CongVanDen.Text = "Bàn làm việc";
                    CongVanDen.TopLevel = false;
                    CongVanDen.MdiParent = this;
                    CongVanDen.Button_Clicked += new EventHandler(frm_OpenForm_Clicked);
                    CongVanDen.Show();
                }
                bbQLCV_TenAdmin.Caption = "Xin chào " + ThamSoHeThong.TenNhanVien + " !";
                ServerMail();
                #region --------- Check form main
                timer1.Start();                
                #endregion
            }
            catch
            { }
        }


        #region----------THÔNG TIN: TÊN SERVER, DATA, USERNAME, VERSION       
        private void ServerMail()
        {
            try
            {
                //Doc file xml
                string Des1 = Application.StartupPath + "\\AccountMail.xml";
                if (File.Exists(Des1))
                {
                    XmlTextReader reader = new XmlTextReader("AccountMail.xml");
                    XmlNodeType type;
                    while (reader.Read())
                    {
                        type = reader.NodeType;
                        if (type == XmlNodeType.Element)
                        {
                            if (reader.Name == "Servser")
                            {
                                reader.Read();
                                ThamSoHeThong.Server = MD5.GMMD5_2(reader.Value);
                            }
                            if (reader.Name == "Port")
                            {
                                reader.Read();
                                ThamSoHeThong.Port = Convert.ToInt32(MD5.GMMD5_2(reader.Value));
                            }
                            if (reader.Name == "SSL")
                            {
                                reader.Read();
                                ThamSoHeThong.SSL = Convert.ToBoolean(MD5.GMMD5_2(reader.Value));
                            }
                            if (reader.Name == "Account")
                            {
                                reader.Read();
                                ThamSoHeThong.Account = MD5.GMMD5_2(reader.Value);
                            }
                            if (reader.Name == "Password")
                            {
                                reader.Read();
                                ThamSoHeThong.Password = MD5.GMMD5_2(reader.Value);
                                break;
                            }
                        }
                    }
                    reader.Close();
                }
            }
            catch
            {
            }
        }
        #endregion
        #region ----------------------------------------------------------------------------------------------------------------------------
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            string skin = defaultLookAndFeel1.LookAndFeel.SkinName;
            string fileName = Application.StartupPath.ToString() + @"\Skin.txt";
            StreamWriter objWrite = new StreamWriter(fileName, false);
            objWrite.Write(skin);
            objWrite.Close();
        }
        
        private void bbThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                foreach (var frm in MdiChildren) frm.Close();
                bbQLCV_TenAdmin.Caption = "Xin chào !";
                rbHeThong.Visible = false;
                rbDanhMuc.Visible = false;
                rbCongVan.Visible = false;
                rbTienIch.Visible = false;
                Ribbon.SelectedPage = rbTroGiup;
                ribbonLogin.Visible = true;
                frm_Login login = new frm_Login();
                login.AutoLogin = false;
                login.Button_Clicked += new EventHandler(frm_Button_Clicked);
                login.ShowDialog();
            }
            catch { }
        }

        private void bbAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_About About = new frm_About();
            About.ShowDialog();
        }

        private void bbHotro_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //nó gọi cái file exe thoi
                System.Diagnostics.Process.Start(Application.StartupPath + "\\TeamViewer.exe");
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Không tìm thấy Teamviewer !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bbDanhMuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (checkAddForm(bbDM_LoaiVB.Caption))
            {
                QuanLyCongVan.DanhMuc.ucLoaiVanban LoaiVanban = new QuanLyCongVan.DanhMuc.ucLoaiVanban();
                LoaiVanban.Text = bbDM_LoaiVB.Caption;
                LoaiVanban.TopLevel = false;
                LoaiVanban.MdiParent = this;
                LoaiVanban.Show();
            }
        }

        private void bbMatkhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_Doimatkhau Doimk = new frm_Doimatkhau();
            Doimk.User = ThamSoHeThong.TenDangNhap;
            Doimk.ShowDialog();
        }

        private void bbDanhba_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (checkAddForm("Danh bạ cá nhân"))
            {
                frm_DanhBaCaNhan Danhba = new frm_DanhBaCaNhan();
                Danhba.Text = "Danh bạ cá nhân";
                Danhba.TopLevel = false;
                Danhba.MdiParent = this;
                Danhba.Show();
            }
        }

        private void bbSaoLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_SaoLuu Saoluu = new frm_SaoLuu();
            Saoluu.GetFirstValue = lbDT.Caption;
            Saoluu.ShowDialog();
        }

        private void bbPhucHoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_Phuchoi PhucHoi = new frm_Phuchoi();
            PhucHoi.GetFirstValue = lbDT.Caption;
            PhucHoi.ShowDialog();
        }

        private void bbPhanQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (checkAddForm(bbPhanQuyen.Caption))
            {
                frm_Phanquyen PhucHoi = new frm_Phanquyen();
                PhucHoi.Text = bbPhanQuyen.Caption;
                PhucHoi.TopLevel = false;
                PhucHoi.MdiParent = this;
                PhucHoi.Show();
            }
        }

        private void bbThongTin_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_InfoCompany InfoCompany = new frm_InfoCompany();
            InfoCompany.ShowDialog();
        }
                
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Maximized;
        }        

        private void Main_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
            else
            {
                notifyIcon1.Visible = false;
            }
        }

        #endregion
        

        #region -----Button
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int description, int reservedValue);
        public static bool IsConnectedToInternet()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }
        int dem = 0;
        int demsaoluu = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dem >= 60)
            {
                if (bbQLCV_CongVanDen.Enabled == true)
                {
                    int Dong = CongVan.SELECT_CHUAXEM(ThamSoHeThong.MaNhanVien);
                    string ThongBao = "";
                    if (Dong > 0)
                    {
                        ThongBao = Dong + " công văn mới";
                    }
                    if (Dong > 0)
                    {
                        notifyIcon1.Visible = true;
                        notifyIcon1.BalloonTipTitle = "Thông báo";
                        notifyIcon1.BalloonTipText = "Bạn có " + ThongBao;
                        notifyIcon1.ShowBalloonTip(10000);
                    }
                }
                dem = 0;
            }

            dem++;
            if (demsaoluu >= 7200)
            {
                try
                {
                    string ThuMuc = "D:\\Data_QLCV";
                    string NoiLuu = ThuMuc + "\\Temp\\";
                    //Xóa file zip trong thư mục
                    DirectoryInfo d = new DirectoryInfo(NoiLuu);
                    foreach (var file in d.GetFiles())
                    {
                        File.Delete(file.FullName);
                    }

                    string FileName = "QLCV-" + DateTime.Now.ToString("ddMMyy-HHmmss");
                    string FileBak = ThuMuc + "\\Temp\\" + FileName + ".bak";
                    string FileZip = ThuMuc + "\\" + FileName + ".zip.qlcv";
                    string FolderTemp = ThuMuc + "\\Temp";
                    if (!Directory.Exists(FolderTemp))
                    {
                        Directory.CreateDirectory(FolderTemp);
                        DirectoryInfo theFolder = new DirectoryInfo(FolderTemp);
                        theFolder.Attributes = FileAttributes.Hidden;//Cho ẩn
                    }
                    //Sao lưu trước
                    Data.BACKUP_DATABASE(FileBak, lbDT.Caption);
                    //nén zip
                    CreateSample(FileZip, "", FolderTemp);

                    //xóa file bak
                    File.Delete(FileBak);
                }
                catch { }
                demsaoluu = 0;
            }
            demsaoluu++;
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

        private void bbDanhBaCQ_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (checkAddForm("Danh bạ cơ quan"))
            {
                frm_DanhBaCoQuan DanhBaCoQuan = new frm_DanhBaCoQuan();
                DanhBaCoQuan.Text = "Danh bạ cơ quan";
                DanhBaCoQuan.TopLevel = false;
                DanhBaCoQuan.MdiParent = this;
                DanhBaCoQuan.Show();
            }
        }

        private void bbDM_CQBH_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (checkAddForm(bbDM_CQBH.Caption))
            {
                QuanLyCongVan.DanhMuc.ucCQBanHanh CQBanHanh = new QuanLyCongVan.DanhMuc.ucCQBanHanh();
                CQBanHanh.Text = bbDM_CQBH.Caption;
                CQBanHanh.TopLevel = false;
                CQBanHanh.MdiParent = this;
                CQBanHanh.Show();
            }
        }

        private void bbDM_CQNCV_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (checkAddForm("Cơ quan nhận"))
            {
                QuanLyCongVan.DanhMuc.ucCQNhanCV CQNhanCV = new QuanLyCongVan.DanhMuc.ucCQNhanCV();
                CQNhanCV.Text = "Cơ quan nhận";
                CQNhanCV.TopLevel = false;
                CQNhanCV.MdiParent = this;
                CQNhanCV.Show();
            }
        }

        private void bbDM_DVXL_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (checkAddForm(bbDM_DVXL.Caption))
            {
                QuanLyCongVan.DanhMuc.ucPhongBan CQNhanCV = new QuanLyCongVan.DanhMuc.ucPhongBan();
                CQNhanCV.Text = bbDM_DVXL.Caption;
                CQNhanCV.TopLevel = false;
                CQNhanCV.MdiParent = this;
                CQNhanCV.Show();
            }
        }

        private void bbDM_CBK_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (checkAddForm(bbDM_CBK.Caption))
            {
                QuanLyCongVan.DanhMuc.ucCanBoKy CQNhanCV = new QuanLyCongVan.DanhMuc.ucCanBoKy();
                CQNhanCV.Text = bbDM_CBK.Caption;
                CQNhanCV.TopLevel = false;
                CQNhanCV.MdiParent = this;
                CQNhanCV.Show();
            }
        }

        private void bbDM_CBXL_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (checkAddForm(bbDM_CBXL.Caption))
            {
                QuanLyCongVan.DanhMuc.ucCanBoXuLy CQNhanCV = new QuanLyCongVan.DanhMuc.ucCanBoXuLy();
                CQNhanCV.Text = bbDM_CBXL.Caption;
                CQNhanCV.TopLevel = false;
                CQNhanCV.MdiParent = this;
                CQNhanCV.Show();
            }
        }

        private void bbNKLV_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (checkAddForm(bbNKLV.Caption))
            {
                QuanLyCongVan.NhatKyLamViec.frm_NhatKyLamViec NhatKy = new QuanLyCongVan.NhatKyLamViec.frm_NhatKyLamViec();
                NhatKy.Text = bbNKLV.Caption;
                NhatKy.TopLevel = false;
                NhatKy.MdiParent = this;
                NhatKy.Show();
            }
        }    
        #endregion




        private void bLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_Login login = new frm_Login();
            login.AutoLogin = true;
            login.Button_Clicked += new EventHandler(frm_Button_Clicked);
            login.ShowDialog();
        }

        private void bbVTLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (checkAddForm("Vị trí lưu"))
            {
                DanhMuc.frm_ViTriLuu ViTriLuu = new DanhMuc.frm_ViTriLuu();
                ViTriLuu.Text = "Vị trí lưu";
                ViTriLuu.TopLevel = false;
                ViTriLuu.MdiParent = this;
                ViTriLuu.Show();
            }
        }
        
        private void bbMuonTra_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (checkAddForm("Mượn - trả công văn"))
            {
                MuonTra.frm_MuonTra MuonTra = new MuonTra.frm_MuonTra();
                MuonTra.Text = "Mượn - trả công văn";
                MuonTra.TopLevel = false;
                MuonTra.MdiParent = this;
                MuonTra.Show();
            }
        }

        private void bbNhapAccess_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ThamSoHeThong.TenDangNhap == "admin")
            {
                frm_ChangeData form = new frm_ChangeData();
                form.ShowDialog();
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Bạn không đủ quyền để thực hiện chức năng này !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bbSoanVB_ItemClick(object sender, ItemClickEventArgs e)
        {
            SoanVB form = new SoanVB();
            form.ShowDialog();
        }

        private void bbEmail_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_Mail form = new frm_Mail();
            form.ShowDialog();
        }

        void MdiChild_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (((sender as Form).Text == "Bàn làm việc") && e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                }
            }
            catch { }
        }

        private void MdiManager_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            e.Page.MdiChild.FormClosing += new FormClosingEventHandler(MdiChild_FormClosing);
        }

        public void frm_OpenForm_Clicked(object sender, EventArgs e)
        {
            if (ThamSoHeThong.FormOpen == "CVDEN")
            {
                OpenCVDen();
            }
            else if (ThamSoHeThong.FormOpen == "CVDI")
            {
                OpenCVDi();
            }
            else if (ThamSoHeThong.FormOpen == "TKDEN")
            {
                OpenTKDEN();
            }
            else if (ThamSoHeThong.FormOpen == "TKDI")
            {
                OpenTKDI();
            }
            else if (ThamSoHeThong.FormOpen == "BNHS")
            {
                OpenBNHS();
            }
        }
        private void OpenCVDen()
        {
            if (bbVT_CVDen.Enabled == true)
            {
                if (checkAddForm(bbVT_CVDen.Caption))
                {
                    VT_CongVanDen.frm_VT_CongVanDen_DS CongVanDen = new VT_CongVanDen.frm_VT_CongVanDen_DS();
                    CongVanDen.Text = bbVT_CVDen.Caption;
                    CongVanDen.TopLevel = false;
                    CongVanDen.MdiParent = this;
                    CongVanDen.Show();
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Bạn không đủ quyền truy cập chức năng này !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void OpenCVDi()
        {
            if (bbVT_CVDi.Enabled == true)
            {
                if (checkAddForm(bbVT_CVDi.Caption))
                {
                    VT_CongVanDi.frm_VT_CongVanDi_DS CongVanDi = new VT_CongVanDi.frm_VT_CongVanDi_DS();
                    CongVanDi.Text = bbVT_CVDi.Caption;
                    CongVanDi.TopLevel = false;
                    CongVanDi.MdiParent = this;
                    CongVanDi.Show();
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Bạn không đủ quyền truy cập chức năng này !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void OpenTKDEN()
        {
            if (bbTK_CVDEN.Enabled == true)
            {
                string Name = "Tìm kiếm công văn đến";
                if (checkAddForm(Name))
                {
                    VT_CongVanDen.frm_VT_CongVanDen_TK form = new VT_CongVanDen.frm_VT_CongVanDen_TK();
                    form.Text = Name;
                    form.TopLevel = false;
                    form.MdiParent = this;
                    form.Show();
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Bạn không đủ quyền truy cập chức năng này !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void OpenTKDI()
        {
            if (bbTK_CVDI.Enabled == true)
            {
                string Name = "Tìm kiếm công văn đi";
                if (checkAddForm(Name))
                {
                    VT_CongVanDi.frm_VT_CongVanDi_TK form = new VT_CongVanDi.frm_VT_CongVanDi_TK();
                    form.Text = Name;
                    form.TopLevel = false;
                    form.MdiParent = this;
                    form.Show();
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Bạn không đủ quyền truy cập chức năng này !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OpenBNHS()
        {
            if (bbBiennhan.Enabled == true)
            {
                string Name = "Biên nhận hồ sơ";
                if (checkAddForm(Name))
                {
                    R6_BienNhanHoSo.frm_BienNhanHoSo_DS form = new R6_BienNhanHoSo.frm_BienNhanHoSo_DS();
                    form.Text = Name;
                    form.TopLevel = false;
                    form.MdiParent = this;
                    form.Show();
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Bạn không đủ quyền truy cập chức năng này !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void bbVT_CVDen_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenCVDen();
        }

        private void bbVT_CVDi_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenCVDi();
        }
        private void bbTK_CVDEN_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenTKDEN();
        }

        private void bbTK_CVDI_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenTKDI();
        }

        private void bbBiennhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenBNHS();            
        }

        private void skinRibbonGalleryBarItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}