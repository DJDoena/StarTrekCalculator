using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace DoenaSoft.STC
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            CultureInfo uiCulture = CultureInfo.GetCultureInfo("en-US");

            if (args.Any(arg => arg.ToLower() == "/de"))
            {
                uiCulture = CultureInfo.GetCultureInfo("de-DE");
            }

            Thread.CurrentThread.CurrentUICulture = uiCulture;

            if (args.Any(arg => arg.ToLower() == "/oldschool"))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
            {
                MainWindow window = new MainWindow();

                window.ShowDialog();
            }
        }
    }
}