using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace DoenaSoft.STC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            if (args?.Length > 0)
            {
                if (args[0].ToLower() == "/de")
                {
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}