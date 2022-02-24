using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace QuanLyCongVan.Class
{
    public class csCongVanDi
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

        string Table_CongVanDen = "CONGVANDI";
        string Table_File = "FILE_CVDI";
        
        public decimal AUTO_ID()
        {
            Open();
            decimal ID = 0;
            try
            {
                DataTable dt = new DataTable();
                string s = "SELECT ID FROM CONGVANDI ORDER BY ID DESC";
                SqlCommand cmd = new SqlCommand(s, con);
                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    ID = 1;
                }
                else
                {
                    ID = Convert.ToDecimal(dt.Rows[0]["ID"].ToString()) + 1;
                }
            }
            catch { ID = 0; }
            return ID;
        }

        //Lấy 1 dòng công văn đến khi sửa
        public DataTable SELECT_CONGVANDI(decimal ID)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM " + Table_CongVanDen + " WHERE ID = @ID ORDER BY SAPXEP ASC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID); 
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        //Lấy ds nhan vien xu ly cong van
        public DataTable SELECT_CONGVANDI_NHANVIENXULY(decimal ID)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT MANV AS ID, TENNV AS Name, DAXEM, NGAYXEM FROM " + Table_CongVanDen + " WHERE ID = @ID AND LOAI = 'NGUOIXEM' ORDER BY SAPXEP ASC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }

        //Lấy ds nhan vien khong xu ly cong van
        public DataTable SELECT_CONGVANDI_NHANVIENXULY_NULL(decimal ID)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT CQNHANCV.ID, CQNHANCV.Name, CVD.MANV FROM CQNHANCV LEFT JOIN (SELECT MANV FROM " + Table_CongVanDen + " WHERE ID = @ID) AS CVD ON CQNHANCV.ID = CVD.MANV WHERE CVD.MANV IS NULL";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }

        // Insert CONGVANDEN
        public void INSERT_CONGVANDI(string MA, decimal ID, string KYHIEU, string ID_LOAIVANBAN, string ID_CQBANHANH, string ID_CQNHANCV, string ID_DVXULY, string ID_CANBOKY, string ID_CANBOXULY, DateTime NGAYKY, DateTime NGAYNHAN, string NOIDUNG, string TIENDO, string THUMUC, string PHEDUYET, int TRANGTHAI, DateTime NGAYHETHAN, string GHICHU, decimal SOCV, int SOBAN, string DUAN, string VITRILUU, string THBAOQUAN, DateTime BATDAU, string KETTHUC, string MANV, string TENNV, string LOAI, bool DAXEM, DateTime NGAYXEM, int SAPXEP, decimal BANSAO, string DOMAT)
        {
            Open();
            string s = "INSERT INTO " + Table_CongVanDen + "(MA, ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, LOAI, DAXEM, NGAYXEM, SAPXEP, BANSAO, DOMAT) VALUES(@MA, @ID, @KYHIEU, @ID_LOAIVANBAN, @ID_CQBANHANH, @ID_CQNHANCV, @ID_DVXULY, @ID_CANBOKY, @ID_CANBOXULY, @NGAYKY, @NGAYNHAN, @NOIDUNG, @TIENDO, @THUMUC, @PHEDUYET, @TRANGTHAI, @NGAYHETHAN, @GHICHU, @SOCV, @SOBAN, @DUAN, @VITRILUU, @THBAOQUAN, @BATDAU, @KETTHUC, @MANV, @TENNV, @LOAI, @DAXEM, @NGAYXEM, @SAPXEP, @BANSAO, @DOMAT)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@MA", MA);
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
            cmd.Parameters.AddWithValue("@MANV", MANV);
            cmd.Parameters.AddWithValue("@TENNV", TENNV);
            cmd.Parameters.AddWithValue("@LOAI", LOAI);
            cmd.Parameters.AddWithValue("@DAXEM", DAXEM);
            cmd.Parameters.AddWithValue("@NGAYXEM", NGAYXEM);
            cmd.Parameters.AddWithValue("@SAPXEP", SAPXEP);
            cmd.Parameters.AddWithValue("@BANSAO", BANSAO);
            cmd.Parameters.AddWithValue("@DOMAT", DOMAT);
            cmd.ExecuteNonQuery();
            Close();
        }
        // Update CONGVANDEN
        public void UPDATE_CONGVANDI(decimal ID, string KYHIEU, string ID_LOAIVANBAN, string ID_CQBANHANH, string ID_CQNHANCV, string ID_DVXULY, string ID_CANBOKY, string ID_CANBOXULY, DateTime NGAYKY, DateTime NGAYNHAN, string NOIDUNG, string TIENDO, string THUMUC, string PHEDUYET, int TRANGTHAI, DateTime NGAYHETHAN, string GHICHU, decimal SOCV, int SOBAN, string DUAN, string VITRILUU, string THBAOQUAN, DateTime BATDAU, string KETTHUC, string MANV, string TENNV, string LOAI, bool DAXEM, DateTime NGAYXEM, int SAPXEP, decimal BANSAO, string DOMAT)
        {
            Open();
            string s = "UPDATE " + Table_CongVanDen + " SET KYHIEU = @KYHIEU, ID_LOAIVANBAN = @ID_LOAIVANBAN, ID_CQBANHANH = @ID_CQBANHANH, ID_CQNHANCV = @ID_CQNHANCV, ID_DVXULY = @ID_DVXULY, ID_CANBOKY = @ID_CANBOKY, ID_CANBOXULY = @ID_CANBOXULY, NGAYKY = @NGAYKY, NGAYNHAN = @NGAYNHAN, NOIDUNG = @NOIDUNG, TIENDO = @TIENDO, THUMUC = @THUMUC, PHEDUYET = @PHEDUYET, TRANGTHAI = @TRANGTHAI, NGAYHETHAN = @NGAYHETHAN, GHICHU = @GHICHU, SOCV = @SOCV, SOBAN = @SOBAN, DUAN = @DUAN, VITRILUU = @VITRILUU, THBAOQUAN = @THBAOQUAN, BATDAU = @BATDAU, KETTHUC = @KETTHUC, MANV = @MANV, TENNV = @TENNV, LOAI = @LOAI, DAXEM = @DAXEM, NGAYXEM = @NGAYXEM, SAPXEP = @SAPXEP, BANSAO = @BANSAO, DOMAT = @DOMAT WHERE ID = @ID";
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
            cmd.Parameters.AddWithValue("@MANV", MANV);
            cmd.Parameters.AddWithValue("@TENNV", TENNV);
            cmd.Parameters.AddWithValue("@LOAI", LOAI);
            cmd.Parameters.AddWithValue("@DAXEM", DAXEM);
            cmd.Parameters.AddWithValue("@NGAYXEM", NGAYXEM);
            cmd.Parameters.AddWithValue("@SAPXEP", SAPXEP);
            cmd.Parameters.AddWithValue("@BANSAO", BANSAO);
            cmd.Parameters.AddWithValue("@DOMAT", DOMAT);
            cmd.ExecuteNonQuery();
            Close();
        }
        
        public void DELETE_CONGVANDI(decimal ID)
        {
            Open();
            string s = "DELETE FROM " + Table_CongVanDen + " WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            Close();
        }
        //Trang thai chua xem cong van đến
        public int SELECT_CHUAXEM(string MANV)
        {
            Open();
            int Row = 0;
            DataTable dt = new DataTable();
            string s = "SELECT MANV, DAXEM FROM " + Table_CongVanDen + " WHERE MANV = @MANV AND DAXEM = 'False'";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@MANV", MANV);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Row = dt.Rows.Count;
            Close();
            return Row;
        }

        //Update trạng thái nhân viên xem công văn
        public void UPDATE_CONGVANDI_DAXEM(decimal ID, string MANV)
        {
            Open();
            string s = "UPDATE " + Table_CongVanDen + " SET DAXEM = 'True' WHERE ID = @ID AND MANV = @MANV";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@MANV", MANV);
            cmd.ExecuteNonQuery();
            Close();
        }




        //Lấy danh sách công văn đến (quản trị admin) theo khoảng thời gian
        public DataTable SELECT_CONGVAN_TIME(DateTime dtp1, DateTime dtp2)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC FROM " + Table_CongVanDen + " WHERE NGAYKY >= @dtp1 AND NGAYKY <= @dtp2 GROUP BY ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@dtp1", dtp1);
            cmd.Parameters.AddWithValue("@dtp2", dtp2);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            cmd.CommandTimeout = 0;
            dad.Fill(dt);
            Close();
            return dt;
        }
        //Lấy danh sách công văn đến (quản trị admin) theo khoảng thời gian
        public DataTable SELECT_CONGVAN_ADMIN_TIME(DateTime dtp1, DateTime dtp2, string ID_LOAIVANBAN)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC FROM " + Table_CongVanDen + " WHERE NGAYKY >= @dtp1 AND NGAYKY <= @dtp2 AND ID_LOAIVANBAN = @ID_LOAIVANBAN GROUP BY ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@dtp1", dtp1);
            cmd.Parameters.AddWithValue("@dtp2", dtp2);
            cmd.Parameters.AddWithValue("@ID_LOAIVANBAN", ID_LOAIVANBAN);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            cmd.CommandTimeout = 0;
            dad.Fill(dt);
            Close();
            return dt;
        }

        //Lấy danh sách công văn đến (quản trị admin) theo khoảng thời gian
        public DataTable SELECT_CONGVAN_ALL()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC FROM " + Table_CongVanDen + " WHERE SAPXEP = '-1' ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            cmd.CommandTimeout = 0;
            dad.Fill(dt);
            Close();
            return dt;
        }

        //Lấy danh sách công văn đến (quản trị admin) theo khoảng thời gian
        public DataTable SELECT_CONGVAN_TOP(int Top)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT TOP " + Top + " ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC FROM " + Table_CongVanDen + " WHERE SAPXEP = '-1' ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            cmd.CommandTimeout = 0;
            dad.Fill(dt);
            Close();
            return dt;
        }
        //Lấy danh sách công văn đến (quản trị admin) theo khoảng thời gian
        public DataTable SELECT_CONGVAN(int Year)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC FROM " + Table_CongVanDen + " WHERE Year(NGAYKY) = @Year AND SAPXEP = '-1' ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Year", Year);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            cmd.CommandTimeout = 0;
            dad.Fill(dt);
            Close();
            return dt;
        }




        //Lấy danh sách công văn đến
        public DataTable SELECT_FILE_CVDI(decimal MACV)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, MACV, LOAICV, LOAIFILE, THUMUC, TAPTIN, NGAY, GHICHU FROM " + Table_File + "  WHERE MACV = @MACV";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@MACV", MACV);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        // Insert FILE_CVDI
        public void INSERT_FILE_CVDI(string ID, decimal MACV, string LOAICV, string LOAIFILE, string THUMUC, string TAPTIN, DateTime NGAY, string GHICHU, byte[] FILEBYTE, string DUNGLUONG, string MD5, string NGUOITAO)
        {
            Open();
            string s = "INSERT INTO " + Table_File + "(ID, MACV, LOAICV, LOAIFILE, THUMUC, TAPTIN, NGAY, GHICHU, FILEBYTE, DUNGLUONG, MD5, NGUOITAO) VALUES(@ID, @MACV, @LOAICV, @LOAIFILE, @THUMUC, @TAPTIN, @NGAY, @GHICHU, @FILEBYTE, @DUNGLUONG, @MD5, @NGUOITAO)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@MACV", MACV);
            cmd.Parameters.AddWithValue("@LOAICV", LOAICV);
            cmd.Parameters.AddWithValue("@LOAIFILE", LOAIFILE);
            cmd.Parameters.AddWithValue("@THUMUC", THUMUC);
            cmd.Parameters.AddWithValue("@TAPTIN", TAPTIN);
            cmd.Parameters.AddWithValue("@NGAY", NGAY);
            cmd.Parameters.AddWithValue("@GHICHU", GHICHU);
            cmd.Parameters.AddWithValue("@FILEBYTE", FILEBYTE);
            cmd.Parameters.AddWithValue("@DUNGLUONG", DUNGLUONG);
            cmd.Parameters.AddWithValue("@MD5", MD5);
            cmd.Parameters.AddWithValue("@NGUOITAO", NGUOITAO);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void DELETE_FILE_CVDI(decimal ID)
        {
            Open();
            string s = "DELETE FROM " + Table_File + " WHERE MACV = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            Close();
        }

        //Lấy file công văn đến chưa xử lý khi sửa
        public DataTable SELECT_FILE_CVDI(decimal ID, string LOAICV)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, MACV, LOAICV, LOAIFILE, THUMUC, TAPTIN, NGAY, GHICHU FROM " + Table_File + " WHERE MACV = @ID AND LOAICV = @LOAICV";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@LOAICV", LOAICV);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        //Xóa file theo ID
        public void DELETE_FILE_CVDI_ID(string ID)
        {
            Open();
            string s = "DELETE FROM " + Table_File + " WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void databaseFileRead(string ID, string PathFile)
        {
            Open();
            string s = "SELECT FILEBYTE FROM " + Table_File + " WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            byte[] buffer = (byte[])cmd.ExecuteScalar();
            FileStream fs = new FileStream(PathFile, FileMode.Create);
            fs.Write(buffer, 0, buffer.Length);
            fs.Close();
            Close();
        }
    }
}
