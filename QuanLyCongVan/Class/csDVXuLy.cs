using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCongVan.Class
{
    public class csDVXuLy
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
        public DataTable SELECT_DVXULY()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, Name, Description, Active FROM DVXULY ORDER BY Active, Name ASC";
            SqlDataAdapter dad = new SqlDataAdapter(s, con);
            dad.Fill(dt);
            Close();
            return dt;
        }
        public bool SELECT_DVXULY_ID(string ID)
        {
            Open();
            bool a = false;
            DataTable dt = new DataTable();
            string s = "SELECT ID FROM DVXULY WHERE ID = @ID";
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

        public bool CHECK_CANBOXULY(string DonViXuLy)
        {
            Open();
            bool a = false;
            DataTable dt = new DataTable();
            string s = "SELECT DonViXuLy FROM CANBOXULY WHERE DonViXuLy = @DonViXuLy";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@DonViXuLy", DonViXuLy);
            SqlDataReader dd = cmd.ExecuteReader();
            if (dd.HasRows)
            {
                a = true;
            }
            Close();
            return a;
        }
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
            Close();
        }
        public void UPDATE_DVXULY(string ID, string Name, string Description, bool Active)
        {
            Open();
            string s = "UPDATE DVXULY SET Name = @Name, Description = @Description, Active = @Active WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void DELETE_DVXULY(string ID)
        {
            Open();
            string s = "DELETE FROM DVXULY WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            Close();
        }

    }
}
