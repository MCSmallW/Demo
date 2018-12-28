using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Test3rd
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
            Application.Run(new Loading());
            //Application.Run(new Form1());
        }
    }
}
