using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace QuanLyCongVan.Class
{
    public class csUser
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
        // Update SYS_USER_FORM
        public void UPDATE_SYS_USER_FORM(string Group_ID, string Form_ID, bool sAll, bool sSee, bool sAdd, bool sDelete, bool sEdit, bool sPrint, bool sExport)
        {
            Open();
            string s = "UPDATE SYS_USER_FORM SET sAll = @sAll, sSee = @sSee, sAdd = @sAdd, sDelete = @sDelete, sEdit = @sEdit, sPrint = @sPrint, sExport = @sExport WHERE Group_ID = @Group_ID AND Form_ID = @Form_ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Group_ID", Group_ID);
            cmd.Parameters.AddWithValue("@Form_ID", Form_ID);
            cmd.Parameters.AddWithValue("@sAll", sAll);
            cmd.Parameters.AddWithValue("@sSee", sSee);
            cmd.Parameters.AddWithValue("@sAdd", sAdd);
            cmd.Parameters.AddWithValue("@sDelete", sDelete);
            cmd.Parameters.AddWithValue("@sEdit", sEdit);
            cmd.Parameters.AddWithValue("@sPrint", sPrint);
            cmd.Parameters.AddWithValue("@sExport", sExport);
            cmd.ExecuteNonQuery();
            Close();
        }
        public DataTable SELECT_SYS_USER_FORM_ID2(string Group_ID)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM SYS_USER_FORM WHERE Group_ID = @Group_ID ORDER BY SapXep ASC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Group_ID", Group_ID);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            return dt;
        }
        public DataTable SELECT_SYS_USER_GROUP()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM SYS_USER_GROUP ORDER BY Group_Name ASC";
            SqlDataAdapter dad = new SqlDataAdapter(s, con);
            dad.Fill(dt);
            Close();
            return dt;
        }
        public DataTable SELECT_RULE_2()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM SYS_USER ORDER BY USER_ID ASC";
            SqlDataAdapter dad = new SqlDataAdapter(s, con);
            dad.Fill(dt);
            Close();
            return dt;
        }
        public DataTable SELECT_SYS_USER_FORM_ID(string Group_ID)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM SYS_USER_FORM WHERE Group_ID = @Group_ID ORDER BY SapXep ASC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Group_ID", Group_ID);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            return dt;
        }
        public void DELETE_SYS_USER_FORM(string Group_ID)
        {
            Open();
            string s = "DELETE FROM SYS_USER_FORM WHERE Group_ID = @Group_ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Group_ID", Group_ID);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void DELETE_SYS_USER_GROUP_ID(string Group_ID)
        {
            Open();
            string s = "DELETE FROM SYS_USER_GROUP WHERE Group_ID = @Group_ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Group_ID", Group_ID);
            cmd.ExecuteNonQuery();
            Close();
        }
        public DataTable SELECT()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM CANBOXULY ORDER BY ACTIVE ASC";
            SqlDataAdapter dad = new SqlDataAdapter(s, con);
            dad.Fill(dt);
            Close();
            return dt;
        }
        public DataTable SELECT_GROUP()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM SYS_USER_GROUP ORDER BY Active ASC";
            SqlDataAdapter dad = new SqlDataAdapter(s, con);
            dad.Fill(dt);
            Close();
            return dt;
        }
        public DataTable SELECT_RULE()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM SYS_USER, SYS_USER_R WHERE SYS_USER.ID = SYS_USER_R.USERID";
            SqlDataAdapter dad = new SqlDataAdapter(s, con);
            dad.Fill(dt);
            Close();
            return dt;
        }
        public DataTable SELECT_ID(string ID)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM SYS_USER WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        public DataTable SELECT_USER_RULE_ID(string USER)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT SYS_USER.USER_ID,SYS_USER_R.Rule1,SYS_USER_R.Rule2,SYS_USER_R.Rule3,SYS_USER_R.Rule4,SYS_USER_R.Rule5,SYS_USER_R.Rule6,SYS_USER_R.Rule7,SYS_USER_R.Rule8,SYS_USER_R.Rule9,SYS_USER_R.Rule10,SYS_USER_R.Rule11,SYS_USER_R.Rule12,SYS_USER_R.Rule13,SYS_USER_R.Rule14,SYS_USER_R.Rule15,SYS_USER_R.Rule16,SYS_USER_R.Rule17,SYS_USER_R.Rule18,SYS_USER_R.Rule19,SYS_USER_R.Rule20,SYS_USER_R.Rule21,SYS_USER_R.Rule22,SYS_USER_R.Rule23,SYS_USER_R.Rule24,SYS_USER_R.Rule25,SYS_USER_R.Rule26,SYS_USER_R.Rule27,SYS_USER_R.Rule28,SYS_USER_R.Rule29,SYS_USER_R.Rule30 FROM SYS_USER,SYS_USER_R WHERE SYS_USER.ID = SYS_USER_R.USERID AND SYS_USER_R.USERID = @USER";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@USER", USER);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            return dt;
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
            Close();
        }
        // Update SYS_USER
        public void UPDATE_SYS_USER(string ID, string PASS, string USER_ID, string USER_NAME, bool ACTIVE, string Type, string Group_ID)
        {
            Open();
            string s = "UPDATE SYS_USER SET PASS = @PASS, USER_ID = @USER_ID, USER_NAME = @USER_NAME, ACTIVE = @ACTIVE, Type = @Type, Group_ID = @Group_ID WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@PASS", PASS);
            cmd.Parameters.AddWithValue("@USER_ID", USER_ID);
            cmd.Parameters.AddWithValue("@USER_NAME", USER_NAME);
            cmd.Parameters.AddWithValue("@ACTIVE", ACTIVE);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Group_ID", Group_ID);
            cmd.ExecuteNonQuery();
            Close();
        }

        public void DELETE_USER_RULE(string ID)
        {
            Open();
            string s = "DELETE FROM SYS_USER WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            Close();
        }

        public void DELETE_USER_RULE_ID(string ID)
        {
            Open();
            string s = "DELETE FROM SYS_USER_R WHERE USERID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            Close();
        }

        // Update SYS_USER
        public void UPDATE_SYS_USER_ACTIVE()
        {
            Open();
            string s = "UPDATE SYS_USER_FORM SET Active = 'False'";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
            Close();
        }

        // Update SYS_USER_FORM
        public void DELETE_SYS_USER_FORM()
        {
            Open();
            string s = "DELETE FROM SYS_USER_FORM WHERE Active = 'False'";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
            Close();
        }






        public void FORM_RULE()
        {
            try
            {
                UPDATE_SYS_USER_ACTIVE();//Chuyển trạng thái false để xem cái nào dư
                DataTable dtg = SELECT_SYS_USER_GROUP();
                for (int j = 0; j < dtg.Rows.Count; j++)
                {
                    string Group_ID = dtg.Rows[j]["Group_ID"].ToString();
                    DataTable dt = new DataTable();
                    string Form_ID = "frm_Phanquyen, frm_SaoLuu, frm_PhucHoi, frm_InfoCompany, ucLoaiVanban, ucCQBanHanh, ucCQNhanCV, ucDVXuLy, ucCanBoKy, ucCanBoXuLy, frm_ViTriLuu, frm_TODANPHO, frm_KHUPHO, frm_CSKV, frm_CongVanDen_DS, frm_CongVanDi_DS, frm_SoanVB, frm_MuonTra, frm_BienNhanHoSo_DS, frm_DanhSach_NVQS, frm_CongVanDen_TK, frm_CongVanDi_TK, frm_NhatKyLamViec, frm_DanhBaCoQuan, frm_DanhBaCaNhan, frm_BAOCAO";
                    string Form_Name = "Phân quyền, Sao lưu, Phục hồi, Đơn vị sử dụng, Danh mục loại văn bản, Danh mục cơ quan ban hành, Danh mục cơ quan nhận công văn, Danh mục đơn vị xử lý, Danh mục cán bộ ký, Danh mục cán bộ xử lý, Danh sách vị trí lưu, Danh sách tổ dân phố, Danh sách khu phố, Danh sách cảnh sát khu vực, Danh sách công văn đến, Danh sách công văn đi, Soạn văn bản, Biên nhận hồ sơ, Nghĩa vụ quân sự, Mượn - trả công văn, Tìm kiếm công văn đến, Tìm kiếm công văn đi, Nhật ký làm việc, Danh bạ cơ quan, Danh bạ cá nhân, Báo cáo các loại";
                    string[] Form_ID_s = Regex.Split(Form_ID, ",");
                    string[] Form_Name_s = Regex.Split(Form_Name, ",");
                    string Description = "";
                    for (int i = 0; i < Form_ID_s.Length; i++)
                    {
                        dt = SELECT_SYS_USER_FORM_ID(Group_ID, Form_ID_s[i].Trim());
                        if (dt.Rows.Count == 0)
                        {
                            string ID = System.Guid.NewGuid().ToString();
                            INSERT_SYS_USER_FORM(ID, Group_ID, Form_ID_s[i].Trim(), Form_Name_s[i].Trim(), Description, false, false, false, false, false, false, false, i, true);
                        }
                        else
                        {
                            UPDATE_SYS_USER_FORM2(Group_ID, Form_ID_s[i].Trim(), Form_Name_s[i].Trim(), Description, i, true);
                        }
                    }
                }
                DELETE_SYS_USER_FORM();
            }
            catch { }
        }

        public DataTable SELECT_SYS_USER_FORM_ID(string Group_ID, string Form_ID)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM SYS_USER_FORM WHERE Group_ID = @Group_ID AND Form_ID = @Form_ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Group_ID", Group_ID);
            cmd.Parameters.AddWithValue("@Form_ID", Form_ID);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            return dt;
        }

        // Insert SYS_USER_FORM
        public void INSERT_SYS_USER_FORM(string ID, string Group_ID, string Form_ID, string Form_Name, string Description, bool sAll, bool sSee, bool sAdd, bool sDelete, bool sEdit, bool sPrint, bool sExport, int SapXep, bool Active)
        {
            Open();
            string s = "INSERT INTO SYS_USER_FORM(ID, Group_ID, Form_ID, Form_Name, Description, sAll, sSee, sAdd, sDelete, sEdit, sPrint, sExport, SapXep, Active) VALUES(@ID, @Group_ID, @Form_ID, @Form_Name, @Description, @sAll, @sSee, @sAdd, @sDelete, @sEdit, @sPrint, @sExport, @SapXep, @Active)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Group_ID", Group_ID);
            cmd.Parameters.AddWithValue("@Form_ID", Form_ID);
            cmd.Parameters.AddWithValue("@Form_Name", Form_Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@sAll", sAll);
            cmd.Parameters.AddWithValue("@sSee", sSee);
            cmd.Parameters.AddWithValue("@sAdd", sAdd);
            cmd.Parameters.AddWithValue("@sDelete", sDelete);
            cmd.Parameters.AddWithValue("@sEdit", sEdit);
            cmd.Parameters.AddWithValue("@sPrint", sPrint);
            cmd.Parameters.AddWithValue("@sExport", sExport);
            cmd.Parameters.AddWithValue("@SapXep", SapXep);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.ExecuteNonQuery();
            Close();
        }
        // Update SYS_USER_FORM
        public void UPDATE_SYS_USER_FORM2(string Group_ID, string Form_ID, string Form_Name, string Description, int SapXep, bool Active)
        {
            Open();
            string s = "UPDATE SYS_USER_FORM SET Form_Name = @Form_Name, Description = @Description, SapXep = @SapXep, Active = @Active WHERE Group_ID = @Group_ID AND Form_ID = @Form_ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Group_ID", Group_ID);
            cmd.Parameters.AddWithValue("@Form_ID", Form_ID);
            cmd.Parameters.AddWithValue("@Form_Name", Form_Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@SapXep", SapXep);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.ExecuteNonQuery();
            Close();
        }

        public bool Quyen(string Form_ID, string Rule)
        {
            bool Rule2 = false;
            DataTable dt = ThamSoHeThong.Table_Rule.AsEnumerable().Where(row => row.Field<String>("Form_ID") == Form_ID).CopyToDataTable();
            if (dt.Rows.Count > 0)
                Rule2 = Convert.ToBoolean(dt.Rows[0][Rule].ToString());
            return Rule2;
        }
    }
}
