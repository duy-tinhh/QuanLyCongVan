using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace QuanLyCongVan.Class
{
    public class csCongVanDen
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
        string Table_CongVanDen = "CONGVANDEN";
        string Table_File = "FILE_CVDEN";
        public decimal AUTO_ID()
        {
            Open();
            decimal ID = 0;
            try
            {
                DataTable dt = new DataTable();
                string s = "SELECT ID FROM CONGVANDEN ORDER BY ID DESC";
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
        public DataTable SELECT_CONGVANDEN(decimal ID)
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
        public DataTable SELECT_CONGVANDEN_DUAN_NHANVIENXULY(decimal ID)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT MANV, TENNV, DAXEM, NGAYXEM, EMAIL FROM " + Table_CongVanDen + " WHERE ID = @ID AND LOAI = 'NGUOIXEM' ORDER BY SAPXEP ASC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }

        //Lấy ds nhan vien khong xu ly cong van
        public DataTable SELECT_CONGVANDEN_DUAN_NHANVIENXULY_NULL(decimal ID)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT CANBOXULY.ID, CANBOXULY.Name, CVD.MANV, CANBOXULY.Email FROM CANBOXULY LEFT JOIN (SELECT MANV FROM " + Table_CongVanDen + " WHERE ID = @ID) AS CVD ON CANBOXULY.ID = CVD.MANV WHERE CVD.MANV IS NULL";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }

        // Insert CONGVANDEN_DUAN
        public void INSERT_CONGVANDEN(string MA, decimal ID, string KYHIEU, string ID_LOAIVANBAN, string ID_CQBANHANH, string ID_CQNHANCV, string ID_DVXULY, string ID_CANBOKY, string ID_CANBOXULY, DateTime NGAYKY, DateTime NGAYNHAN, string NOIDUNG, string TIENDO, string THUMUC, string PHEDUYET, int TRANGTHAI, DateTime NGAYHETHAN, string GHICHU, decimal SOCV, int SOBAN, string DUAN, string VITRILUU, string THBAOQUAN, DateTime BATDAU, string KETTHUC, string MANV, string TENNV, string LOAI, bool DAXEM, DateTime NGAYXEM, int SAPXEP, decimal BANSAO, string DOMAT, string EMAIL, bool SENDMAIL)
        {
            Open();
            string s = "INSERT INTO " + Table_CongVanDen + "(MA, ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, LOAI, DAXEM, NGAYXEM, SAPXEP, BANSAO, DOMAT, EMAIL, SENDMAIL) VALUES(@MA, @ID, @KYHIEU, @ID_LOAIVANBAN, @ID_CQBANHANH, @ID_CQNHANCV, @ID_DVXULY, @ID_CANBOKY, @ID_CANBOXULY, @NGAYKY, @NGAYNHAN, @NOIDUNG, @TIENDO, @THUMUC, @PHEDUYET, @TRANGTHAI, @NGAYHETHAN, @GHICHU, @SOCV, @SOBAN, @DUAN, @VITRILUU, @THBAOQUAN, @BATDAU, @KETTHUC, @MANV, @TENNV, @LOAI, @DAXEM, @NGAYXEM, @SAPXEP, @BANSAO, @DOMAT, @EMAIL, @SENDMAIL)";
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
            cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
            cmd.Parameters.AddWithValue("@SENDMAIL", SENDMAIL);
            cmd.ExecuteNonQuery();
            Close();
        }
        // Update CONGVANDEN_DUAN
        public void UPDATE_CONGVANDEN(decimal ID, string KYHIEU, string ID_LOAIVANBAN, string ID_CQBANHANH, string ID_CQNHANCV, string ID_DVXULY, string ID_CANBOKY, string ID_CANBOXULY, DateTime NGAYKY, DateTime NGAYNHAN, string NOIDUNG, string TIENDO, string THUMUC, string PHEDUYET, int TRANGTHAI, DateTime NGAYHETHAN, string GHICHU, decimal SOCV, int SOBAN, string DUAN, string VITRILUU, string THBAOQUAN, DateTime BATDAU, string KETTHUC, string MANV, string TENNV, string LOAI, bool DAXEM, DateTime NGAYXEM, int SAPXEP, decimal BANSAO, string DOMAT, string EMAIL, bool SENDMAIL)
        {
            Open();
            string s = "UPDATE " + Table_CongVanDen + " SET KYHIEU = @KYHIEU, ID_LOAIVANBAN = @ID_LOAIVANBAN, ID_CQBANHANH = @ID_CQBANHANH, ID_CQNHANCV = @ID_CQNHANCV, ID_DVXULY = @ID_DVXULY, ID_CANBOKY = @ID_CANBOKY, ID_CANBOXULY = @ID_CANBOXULY, NGAYKY = @NGAYKY, NGAYNHAN = @NGAYNHAN, NOIDUNG = @NOIDUNG, TIENDO = @TIENDO, THUMUC = @THUMUC, PHEDUYET = @PHEDUYET, TRANGTHAI = @TRANGTHAI, NGAYHETHAN = @NGAYHETHAN, GHICHU = @GHICHU, SOCV = @SOCV, SOBAN = @SOBAN, DUAN = @DUAN, VITRILUU = @VITRILUU, THBAOQUAN = @THBAOQUAN, BATDAU = @BATDAU, KETTHUC = @KETTHUC, MANV = @MANV, TENNV = @TENNV, LOAI = @LOAI, DAXEM = @DAXEM, NGAYXEM = @NGAYXEM, SAPXEP = @SAPXEP, BANSAO = @BANSAO, DOMAT = @DOMAT, EMAIL = @EMAIL, SENDMAIL = @SENDMAIL WHERE ID = @ID";
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
            cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
            cmd.Parameters.AddWithValue("@SENDMAIL", SENDMAIL);
            cmd.ExecuteNonQuery();
            Close();
        }

        // Update CONGVANDEN
        public void UPDATE_CONGVANDEN_ID_DVXULY(decimal ID, string ID_DVXULY)
        {
            Open();
            string s = "UPDATE CONGVANDEN SET ID_DVXULY = @ID_DVXULY WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@ID_DVXULY", ID_DVXULY);
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            Close();
        }

        public void DELETE_CONGVAN_ALL(decimal ID)
        {
            Open();
            string s = "DELETE FROM " + Table_CongVanDen + " WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void DELETE_CONGVAN(decimal ID)
        {
            Open();
            string s = "DELETE FROM " + Table_CongVanDen + " WHERE ID = @ID AND SAPXEP  > '-1'";
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
            string s = "SELECT " + Table_CongVanDen + ".MANV, " + Table_CongVanDen + ".DAXEM FROM " + Table_CongVanDen + " WHERE " + Table_CongVanDen + ".MANV = @MANV AND " + Table_CongVanDen + ".DAXEM = 'False'";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@MANV", MANV);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Row = dt.Rows.Count;
            Close();
            return Row;
        }

        //Update trạng thái nhân viên xem công văn
        public void UPDATE_CONGVANDEN_DUAN_DAXEM(decimal ID, string MANV)
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
        public DataTable SELECT_CONGVAN_ADMIN_TIME(DateTime dtp1, DateTime dtp2)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, DOMAT FROM " + Table_CongVanDen + " WHERE NGAYKY >= @dtp1 AND NGAYKY <= @dtp2 GROUP BY ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, DOMAT ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@dtp1", dtp1);
            cmd.Parameters.AddWithValue("@dtp2", dtp2);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            cmd.CommandTimeout = 0;
            dad.Fill(dt);
            Close();
            return dt;
        }


        //Lấy danh sách công văn đến theo nhân viên
        public DataTable SELECT_CONGVAN_MANV_TIME(string MANV, DateTime dtp1, DateTime dtp2)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, DAXEM, DOMAT FROM " + Table_CongVanDen + " WHERE MANV = @MANV AND NGAYKY >= @dtp1 AND NGAYKY <= @dtp2 GROUP BY ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, DAXEM, DOMAT ORDER BY ID DESC";
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
        



        //Lấy danh sách tất cả công văn đến nhân viên bất kỳ
        public DataTable SELECT_CONGVAN_NV_ALL(string MANV)
        {
            //Phải group lại vì có thể nhân viên thực hiện và nhân viên tạo công văn nên 2 dòng
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, DAXEM, DOMAT FROM " + Table_CongVanDen + " WHERE MANV = @MANV GROUP BY ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, DAXEM, DOMAT ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@MANV", MANV);
            cmd.CommandTimeout = 0;
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        //Lấy danh sách công văn đến
        public DataTable SELECT_CONGVAN_LD_VT_ALL()
        {
            //Mỗi công văn chỉ có 1 dòng -1
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, DAXEM, DOMAT FROM " + Table_CongVanDen + " WHERE SAPXEP = '-1' ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            cmd.CommandTimeout = 0;
            dad.Fill(dt);
            Close();
            return dt;
        }






        //Lấy danh sách công văn đến nhân viên tất cả
        public DataTable SELECT_CONGVAN_NV_TOP(string MANV, int Top)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT TOP " + Top + " ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, DAXEM, DOMAT FROM " + Table_CongVanDen + " WHERE MANV = @MANV GROUP BY ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, DAXEM, DOMAT ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@MANV", MANV);
            cmd.CommandTimeout = 0;
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }

        //Lấy danh sách công văn đến
        public DataTable SELECT_CONGVAN_LD_VT_TOP(int Top)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT TOP " + Top + " ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, DAXEM, DOMAT FROM " + Table_CongVanDen + " WHERE SAPXEP = '-1' ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            cmd.CommandTimeout = 0;
            dad.Fill(dt);
            Close();
            return dt;
        }





        //Lấy danh sách công văn đến nhân viên theo năm
        public DataTable SELECT_CONGVAN_NV(string MANV, int Year)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, DAXEM, DOMAT FROM " + Table_CongVanDen + " WHERE MANV = @MANV AND Year(NGAYKY) = @Year GROUP BY ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, DAXEM, DOMAT ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@MANV", MANV);
            cmd.Parameters.AddWithValue("@Year", Year);
            cmd.CommandTimeout = 0;
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }

        //Lấy danh sách công văn đến
        public DataTable SELECT_CONGVAN_LD_VT(int Year)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, DAXEM, DOMAT FROM " + Table_CongVanDen + " WHERE Year(NGAYKY) = @Year AND SAPXEP = '-1' ORDER BY ID DESC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Year", Year);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            cmd.CommandTimeout = 0;
            dad.Fill(dt);
            Close();
            return dt;
        }











        //Lấy danh sách file
        public DataTable SELECT_FILE_CVDEN(decimal ID)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, MACV, LOAICV, LOAIFILE, THUMUC, TAPTIN, NGAY, GHICHU FROM " + Table_File + " WHERE MACV = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        //Lấy file công văn đến chưa xử lý khi sửa
        public DataTable SELECT_FILE_CVDEN(decimal MACV, string LOAICV)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, MACV, LOAICV, LOAIFILE, THUMUC, TAPTIN, NGAY, GHICHU FROM " + Table_File + " WHERE MACV = @MACV AND LOAICV = @LOAICV ORDER BY NGAY ASC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@MACV", MACV);
            cmd.Parameters.AddWithValue("@LOAICV", LOAICV);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }

        // Insert FILE_CVDEN
        public void INSERT_FILE_CVDEN(string ID, decimal MACV, string LOAICV, string LOAIFILE, string THUMUC, string TAPTIN, DateTime NGAY, string GHICHU, byte[] FILEBYTE, string DUNGLUONG, string MD5, string NGUOITAO)
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
        //Xóa ds file
        public void DELETE_FILE_CVDEN(decimal MACV)
        {
            Open();
            string s = "DELETE FROM " + Table_File + " WHERE MACV = @MACV";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@MACV", MACV);
            cmd.ExecuteNonQuery();
            Close();
        }
        //Xóa file theo ID
        public void DELETE_FILE_CVDEN_ID(string ID)
        {
            Open();
            string s = "DELETE FROM " + Table_File + " WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            Close();
        }
        //public byte[] GETFILEBYTE()
        //{
        //    Open();
        //    DataTable dt = new DataTable();
        //    string s = "SELECT FILEBYTE FROM FILE_CVDEN WHERE ID = '20ff949d-5bf9-4c03-911f-5b27f06fd5a2'";
        //    SqlCommand cmd = new SqlCommand(s, con);
        //    byte[] b = (byte[])cmd.ExecuteScalar();
        //    Close();
        //    return b;
        //}
        public void databaseFileRead(string ID, string PathFile)
        {
            Open();
            string s = "SELECT FILEBYTE FROM FILE_CVDEN WHERE ID = @ID";
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
