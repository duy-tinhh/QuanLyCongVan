using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Xml;
using System.Runtime.InteropServices;
using System.Management;

namespace QuanLyCongVan.Class
{
    public class csKiemTraSoDT
    {

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int description, int reservedValue);
        public bool IsConnectedToInternet()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }

        public bool KiemTraEmail(string emailVerify)
        {
            using (WebClient webclient = new WebClient())
            {
                string url = "http://www.validateemailaddress.org/";
                NameValueCollection formData = new NameValueCollection();
                formData["check"] = emailVerify;
                byte[] responseBytes = webclient.UploadValues(url, "POST", formData);
                string response = Encoding.ASCII.GetString(responseBytes);
                if (response.Contains("Result: Ok"))
                {
                    return true;
                }
                return false;
            }
        }
        public bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        public bool KiemTraSoDienThoai(string SoDT)
        {
            bool TrangThai = true;
            if ((SoDT.Length != 10) && (SoDT.Length != 11))
            {
                return false;
            }   
            string SoKHong = SoDT.Substring(0, 1);
            if (SoKHong != "0")
            {
                return false;
            }
            string DauSo = SoDT.Substring(0, SoDT.Length - 7);
            if (NhaMangDiDong(DauSo) == false)
            {
                return false;
            }           
            return TrangThai;
        }
        private static readonly string[] DayDauSoDiDong = new string[]
        {
            "090","093","0120","0121","0122","0126","0128","089",//Mobifone
            "096","097","098","0162","0163","0164","0165","0166","0167","0168","0169","086",//Viettel            
            "091","094","0123","0124","0125","0127","0129","088",//Vinaphone
            "092","0188",//Vietnamobile
            "095",//Sphone
            "0993","0994","0995","0996","0199"//Gphone
        };
        public bool NhaMangDiDong(string str)
        {
            bool dung = false;
            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi
            for (int i = 0; i < DayDauSoDiDong.Length; i++)
            {
               string dauso = DayDauSoDiDong[i];
               if (str == dauso)
                {
                    return true;
                }
            }
            return dung;
        }
        public void sendEMailThroughGmail(string Account, string Password, string EmailTo, string Body)
        {
            try
            {
                //Mail Message
                MailMessage mM = new MailMessage();
                //Mail Address
                mM.From = new MailAddress(Account);
                //receiver email id
                mM.To.Add(EmailTo);
                //subject of the email
                mM.Subject = "QLCV";
                //add the body of the email
                mM.Body = Body;
                mM.IsBodyHtml = true;
                //SMTP client
                SmtpClient sC = new SmtpClient("smtp.gmail.com");
                //port number for Gmail mail
                sC.Port = 587;
                //credentials to login in to Gmail account
                sC.Credentials = new NetworkCredential(Account, Password);
                //enabled SSL
                sC.EnableSsl = true;
                //Send an email
                sC.Send(mM);
            }//end of try block
            catch// (Exception ex)
            {
            }//end of catch
        }
        public string GetHardDiskSerialNo()
        {
            string result = "";
            try
            {
                ManagementClass mangnmt = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection mcol = mangnmt.GetInstances();
                foreach (ManagementObject strt in mcol)
                {
                    string Index = Convert.ToString(strt["Index"]);
                    if (Index == "0")
                        result = Convert.ToString(strt["SerialNumber"]);
                }
            }
            catch { }
            return result;
        }
        Class.csMD5 MD5 = new Class.csMD5();
        public void GuiEmail(string DONVICHUQUAN, string DONVISUDUNG, string DIACHI, string SODT, string FAX, string EMAIL, string WEBSITE, string TINH, string GHICHU, string MADV)
        {
            string Account = "tiennguyen.hotro@gmail.com";
            string Password = "T@hjgad654ghfah";
            string Body = "<br/>" +
                    "Đvcq: <b>" + DONVICHUQUAN + "</b><br/>" +
                    "Đvsd: <b>" + DONVISUDUNG + "</b><br/>" +
                    "Đc: " + DIACHI + "<br/>" +
                    "Tỉnh: " + TINH + "<br/>" +
                    "Điện thoại: " + SODT + "<br/>" +
                    "Fax: " + FAX + "<br/>" +
                    "Email: " + EMAIL + "<br/>" +
                    "Website: " + WEBSITE + "<br/>" +
                    "Ghi chú: " + GHICHU + "<br/>" +
                    "Mã đơn vị: " + MADV + "<br/>" +
                    "Ngày giờ: " + DateTime.Now + "<br/>";
            sendEMailThroughGmail(Account, Password, Account, Body);
        }
        public void GuiEmail_2(string ID, string DONVICHUQUAN, string DONVISUDUNG, string DIACHI, string SODT, string FAX, string EMAIL, string WEBSITE, string TINH, string GHICHU, string MADV, string TenDangNhap, string TenNhanVien, string TenMayTinh, string IP, string MAC)
        {
            string Account = "tiennguyen.hotro@gmail.com";
            string Password = "T@hjgad654ghfah";
            string Body = "<br/>" +
                    "Đvcq: <b>" + DONVICHUQUAN + "</b><br/>" +
                    "Đvsd: <b>" + DONVISUDUNG + "</b><br/>" +
                    "Đc: " + DIACHI + "<br/>" +
                    "Tỉnh: " + TINH + "<br/>" +
                    "Điện thoại: " + SODT + "<br/>" +
                    "Fax: " + FAX + "<br/>" +
                    "Email: " + EMAIL + "<br/>" +
                    "Website: " + WEBSITE + "<br/>" +
                    "Ghi chú: " + GHICHU + "<br/>" +
                    "Mã đơn vị: " + MADV + "<br/>" +
                    "Tài khoản: " + TenDangNhap + "<br/>" +
                    "Người dùng: " + TenNhanVien + "<br/>" +
                    "Máy tính: " + TenMayTinh + "<br/>" +
                    "IP: " + IP + "<br/>" +
                    "Mac: " + MAC + "<br/>" +
                    "HDD: " + GetHardDiskSerialNo().Trim() + "<br/>" +
                    "ID: " + ID + "<br/>" +
                    "Ngày giờ: " + DateTime.Now + "<br/>";
            sendEMailThroughGmail(Account, Password, Account, Body);
        }
    }
}
