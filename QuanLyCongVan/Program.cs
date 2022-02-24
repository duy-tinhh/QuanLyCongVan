using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;


namespace QuanLyCongVan
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {    
            bool firstInstance;
            string s = "QLCV";
            using (Mutex mutex = new Mutex(true, s, out firstInstance))
            {
                if (firstInstance)
                {   
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    GridLocalizer.Active = new Class.MyGridLocalizer();
                    Localizer.Active = new Class.MyLocalizer();

                    DevExpress.Skins.SkinManager.EnableFormSkins();
                    DevExpress.UserSkins.BonusSkins.Register();
                    UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
                    Application.Run(new Main());
                  //  Application.Run(new R7_NVQS.frm_Them());
                }
                else
                {
                    Application.Exit();
                }
            }    
        }
    }
}