using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QuanLyCongVan.Class
{
    public class csAddTable
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
        public void EDIT_DATA()
        {
            try
            {
                int ID = CHECK_VERSION();
                if (ID <= 20)
                {
                    CREATE_SQL("DROP TABLE CONGVANDEN_DUAN");
                    CREATE_SQL("DROP TABLE CONGVANDI_DUAN");
                    CREATE_SQL("DROP TABLE CSKV");
                    CREATE_SQL("DROP TABLE FILE_CVDEN_DA");
                    CREATE_SQL("DROP TABLE FILE_CVDI_DA");
                    CREATE_SQL("DROP TABLE KHUPHO");
                    CREATE_SQL("DROP TABLE GIAIDOAN");
                    CREATE_SQL("DROP TABLE MUONTRA_DA");
                    CREATE_SQL("DROP TABLE NVQS");
                    CREATE_SQL("DROP TABLE NVQS_DS");
                    CREATE_SQL("DROP TABLE NVQS_NH");
                    CREATE_SQL("DROP TABLE NVQS_REPORT");
                    CREATE_SQL("DROP TABLE TODANPHO");
                    CREATE_SQL("DROP TABLE DUAN");

                    CREATE_SQL("UPDATE CONGVANDEN SET ID = (RIGHT(ID, LEN(ID)- 6))");
                    CREATE_SQL("UPDATE FILE_CVDEN SET ID = (RIGHT(ID, LEN(ID)- 6))");
                    CREATE_SQL("ALTER TABLE CONGVANDEN ALTER COLUMN ID INT");
                    CREATE_SQL("ALTER TABLE FILE_CVDEN ALTER COLUMN MACV INT");

                    //CREATE_SQL("UPDATE CONGVANDI SET ID = (RIGHT(ID, LEN(ID)- 6))");
                    //CREATE_SQL("UPDATE FILE_CVDI SET ID = (RIGHT(ID, LEN(ID)- 6))");
                    CREATE_SQL("ALTER TABLE CONGVANDI ALTER COLUMN ID INT");
                    CREATE_SQL("ALTER TABLE FILE_CVDI ALTER COLUMN MACV INT");
                    Class.csUser Adduser = new Class.csUser();
                    Adduser.FORM_RULE();
                    UPDATE_VERSION(21);
                }
                if (ID <= 21)
                {
                    DataTable dt = SELECT_SQL("SELECT * FROM CONGVANDEN WHERE SAPXEP = '-1'");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        decimal ID_CONGVANDEN = Convert.ToDecimal(dt.Rows[i]["ID"].ToString());
                        DataTable dtchitiet = SELECT_SQL("SELECT * FROM CONGVANDEN WHERE ID = '"+ ID_CONGVANDEN + "' AND SAPXEP > '-1' ORDER BY SAPXEP ASC");
                        string ID_DVXULY = "";
                        for (int j = 0; j < dtchitiet.Rows.Count; j++)
                        {
                            ID_DVXULY += dtchitiet.Rows[j]["TENNV"].ToString() + ", ";
                        }
                        if (ID_DVXULY.Length > 2)
                            ID_DVXULY = ID_DVXULY.Substring(0, ID_DVXULY.Length - 2);

                        CREATE_SQL("UPDATE CONGVANDEN SET ID_DVXULY = N'" + ID_DVXULY + "' WHERE ID = '" + ID_CONGVANDEN + "'");
                    }
                    UPDATE_VERSION(22);
                }
            }
            catch { }
        }
        public int CHECK_VERSION()
        {
            Open();
            int Version = 100;
            DataTable dt = new DataTable();
            string s = "SELECT VERSION FROM VERSION WHERE APPNAME = 'QLCV_SXDHN'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Version = Convert.ToInt16(dt.Rows[0]["VERSION"].ToString());
            }
            Close();
            return Version;
        }
        void UPDATE_VERSION(int VERSION)
        {
            try
            {
                Open();
                string s = "UPDATE VERSION SET VERSION = @VERSION WHERE APPNAME = 'QLCV_SXDHN'";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@VERSION", VERSION);
                cmd.ExecuteNonQuery();
                Close();
            }
            catch { }
        }
        void CREATE_SQL(string sql)
        {
            try
            {
                Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                Close();
            }
            catch { }
        }
        DataTable SELECT_SQL(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter dad = new SqlDataAdapter(cmd);
                dad.Fill(dt);
                Close();
            }
            catch { }
            return dt;
        }
    }
}
