using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace DoenaSoft.STC
{
    static class Program
    {
        [STAThread]
        static void Main(String[] args)
        {
            string firstArg = args?.FirstOrDefault();

            CultureInfo uiCulture = CultureInfo.GetCultureInfo("en-US");

            if (firstArg?.ToLower() == "/de")
            {
                uiCulture = CultureInfo.GetCultureInfo("de-DE");
            }

            Thread.CurrentThread.CurrentUICulture = uiCulture;

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());

            MainWindow window = new MainWindow();

            window.ShowDialog();
        }
    }
}