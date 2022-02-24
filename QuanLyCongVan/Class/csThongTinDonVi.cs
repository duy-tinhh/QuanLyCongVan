using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCongVan.Class
{
    public class csThongTinDonVi
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

        public DataTable GetData2()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM THONGTINDONVI";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }


        // Insert THONGTINDONVI
        public void INSERT_THONGTINDONVI(int ID, string DONVICHUQUAN, string DONVISUDUNG, string DIACHI, string SODT, string FAX, string EMAIL, string WEBSITE, string TINH, string GHICHU, byte[] LOGO, string XAPHUONG, string HUYENQUAN)
        {
            Open();
            string s = "INSERT INTO THONGTINDONVI(ID, DONVICHUQUAN, DONVISUDUNG, DIACHI, SODT, FAX, EMAIL, WEBSITE, TINH, GHICHU, LOGO, XAPHUONG, HUYENQUAN) VALUES(@ID, @DONVICHUQUAN, @DONVISUDUNG, @DIACHI, @SODT, @FAX, @EMAIL, @WEBSITE, @TINH, @GHICHU, @LOGO, @XAPHUONG, @HUYENQUAN)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@DONVICHUQUAN", DONVICHUQUAN);
            cmd.Parameters.AddWithValue("@DONVISUDUNG", DONVISUDUNG);
            cmd.Parameters.AddWithValue("@DIACHI", DIACHI);
            cmd.Parameters.AddWithValue("@SODT", SODT);
            cmd.Parameters.AddWithValue("@FAX", FAX);
            cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
            cmd.Parameters.AddWithValue("@WEBSITE", WEBSITE);
            cmd.Parameters.AddWithValue("@TINH", TINH);
            cmd.Parameters.AddWithValue("@GHICHU", GHICHU);
            cmd.Parameters.AddWithValue("@LOGO", LOGO);
            cmd.Parameters.AddWithValue("@XAPHUONG", XAPHUONG);
            cmd.Parameters.AddWithValue("@HUYENQUAN", HUYENQUAN);
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            Close();
        }
        // Update THONGTINDONVI
        public void UPDATE_THONGTINDONVI(int ID, string DONVICHUQUAN, string DONVISUDUNG, string DIACHI, string SODT, string FAX, string EMAIL, string WEBSITE, string TINH, string GHICHU, byte[] LOGO, string XAPHUONG, string HUYENQUAN)
        {
            Open();
            string s = "UPDATE THONGTINDONVI SET DONVICHUQUAN = @DONVICHUQUAN, DONVISUDUNG = @DONVISUDUNG, DIACHI = @DIACHI, SODT = @SODT, FAX = @FAX, EMAIL = @EMAIL, WEBSITE = @WEBSITE, TINH = @TINH, GHICHU = @GHICHU, LOGO = @LOGO, XAPHUONG = @XAPHUONG, HUYENQUAN = @HUYENQUAN WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@DONVICHUQUAN", DONVICHUQUAN);
            cmd.Parameters.AddWithValue("@DONVISUDUNG", DONVISUDUNG);
            cmd.Parameters.AddWithValue("@DIACHI", DIACHI);
            cmd.Parameters.AddWithValue("@SODT", SODT);
            cmd.Parameters.AddWithValue("@FAX", FAX);
            cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
            cmd.Parameters.AddWithValue("@WEBSITE", WEBSITE);
            cmd.Parameters.AddWithValue("@TINH", TINH);
            cmd.Parameters.AddWithValue("@GHICHU", GHICHU);
            cmd.Parameters.AddWithValue("@LOGO", LOGO);
            cmd.Parameters.AddWithValue("@XAPHUONG", XAPHUONG);
            cmd.Parameters.AddWithValue("@HUYENQUAN", HUYENQUAN);
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            Close();
        }

        public byte[] GetPic()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT LOGO FROM THONGTINDONVI";
            SqlCommand cmd = new SqlCommand(s, con);
            byte[] b = (byte[])cmd.ExecuteScalar();
            Close();
            return b;
        }
    }
}
