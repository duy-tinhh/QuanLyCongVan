using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCongVan.Class
{
    public class csData
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
        public void BACKUP_DATABASE(string Disk, string Data)
        {
            Open();
            string s = "BACKUP DATABASE @Data TO DISK = @Disk";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Disk", Disk);
            cmd.Parameters.AddWithValue("@Data", Data); 
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            Close();
        }
        public void RESTORE_DATABASE(string Disk, string Data)
        {
            Open();
            string UseMaster = "USE master";
            SqlCommand UseMasterCommand = new SqlCommand(UseMaster, con);
            UseMasterCommand.CommandTimeout = 0;
            UseMasterCommand.ExecuteNonQuery();

            string Alter1 = @"ALTER DATABASE " + Data + " SET Single_User WITH Rollback Immediate";
            SqlCommand Alter1Cmd = new SqlCommand(Alter1, con);
            //Alter1Cmd.Parameters.AddWithValue("@Data", Data);
            Alter1Cmd.CommandTimeout = 0;
            Alter1Cmd.ExecuteNonQuery();

            string Restore = @"RESTORE DATABASE " + Data + " FROM DISK = N'" + Disk + @"' WITH  FILE = 1,  NOUNLOAD,  STATS = 10";
            SqlCommand RestoreCmd = new SqlCommand(Restore, con);
            //RestoreCmd.Parameters.AddWithValue("@Disk", Disk);
            //RestoreCmd.Parameters.AddWithValue("@Data", Data);
            RestoreCmd.CommandTimeout = 0;
            RestoreCmd.ExecuteNonQuery();

            string Alter2 = @"ALTER DATABASE " + Data + " SET Multi_User";
            SqlCommand Alter2Cmd = new SqlCommand(Alter2, con);
            //RestoreCmd.Parameters.AddWithValue("@Data", Data);
            Alter2Cmd.CommandTimeout = 0;
            Alter2Cmd.ExecuteNonQuery();
            Close();
        }
        public void RESTORE_DATABASE_ERROR(string Data)
        {
            Open();
            string Alter2 = @"ALTER DATABASE " + Data + " SET Multi_User";
            SqlCommand Alter2Cmd = new SqlCommand(Alter2, con);
            Alter2Cmd.CommandTimeout = 0;
            Alter2Cmd.ExecuteNonQuery();
            Close();
        }
    }
}
