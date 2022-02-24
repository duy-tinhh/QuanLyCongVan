using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCongVan.Class
{
    public class csVaitro
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
        public DataTable SELECT_SYS_USER_GROUP_ID(string Group_ID)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM SYS_USER_GROUP WHERE Group_ID = @Group_ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Group_ID", Group_ID);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        // Insert SYS_USER_GROUP
        public void INSERT_SYS_USER_GROUP(string Group_ID, string Group_Name, string Description, bool Active)
        {
            Open();
            string s = "INSERT INTO SYS_USER_GROUP(Group_ID, Group_Name, Description, Active) VALUES(@Group_ID, @Group_Name, @Description, @Active)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Group_ID", Group_ID);
            cmd.Parameters.AddWithValue("@Group_Name", Group_Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.ExecuteNonQuery();
            Close();
        }
        // Update SYS_USER_GROUP
        public void UPDATE_SYS_USER_GROUP(string Group_ID, string Group_Name, string Description, bool Active)
        {
            Open();
            string s = "UPDATE SYS_USER_GROUP SET Group_Name = @Group_Name, Description = @Description, Active = @Active WHERE Group_ID = @Group_ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Group_ID", Group_ID);
            cmd.Parameters.AddWithValue("@Group_Name", Group_Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.ExecuteNonQuery();
            Close();
        }
        // Delete SYS_USER_GROUP
        public void DELETE_SYS_USER_GROUP(string Group_ID)
        {
            Open();
            string s = "DELETE FROM SYS_USER_GROUP WHERE Group_ID = @Group_ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Group_ID", Group_ID);
            cmd.ExecuteNonQuery();
            Close();
        }
    }
}
