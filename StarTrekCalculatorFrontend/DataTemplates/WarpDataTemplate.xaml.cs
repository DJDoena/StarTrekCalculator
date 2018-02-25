using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;

namespace DoenaSoft.STC
{
    partial class WarpDataTemplate
    {
        void OnLinkClicked(object sender, RoutedEventArgs e)
        {
            string url = ((Hyperlink)sender).NavigateUri.ToString();

            Process.Start(url);
        }
    }
}