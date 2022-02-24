using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCongVan.Class
{
    public class csCanBoXuLy
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
        public DataTable SELECT_CANBOXULY()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM CANBOXULY ORDER BY ACTIVE, Name ASC";
            SqlDataAdapter dad = new SqlDataAdapter(s, con);
            dad.Fill(dt);
            Close();
            return dt;
        }

        public DataTable SELECT_NGUOIDUYET()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT CANBOXULY.ID, CANBOXULY.Name FROM CANBOXULY, SYS_USER WHERE CANBOXULY.ID = SYS_USER.USER_ID AND SYS_USER.TYPE = 'LD' ORDER BY CANBOXULY.ACTIVE, CANBOXULY.Name ASC";
            SqlDataAdapter dad = new SqlDataAdapter(s, con);
            dad.Fill(dt);
            Close();
            return dt;
        }
        public bool SELECT_LOAIVANBAN_ID(string ID)
        {
            Open();
            bool a = false;
            string s = "SELECT ID FROM CANBOXULY WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s,con);
            cmd.Parameters.AddWithValue("@ID", ID); 
            SqlDataReader dd = cmd.ExecuteReader();
            if (dd.HasRows)
            {
                a = true;
            }
            Close();
            return a;
        }
        public bool CHECK_LOAIVANBAN_DI(string ID_CANBOXULY)
        {
            Open();
            bool a = false;
            string s = "SELECT ID_CANBOXULY FROM CONGVANDI WHERE ID_CANBOXULY = @ID_CANBOXULY";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID_CANBOXULY", ID_CANBOXULY);
            SqlDataReader dd = cmd.ExecuteReader();
            if (dd.HasRows)
            {
                a = true;
            }
            Close();
            return a;
        }
        public bool CHECK_LOAIVANBAN_DEN(string ID_CANBOXULY)
        {
            Open();
            bool a = false;
            string s = "SELECT ID_CANBOXULY FROM CONGVANDEN WHERE ID_CANBOXULY = @ID_CANBOXULY";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID_CANBOXULY", ID_CANBOXULY);
            SqlDataReader dd = cmd.ExecuteReader();
            if (dd.HasRows)
            {
                a = true;
            }
            Close();
            return a;
        }
        // Insert CANBOXULY
        public void INSERT_CANBOXULY(string ID, string Name, string Description, bool Active, string DonViXuLy, string MADV, string Address, string Tel, string Email)
        {
            Open();
            string s = "INSERT INTO CANBOXULY(ID, Name, Description, Active, DonViXuLy, MADV, Address, Tel, Email) VALUES(@ID, @Name, @Description, @Active, @DonViXuLy, @MADV, @Address, @Tel, @Email)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@DonViXuLy", DonViXuLy);
            cmd.Parameters.AddWithValue("@MADV", MADV);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Tel", Tel);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            Close();
        }

        // Update CANBOXULY
        public void UPDATE_CANBOXULY(string ID, string Name, string Description, bool Active, string DonViXuLy, string MADV, string Address, string Tel, string Email)
        {
            Open();
            string s = "UPDATE CANBOXULY SET Name = @Name, Description = @Description, Active = @Active, DonViXuLy = @DonViXuLy, MADV = @MADV, Address = @Address, Tel = @Tel, Email = @Email WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.Parameters.AddWithValue("@DonViXuLy", DonViXuLy);
            cmd.Parameters.AddWithValue("@MADV", MADV);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Tel", Tel);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            Close();
        }
        public void DELETE_CANBOXULY(string ID)
        {
            Open();
            string s = "DELETE FROM CANBOXULY WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            Close();
        }

    }
}
