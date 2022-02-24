using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCongVan.Class
{
    public class csDanhBa
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

        public DataTable GetData(string USER_ID)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM DANHBA WHERE USER_ID = @USER_ID ORDER BY ID ASC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@USER_ID", USER_ID);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        public DataTable GetDataID(string ID)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM DANHBA WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }

        public int AUTO_ID()
        {
            Open(); int ID = 0;
            DataTable dt = new DataTable();
            string s = "SELECT ID FROM DANHBA ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ID = Convert.ToInt16(dt.Rows[0][0].ToString()) + 1;
            }
            else
            {
                ID = 1;
            }
            Close();
            return ID;
        }

        public void INSERT_DB(string ID, string TEN, string DIACHI, string COQUAN, string EMAIL, string DIENTHOAI, string FAX, string YAHOO, string SKYPE, string TAIKHOAN, string NGANHANG, string USER_ID, DateTime NGAYSINH)
        {
            Open();
            string s = "INSERT INTO DANHBA(ID, TEN, DIACHI, COQUAN, EMAIL, DIENTHOAI, FAX, YAHOO, SKYPE, TAIKHOAN, NGANHANG, USER_ID, NGAYSINH) VALUES(@ID, @TEN, @DIACHI, @COQUAN, @EMAIL, @DIENTHOAI, @FAX, @YAHOO, @SKYPE, @TAIKHOAN, @NGANHANG, @USER_ID, @NGAYSINH)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@TEN", TEN);
            cmd.Parameters.AddWithValue("@DIACHI", DIACHI);
            cmd.Parameters.AddWithValue("@COQUAN", COQUAN);
            cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
            cmd.Parameters.AddWithValue("@DIENTHOAI", DIENTHOAI);
            cmd.Parameters.AddWithValue("@FAX", FAX);
            cmd.Parameters.AddWithValue("@YAHOO", YAHOO);
            cmd.Parameters.AddWithValue("@SKYPE", SKYPE);
            cmd.Parameters.AddWithValue("@TAIKHOAN", TAIKHOAN);
            cmd.Parameters.AddWithValue("@NGANHANG", NGANHANG);
            cmd.Parameters.AddWithValue("@USER_ID", USER_ID);
            cmd.Parameters.AddWithValue("@NGAYSINH", NGAYSINH);
            cmd.ExecuteNonQuery();
            Close();
        }
        // Update DANHBA
        public void UPDATE_DB(string ID, string TEN, string DIACHI, string COQUAN, string EMAIL, string DIENTHOAI, string FAX, string YAHOO, string SKYPE, string TAIKHOAN, string NGANHANG, string USER_ID, DateTime NGAYSINH)
        {
            Open();
            string s = "UPDATE DANHBA SET TEN = @TEN, DIACHI = @DIACHI, COQUAN = @COQUAN, EMAIL = @EMAIL, DIENTHOAI = @DIENTHOAI, FAX = @FAX, YAHOO = @YAHOO, SKYPE = @SKYPE, TAIKHOAN = @TAIKHOAN, NGANHANG = @NGANHANG, USER_ID = @USER_ID, NGAYSINH = @NGAYSINH WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@TEN", TEN);
            cmd.Parameters.AddWithValue("@DIACHI", DIACHI);
            cmd.Parameters.AddWithValue("@COQUAN", COQUAN);
            cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
            cmd.Parameters.AddWithValue("@DIENTHOAI", DIENTHOAI);
            cmd.Parameters.AddWithValue("@FAX", FAX);
            cmd.Parameters.AddWithValue("@YAHOO", YAHOO);
            cmd.Parameters.AddWithValue("@SKYPE", SKYPE);
            cmd.Parameters.AddWithValue("@TAIKHOAN", TAIKHOAN);
            cmd.Parameters.AddWithValue("@NGANHANG", NGANHANG);
            cmd.Parameters.AddWithValue("@USER_ID", USER_ID);
            cmd.Parameters.AddWithValue("@NGAYSINH", NGAYSINH);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void DELETE_DB(string ID)
        {
            Open();
            string s = "DELETE FROM DANHBA WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            Close();
        }
        public DataTable SELECT_DANHBACQ()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM DANHBACQ ORDER BY ID ASC";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        public void DELETE_DBCQ(string ID)
        {
            Open();
            string s = "DELETE FROM DANHBACQ WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            Close();
        }


        public void INSERT_DBCQ(string ID, string TEN, string DIACHI, string COQUAN, string EMAIL, string DIENTHOAI, string FAX, string YAHOO, string SKYPE, string TAIKHOAN, string NGANHANG)
        {
            Open();
            string s = "INSERT INTO DANHBACQ(ID, TEN, DIACHI, COQUAN, EMAIL, DIENTHOAI, FAX, YAHOO, SKYPE, TAIKHOAN, NGANHANG) VALUES(@ID, @TEN, @DIACHI, @COQUAN, @EMAIL, @DIENTHOAI, @FAX, @YAHOO, @SKYPE, @TAIKHOAN, @NGANHANG)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@TEN", TEN);
            cmd.Parameters.AddWithValue("@DIACHI", DIACHI);
            cmd.Parameters.AddWithValue("@COQUAN", COQUAN);
            cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
            cmd.Parameters.AddWithValue("@DIENTHOAI", DIENTHOAI);
            cmd.Parameters.AddWithValue("@FAX", FAX);
            cmd.Parameters.AddWithValue("@YAHOO", YAHOO);
            cmd.Parameters.AddWithValue("@SKYPE", SKYPE);
            cmd.Parameters.AddWithValue("@TAIKHOAN", TAIKHOAN);
            cmd.Parameters.AddWithValue("@NGANHANG", NGANHANG);
            cmd.ExecuteNonQuery();
            Close();
        }
        // Update DANHBACQ
        public void UPDATE_DBCQ(string ID, string TEN, string DIACHI, string COQUAN, string EMAIL, string DIENTHOAI, string FAX, string YAHOO, string SKYPE, string TAIKHOAN, string NGANHANG)
        {
            Open();
            string s = "UPDATE DANHBACQ SET TEN = @TEN, DIACHI = @DIACHI, COQUAN = @COQUAN, EMAIL = @EMAIL, DIENTHOAI = @DIENTHOAI, FAX = @FAX, YAHOO = @YAHOO, SKYPE = @SKYPE, TAIKHOAN = @TAIKHOAN, NGANHANG = @NGANHANG WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@TEN", TEN);
            cmd.Parameters.AddWithValue("@DIACHI", DIACHI);
            cmd.Parameters.AddWithValue("@COQUAN", COQUAN);
            cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
            cmd.Parameters.AddWithValue("@DIENTHOAI", DIENTHOAI);
            cmd.Parameters.AddWithValue("@FAX", FAX);
            cmd.Parameters.AddWithValue("@YAHOO", YAHOO);
            cmd.Parameters.AddWithValue("@SKYPE", SKYPE);
            cmd.Parameters.AddWithValue("@TAIKHOAN", TAIKHOAN);
            cmd.Parameters.AddWithValue("@NGANHANG", NGANHANG);
            cmd.ExecuteNonQuery();
            Close();
        }
        public DataTable SELECT_DANHBACQ_ID(string ID)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM DANHBACQ WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
    }
}
