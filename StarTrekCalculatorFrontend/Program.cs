namespace DoenaSoft.STC
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            var uiCulture = CultureInfo.GetCultureInfo("en-US");

            if (args.Any(arg => arg.ToLower() == "/de"))
            {
                uiCulture = CultureInfo.GetCultureInfo("de-DE");
            }

            Thread.CurrentThread.CurrentUICulture = uiCulture;

            var window = new MainWindow();

            window.ShowDialog();
        }
    }
}