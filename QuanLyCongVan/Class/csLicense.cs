using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace QuanLyCongVan.Class
{
    public class csLicense
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

        Class.csMD5 MD5 = new Class.csMD5();

        //Lấy cpu cách cũ
        public string GetCPUId()
        {
            string cpuInfo = String.Empty;
            string temp = String.Empty;
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (cpuInfo == String.Empty)
                {
                    // only return cpuInfo from first CPU 
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                }
            } 
            return cpuInfo;
        }

        //Lấy cpu cách mới
        public static string ExecuteCommandSync(object command)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                string result = proc.StandardOutput.ReadToEnd();
                return result;
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetLicense()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT Sales_ID FROM STO_SALES";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        public string SetSerial_LANN(string Key)
        {
            string C = "";
            string Key2 = Key + "-LANN";
            string Chuoi = MD5.MD5("NG11YENNG@C" + Key2 + "TH@1TR1NH") + MD5.MD5("NG11YENNG@C" + Key2 + "B1NH@N");
            string A = Chuoi;
            for (int i = 0; i < A.Length; i++)
            {
                if (i % 2 == 0)
                {
                    C += A.Substring(i, 1);
                    if ((C.Length == 4) || (C.Length == 9) || (C.Length == 14))
                    {
                        C += "-";
                    }
                    if (C.Length == 19)
                    {
                        break;
                    }
                }
            }
            return C;
        }
        public string SetSerial_WANN(string Key)
        {
            string C = "";
            string Key2 = Key + "-WANN";
            string Chuoi = MD5.MD5("NG11YENNG@C" + Key2 + "TH@1TR1NH") + MD5.MD5("NG11YENNG@C" + Key2 + "B1NH@N");
            string A = Chuoi;
            for (int i = 0; i < A.Length; i++)
            {
                if (i % 2 == 0)
                {
                    C += A.Substring(i, 1);
                    if ((C.Length == 4) || (C.Length == 9) || (C.Length == 14))
                    {
                        C += "-";
                    }
                    if (C.Length == 19)
                    {
                        break;
                    }
                }
            }
            return C;
        }


        public string Get_MAC()
        {
            //MAC
            string M = MAC_ID();//Lấy mac ip
            M = M.Replace("-", "");//Xoá dấu "-"
            string Chuoi = MD5.MD5("NG11YENNG@C" + M + "TH@1TR1NH");
            string A = Chuoi + MAC_ID();
            string C = "";
            for (int i = 0; i < A.Length; i++)
            {
                if (i % 2 == 0)
                {
                    C += A.Substring(i, 1);
                    if ((C.Length == 4) || (C.Length == 9) || (C.Length == 14))
                    {
                        C += "-";
                    }
                    if (C.Length == 19)
                    {
                        break;
                    }
                }
            }
            return C;
        }
        string MAC_ID()
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
    }
}
