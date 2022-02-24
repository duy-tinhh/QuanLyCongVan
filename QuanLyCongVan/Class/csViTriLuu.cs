using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCongVan.Class
{
    public class csViTriLuu
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

        public DataTable SELECT_VITRILUU()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, Name, Description, Sort, Active FROM VITRILUU ORDER BY Sort, Name ASC";
            SqlDataAdapter dad = new SqlDataAdapter(s, con);
            dad.Fill(dt);
            Close();
            return dt;
        }
        public bool SELECT_VITRILUU_ID(string ID)
        {
            Open();
            bool a = false;
            string s = "SELECT ID FROM VITRILUU WHERE ID = @ID";
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
        public bool CHECK_VITRILUU_DI(string VITRILUU)
        {
            Open();
            bool a = false;
            string s = "SELECT VITRILUU FROM CONGVANDI WHERE VITRILUU = @VITRILUU";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@VITRILUU", VITRILUU);
            SqlDataReader dd = cmd.ExecuteReader();
            if (dd.HasRows)
            {
                a = true;
            }
            Close();
            return a;
        }
        public bool CHECK_VITRILUU_DEN(string VITRILUU)
        {
            Open();
            bool a = false;
            string s = "SELECT VITRILUU FROM CONGVANDEN WHERE VITRILUU = @VITRILUU";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@VITRILUU", VITRILUU);
            SqlDataReader dd = cmd.ExecuteReader();
            if (dd.HasRows)
            {
                a = true;
            }
            Close();
            return a;
        }
        public void INSERT_VITRILUU(string ID, string Name, string Description, bool Active)
        {
            Open();
            string s = "INSERT INTO VITRILUU(ID, Name, Description, Active) VALUES(@ID, @Name, @Description, @Active)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void UPDATE_VITRILUU(string ID, string Name, string Description, bool Active)
        {
            Open();
            string s = "UPDATE VITRILUU SET Name = @Name, Description = @Description, Active = @Active WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void DELETE_VITRILUU(string ID)
        {
            Open();
            string s = "DELETE FROM VITRILUU WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            Close();
        }

    }
}
