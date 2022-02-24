using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;
//using System.Text;
using System.IO;
using System.Xml;
using System.Text;
using System.Security.Cryptography;

namespace QuanLyCongVan
{
    public class clsConnection
    {
        public static string sConnection = connect();
        public static string connect()
        {
            string strDecypt = "";
            string Des1 = Application.StartupPath + "\\ConnectString.xml";
            if (File.Exists(Des1))
            {               
                XmlTextReader reader = new XmlTextReader("ConnectString.xml");
                XmlNodeType type;
                while (reader.Read())
                {
                    type = reader.NodeType;
                    if (type == XmlNodeType.Element)
                    {
                        if (reader.Name == "Connect")
                        {
                            reader.Read();
                            strDecypt = reader.Value;
                        } 
                        if (reader.Name == "Server")
                        {
                            reader.Read();
                            ThamSoHeThong.ServerName = reader.Value;
                        }
                        if (reader.Name == "DataSource")
                        {
                            reader.Read();
                            ThamSoHeThong.DatabaseName = reader.Value;
                        }
                        if (reader.Name == "Folder")
                        {
                            reader.Read();
                            ThamSoHeThong.ThuMucTapTin = reader.Value;
                            break;
                        }
                    }
                }
                reader.Close();
            }
            Class.csMD5 MD5 = new Class.csMD5();
            try
            {
                byte[] keyArr;
                byte[] DeCryptArr = Convert.FromBase64String(strDecypt);
                MD5CryptoServiceProvider MD5Hash = new MD5CryptoServiceProvider();
                keyArr = MD5Hash.ComputeHash(UTF8Encoding.UTF8.GetBytes(MD5.KeyAll));
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
    }
}
