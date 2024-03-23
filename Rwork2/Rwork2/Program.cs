using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rwork2
{
    internal static class Program
    {
        public static FormLogin formLogin;
        public static FormMain formMain;
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formLogin = new FormLogin();
            Application.Run(formLogin);
        }
    }
}
