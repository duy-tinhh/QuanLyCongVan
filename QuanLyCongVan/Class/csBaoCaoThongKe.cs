using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCongVan.Class
{
    public class csBaoCaoThongKe
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



        //Lấy danh sách công văn đến
        public DataTable SELECT_CONGVANDEN_YEAR(decimal Year)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM CONGVANDEN WHERE Year(NGAYKY) = @Year ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Year", Year);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }








        public int AUTO_ID()
        {
            Open(); 
            int ID = 0;
            DataTable dt = new DataTable();
            string s = "SELECT SOCV FROM CONGVANDEN ORDER BY SOCV DESC";
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


        //Lấy 1 dòng công văn đến khi sửa
        public DataTable SELECT_CONGVANDEN(string ID)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT CONGVANDEN.ID,CONGVANDEN.KYHIEU, CONGVANDEN.ID_LOAIVANBAN,CONGVANDEN.ID_CQBANHANH,CONGVANDEN.ID_CQNHANCV,CONGVANDEN.ID_DVXULY,CONGVANDEN.ID_CANBOKY,CONGVANDEN.ID_CANBOXULY,CONGVANDEN.NGAYKY,CONGVANDEN.NGAYNHAN,CONGVANDEN.NOIDUNG, CONGVANDEN.TIENDO, CONGVANDEN.THUMUC, CONGVANDEN.THUMUC,CONGVANDEN.PHEDUYET,CONGVANDEN.TRANGTHAI,CONGVANDEN.NGAYHETHAN,CONGVANDEN.GHICHU,CONGVANDEN.SOCV, CONGVANDEN.SOBAN, CONGVANDEN.DUAN, CONGVANDEN.VITRILUU, CONGVANDEN.THBAOQUAN, CONGVANDEN.BATDAU, CONGVANDEN.KETTHUC FROM CONGVANDEN WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID); 
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        //Lấy file công văn đến chưa xử lý khi sửa
        public DataTable SELECT_FILE_CVDEN(string ID, string LOAICV)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT FILE_CVDEN.ID,FILE_CVDEN.MACV,FILE_CVDEN.LOAICV,FILE_CVDEN.LOAIFILE,FILE_CVDEN.THUMUC,FILE_CVDEN.TAPTIN,FILE_CVDEN.NGAY,FILE_CVDEN.GHICHU FROM FILE_CVDEN WHERE FILE_CVDEN.MACV = @ID AND FILE_CVDEN.LOAICV = @LOAICV";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@LOAICV", LOAICV);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        // Insert CONGVANDEN
        public void INSERT_CONGVANDEN(string ID, string KYHIEU, string ID_LOAIVANBAN, string ID_CQBANHANH, string ID_CQNHANCV, string ID_DVXULY, string ID_CANBOKY, string ID_CANBOXULY, DateTime NGAYKY, DateTime NGAYNHAN, string NOIDUNG, string TIENDO, string THUMUC, string PHEDUYET, int TRANGTHAI, DateTime NGAYHETHAN, string GHICHU, decimal SOCV, decimal SOBAN, string DUAN, string VITRILUU, string THBAOQUAN, DateTime BATDAU, DateTime KETTHUC)
        {
            Open();
            string s = "INSERT INTO CONGVANDEN(ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC) VALUES(@ID, @KYHIEU, @ID_LOAIVANBAN, @ID_CQBANHANH, @ID_CQNHANCV, @ID_DVXULY, @ID_CANBOKY, @ID_CANBOXULY, @NGAYKY, @NGAYNHAN, @NOIDUNG, @TIENDO, @THUMUC, @PHEDUYET, @TRANGTHAI, @NGAYHETHAN, @GHICHU, @SOCV, @SOBAN, @DUAN, @VITRILUU, @THBAOQUAN, @BATDAU, @KETTHUC)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@KYHIEU", KYHIEU);
            cmd.Parameters.AddWithValue("@ID_LOAIVANBAN", ID_LOAIVANBAN);
            cmd.Parameters.AddWithValue("@ID_CQBANHANH", ID_CQBANHANH);
            cmd.Parameters.AddWithValue("@ID_CQNHANCV", ID_CQNHANCV);
            cmd.Parameters.AddWithValue("@ID_DVXULY", ID_DVXULY);
            cmd.Parameters.AddWithValue("@ID_CANBOKY", ID_CANBOKY);
            cmd.Parameters.AddWithValue("@ID_CANBOXULY", ID_CANBOXULY);
            cmd.Parameters.AddWithValue("@NGAYKY", NGAYKY);
            cmd.Parameters.AddWithValue("@NGAYNHAN", NGAYNHAN);
            cmd.Parameters.AddWithValue("@NOIDUNG", NOIDUNG);
            cmd.Parameters.AddWithValue("@TIENDO", TIENDO);
            cmd.Parameters.AddWithValue("@THUMUC", THUMUC);
            cmd.Parameters.AddWithValue("@PHEDUYET", PHEDUYET);
            cmd.Parameters.AddWithValue("@TRANGTHAI", TRANGTHAI);
            cmd.Parameters.AddWithValue("@NGAYHETHAN", NGAYHETHAN);
            cmd.Parameters.AddWithValue("@GHICHU", GHICHU);
            cmd.Parameters.AddWithValue("@SOCV", SOCV);
            cmd.Parameters.AddWithValue("@SOBAN", SOBAN);
            cmd.Parameters.AddWithValue("@DUAN", DUAN);
            cmd.Parameters.AddWithValue("@VITRILUU", VITRILUU);
            cmd.Parameters.AddWithValue("@THBAOQUAN", THBAOQUAN);
            cmd.Parameters.AddWithValue("@BATDAU", BATDAU);
            cmd.Parameters.AddWithValue("@KETTHUC", KETTHUC);
            cmd.ExecuteNonQuery();
            Close();
        }
        // Update CONGVANDEN
        public void UPDATE_CONGVANDEN(string ID, string KYHIEU, string ID_LOAIVANBAN, string ID_CQBANHANH, string ID_CQNHANCV, string ID_DVXULY, string ID_CANBOKY, string ID_CANBOXULY, DateTime NGAYKY, DateTime NGAYNHAN, string NOIDUNG, string TIENDO, string THUMUC, string PHEDUYET, int TRANGTHAI, DateTime NGAYHETHAN, string GHICHU, decimal SOCV, decimal SOBAN, string DUAN, string VITRILUU, string THBAOQUAN, DateTime BATDAU, DateTime KETTHUC)
        {
            Open();
            string s = "UPDATE CONGVANDEN SET KYHIEU = @KYHIEU, ID_LOAIVANBAN = @ID_LOAIVANBAN, ID_CQBANHANH = @ID_CQBANHANH, ID_CQNHANCV = @ID_CQNHANCV, ID_DVXULY = @ID_DVXULY, ID_CANBOKY = @ID_CANBOKY, ID_CANBOXULY = @ID_CANBOXULY, NGAYKY = @NGAYKY, NGAYNHAN = @NGAYNHAN, NOIDUNG = @NOIDUNG, TIENDO = @TIENDO, THUMUC = @THUMUC, PHEDUYET = @PHEDUYET, TRANGTHAI = @TRANGTHAI, NGAYHETHAN = @NGAYHETHAN, GHICHU = @GHICHU, SOCV = @SOCV, SOBAN = @SOBAN, DUAN = @DUAN, VITRILUU = @VITRILUU, THBAOQUAN = @THBAOQUAN, BATDAU = @BATDAU, KETTHUC = @KETTHUC WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@KYHIEU", KYHIEU);
            cmd.Parameters.AddWithValue("@ID_LOAIVANBAN", ID_LOAIVANBAN);
            cmd.Parameters.AddWithValue("@ID_CQBANHANH", ID_CQBANHANH);
            cmd.Parameters.AddWithValue("@ID_CQNHANCV", ID_CQNHANCV);
            cmd.Parameters.AddWithValue("@ID_DVXULY", ID_DVXULY);
            cmd.Parameters.AddWithValue("@ID_CANBOKY", ID_CANBOKY);
            cmd.Parameters.AddWithValue("@ID_CANBOXULY", ID_CANBOXULY);
            cmd.Parameters.AddWithValue("@NGAYKY", NGAYKY);
            cmd.Parameters.AddWithValue("@NGAYNHAN", NGAYNHAN);
            cmd.Parameters.AddWithValue("@NOIDUNG", NOIDUNG);
            cmd.Parameters.AddWithValue("@TIENDO", TIENDO);
            cmd.Parameters.AddWithValue("@THUMUC", THUMUC);
            cmd.Parameters.AddWithValue("@PHEDUYET", PHEDUYET);
            cmd.Parameters.AddWithValue("@TRANGTHAI", TRANGTHAI);
            cmd.Parameters.AddWithValue("@NGAYHETHAN", NGAYHETHAN);
            cmd.Parameters.AddWithValue("@GHICHU", GHICHU);
            cmd.Parameters.AddWithValue("@SOCV", SOCV);
            cmd.Parameters.AddWithValue("@SOBAN", SOBAN);
            cmd.Parameters.AddWithValue("@DUAN", DUAN);
            cmd.Parameters.AddWithValue("@VITRILUU", VITRILUU);
            cmd.Parameters.AddWithValue("@THBAOQUAN", THBAOQUAN);
            cmd.Parameters.AddWithValue("@BATDAU", BATDAU);
            cmd.Parameters.AddWithValue("@KETTHUC", KETTHUC);
            cmd.ExecuteNonQuery();
            Close();
        }
        
        public void DELETE_CONGVAN(string ID)
        {
            Open();
            string s = "DELETE FROM CONGVANDEN WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            Close();
        }
        //Lấy danh sách công văn đến
        public DataTable SELECT_FILE_CVDEN(string ID)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, MACV, LOAICV, LOAIFILE, THUMUC, TAPTIN, NGAY, GHICHU FROM FILE_CVDEN  WHERE MACV = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        // Insert FILE_CVDEN
        public void INSERT_FILE_CVDEN(string ID, string MACV, string LOAICV, string LOAIFILE, string THUMUC, string TAPTIN, DateTime NGAY, string GHICHU)
        {
            Open();
            string s = "INSERT INTO FILE_CVDEN(ID, MACV, LOAICV, LOAIFILE, THUMUC, TAPTIN, NGAY, GHICHU) VALUES(@ID, @MACV, @LOAICV, @LOAIFILE, @THUMUC, @TAPTIN, @NGAY, @GHICHU)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@MACV", MACV);
            cmd.Parameters.AddWithValue("@LOAICV", LOAICV);
            cmd.Parameters.AddWithValue("@LOAIFILE", LOAIFILE);
            cmd.Parameters.AddWithValue("@THUMUC", THUMUC);
            cmd.Parameters.AddWithValue("@TAPTIN", TAPTIN);
            cmd.Parameters.AddWithValue("@NGAY", NGAY);
            cmd.Parameters.AddWithValue("@GHICHU", GHICHU);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void DELETE_FILE_CVDEN(string ID)
        {
            Open();
            string s = "DELETE FROM FILE_CVDEN WHERE MACV = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            Close();
        }

    }
}
