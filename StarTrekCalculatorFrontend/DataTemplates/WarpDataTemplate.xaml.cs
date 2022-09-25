namespace DoenaSoft.StarTrekCalculatorApp
{
    using System.Diagnostics;
    using System.IO;
    using System.Windows;
    using Calc = StarTrekCalculator;

    public partial class WarpDataTemplate
    {
        private void OnLinkClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var image = Calc.Images.GetWarpChartJpeg())
                {
                    var fileName = Path.Combine(Path.GetTempPath(), "warpchart.jpg");

                    using (var fileStream = File.Create(fileName))
                    {
                        var buffer = new byte[8192];

                        int bytesRead;
                        while ((bytesRead = image.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, bytesRead);
                        }
                    }

                    Process.Start(fileName);
                }
            }
            catch
            {
                MessageBox.Show("Could not open image!");
            }
        }
    }
}