using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace QuanLyCongVan.Class
{
    public class csBienNhan
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
        public decimal AUTO_ID()
        {
            Open();
            decimal ID = 0;
            try
            {
                DataTable dt = new DataTable();
                string s = "SELECT ID FROM BIENNHAN ORDER BY ID DESC";
                SqlCommand cmd = new SqlCommand(s, con);
                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    ID = 1;
                }
                else
                {
                    ID = Convert.ToDecimal(dt.Rows[0][0].ToString()) + 1;
                }
            }
            catch { ID = 0; }
            return ID;
        }

        //Lấy 1 dòng công văn đến khi sửa
        public DataTable SELECT_BIENNHAN(string ID)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM BIENNHAN WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID); 
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }

        // Insert BIENNHAN
        public void INSERT_BIENNHAN(decimal ID, string SOBN, DateTime NGAYNHAN, decimal SOBAN, string MANV, string TENNV, string CHUCVU, string NGUOIGUI, string NOIDUNG, string GHICHU, string NGUOITAO, DateTime NGAYTAO, string NGUOISUA, DateTime NGAYSUA, bool TRANGTHAI, string DIACHI)
        {
            Open();
            string s = "INSERT INTO BIENNHAN(ID, SOBN, NGAYNHAN, SOBAN, MANV, TENNV, CHUCVU, NGUOIGUI, NOIDUNG, GHICHU, NGUOITAO, NGAYTAO, NGUOISUA, NGAYSUA, TRANGTHAI, DIACHI) VALUES(@ID, @SOBN, @NGAYNHAN, @SOBAN, @MANV, @TENNV, @CHUCVU, @NGUOIGUI, @NOIDUNG, @GHICHU, @NGUOITAO, @NGAYTAO, @NGUOISUA, @NGAYSUA, @TRANGTHAI, @DIACHI)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@SOBN", SOBN);
            cmd.Parameters.AddWithValue("@NGAYNHAN", NGAYNHAN);
            cmd.Parameters.AddWithValue("@SOBAN", SOBAN);
            cmd.Parameters.AddWithValue("@MANV", MANV);
            cmd.Parameters.AddWithValue("@TENNV", TENNV);
            cmd.Parameters.AddWithValue("@CHUCVU", CHUCVU);
            cmd.Parameters.AddWithValue("@NGUOIGUI", NGUOIGUI);
            cmd.Parameters.AddWithValue("@NOIDUNG", NOIDUNG);
            cmd.Parameters.AddWithValue("@GHICHU", GHICHU);
            cmd.Parameters.AddWithValue("@NGUOITAO", NGUOITAO);
            cmd.Parameters.AddWithValue("@NGAYTAO", NGAYTAO);
            cmd.Parameters.AddWithValue("@NGUOISUA", NGUOISUA);
            cmd.Parameters.AddWithValue("@NGAYSUA", NGAYSUA);
            cmd.Parameters.AddWithValue("@TRANGTHAI", TRANGTHAI);
            cmd.Parameters.AddWithValue("@DIACHI", DIACHI);
            cmd.ExecuteNonQuery();
            Close();
        }
        // Update BIENNHAN
        public void UPDATE_BIENNHAN(decimal ID, string SOBN, DateTime NGAYNHAN, decimal SOBAN, string MANV, string TENNV, string CHUCVU, string NGUOIGUI, string NOIDUNG, string GHICHU, string NGUOISUA, DateTime NGAYSUA, bool TRANGTHAI, string DIACHI)
        {
            Open();
            string s = "UPDATE BIENNHAN SET SOBN = @SOBN, NGAYNHAN = @NGAYNHAN, SOBAN = @SOBAN, MANV = @MANV, TENNV = @TENNV, CHUCVU = @CHUCVU, NGUOIGUI = @NGUOIGUI, NOIDUNG = @NOIDUNG, GHICHU = @GHICHU, NGUOISUA = @NGUOISUA, NGAYSUA = @NGAYSUA, TRANGTHAI = @TRANGTHAI, DIACHI = @DIACHI WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@SOBN", SOBN);
            cmd.Parameters.AddWithValue("@NGAYNHAN", NGAYNHAN);
            cmd.Parameters.AddWithValue("@SOBAN", SOBAN);
            cmd.Parameters.AddWithValue("@MANV", MANV);
            cmd.Parameters.AddWithValue("@TENNV", TENNV);
            cmd.Parameters.AddWithValue("@CHUCVU", CHUCVU);
            cmd.Parameters.AddWithValue("@NGUOIGUI", NGUOIGUI);
            cmd.Parameters.AddWithValue("@NOIDUNG", NOIDUNG);
            cmd.Parameters.AddWithValue("@GHICHU", GHICHU);
            cmd.Parameters.AddWithValue("@NGUOISUA", NGUOISUA);
            cmd.Parameters.AddWithValue("@NGAYSUA", NGAYSUA);
            cmd.Parameters.AddWithValue("@TRANGTHAI", TRANGTHAI);
            cmd.Parameters.AddWithValue("@DIACHI", DIACHI);
            cmd.ExecuteNonQuery();
            Close();
        }

        public void DELETE_BIENNHAN(string ID)
        {
            Open();
            string s = "DELETE FROM BIENNHAN WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            Close();
        }





        //Lấy danh sách công văn đến (quản trị admin) theo khoảng thời gian
        public DataTable SELECT_BIENNHAN_TIME(DateTime dtp1, DateTime dtp2)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM BIENNHAN WHERE NGAYNHAN >= @dtp1 AND NGAYNHAN <= @dtp2 ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@dtp1", dtp1);
            cmd.Parameters.AddWithValue("@dtp2", dtp2);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            cmd.CommandTimeout = 0;
            dad.Fill(dt);
            Close();
            return dt;
        }
        



        //Lấy danh sách biên nhận
        public DataTable SELECT_BIENNHAN_ALL()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM BIENNHAN ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            cmd.CommandTimeout = 0;
            dad.Fill(dt);
            Close();
            return dt;
        }

        //Lấy danh sách công văn đến
        public DataTable SELECT_BIENNHAN_TOP(int Top)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT TOP " + Top + " * FROM BIENNHAN ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            cmd.CommandTimeout = 0;
            dad.Fill(dt);
            Close();
            return dt;
        }

        //Lấy danh sách công văn đến
        public DataTable SELECT_BIENNHAN(int Year)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM BIENNHAN WHERE Year(NGAYNHAN) = @Year ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Year", Year);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            cmd.CommandTimeout = 0;
            dad.Fill(dt);
            Close();
            return dt;
        }
    }
}
