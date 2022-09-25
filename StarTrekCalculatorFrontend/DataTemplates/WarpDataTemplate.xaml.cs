namespace DoenaSoft.STC
{
    using System.Diagnostics;
    using System.IO;
    using System.Windows;
    using System.Windows.Media.Imaging;
    using Resources;

    public partial class WarpDataTemplate
    {
        private void OnLinkClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var image = (BitmapImage)((new Images())["WarpChart"]);

                var fileName = Path.Combine(Path.GetTempPath(), "warpchart.jpg");

                var encoder = new PngBitmapEncoder();

                encoder.Frames.Add(BitmapFrame.Create(image));

                using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    encoder.Save(fileStream);
                }

                Process.Start(fileName);
            }
            catch
            {
                MessageBox.Show("Could not open image!");
            }
        }
    }
}