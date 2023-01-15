using AppBanVeXemPhim.PresentationTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AppBanVeXemPhim
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //frmLogin frmDangNhap = new frmLogin();
            //if(frmDangNhap.ShowDialog() == DialogResult.OK)
            //{
                Application.Run(new frmLogin());
            //}
            
        }
    }

}
