using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCongVan.Class
{
    public class csLoaiVanBan
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

        public DataTable SELECT_LOAIVANBAN()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT ID, Name, Description, Active FROM LOAIVANBAN ORDER BY Sort ASC, Active ASC";
            SqlDataAdapter dad = new SqlDataAdapter(s, con);
            dad.Fill(dt);
            Close();
            return dt;
        }
        public bool SELECT_LOAIVANBAN_ID(string ID)
        {
            Open();
            bool a = false;
            DataTable dt = new DataTable();
            string s = "SELECT ID FROM LOAIVANBAN WHERE ID = @ID";
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
        public bool CHECK_LOAIVANBAN(string ID_LOAIVANBAN, string TableName)
        {
            Open();
            bool a = false;
            DataTable dt = new DataTable();
            string s = "SELECT ID_LOAIVANBAN FROM " + TableName + " WHERE ID_LOAIVANBAN = @ID_LOAIVANBAN";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID_LOAIVANBAN", ID_LOAIVANBAN);
            SqlDataReader dd = cmd.ExecuteReader();
            if (dd.HasRows)
            {
                a = true;
            }
            Close();
            return a;
        }
        public void INSERT_LOAIVANBAN(string ID, string Name, string Description, bool Active)
        {
            Open();
            string s = "INSERT INTO LOAIVANBAN(ID, Name, Description, Active) VALUES(@ID, @Name, @Description, @Active)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void UPDATE_LOAIVANBAN(string ID, string Name, string Description, bool Active)
        {
            Open();
            string s = "UPDATE LOAIVANBAN SET Name = @Name, Description = @Description, Active = @Active WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void DELETE_LOAIVANBAN(string ID)
        {
            Open();
            string s = "DELETE FROM LOAIVANBAN WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            Close();
        }

    }
}
