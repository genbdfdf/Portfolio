using System;
using System.Windows.Forms;

namespace mapMaker
{
    static class Program
    {
        /// <summary>
        ///  應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
