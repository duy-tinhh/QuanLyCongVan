using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCongVan.Class
{
    public class ConfigApp
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
        // Delete CONFIG
        public void DELETE_CONFIG(string COMPUTER, string FORM, string CONTROL)
        {
            Open();
            string s = "DELETE CONFIG WHERE FORM = @FORM AND CONTROL = @CONTROL AND COMPUTER = @COMPUTER";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@COMPUTER", COMPUTER);
            cmd.Parameters.AddWithValue("@FORM", FORM);
            cmd.Parameters.AddWithValue("@CONTROL", CONTROL);
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            Close();
        }
        private DataTable CHECK_CONFIG_FORM(string COMPUTER, string FORM, string CONTROL, string COLUMNS)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM CONFIG WHERE FORM = @FORM AND CONTROL = @CONTROL AND COLUMNS = @COLUMNS AND COMPUTER = @COMPUTER";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@COMPUTER", COMPUTER);
            cmd.Parameters.AddWithValue("@FORM", FORM);
            cmd.Parameters.AddWithValue("@CONTROL", CONTROL);
            cmd.Parameters.AddWithValue("@COLUMNS", COLUMNS);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }
        private DataTable CHECK_CONFIG_FORM_2(string COMPUTER, string FORM, string CONTROL)
        {
            Open();
            DataTable dt = new DataTable();
            string s = "SELECT * FROM CONFIG WHERE FORM = @FORM AND CONTROL = @CONTROL AND COMPUTER = @COMPUTER ORDER BY SORT ASC";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@COMPUTER", COMPUTER);
            cmd.Parameters.AddWithValue("@FORM", FORM);
            cmd.Parameters.AddWithValue("@CONTROL", CONTROL);
            SqlDataAdapter dad = new SqlDataAdapter(cmd);
            dad.Fill(dt);
            Close();
            return dt;
        }

        public void INSERT_CONFIG(string ID, string COMPUTER, string FORM, string CONTROL, string COLUMNS, bool HIDDEN, int WIDTH, int SORT)
        {
            Open();
            string s = "INSERT INTO CONFIG(ID, COMPUTER, FORM, CONTROL, COLUMNS, HIDDEN, WIDTH, SORT) VALUES(@ID, @COMPUTER, @FORM, @CONTROL, @COLUMNS, @HIDDEN, @WIDTH, @SORT)";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@COMPUTER", COMPUTER);
            cmd.Parameters.AddWithValue("@FORM", FORM);
            cmd.Parameters.AddWithValue("@CONTROL", CONTROL);
            cmd.Parameters.AddWithValue("@COLUMNS", COLUMNS);
            cmd.Parameters.AddWithValue("@HIDDEN", HIDDEN);
            cmd.Parameters.AddWithValue("@WIDTH", WIDTH);
            cmd.Parameters.AddWithValue("@SORT", SORT);
            cmd.ExecuteNonQuery();
            Close();
        }
        public void UPDATE_CONFIG_FORM(string COMPUTER, string FORM, string COLUMNS, bool HIDDEN, int WIDTH, int SORT)
        {
            Open();
            string s = "UPDATE CONFIG SET HIDDEN = @HIDDEN, WIDTH = @WIDTH, SORT = @SORT WHERE FORM =  @FORM AND COLUMNS =  @COLUMNS AND COMPUTER = @COMPUTER";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@COMPUTER", COMPUTER);
            cmd.Parameters.AddWithValue("@FORM", FORM);
            cmd.Parameters.AddWithValue("@COLUMNS", COLUMNS);
            cmd.Parameters.AddWithValue("@HIDDEN", HIDDEN);
            cmd.Parameters.AddWithValue("@WIDTH", WIDTH);
            cmd.Parameters.AddWithValue("@SORT", SORT);
            cmd.ExecuteNonQuery();
            Close();
        }

        public void UPDATE_CONFIG_FORM_2(string COMPUTER, string FORM, string CONTROL, string COLUMNS, bool HIDDEN, int WIDTH, int SORT)
        {
            Open();
            string s = "UPDATE CONFIG SET COLUMNS =  @COLUMNS, HIDDEN = @HIDDEN, WIDTH = @WIDTH, SORT = @SORT WHERE FORM =  @FORM AND CONTROL =  @CONTROL AND COMPUTER = @COMPUTER";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@COMPUTER", COMPUTER);
            cmd.Parameters.AddWithValue("@FORM", FORM);
            cmd.Parameters.AddWithValue("@CONTROL", CONTROL);
            cmd.Parameters.AddWithValue("@COLUMNS", COLUMNS);
            cmd.Parameters.AddWithValue("@HIDDEN", HIDDEN);
            cmd.Parameters.AddWithValue("@WIDTH", WIDTH);
            cmd.Parameters.AddWithValue("@SORT", SORT);
            cmd.ExecuteNonQuery();
            Close();
        }

        public void Load_View(string FormName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            try
            {
                string COMPUTER = ThamSoHeThong.TenMayTinh;
                DataTable dt = CHECK_CONFIG_FORM_2(COMPUTER, FormName, gridView.Name);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ColumnsName = dt.Rows[i]["COLUMNS"].ToString();
                    bool Hidden = Convert.ToBoolean(dt.Rows[i]["HIDDEN"].ToString());
                    int Width = Convert.ToInt16(dt.Rows[i]["WIDTH"].ToString());
                    gridView.Columns[ColumnsName].VisibleIndex = i;
                    gridView.Columns[ColumnsName].Width = Width;
                    gridView.Columns[ColumnsName].Visible = Hidden;
                }
            }
            catch { }
        }
        public void Set_View(string FormName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            try
            {
                string COMPUTER = ThamSoHeThong.TenMayTinh;
                DELETE_CONFIG(COMPUTER, FormName, gridView.Name);
                for (int i = 0; i < gridView.Columns.Count; i++)
                {
                    string ID = System.Guid.NewGuid().ToString();
                    string ColumnsName = gridView.Columns[i].FieldName.ToString();
                    int Index = gridView.Columns[i].VisibleIndex;
                    bool VisiableColumns = gridView.Columns[i].Visible;
                    int Width = gridView.Columns[i].Width;
                    INSERT_CONFIG(ID, COMPUTER, FormName, gridView.Name, ColumnsName, VisiableColumns, Width, Index);
                }
            }
            catch { }        
        }

        string TenDropDownButton = "DropDownButton1";
        public string Set_DropDownButton(string FormName)
        {
            string Value = "";
            try
            {
                string COMPUTER = ThamSoHeThong.TenMayTinh;
                DataTable dt = CHECK_CONFIG_FORM_2(COMPUTER, FormName, TenDropDownButton);
                if (dt.Rows.Count > 0)
                {
                    Value = dt.Rows[0]["COLUMNS"].ToString();
                }                
            }
            catch { }
            return Value;
        }
        public void Get_DropDownButton(string FormName, string ColumnsName)
        {
            try
            {
                string COMPUTER = ThamSoHeThong.TenMayTinh;
                DataTable dt = CHECK_CONFIG_FORM_2(COMPUTER, FormName, TenDropDownButton);
                if (dt.Rows.Count > 0)
                    UPDATE_CONFIG_FORM_2(COMPUTER, FormName, TenDropDownButton, ColumnsName, true, 0, 0);
                else
                {
                    string ID = System.Guid.NewGuid().ToString();
                    INSERT_CONFIG(ID, COMPUTER, FormName, TenDropDownButton, ColumnsName, true, 0, 0);
                }
            }
            catch { }
        }
    }
}
