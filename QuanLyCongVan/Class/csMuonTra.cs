using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCongVan.Class
{
    public class csMuonTra
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


        //Lấy danh sách theo thời gian
        public DataTable SELECT_MUONTRA_TIME(DateTime dtp1, DateTime dtp2)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM MUONTRA WHERE NGAYMUON >= @dtp1 AND NGAYMUON <= @dtp2 ORDER BY MA ASC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@dtp1", dtp1);
            cmd.Parameters.AddWithValue("@dtp2", dtp2);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            cmd.CommandTimeout = 0;
            dad.Fill(dt);
            Close();
            return dt;
        }
        public decimal AUTO_ID()
        {
            Open();
            decimal ID = 0;
            DataTable dt = new DataTable();
            string s = "SELECT MA FROM MUONTRA ORDER BY MA DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ID = Convert.ToDecimal(dt.Rows[0][0].ToString()) + 1;
            }
            else
            {
                ID = 1;
            }
            Close();
            return ID;
        }
        
        //Lấy 1 dòng công văn đến khi sửa
        public DataTable SELECT_MUONTRA_MA(decimal MA)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM MUONTRA WHERE MA = @MA";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@MA", MA);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }



        // Insert MUONTRA
        public void INSERT_MUONTRA(decimal MA, string MACV, string NOIDUNG, DateTime NGAYMUON, DateTime NGAYTRA, string NGUOIMUON, string NGUOITRA, string GHICHU, string TRANGTHAI, DateTime NGAYCV)
        {
            Open();
            string s = "INSERT INTO MUONTRA(MA, MACV, NOIDUNG, NGAYMUON, NGAYTRA, NGUOIMUON, NGUOITRA, GHICHU, TRANGTHAI, NGAYCV) VALUES(@MA, @MACV, @NOIDUNG, @NGAYMUON, @NGAYTRA, @NGUOIMUON, @NGUOITRA, @GHICHU, @TRANGTHAI, @NGAYCV)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@MA", MA);
            cmd.Parameters.AddWithValue("@MACV", MACV);
            cmd.Parameters.AddWithValue("@NOIDUNG", NOIDUNG);
            cmd.Parameters.AddWithValue("@NGAYMUON", NGAYMUON);
            cmd.Parameters.AddWithValue("@NGAYTRA", NGAYTRA);
            cmd.Parameters.AddWithValue("@NGUOIMUON", NGUOIMUON);
            cmd.Parameters.AddWithValue("@NGUOITRA", NGUOITRA);
            cmd.Parameters.AddWithValue("@GHICHU", GHICHU);
            cmd.Parameters.AddWithValue("@TRANGTHAI", TRANGTHAI);
            cmd.Parameters.AddWithValue("@NGAYCV", NGAYCV);
            cmd.ExecuteNonQuery();
            Close();
        }
        // Update MUONTRA
        public void UPDATE_MUONTRA(decimal MA, string MACV, string NOIDUNG, DateTime NGAYMUON, DateTime NGAYTRA, string NGUOIMUON, string NGUOITRA, string GHICHU, string TRANGTHAI, DateTime NGAYCV)
        {
            Open();
            string s = "UPDATE MUONTRA SET MACV = @MACV, NOIDUNG = @NOIDUNG, NGAYMUON = @NGAYMUON, NGAYTRA = @NGAYTRA, NGUOIMUON = @NGUOIMUON, NGUOITRA = @NGUOITRA, GHICHU = @GHICHU, TRANGTHAI = @TRANGTHAI, NGAYCV = @NGAYCV WHERE MA = @MA";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@MA", MA);
            cmd.Parameters.AddWithValue("@MACV", MACV);
            cmd.Parameters.AddWithValue("@NOIDUNG", NOIDUNG);
            cmd.Parameters.AddWithValue("@NGAYMUON", NGAYMUON);
            cmd.Parameters.AddWithValue("@NGAYTRA", NGAYTRA);
            cmd.Parameters.AddWithValue("@NGUOIMUON", NGUOIMUON);
            cmd.Parameters.AddWithValue("@NGUOITRA", NGUOITRA);
            cmd.Parameters.AddWithValue("@GHICHU", GHICHU);
            cmd.Parameters.AddWithValue("@TRANGTHAI", TRANGTHAI);
            cmd.Parameters.AddWithValue("@NGAYCV", NGAYCV);
            cmd.ExecuteNonQuery();
            Close();
        }
        // Delete NHATKYLAMVIEC
        public void DELETE_MUONTRA(decimal MA)
        {
            Open();
            string s = "DELETE FROM MUONTRA WHERE MA = @MA";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@MA", MA);
            cmd.ExecuteNonQuery();
            Close();
        }

    }
}
