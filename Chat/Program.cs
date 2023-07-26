using Server.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    internal static class Program
    {
        ///// <summary>
        ///// 应用程序的主入口点。
        ///// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);

        //    Application.Run(new UIL.View.FormServer());
        //    //Application.Run(new test.Form1());
        //}

        static void Main(string[] args)
        {
            StartUp st = new StartUp();
            st.Start();

            Console.WriteLine("Server start...");
            Console.Read();
        }

    }
}
