using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyCongVan.Class
{
    public class csLogin
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
        public DataTable GetLogin(string USER, string PASS)
        {
            DataTable dt = new DataTable();
            try
            {
                Open();
                string s = "SELECT * FROM SYS_USER WHERE ID = @USER AND PASS = @PASS";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@USER", USER);
                cmd.Parameters.AddWithValue("@PASS", PASS);
                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.Fill(dt);
                Close();
            }
            catch
            {
                Close();
                DevExpress.XtraEditors.XtraMessageBox.Show("Kết nối cơ sở dữ liệu không thành công, vui lòng vào tùy chỉnh để kết nối data !" , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Close();
            }
            return dt;
        }
        public void UpdateLogin(string USER, string PASS)
        {
            Open();
            string s = "UPDATE SYS_USER SET PASS = @PASS WHERE ID = @USER";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@USER", USER);
            cmd.Parameters.AddWithValue("@PASS", PASS);
            cmd.ExecuteNonQuery();
            Close();
        }
        public string TenPhongBan(string MANV)
        {
            DataTable dt = new DataTable();
            Open();
            string s = "SELECT DVXULY.Name FROM CANBOXULY, DVXULY WHERE CANBOXULY.ID = @MANV AND CANBOXULY.DonViXuLy = DVXULY.ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@MANV", MANV);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            string PhongBan = dt.Rows[0][0].ToString();
            return PhongBan;
        }
    }
}
