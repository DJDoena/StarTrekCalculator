namespace DoenaSoft.STC
{
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Documents;

    partial class WarpDataTemplate
    {
        private void OnLinkClicked(object sender, RoutedEventArgs e)
        {
            var url = ((Hyperlink)sender).NavigateUri.ToString();

            Process.Start(url);
        }
    }
}