using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCongVan.Class
{
    public class csCQNhanCV
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
        public DataTable SELECT_CQNHANCV()
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM CQNHANCV ORDER BY ACTIVE,NAME ASC";
            SqlDataAdapter dad = new SqlDataAdapter(s, con);
            dad.Fill(dt);
            Close();
            return dt;
        }
        public bool SELECT_CQNHANCV_ID(string ID)
        {
            Open();
            bool a = false;
            DataTable dt = new DataTable();
            string s = "SELECT ID FROM CQNHANCV WHERE ID = @ID";
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
        public bool CHECK_LOAIVANBAN_DI(string ID)
        {
            Open();
            bool a = false;
            DataTable dt = new DataTable();
            string s = "SELECT ID_DVXULY FROM CONGVANDI_DONVI WHERE ID_DVXULY = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataReader dd = cmd.ExecuteReader();
            if (dd.HasRows)
            {
                a = true;
            }
            Close();
            return a;
        }

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
            Close();
        }
        public void UPDATE_CQNHANCV(string ID, string Name, string Description, bool Active)
        {
            Open();
            string s = "UPDATE CQNHANCV SET Name = @Name, Description = @Description, Active = @Active WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Active", Active);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void DELETE_CQNHANCV(string ID)
        {
            Open();
            string s = "DELETE FROM CQNHANCV WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            Close();
        }

        public bool CHECK_CQBANHANH(string ID, string TableName)
        {
            Open();
            bool a = false;
            DataTable dt = new DataTable();
            string s = "SELECT ID_CQBANHANH FROM " + TableName + " WHERE ID_CQBANHANH = @ID";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataReader dd = cmd.ExecuteReader();
            if (dd.HasRows)
            {
                a = true;
            }
            Close();
            return a;
        }
    }
}
