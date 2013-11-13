using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;

namespace ChartTests.Charting.MsCharting
{
    public class MicrosoftChartWrapper : BaseChartWrapper
    {
        public MicrosoftChartWrapper(ChartParameters parameters) : base(parameters)
        {
        }

        private Series  GenerateSeria()
        {
            var tmpSeries = new Series
                {
                ChartType = SeriesChartType.Line,
                Color = Color.Red
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
            var tmpChartArea = new ChartArea("test area");
            testChart.ChartAreas.Add(tmpChartArea);
            testChart.Legends.Add(new Legend("testLegend"));
            testChart.Series.Add(tmpSeria);
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