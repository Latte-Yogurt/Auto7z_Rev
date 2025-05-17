using System;
using System.Windows.Forms;

namespace DelList
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }

            catch (Exception)
            {
                Environment.Exit(0);
            }
        }
    }
}
