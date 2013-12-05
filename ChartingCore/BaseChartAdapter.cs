using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace ChartingCore
{
    public abstract class BaseChartAdapter: IChartAdapter
    {
        private const string AssemblyMissingMessage = @"Unable to show this chart, because assembly {0} isn't avalialble. Try to download it{1}, and add to the 'bin' folder. {2}";

        protected ChartParameters Parameters { get; private set; }
        protected BaseChartAdapter(ChartParameters parameters)
        {
            Parameters = parameters;
        }

        protected abstract Image DoCreateChartImage();
        public Image CreateChartImage()
        {
            try
            {
                return DoCreateChartImage();
            }
            catch (FileNotFoundException e)
            {
                var tmpImage = new Bitmap(Parameters.ChartWidth, Parameters.ChartWidth);
                using (var g = Graphics.FromImage(tmpImage))
                {
                    g.Clear(Color.White);
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    var rectf = new RectangleF(Parameters.ChartWidth * 0.1f, Parameters.ChartHeight * 0.1f, Parameters.ChartWidth * 0.9f, Parameters.ChartHeight * 0.9f);
                    var downloadLinkStr = Owner == null ? String.Empty : String.Format(" from '{0}'", Owner.DownloadLink);
                    var commercialMessage = "";
                    if (Owner != null && Owner.SolutionType == SolutionType.Commercial)
                        commercialMessage = "Since this is commercial solution, we are not able to ship it with this project. You should download it by yourself.";
                    g.DrawString(String.Format(AssemblyMissingMessage, e.FileName, downloadLinkStr, commercialMessage), new Font("Arial", 11), Brushes.Black, rectf);
                    g.Flush();
                }
                return tmpImage;
            }
        }

        public IChartFactory Owner { get; set; }
    }
}