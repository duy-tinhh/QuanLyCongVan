using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QuanLyCongVan.Class
{
    public class csChangeData
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
        // Insert CANBOKY
        public void INSERT_CANBOKY(string ID, string Name, string Description, bool Active)
        {
            Open();
            string s = "INSERT INTO CANBOKY(ID, Name, Description, Active) VALUES(@ID, @Name, @Description, @Active)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.ExecuteNonQuery();
        }

        // Insert CANBOXULY
        public void INSERT_CANBOXULY(string ID, string Name, string Description, bool Active, string DonViXuLy, string MADV)
        {
            Open();
            string s = "INSERT INTO CANBOXULY(ID, Name, Description, Active, DonViXuLy, MADV) VALUES(@ID, @Name, @Description, @Active, @DonViXuLy, @MADV)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@DonViXuLy", DonViXuLy);
            cmd.Parameters.AddWithValue("@MADV", MADV);
            cmd.ExecuteNonQuery();
        }


        // Insert CONGVANDEN
        public void INSERT_CONGVANDEN(string MA, string ID, string KYHIEU, string ID_LOAIVANBAN, string ID_CQBANHANH, string ID_CQNHANCV, string ID_DVXULY, string ID_CANBOKY, string ID_CANBOXULY, DateTime NGAYKY, DateTime NGAYNHAN, string NOIDUNG, string TIENDO, string THUMUC, string PHEDUYET, int TRANGTHAI, DateTime NGAYHETHAN, string GHICHU, int SOCV, int SOBAN, string DUAN, string VITRILUU, string THBAOQUAN, DateTime BATDAU, string KETTHUC, string MANV, string TENNV, string LOAI, bool DAXEM, DateTime NGAYXEM, int SAPXEP, int BANSAO, string DOMAT, string EMAIL, bool SENDMAIL)
        {
            Open();
            string s = "INSERT INTO CONGVANDEN(MA, ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, LOAI, DAXEM, NGAYXEM, SAPXEP, BANSAO, DOMAT, EMAIL, SENDMAIL) VALUES(@MA, @ID, @KYHIEU, @ID_LOAIVANBAN, @ID_CQBANHANH, @ID_CQNHANCV, @ID_DVXULY, @ID_CANBOKY, @ID_CANBOXULY, @NGAYKY, @NGAYNHAN, @NOIDUNG, @TIENDO, @THUMUC, @PHEDUYET, @TRANGTHAI, @NGAYHETHAN, @GHICHU, @SOCV, @SOBAN, @DUAN, @VITRILUU, @THBAOQUAN, @BATDAU, @KETTHUC, @MANV, @TENNV, @LOAI, @DAXEM, @NGAYXEM, @SAPXEP, @BANSAO, @DOMAT, @EMAIL, @SENDMAIL)";
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

        //Update trạng thái nhân viên xem công văn
        public void UPDATE_CONGVANDEN_DAXEM(string Table_CongVanDen, string ID, string MANV)
        {
            Open();
            string s = "UPDATE " + Table_CongVanDen + " SET DAXEM = 'True' WHERE ID = @ID AND MANV = @MANV";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@MANV", MANV);
            cmd.ExecuteNonQuery();
        }
        // Insert CONGVANDEN_DUAN
        public void INSERT_CONGVANDEN_DUAN(string MA, string ID, string KYHIEU, string ID_LOAIVANBAN, string ID_CQBANHANH, string ID_CQNHANCV, string ID_DVXULY, string ID_CANBOKY, string ID_CANBOXULY, DateTime NGAYKY, DateTime NGAYNHAN, string NOIDUNG, string TIENDO, string THUMUC, string PHEDUYET, int TRANGTHAI, DateTime NGAYHETHAN, string GHICHU, int SOCV, int SOBAN, string DUAN, string VITRILUU, string THBAOQUAN, DateTime BATDAU, string KETTHUC, string MANV, string TENNV, string LOAI, bool DAXEM, DateTime NGAYXEM, int SAPXEP, int BANSAO)
        {
            Open();
            string s = "INSERT INTO CONGVANDEN_DUAN(MA, ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, LOAI, DAXEM, NGAYXEM, SAPXEP, BANSAO) VALUES(@MA, @ID, @KYHIEU, @ID_LOAIVANBAN, @ID_CQBANHANH, @ID_CQNHANCV, @ID_DVXULY, @ID_CANBOKY, @ID_CANBOXULY, @NGAYKY, @NGAYNHAN, @NOIDUNG, @TIENDO, @THUMUC, @PHEDUYET, @TRANGTHAI, @NGAYHETHAN, @GHICHU, @SOCV, @SOBAN, @DUAN, @VITRILUU, @THBAOQUAN, @BATDAU, @KETTHUC, @MANV, @TENNV, @LOAI, @DAXEM, @NGAYXEM, @SAPXEP, @BANSAO)";
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
            cmd.ExecuteNonQuery();
        }


        // Insert CONGVANDI
        public void INSERT_CONGVANDI(string MA, string ID, string KYHIEU, string ID_LOAIVANBAN, string ID_CQBANHANH, string ID_CQNHANCV, string ID_DVXULY, string ID_CANBOKY, string ID_CANBOXULY, DateTime NGAYKY, DateTime NGAYNHAN, string NOIDUNG, string TIENDO, string THUMUC, string PHEDUYET, int TRANGTHAI, DateTime NGAYHETHAN, string GHICHU, int SOCV, int SOBAN, string DUAN, string VITRILUU, string THBAOQUAN, DateTime BATDAU, string KETTHUC, string MANV, string TENNV, string LOAI, bool DAXEM, DateTime NGAYXEM, int SAPXEP, int BANSAO, string DOMAT, string EMAIL, bool SENDMAIL)
        {
            Open();
            string s = "INSERT INTO CONGVANDI(MA, ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, LOAI, DAXEM, NGAYXEM, SAPXEP, BANSAO, DOMAT, EMAIL, SENDMAIL) VALUES(@MA, @ID, @KYHIEU, @ID_LOAIVANBAN, @ID_CQBANHANH, @ID_CQNHANCV, @ID_DVXULY, @ID_CANBOKY, @ID_CANBOXULY, @NGAYKY, @NGAYNHAN, @NOIDUNG, @TIENDO, @THUMUC, @PHEDUYET, @TRANGTHAI, @NGAYHETHAN, @GHICHU, @SOCV, @SOBAN, @DUAN, @VITRILUU, @THBAOQUAN, @BATDAU, @KETTHUC, @MANV, @TENNV, @LOAI, @DAXEM, @NGAYXEM, @SAPXEP, @BANSAO, @DOMAT, @EMAIL, @SENDMAIL)";
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

        // Insert CONGVANDI_DUAN
        public void INSERT_CONGVANDI_DUAN(string MA, string ID, string KYHIEU, string ID_LOAIVANBAN, string ID_CQBANHANH, string ID_CQNHANCV, string ID_DVXULY, string ID_CANBOKY, string ID_CANBOXULY, DateTime NGAYKY, DateTime NGAYNHAN, string NOIDUNG, string TIENDO, string THUMUC, string PHEDUYET, int TRANGTHAI, DateTime NGAYHETHAN, string GHICHU, int SOCV, int SOBAN, string DUAN, string VITRILUU, string THBAOQUAN, DateTime BATDAU, string KETTHUC, string MANV, string TENNV, string LOAI, bool DAXEM, DateTime NGAYXEM, int SAPXEP, int BANSAO)
        {
            Open();
            string s = "INSERT INTO CONGVANDI_DUAN(MA, ID, KYHIEU, ID_LOAIVANBAN, ID_CQBANHANH, ID_CQNHANCV, ID_DVXULY, ID_CANBOKY, ID_CANBOXULY, NGAYKY, NGAYNHAN, NOIDUNG, TIENDO, THUMUC, PHEDUYET, TRANGTHAI, NGAYHETHAN, GHICHU, SOCV, SOBAN, DUAN, VITRILUU, THBAOQUAN, BATDAU, KETTHUC, MANV, TENNV, LOAI, DAXEM, NGAYXEM, SAPXEP, BANSAO) VALUES(@MA, @ID, @KYHIEU, @ID_LOAIVANBAN, @ID_CQBANHANH, @ID_CQNHANCV, @ID_DVXULY, @ID_CANBOKY, @ID_CANBOXULY, @NGAYKY, @NGAYNHAN, @NOIDUNG, @TIENDO, @THUMUC, @PHEDUYET, @TRANGTHAI, @NGAYHETHAN, @GHICHU, @SOCV, @SOBAN, @DUAN, @VITRILUU, @THBAOQUAN, @BATDAU, @KETTHUC, @MANV, @TENNV, @LOAI, @DAXEM, @NGAYXEM, @SAPXEP, @BANSAO)";
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
            cmd.ExecuteNonQuery();
        }

        // Insert CQBANHANH
        public void INSERT_CQBANHANH(string ID, string Name, string Description, bool Active)
        {
            Open();
            string s = "INSERT INTO CQBANHANH(ID, Name, Description, Active) VALUES(@ID, @Name, @Description, @Active)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.ExecuteNonQuery();
        }

        // Insert CQNHANCV
        public void INSERT_CQNHANCV(string ID, string Name, string Description, bool Active)
        {
            Open();
            string s = "INSERT INTO CQNHANCV(ID, Name, Description, Active) VALUES(@ID, @Name, @Description, @Active)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.ExecuteNonQuery();
        }

        // Insert DANHBA
        public void INSERT_DANHBA(int ID, string TEN, string DIACHI, string COQUAN, string EMAIL, string DIENTHOAI, string FAX, string YAHOO, string SKYPE, string TAIKHOAN, string NGANHANG, string USER_ID, DateTime NGAYSINH)
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
        }

        // Insert DANHBACQ
        public void INSERT_DANHBACQ(string ID, string TEN, string DIACHI, string COQUAN, string EMAIL, string DIENTHOAI, string FAX, string YAHOO, string SKYPE, string TAIKHOAN, string NGANHANG)
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
        }

        // Insert DUAN
        public void INSERT_DUAN(string MA, string TENDUAN, string HANGMUC, string DIACHI, string GHICHU, string GIAIDOAN, DateTime NGAYBATDAU, DateTime NGAYKETTHUC, string NGUOIPHUTRACH, DateTime NGAYTAO, DateTime NGAYSUA, string NGUOITAO, bool TRANGTHAI)
        {
            Open();
            string s = "INSERT INTO DUAN(MA, TENDUAN, HANGMUC, DIACHI, GHICHU, GIAIDOAN, NGAYBATDAU, NGAYKETTHUC, NGUOIPHUTRACH, NGAYTAO, NGAYSUA, NGUOITAO, TRANGTHAI) VALUES(@MA, @TENDUAN, @HANGMUC, @DIACHI, @GHICHU, @GIAIDOAN, @NGAYBATDAU, @NGAYKETTHUC, @NGUOIPHUTRACH, @NGAYTAO, @NGAYSUA, @NGUOITAO, @TRANGTHAI)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@MA", MA);
            cmd.Parameters.AddWithValue("@TENDUAN", TENDUAN);
            cmd.Parameters.AddWithValue("@HANGMUC", HANGMUC);
            cmd.Parameters.AddWithValue("@DIACHI", DIACHI);
            cmd.Parameters.AddWithValue("@GHICHU", GHICHU);
            cmd.Parameters.AddWithValue("@GIAIDOAN", GIAIDOAN);
            cmd.Parameters.AddWithValue("@NGAYBATDAU", NGAYBATDAU);
            cmd.Parameters.AddWithValue("@NGAYKETTHUC", NGAYKETTHUC);
            cmd.Parameters.AddWithValue("@NGUOIPHUTRACH", NGUOIPHUTRACH);
            cmd.Parameters.AddWithValue("@NGAYTAO", NGAYTAO);
            cmd.Parameters.AddWithValue("@NGAYSUA", NGAYSUA);
            cmd.Parameters.AddWithValue("@NGUOITAO", NGUOITAO);
            cmd.Parameters.AddWithValue("@TRANGTHAI", TRANGTHAI);
            cmd.ExecuteNonQuery();
        }

        // Insert DVXULY
        public void INSERT_DVXULY(string ID, string Name, string Description, bool Active)
        {
            Open();
            string s = "INSERT INTO DVXULY(ID, Name, Description, Active) VALUES(@ID, @Name, @Description, @Active)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.ExecuteNonQuery();
        }

        // Insert FILE_CVDEN
        public void INSERT_FILE_CVDEN(string ID, string MACV, string LOAICV, string LOAIFILE, string THUMUC, string TAPTIN, DateTime NGAY, string GHICHU, byte[] FILEBYTE, string DUNGLUONG, string MD5, string NGUOITAO)
        {
            Open();
            string s = "INSERT INTO FILE_CVDEN(ID, MACV, LOAICV, LOAIFILE, THUMUC, TAPTIN, NGAY, GHICHU, FILEBYTE, DUNGLUONG, MD5, NGUOITAO) VALUES(@ID, @MACV, @LOAICV, @LOAIFILE, @THUMUC, @TAPTIN, @NGAY, @GHICHU, @FILEBYTE, @DUNGLUONG, @MD5, @NGUOITAO)";
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
        }

        // Insert FILE_CVDEN_DA
        public void INSERT_FILE_CVDEN_DA(string ID, string MACV, string LOAICV, string LOAIFILE, string THUMUC, string TAPTIN, DateTime NGAY, string GHICHU, byte FILEBYTE, string DUNGLUONG, string MD5, string NGUOITAO)
        {
            Open();
            string s = "INSERT INTO FILE_CVDEN_DA(ID, MACV, LOAICV, LOAIFILE, THUMUC, TAPTIN, NGAY, GHICHU, FILEBYTE, DUNGLUONG, MD5, NGUOITAO) VALUES(@ID, @MACV, @LOAICV, @LOAIFILE, @THUMUC, @TAPTIN, @NGAY, @GHICHU, @FILEBYTE, @DUNGLUONG, @MD5, @NGUOITAO)";
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
        }

        // Insert FILE_CVDI
        public void INSERT_FILE_CVDI(string ID, string MACV, string LOAICV, string LOAIFILE, string THUMUC, string TAPTIN, DateTime NGAY, string GHICHU, byte[] FILEBYTE, string DUNGLUONG, string MD5, string NGUOITAO)
        {
            Open();
            string s = "INSERT INTO FILE_CVDI(ID, MACV, LOAICV, LOAIFILE, THUMUC, TAPTIN, NGAY, GHICHU, FILEBYTE, DUNGLUONG, MD5, NGUOITAO) VALUES(@ID, @MACV, @LOAICV, @LOAIFILE, @THUMUC, @TAPTIN, @NGAY, @GHICHU, @FILEBYTE, @DUNGLUONG, @MD5, @NGUOITAO)";
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
        }

        // Insert FILE_CVDI_DA
        public void INSERT_FILE_CVDI_DA(string ID, string MACV, string LOAICV, string LOAIFILE, string THUMUC, string TAPTIN, DateTime NGAY, string GHICHU, byte FILEBYTE, string DUNGLUONG, string MD5, string NGUOITAO)
        {
            Open();
            string s = "INSERT INTO FILE_CVDI_DA(ID, MACV, LOAICV, LOAIFILE, THUMUC, TAPTIN, NGAY, GHICHU, FILEBYTE, DUNGLUONG, MD5, NGUOITAO) VALUES(@ID, @MACV, @LOAICV, @LOAIFILE, @THUMUC, @TAPTIN, @NGAY, @GHICHU, @FILEBYTE, @DUNGLUONG, @MD5, @NGUOITAO)";
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
        }

        // Insert GIAIDOAN
        public void INSERT_GIAIDOAN(string ID, string Name, string Description, int Sort, bool Active)
        {
            Open();
            string s = "INSERT INTO GIAIDOAN(ID, Name, Description, Sort, Active) VALUES(@ID, @Name, @Description, @Sort, @Active)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Sort", Sort);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.ExecuteNonQuery();
        }

        // Insert LOAIVANBAN
        public void INSERT_LOAIVANBAN(string ID, string Name, string Description, bool Active, int Sort)
        {
            Open();
            string s = "INSERT INTO LOAIVANBAN(ID, Name, Description, Active, Sort) VALUES(@ID, @Name, @Description, @Active, @Sort)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@Sort", Sort);
            cmd.ExecuteNonQuery();
        }

        // Insert MUONTRA
        public void INSERT_MUONTRA(int MA, string MACV, string NOIDUNG, DateTime NGAYMUON, DateTime NGAYTRA, string NGUOIMUON, string NGUOITRA, string GHICHU, string TRANGTHAI, DateTime NGAYCV)
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
        }

        // Insert MUONTRA_DA
        public void INSERT_MUONTRA_DA(int MA, string MACV, string NOIDUNG, DateTime NGAYMUON, DateTime NGAYTRA, string NGUOIMUON, string NGUOITRA, string GHICHU, string TRANGTHAI, DateTime NGACV)
        {
            Open();
            string s = "INSERT INTO MUONTRA_DA(MA, MACV, NOIDUNG, NGAYMUON, NGAYTRA, NGUOIMUON, NGUOITRA, GHICHU, TRANGTHAI, NGACV) VALUES(@MA, @MACV, @NOIDUNG, @NGAYMUON, @NGAYTRA, @NGUOIMUON, @NGUOITRA, @GHICHU, @TRANGTHAI, @NGACV)";
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
            cmd.Parameters.AddWithValue("@NGACV", NGACV);
            cmd.ExecuteNonQuery();
        }

        // Insert NHATKYLAMVIEC
        public void INSERT_NHATKYLAMVIEC(int ID, DateTime NGAY, DateTime BATDAU, DateTime KETTHUC, string MANV, string HOTEN, string NOIDUNG, string GHICHU, bool TRANGTHAI, DateTime NGAYTAO, DateTime NGAYSUA, bool XOA)
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
        }

        // Insert SYS_USER
        public void INSERT_SYS_USER(string ID, string PASS, string USER_ID, string USER_NAME, string USER_CREATE, DateTime DATE_CREATE, bool ACTIVE, string Type, string Group_ID)
        {
            Open();
            string s = "INSERT INTO SYS_USER(ID, PASS, USER_ID, USER_NAME, USER_CREATE, DATE_CREATE, ACTIVE, Type, Group_ID) VALUES(@ID, @PASS, @USER_ID, @USER_NAME, @USER_CREATE, @DATE_CREATE, @ACTIVE, @Type, @Group_ID)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@PASS", PASS);
            cmd.Parameters.AddWithValue("@USER_ID", USER_ID);
            cmd.Parameters.AddWithValue("@USER_NAME", USER_NAME);
            cmd.Parameters.AddWithValue("@USER_CREATE", USER_CREATE);
            cmd.Parameters.AddWithValue("@DATE_CREATE", DATE_CREATE);
            cmd.Parameters.AddWithValue("@ACTIVE", ACTIVE);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Group_ID", Group_ID);
            cmd.ExecuteNonQuery();
        }

        // Insert SYS_USER_R
        public void INSERT_SYS_USER_R(string USERID, bool Rule1, bool Rule2, bool Rule3, bool Rule4, bool Rule5, bool Rule6, bool Rule7, bool Rule8, bool Rule9, bool Rule10, bool Rule11, bool Rule12, bool Rule13, bool Rule14, bool Rule15, bool Rule16, bool Rule17, bool Rule18, bool Rule19, bool Rule20, bool Rule21, bool Rule22, bool Rule23, bool Rule24, bool Rule25, bool Rule26, bool Rule27, bool Rule28, bool Rule29, bool Rule30)
        {
            Open();
            string s = "INSERT INTO SYS_USER_R(USERID, Rule1, Rule2, Rule3, Rule4, Rule5, Rule6, Rule7, Rule8, Rule9, Rule10, Rule11, Rule12, Rule13, Rule14, Rule15, Rule16, Rule17, Rule18, Rule19, Rule20, Rule21, Rule22, Rule23, Rule24, Rule25, Rule26, Rule27, Rule28, Rule29, Rule30) VALUES(@USERID, @Rule1, @Rule2, @Rule3, @Rule4, @Rule5, @Rule6, @Rule7, @Rule8, @Rule9, @Rule10, @Rule11, @Rule12, @Rule13, @Rule14, @Rule15, @Rule16, @Rule17, @Rule18, @Rule19, @Rule20, @Rule21, @Rule22, @Rule23, @Rule24, @Rule25, @Rule26, @Rule27, @Rule28, @Rule29, @Rule30)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@USERID", USERID);
            cmd.Parameters.AddWithValue("@Rule1", Rule1);
            cmd.Parameters.AddWithValue("@Rule2", Rule2);
            cmd.Parameters.AddWithValue("@Rule3", Rule3);
            cmd.Parameters.AddWithValue("@Rule4", Rule4);
            cmd.Parameters.AddWithValue("@Rule5", Rule5);
            cmd.Parameters.AddWithValue("@Rule6", Rule6);
            cmd.Parameters.AddWithValue("@Rule7", Rule7);
            cmd.Parameters.AddWithValue("@Rule8", Rule8);
            cmd.Parameters.AddWithValue("@Rule9", Rule9);
            cmd.Parameters.AddWithValue("@Rule10", Rule10);
            cmd.Parameters.AddWithValue("@Rule11", Rule11);
            cmd.Parameters.AddWithValue("@Rule12", Rule12);
            cmd.Parameters.AddWithValue("@Rule13", Rule13);
            cmd.Parameters.AddWithValue("@Rule14", Rule14);
            cmd.Parameters.AddWithValue("@Rule15", Rule15);
            cmd.Parameters.AddWithValue("@Rule16", Rule16);
            cmd.Parameters.AddWithValue("@Rule17", Rule17);
            cmd.Parameters.AddWithValue("@Rule18", Rule18);
            cmd.Parameters.AddWithValue("@Rule19", Rule19);
            cmd.Parameters.AddWithValue("@Rule20", Rule20);
            cmd.Parameters.AddWithValue("@Rule21", Rule21);
            cmd.Parameters.AddWithValue("@Rule22", Rule22);
            cmd.Parameters.AddWithValue("@Rule23", Rule23);
            cmd.Parameters.AddWithValue("@Rule24", Rule24);
            cmd.Parameters.AddWithValue("@Rule25", Rule25);
            cmd.Parameters.AddWithValue("@Rule26", Rule26);
            cmd.Parameters.AddWithValue("@Rule27", Rule27);
            cmd.Parameters.AddWithValue("@Rule28", Rule28);
            cmd.Parameters.AddWithValue("@Rule29", Rule29);
            cmd.Parameters.AddWithValue("@Rule30", Rule30);
            cmd.ExecuteNonQuery();
        }

        // Insert THBAOQUAN
        public void INSERT_THBAOQUAN(string ID, string Name, string Description, int Sort, bool Active)
        {
            Open();
            string s = "INSERT INTO THBAOQUAN(ID, Name, Description, Sort, Active) VALUES(@ID, @Name, @Description, @Sort, @Active)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Sort", Sort);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.ExecuteNonQuery();
        }

        // Insert THONGTINDONVI
        public void INSERT_THONGTINDONVI(int ID, string DONVICHUQUAN, string DONVISUDUNG, string DIACHI, string SODT, string FAX, string EMAIL, string WEBSITE, string TINH, string GHICHU, byte LOGO)
        {
            Open();
            string s = "INSERT INTO THONGTINDONVI(ID, DONVICHUQUAN, DONVISUDUNG, DIACHI, SODT, FAX, EMAIL, WEBSITE, TINH, GHICHU, LOGO) VALUES(@ID, @DONVICHUQUAN, @DONVISUDUNG, @DIACHI, @SODT, @FAX, @EMAIL, @WEBSITE, @TINH, @GHICHU, @LOGO)";
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
            cmd.ExecuteNonQuery();
        }

        // Insert TRANGTHAI
        public void INSERT_TRANGTHAI(string ID, string Name, string Description, int Sort, bool Active)
        {
            Open();
            string s = "INSERT INTO TRANGTHAI(ID, Name, Description, Sort, Active) VALUES(@ID, @Name, @Description, @Sort, @Active)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Sort", Sort);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.ExecuteNonQuery();
        }

        // Insert VERSION
        public void INSERT_VERSION(int ID, string APPNAME, int VERSION, string GHICHU)
        {
            Open();
            string s = "INSERT INTO VERSION(ID, APPNAME, VERSION, GHICHU) VALUES(@ID, @APPNAME, @VERSION, @GHICHU)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@APPNAME", APPNAME);
            cmd.Parameters.AddWithValue("@VERSION", VERSION);
            cmd.Parameters.AddWithValue("@GHICHU", GHICHU);
            cmd.ExecuteNonQuery();
        }

        // Insert VITRILUU
        public void INSERT_VITRILUU(string ID, string Name, string Description, int Sort, bool Active)
        {
            Open();
            string s = "INSERT INTO VITRILUU(ID, Name, Description, Sort, Active) VALUES(@ID, @Name, @Description, @Sort, @Active)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Sort", Sort);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.ExecuteNonQuery();
        }

        // Delete CANBOKY
        public void DELETE_CANBOKY()
        {
            Open();
            string s = "DELETE CANBOKY";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete CANBOXULY
        public void DELETE_CANBOXULY()
        {
            Open();
            string s = "DELETE CANBOXULY";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete CONGVANDEN
        public void DELETE_CONGVANDEN()
        {
            Open();
            string s = "DELETE CONGVANDEN";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete CONGVANDEN_DUAN
        public void DELETE_CONGVANDEN_DUAN()
        {
            Open();
            string s = "DELETE CONGVANDEN_DUAN";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete CONGVANDI
        public void DELETE_CONGVANDI()
        {
            Open();
            string s = "DELETE CONGVANDI";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete CONGVANDI_DUAN
        public void DELETE_CONGVANDI_DUAN()
        {
            Open();
            string s = "DELETE CONGVANDI_DUAN";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete CQBANHANH
        public void DELETE_CQBANHANH()
        {
            Open();
            string s = "DELETE CQBANHANH";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete CQNHANCV
        public void DELETE_CQNHANCV()
        {
            Open();
            string s = "DELETE CQNHANCV";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete DANHBA
        public void DELETE_DANHBA()
        {
            Open();
            string s = "DELETE DANHBA";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete DANHBACQ
        public void DELETE_DANHBACQ()
        {
            Open();
            string s = "DELETE DANHBACQ";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete DUAN
        public void DELETE_DUAN()
        {
            Open();
            string s = "DELETE DUAN";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete DVXULY
        public void DELETE_DVXULY()
        {
            Open();
            string s = "DELETE DVXULY";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete FILE_CVDEN
        public void DELETE_FILE_CVDEN()
        {
            Open();
            string s = "DELETE FILE_CVDEN";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete FILE_CVDEN_DA
        public void DELETE_FILE_CVDEN_DA()
        {
            Open();
            string s = "DELETE FILE_CVDEN_DA";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete FILE_CVDI
        public void DELETE_FILE_CVDI()
        {
            Open();
            string s = "DELETE FILE_CVDI";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete FILE_CVDI_DA
        public void DELETE_FILE_CVDI_DA()
        {
            Open();
            string s = "DELETE FILE_CVDI_DA";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete GIAIDOAN
        public void DELETE_GIAIDOAN()
        {
            Open();
            string s = "DELETE GIAIDOAN";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete LOAIVANBAN
        public void DELETE_LOAIVANBAN()
        {
            Open();
            string s = "DELETE LOAIVANBAN";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete MUONTRA
        public void DELETE_MUONTRA()
        {
            Open();
            string s = "DELETE MUONTRA";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete MUONTRA_DA
        public void DELETE_MUONTRA_DA()
        {
            Open();
            string s = "DELETE MUONTRA_DA";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete NHATKYLAMVIEC
        public void DELETE_NHATKYLAMVIEC()
        {
            Open();
            string s = "DELETE NHATKYLAMVIEC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete SYS_USER
        public void DELETE_SYS_USER()
        {
            Open();
            string s = "DELETE SYS_USER";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete SYS_USER_R
        public void DELETE_SYS_USER_R()
        {
            Open();
            string s = "DELETE SYS_USER_R";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete THBAOQUAN
        public void DELETE_THBAOQUAN()
        {
            Open();
            string s = "DELETE THBAOQUAN";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete TRANGTHAI
        public void DELETE_TRANGTHAI()
        {
            Open();
            string s = "DELETE TRANGTHAI";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }

        // Delete VITRILUU
        public void DELETE_VITRILUU()
        {
            Open();
            string s = "DELETE VITRILUU";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
        }
    }
}
