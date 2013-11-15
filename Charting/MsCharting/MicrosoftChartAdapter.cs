using System.Drawing;
using System.IO;
using System.Web.UI.DataVisualization.Charting;

namespace FreeChartTools.Charting.MsCharting
{
    public class MicrosoftChartAdapter : BaseChartAdapter
    {
        public MicrosoftChartAdapter(ChartParameters parameters) : base(parameters)
        {
        }

        private Series  GenerateSeria()
        {
            var tmpSeries = new Series
                {
                ChartType = SeriesChartType.Line
            };
            foreach (var point in Parameters.SeriaData)
            {
                tmpSeries.Points.Add(new DataPoint(point.Key, point.Value));
            }
            return tmpSeries;
        }


        private Chart GenerateChartConrol()
        {
            var testChart = new Chart { ImageStorageMode = ImageStorageMode.UseImageLocation };
            var tmpSeria = GenerateSeria();
            var tmpChartArea = new ChartArea("");
            testChart.ChartAreas.Add(tmpChartArea);
            testChart.Legends.Add(new Legend(""));
            testChart.Series.Add(tmpSeria);
            testChart.Width = Parameters.ChartWidth;
            testChart.Height = Parameters.ChartHeight;
            return testChart;
        }

        protected override Image DoCreateChartImage()
        {
            return GenerateChartConrol().ToImage();
        }
    }

    internal static class MsChartHelper
    {
        internal static Image ToImage(this Chart chart)
        {
            var imageStream = new MemoryStream();
            chart.SaveImage(imageStream);
            return new Bitmap(imageStream);
        }
    }
}