using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net;
using System.Net.Mail;
using DevExpress.Utils.Menu;
using System.Xml;
using System.IO;

namespace QuanLyCongVan
{
    public partial class frm_Mail : DevExpress.XtraEditors.XtraForm
    {
        public frm_Mail()
        {
            InitializeComponent();
        }
        Class.csKiemTraSoDT KiemTra = new Class.csKiemTraSoDT();
        Class.csMD5 MD5 = new Class.csMD5();
        private void frm_Mail_Load(object sender, EventArgs e)
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
                                txtMayChu.Text = MD5.GMMD5_2(reader.Value);
                            }
                            if (reader.Name == "Port")
                            {
                                reader.Read();
                                txtPort.Text = MD5.GMMD5_2(reader.Value);
                            }
                            if (reader.Name == "SSL")
                            {
                                reader.Read();
                                ckSSL.Checked = Convert.ToBoolean(MD5.GMMD5_2(reader.Value));
                            }
                            if (reader.Name == "Account")
                            {
                                reader.Read();
                                txtEmail.Text = MD5.GMMD5_2(reader.Value);
                            }
                            if (reader.Name == "Password")
                            {
                                reader.Read();
                                txtPass.Text = MD5.GMMD5_2(reader.Value);
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
        
        //method to send email to Gmail
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
                mM.Subject = "Đăng ký tài khoản eSMS Partner";
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

        //method to send email to Gmail
        public void sendEMailThroughGmail2(string Account, string Password, string EmailTo, string Body)
        {  
            string your_id = Account;
            string your_password = Password;
            try
            {
                SmtpClient client = new SmtpClient
                {
                    Host = "mail.softphongkham.com",
                    Port = 587,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(your_id, your_password),
                    Timeout = 10000,
                };
                MailMessage mm = new MailMessage(your_id, EmailTo, "subject", Body);
                client.Send(mm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not end email\n\n" + e.ToString());
            }
        }
        //Method to send email from YAHOO!!
        public void sendEMailThroughYahoo()
        {
            try
            {
                //mail message
                MailMessage mM = new MailMessage();
                //Mail Address
                mM.From = new MailAddress("vanbietdoicodon@yahoo.com");
                //emailid to send
                mM.To.Add("tiennguyencc2013@gmail.com");
                //your subject line of the message
                mM.Subject = "your subject line will go hereasasfasfdasf.";
                //now attached the file
                mM.Attachments.Add(new Attachment(@"C:\\attachedfile.bmp"));
                //add the body of the email
                mM.Body = "Your Body of the email.";
                mM.IsBodyHtml = false;
                //SMTP 
                SmtpClient SmtpServer = new SmtpClient();
                //your credential will go here
                SmtpServer.Credentials = new System.Net.NetworkCredential("vanbietdoicodon@yahoo.com", "");
                //port number to login yahoo server
                SmtpServer.Port = 587;
                //yahoo host name
                SmtpServer.Host = "smtp.mail.yahoo.com";
                //Send the email
                SmtpServer.Send(mM);
            }//end of try block
            catch// (Exception ex)
            {
            }//end of catch
        }

        private void bDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMayChu.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập máy chủ email ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMayChu.Focus();
                }
                else if (txtPort.Value <= 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập port để gửi email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if ((txtEmail.Text.Trim() == "") || (KiemTra.isValidEmail(txtEmail.Text.Trim()) == false))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập đúng email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();
                }
                else if (txtPass.Text.Trim() == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPass.Focus();
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    DataTable dt1 = new DataTable();
                    ThamSoHeThong.Server = txtMayChu.Text.Trim();
                    ThamSoHeThong.Port = Convert.ToInt32(txtPort.Value);
                    ThamSoHeThong.SSL = ckSSL.Checked;
                    ThamSoHeThong.Account= txtEmail.Text;
                    ThamSoHeThong.Password = txtPass.Text;
                    dt1.TableName = "Account";
                    dt1.Columns.Add("Servser", typeof(string));
                    dt1.Columns.Add("Port", typeof(string));
                    dt1.Columns.Add("SSL", typeof(string));
                    dt1.Columns.Add("Account", typeof(string));
                    dt1.Columns.Add("Password", typeof(string));
                    string Servser = MD5.MHMD5_2(txtMayChu.Text.Trim());
                    string Port = MD5.MHMD5_2(txtPort.Text.Trim());
                    string SSL = MD5.MHMD5_2(ckSSL.Checked.ToString());
                    string Account = MD5.MHMD5_2(txtEmail.Text.Trim());
                    string Password = MD5.MHMD5_2(txtPass.Text.Trim());
                    dt1.Rows.Add(Servser, Port, SSL, Account, Password);
                    DataSet ds = new DataSet();
                    ds.DataSetName = "AccountMail";
                    ds.Tables.Add(dt1);
                    ds.WriteXml("AccountMail.xml");
                    MD5.sendEMailThroughGmail2(ThamSoHeThong.Account, "Test mail", " Test mail từ phần mềm quản lý công văn", "");
                    DevExpress.XtraEditors.XtraMessageBox.Show("Lưu cấu hình thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    Cursor.Current = Cursors.Default;
                }
            }
            catch(Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Lưu cấu hình hất bại !"+ Environment.NewLine + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtType.SelectedIndex == 0)
                {
                    txtMayChu.Properties.ReadOnly = false;
                    txtPort.Properties.ReadOnly = false;
                    ckSSL.Properties.ReadOnly = false;
                    txtMayChu.Text = "";
                    txtPort.Text = "";
                    ckSSL.Checked = false;
                    txtMayChu.Focus();
                }
                else if (txtType.SelectedIndex == 1)
                {
                    txtMayChu.Properties.ReadOnly = true;
                    txtPort.Properties.ReadOnly = true;
                    ckSSL.Properties.ReadOnly = true;
                    txtMayChu.Text = "smtp.gmail.com";
                    txtPort.Text = "587";
                    ckSSL.Checked = true;
                    txtEmail.Focus();
                }
                else if (txtType.SelectedIndex == 2)
                {
                    txtMayChu.Properties.ReadOnly = true;
                    txtPort.Properties.ReadOnly = true;
                    ckSSL.Properties.ReadOnly = true;
                    txtMayChu.Text = "smtp.mail.yahoo.com";
                    txtPort.Text = "587";
                    ckSSL.Checked = true;
                    txtEmail.Focus();
                }
                else if (txtType.SelectedIndex == 3)
                {
                    txtMayChu.Properties.ReadOnly = true;
                    txtPort.Properties.ReadOnly = true;
                    ckSSL.Properties.ReadOnly = true;
                    txtMayChu.Text = "smtp.live.com";
                    txtPort.Text = "587";
                    ckSSL.Checked = true;
                    txtEmail.Focus();
                }
            }
            catch
            {
            }
        }

        private void txtPass_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}