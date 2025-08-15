using System;
using System.Windows.Forms;

namespace MD5Calculator
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ProgressBarForm(args));
            }

            catch (Exception)
            {
                Environment.Exit(0);
            }
        }
    }
}
