using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCongVan.Class
{
    public class csNhatKyLamViec
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
        public DataTable SELECT_NHATKYLAMVIEC_TIME(string MANV, DateTime dtp1, DateTime dtp2)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM NHATKYLAMVIEC WHERE MANV = @MANV AND NGAY >= @dtp1 AND NGAY <= @dtp2 ORDER BY ID ASC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@MANV", MANV);
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
            string s = "SELECT ID FROM NHATKYLAMVIEC ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ID = Convert.ToDecimal(dt.Rows[0]["ID"].ToString()) + 1;
            }
            else
            {
                ID = 1;
            }
            Close();
            return ID;
        }
        
        //Lấy 1 dòng công văn đến khi sửa
        public DataTable SELECT_TRAODOI_MA(decimal ID)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM NHATKYLAMVIEC WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        // Insert NHATKYLAMVIEC
        public void INSERT_NHATKYLAMVIEC(decimal ID, DateTime NGAY, DateTime BATDAU, DateTime KETTHUC, string MANV, string HOTEN, string NOIDUNG, string GHICHU, bool TRANGTHAI, DateTime NGAYTAO, DateTime NGAYSUA, bool XOA)
        {
            Open();
            string s = "INSERT INTO NHATKYLAMVIEC(ID, NGAY, BATDAU, KETTHUC, MANV, HOTEN, NOIDUNG, GHICHU, TRANGTHAI, NGAYTAO, NGAYSUA, XOA) VALUES(@ID, @NGAY, @BATDAU, @KETTHUC, @MANV, @HOTEN, @NOIDUNG, @GHICHU, @TRANGTHAI, @NGAYTAO, @NGAYSUA, @XOA)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@NGAY", NGAY);
            cmd.Parameters.AddWithValue("@BATDAU", BATDAU);
            cmd.Parameters.AddWithValue("@KETTHUC", KETTHUC);
            cmd.Parameters.AddWithValue("@MANV", MANV);
            cmd.Parameters.AddWithValue("@HOTEN", HOTEN);
            cmd.Parameters.AddWithValue("@NOIDUNG", NOIDUNG);
            cmd.Parameters.AddWithValue("@GHICHU", GHICHU);
            cmd.Parameters.AddWithValue("@TRANGTHAI", TRANGTHAI);
            cmd.Parameters.AddWithValue("@NGAYTAO", NGAYTAO);
            cmd.Parameters.AddWithValue("@NGAYSUA", NGAYSUA);
            cmd.Parameters.AddWithValue("@XOA", XOA);
            cmd.ExecuteNonQuery();
            Close();
        }
        
        public void UPDATE_NHATKYLAMVIEC(decimal ID, DateTime NGAY, DateTime BATDAU, DateTime KETTHUC, string MANV, string HOTEN, string NOIDUNG, string GHICHU, bool TRANGTHAI, DateTime NGAYSUA, bool XOA)
        {
            Open();
            string s = "UPDATE NHATKYLAMVIEC SET NGAY = @NGAY, BATDAU = @BATDAU, KETTHUC = @KETTHUC, MANV = @MANV, HOTEN = @HOTEN, NOIDUNG = @NOIDUNG, GHICHU = @GHICHU, TRANGTHAI = @TRANGTHAI, NGAYSUA = @NGAYSUA, XOA = @XOA WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@NGAY", NGAY);
            cmd.Parameters.AddWithValue("@BATDAU", BATDAU);
            cmd.Parameters.AddWithValue("@KETTHUC", KETTHUC);
            cmd.Parameters.AddWithValue("@MANV", MANV);
            cmd.Parameters.AddWithValue("@HOTEN", HOTEN);
            cmd.Parameters.AddWithValue("@NOIDUNG", NOIDUNG);
            cmd.Parameters.AddWithValue("@GHICHU", GHICHU);
            cmd.Parameters.AddWithValue("@TRANGTHAI", TRANGTHAI);
            cmd.Parameters.AddWithValue("@NGAYSUA", NGAYSUA);
            cmd.Parameters.AddWithValue("@XOA", XOA);
            cmd.ExecuteNonQuery();
            Close();
        }
        // Delete NHATKYLAMVIEC
        public void DELETE_NHATKYLAMVIEC(decimal ID)
        {
            Open();
            string s = "DELETE FROM NHATKYLAMVIEC WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            Close();
        }

    }
}
