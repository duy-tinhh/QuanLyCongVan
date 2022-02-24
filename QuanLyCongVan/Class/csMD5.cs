using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Xml;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Management;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using IWshRuntimeLibrary;
using System.Net.Mail;
using Microsoft.Win32;
using NetFwTypeLib;

namespace QuanLyCongVan.Class
{
    public class csMD5
    {
        SqlConnection con = new SqlConnection(clsConnection.sConnection);
        public void Open()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void Close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public string KeyAll = "@chinh#";

        #region --- Tạo Shortcut Desktop
        //Tạo ShortCut cho app
        ////MD5.CreateShortcut("Quan Ly Phong Kham", Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory), Assembly.GetExecutingAssembly().Location);                

        //Add 2 refenrence: Windows Script Host Object Model, Microsoft.CSharp
        //Refesh desktop
        [System.Runtime.InteropServices.DllImport("Shell32.dll")]
        private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);
        //Tạo shortcut
        public void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation)
        {
            try
            {
                string startUpFolderPath = shortcutPath;
                DirectoryInfo di = new DirectoryInfo(startUpFolderPath);
                FileInfo[] files = di.GetFiles("*.lnk");
                foreach (FileInfo fi in files)
                {
                    string shortcutTargetFile = GetTargetPath(fi.FullName);
                    if (shortcutTargetFile == targetFileLocation)
                    {
                        string TenShortcut = fi.Name;
                        if (TenShortcut != shortcutName + ".lnk")
                        {
                            System.IO.File.Delete(fi.FullName);
                            SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero);
                        }
                    }
                }
                string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
                shortcut.WorkingDirectory = Application.StartupPath;
                shortcut.Description = shortcutName;   // The description of the shortcut
                shortcut.IconLocation = Application.StartupPath + @"\IconApp.ico";
                shortcut.TargetPath = targetFileLocation;                 // The path of the file that will launch when the shortcut is run
                shortcut.Save();// Save the shortcut
            }
            catch
            {
            }
        }
        //Kiem tra shortcut
        public static string GetTargetPath(string filePath)
        {
            string targetPath = ResolveMsiShortcut(filePath);
            if (targetPath == null)
            {
                targetPath = ResolveShortcut(filePath);
            }

            return targetPath;
        }
        static string ResolveShortcut(string filePath)
        {
            // IWshRuntimeLibrary is in the COM library "Windows Script Host Object Model"
            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            try
            {
                IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(filePath);
                return shortcut.TargetPath;
            }
            catch (COMException)
            {
                // A COMException is thrown if the file is not a valid shortcut (.lnk) file 
                return null;
            }
        }
        static string ResolveMsiShortcut(string file)
        {
            StringBuilder product = new StringBuilder(NativeMethods.MaxGuidLength + 1);
            StringBuilder feature = new StringBuilder(NativeMethods.MaxFeatureLength + 1);
            StringBuilder component = new StringBuilder(NativeMethods.MaxGuidLength + 1);

            NativeMethods.MsiGetShortcutTarget(file, product, feature, component);

            int pathLength = NativeMethods.MaxPathLength;
            StringBuilder path = new StringBuilder(pathLength);

            NativeMethods.InstallState installState = NativeMethods.MsiGetComponentPath(product.ToString(), component.ToString(), path, ref pathLength);
            if (installState == NativeMethods.InstallState.Local)
            {
                return path.ToString();
            }
            else
            {
                return null;
            }
        }
        private class NativeMethods
        {
            [DllImport("msi.dll", CharSet = CharSet.Auto)]
            public static extern uint MsiGetShortcutTarget(string targetFile, StringBuilder productCode, StringBuilder featureID, StringBuilder componentCode);

            [DllImport("msi.dll", CharSet = CharSet.Auto)]
            public static extern InstallState MsiGetComponentPath(string productCode, string componentCode, StringBuilder componentPath, ref int componentPathBufferSize);

            public const int MaxFeatureLength = 38;
            public const int MaxGuidLength = 38;
            public const int MaxPathLength = 1024;

            public enum InstallState
            {
                NotUsed = -7,
                BadConfig = -6,
                Incomplete = -5,
                SourceAbsent = -4,
                MoreData = -3,
                InvalidArg = -2,
                Unknown = -1,
                Broken = 0,
                Advertised = 1,
                Removed = 1,
                Absent = 2,
                Local = 3,
                Source = 4,
                Default = 5
            }
        }
        #endregion



        public string MHMD5(string strEnCrypt)
        {
            try
            {
                byte[] keyArr;
                byte[] EnCryptArr = UTF8Encoding.UTF8.GetBytes(strEnCrypt);
                MD5CryptoServiceProvider MD5Hash = new MD5CryptoServiceProvider();
                keyArr = MD5Hash.ComputeHash(UTF8Encoding.UTF8.GetBytes(KeyAll));
                TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider();
                tripDes.Key = keyArr;
                tripDes.Mode = CipherMode.ECB;
                tripDes.Padding = PaddingMode.PKCS7;
                ICryptoTransform transform = tripDes.CreateEncryptor();
                byte[] arrResult = transform.TransformFinalBlock(EnCryptArr, 0, EnCryptArr.Length);
                return Convert.ToBase64String(arrResult, 0, arrResult.Length);          
            }
            catch
            {
            }
            return "";
        }
        public  string GMMD5(string strDecypt)
        {
            try
            {
                byte[] keyArr;
                byte[] DeCryptArr = Convert.FromBase64String(strDecypt);
                MD5CryptoServiceProvider MD5Hash = new MD5CryptoServiceProvider();
                keyArr = MD5Hash.ComputeHash(UTF8Encoding.UTF8.GetBytes(KeyAll));
                TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider();
                tripDes.Key = keyArr;
                tripDes.Mode = CipherMode.ECB;
                tripDes.Padding = PaddingMode.PKCS7;
                ICryptoTransform transform = tripDes.CreateDecryptor();
                byte[] arrResult = transform.TransformFinalBlock(DeCryptArr, 0, DeCryptArr.Length);
                return UTF8Encoding.UTF8.GetString(arrResult);
            }
            catch
            {
            }
            return "";
        }
        public string MHMD5_2(string strEnCrypt)
        {
            try
            {
                byte[] keyArr;
                byte[] EnCryptArr = UTF8Encoding.UTF8.GetBytes(strEnCrypt);
                MD5CryptoServiceProvider MD5Hash = new MD5CryptoServiceProvider();
                keyArr = MD5Hash.ComputeHash(UTF8Encoding.UTF8.GetBytes(KeyAll));
                TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider();
                tripDes.Key = keyArr;
                tripDes.Mode = CipherMode.ECB;
                tripDes.Padding = PaddingMode.PKCS7;
                ICryptoTransform transform = tripDes.CreateEncryptor();
                byte[] arrResult = transform.TransformFinalBlock(EnCryptArr, 0, EnCryptArr.Length);
                return Convert.ToBase64String(arrResult, 0, arrResult.Length);
            }
            catch
            {
            }
            return "";
        }
        public string GMMD5_2(string strDecypt)
        {
            try
            {
                byte[] keyArr;
                byte[] DeCryptArr = Convert.FromBase64String(strDecypt);
                MD5CryptoServiceProvider MD5Hash = new MD5CryptoServiceProvider();
                keyArr = MD5Hash.ComputeHash(UTF8Encoding.UTF8.GetBytes(KeyAll));
                TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider();
                tripDes.Key = keyArr;
                tripDes.Mode = CipherMode.ECB;
                tripDes.Padding = PaddingMode.PKCS7;
                ICryptoTransform transform = tripDes.CreateDecryptor();
                byte[] arrResult = transform.TransformFinalBlock(DeCryptArr, 0, DeCryptArr.Length);
                return UTF8Encoding.UTF8.GetString(arrResult);
            }
            catch
            {
            }
            return "";
        }

        public string MD5(string data)
        {
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            byte[] b = System.Text.Encoding.UTF8.GetBytes(data);
            b = MD5.ComputeHash(b);
            StringBuilder s = new StringBuilder();
            foreach (byte p in b)
            {
                s.Append(p.ToString("x").ToUpper());
            }
            return s.ToString();
        }


        public static void AddPortSQL(string portnumber)
        {
            string RuleName = "PortSQL_" + portnumber;
            try
            {
                Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
                var currentProfiles = fwPolicy2.CurrentProfileTypes;
                foreach (INetFwRule rule in fwPolicy2.Rules)
                {
                    if (rule.Name.IndexOf(RuleName) != -1)
                    {
                        INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                        firewallPolicy.Rules.Remove(rule.Name);
                    }
                }
            }
            catch { }
            try
            {
                INetFwRule firewallRule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                firewallRule.Description = "Add port program";
                firewallRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                firewallRule.Enabled = true;
                firewallRule.InterfaceTypes = "All";
                firewallRule.Name = RuleName;
                firewallRule.Protocol = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                firewallRule.LocalPorts = portnumber;
                INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                firewallPolicy.Rules.Add(firewallRule);
            }
            catch { }
        }
        public string MAC_ID()
        {
            string DanhSachMAC = "";
            NetworkInterface[] DanhSachCardMang = NetworkInterface.GetAllNetworkInterfaces();
            PhysicalAddress DiaChiMAC = DanhSachCardMang[0].GetPhysicalAddress();
            byte[] ByteDiaChi = DiaChiMAC.GetAddressBytes();
            for (int j = 0; j < ByteDiaChi.Length; j++)
            {
                DanhSachMAC += ByteDiaChi[j].ToString("X2");
                if (j != ByteDiaChi.Length - 1)
                {
                    DanhSachMAC += "-";
                }
            }
            return DanhSachMAC;
        }

        public string VersionApp()
        {
            string VersionOld = "";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Quan Ly Cong Van\Quan Ly Cong Van");
            RegistryKey key2 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Quan Ly Cong Van\Quan Ly Cong Van");
            if (key != null)
            {
                Object o = key.GetValue("Version");
                if (o != null)
                {
                    Version version = new Version(o as String);
                    VersionOld = version.ToString();
                }
            }
            else if (key2 != null)
            {
                Object o = key2.GetValue("Version");
                if (o != null)
                {
                    Version version = new Version(o as String);
                    VersionOld = version.ToString();
                }
            }
            else
            {
                VersionOld = "1.0.0";
            }
            return VersionOld;
        }


        //Lấy 1 dòng công văn đến khi sửa
        public DataTable SELECT_CONGVANDEN()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM CONGVANDEN";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        //Ghi file XML
        public void WriteXML()
        {            
            try
            {
                string ConnectString = Application.StartupPath + "\\ConnectString.xml";
                if (!System.IO.File.Exists(ConnectString))
                {
                    string MChine = SystemInformation.ComputerName;
                    //Lấy chuổi connect
                    string connect = "Data Source=" + MChine + "\\SQLEXPRESS;Initial Catalog=QLCV;Integrated Security=True";
                    DataTable dts = new DataTable();
                    dts.TableName = "String";
                    dts.Columns.Add("Connect", typeof(string));
                    dts.Columns.Add("Server", typeof(string));
                    dts.Columns.Add("DataSource", typeof(string));
                    connect = MHMD5(connect);
                    dts.Rows.Add(connect, MChine + "\\SQLEXPRESS", "QLCV");
                    DataSet dss = new DataSet();
                    dss.DataSetName = "ConnectString";
                    dss.Tables.Add(dts);
                    dss.WriteXml("ConnectString.xml");
                    Application.Restart();
                }
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Có lỗi trong quá trình tạo file xml !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }

        //method to send email to Gmail
        public void sendEMailThroughGmail2(string EmailTo, string SubjectMail, string BodyMail, string FileAttachment)
        {
            SmtpClient client = new SmtpClient
            {
                Host = ThamSoHeThong.Server,
                Port = ThamSoHeThong.Port,
                EnableSsl = ThamSoHeThong.SSL,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new System.Net.NetworkCredential(ThamSoHeThong.Account, ThamSoHeThong.Password),
                Timeout = 100000
            };
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(ThamSoHeThong.Account);
            mm.To.Add(EmailTo);
            mm.Subject = SubjectMail;
            if (FileAttachment != "")
            {
                mm.Attachments.Add(new Attachment(FileAttachment));
            }
            mm.Body = BodyMail;
            mm.IsBodyHtml = false;
            client.Send(mm);
            client.Dispose();
            mm.Dispose();
        }
     }
}
