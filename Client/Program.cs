using Client.UIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //FrmLogin frmLogin = new FrmLogin();
            //Application.Run(frmLogin);
            //if (frmLogin.Login == true)
            //{
            //    Application.Run(new FrmClientList());
            //}

            Application.Run(new test.Form1());
        }
    }
}
