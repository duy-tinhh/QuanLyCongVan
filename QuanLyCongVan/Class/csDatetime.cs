using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCongVan.Class
{
    public class csDatetime
    {

        public DateTime Today()
        {
            int y = DateTime.Now.Year;
            int m = DateTime.Now.Month;
            int d = DateTime.Now.Day;
            DateTime First = new DateTime(y,m,d);
            return First;
        }

        DateTime Yesterday()
        {
            DateTime First;
            int y = DateTime.Now.Year;
            int m = DateTime.Now.Month;
            int d = DateTime.Now.Day;
            First = new DateTime(y, m, d);
            First = First.AddDays(-1);
            return First;
        }
        //Đầu tuần
        DateTime WeekFirst()
        {
            DateTime date = DateTime.Now;
            while (date.DayOfWeek != DayOfWeek.Monday)
            {
                date = date.AddDays(-1);
            }     
            DateTime d = new DateTime(date.Year, date.Month, date.Day);
            return d;
        }

        //Cuoi tuan
        DateTime WeekEnd()
        {
            DateTime date = DateTime.Now;
            while (date.DayOfWeek != DayOfWeek.Sunday)
            {
                date = date.AddDays(1);
            }
            DateTime d = new DateTime(date.Year, date.Month, date.Day);
            return d;
        }
        //Tháng này
        public DateTime DateFirstMonth()
        {
            int y = DateTime.Now.Year;
            int m = DateTime.Now.Month;
            DateTime First =  new DateTime(y, m, 1);
            return First;
        }//tháng này
        DateTime DateLastMonth()
        {
            int y = DateTime.Now.Year;
            int m = DateTime.Now.Month;
            DateTime First = new DateTime(y, m, 1);
            DateTime Last = First.AddMonths(1).AddDays(-1);
            return Last;
        }

        //Thangtruoc
        DateTime DateMonthAgo1()
        {
            int y = DateTime.Now.Year;
            int m = DateTime.Now.Month;
            DateTime First = new DateTime(y, m, 1);
            return First.AddMonths(-1);
        }
        DateTime DateMonthAgo2()
        {
            int y = DateTime.Now.Year;
            int m = DateTime.Now.Month;
            DateTime First = new DateTime(y, m, 1);
            DateTime Last = First.AddDays(-1);
            return Last;
        }
        //Nam nay
        DateTime DateYear1()
        {
            int y = DateTime.Now.Year;
            DateTime First = new DateTime(y, 1, 1);
            return First;
        }
        DateTime DateYear2()
        {
            int y = DateTime.Now.Year;
            DateTime First = new DateTime(y, 1, 1);
            DateTime Last = First.AddYears(1).AddDays(-1);
            return Last;
        }
        //Nam roi
        DateTime DateYearAgo1()
        {
            int y = DateTime.Now.Year - 1;
            DateTime First = new DateTime(y, 1, 1);
            return First;
        }
        DateTime DateYearAgo2()
        {
            int y = DateTime.Now.Year - 1;
            DateTime First = new DateTime(y, 1, 1);
            DateTime Last = First.AddYears(1).AddDays(-1);
            return Last;
        }
        //Tháng gì?
        DateTime DateMonth1(int m)
        {
            int y = DateTime.Now.Year;
            DateTime First = new DateTime(y, m, 1);
            return First;
        }
        DateTime DateMonth2(int m)
        {
            int y = DateTime.Now.Year;
            DateTime First = new DateTime(y, m, 1);
            DateTime Last = First.AddMonths(1).AddDays(-1);
            return Last;
        }
        //Ca lam viec

        public void CaLamViec(DevExpress.XtraEditors.ComboBoxEdit cbCa, DevExpress.XtraEditors.CalcEdit Dauca, DevExpress.XtraEditors.CalcEdit Cuoica)
        {
            if (cbCa.SelectedItem.ToString() == "Cả ngày")
            {
                Dauca.Value = 0;
                Cuoica.Value = 24;
            }
            else if (cbCa.SelectedItem.ToString() == "Ca sáng")
            {
                Dauca.Value = 0;
                Cuoica.Value = 13;
            }
            else
            {
                Dauca.Value = 13;
                Cuoica.Value = 24;
            }
        }
        public void NgayThangNam(string Chon, DevExpress.XtraEditors.DateEdit dtp1, DevExpress.XtraEditors.DateEdit dtp2)
        {
            if (Chon == "0")
            {
                dtp1.DateTime = Today();
                dtp2.DateTime = Today();
            }
            else if (Chon == "1")
            {
                dtp1.DateTime = Yesterday();
                dtp2.DateTime = Yesterday();
            }
            else if (Chon == "2")
            {
                dtp1.DateTime = WeekFirst();
                dtp2.DateTime = WeekEnd();
            }
            else if (Chon == "3")
            {
                dtp1.DateTime = DateFirstMonth();
                dtp2.DateTime = DateLastMonth();
            }
            else if (Chon == "4")
            {
                dtp1.DateTime = DateMonthAgo1();
                dtp2.DateTime = DateMonthAgo2();
            }
            else if (Chon == "5")
            {
                dtp1.DateTime = DateYear1();
                dtp2.DateTime = DateYear2();
            }
            else if (Chon == "6")
            {
                dtp1.DateTime = DateYearAgo1();
                dtp2.DateTime = DateYearAgo2();
            }
            else
            {
                int So = Convert.ToInt16(Chon);
                dtp1.DateTime = DateMonth1(So - 6);
                dtp2.DateTime = DateMonth2(So - 6);
            }
        }

        public string Ngaythangsinh(DevExpress.XtraEditors.DateEdit dtp1)
        {
            string Ngaythangnam = "";
            TimeSpan d = DateTime.Now - dtp1.DateTime;
            int TongNgay = d.Days;
            if (TongNgay <= 31)
            {
                Ngaythangnam = TongNgay + " ngày";
            }
            else if (TongNgay < 2160)
            {
                int TongThang = d.Days / 30;
                int ngay = TongNgay - (TongThang * 30);
                Ngaythangnam = TongThang + " tháng " + ngay + " ngày";
            }
            else
            {
                int Tuoi = DateTime.Now.Year - dtp1.DateTime.Year;
                Ngaythangnam = Tuoi.ToString();
            }
            return Ngaythangnam;
        }

        public DataTable DanhMucDate()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            try
            {
                string file = Application.StartupPath + "\\Language.txt";
                if (File.Exists(file))
                {
                    string lang = File.ReadAllText(file);
                    if (lang != "vn")
                    {
                        file = Application.StartupPath + "\\Languages\\" + lang + "\\Date.txt";
                        if (File.Exists(file))
                        {
                            string[] lines = File.ReadAllLines(file);
                            int RowLine = File.ReadAllLines(file).Length;
                            for (int i = 0; i < RowLine; i++)
                            {
                                dt.Rows.Add(i, lines[i]);
                            }
                        }
                        else
                        {
                            dt.Rows.Add(0, "Hôm nay");
                            dt.Rows.Add(1, "Hôm qua");
                            dt.Rows.Add(2, "Tuần này");
                            dt.Rows.Add(3, "Tháng này");
                            dt.Rows.Add(4, "Tháng trước");
                            dt.Rows.Add(5, "Năm nay");
                            dt.Rows.Add(6, "Năm trước");
                            dt.Rows.Add(7, "Tháng 1");
                            dt.Rows.Add(8, "Tháng 2");
                            dt.Rows.Add(9, "Tháng 3");
                            dt.Rows.Add(10, "Tháng 4");
                            dt.Rows.Add(11, "Tháng 5");
                            dt.Rows.Add(12, "Tháng 6");
                            dt.Rows.Add(13, "Tháng 7");
                            dt.Rows.Add(14, "Tháng 8");
                            dt.Rows.Add(15, "Tháng 9");
                            dt.Rows.Add(16, "Tháng 10");
                            dt.Rows.Add(17, "Tháng 11");
                            dt.Rows.Add(18, "Tháng 12");
                        }
                    }
                    else
                    {
                        dt.Rows.Add(0, "Hôm nay");
                        dt.Rows.Add(1, "Hôm qua");
                        dt.Rows.Add(2, "Tuần này");
                        dt.Rows.Add(3, "Tháng này");
                        dt.Rows.Add(4, "Tháng trước");
                        dt.Rows.Add(5, "Năm nay");
                        dt.Rows.Add(6, "Năm trước");
                        dt.Rows.Add(7, "Tháng 1");
                        dt.Rows.Add(8, "Tháng 2");
                        dt.Rows.Add(9, "Tháng 3");
                        dt.Rows.Add(10, "Tháng 4");
                        dt.Rows.Add(11, "Tháng 5");
                        dt.Rows.Add(12, "Tháng 6");
                        dt.Rows.Add(13, "Tháng 7");
                        dt.Rows.Add(14, "Tháng 8");
                        dt.Rows.Add(15, "Tháng 9");
                        dt.Rows.Add(16, "Tháng 10");
                        dt.Rows.Add(17, "Tháng 11");
                        dt.Rows.Add(18, "Tháng 12");
                    }
                }
                else
                {
                    dt.Rows.Add(0, "Hôm nay");
                    dt.Rows.Add(1, "Hôm qua");
                    dt.Rows.Add(2, "Tuần này");
                    dt.Rows.Add(3, "Tháng này");
                    dt.Rows.Add(4, "Tháng trước");
                    dt.Rows.Add(5, "Năm nay");
                    dt.Rows.Add(6, "Năm trước");
                    dt.Rows.Add(7, "Tháng 1");
                    dt.Rows.Add(8, "Tháng 2");
                    dt.Rows.Add(9, "Tháng 3");
                    dt.Rows.Add(10, "Tháng 4");
                    dt.Rows.Add(11, "Tháng 5");
                    dt.Rows.Add(12, "Tháng 6");
                    dt.Rows.Add(13, "Tháng 7");
                    dt.Rows.Add(14, "Tháng 8");
                    dt.Rows.Add(15, "Tháng 9");
                    dt.Rows.Add(16, "Tháng 10");
                    dt.Rows.Add(17, "Tháng 11");
                    dt.Rows.Add(18, "Tháng 12");
                }
            }
            catch { }
            return dt;
        }
    }
}
