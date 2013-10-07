using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;

namespace ChartTests.SpecificChartFactories
{
    public class MicrosoftChartFactory : BaseChartFactory 
    {
        private Series GenerateSeria(int seed)
        {
            var tmpSeries = new Series("Disc to Ord")
                {
                    ChartType = SeriesChartType.Line,
                    Color = Color.Red
                };            
            var random = new Random(seed);
            for (var i = 0; i < DataPointsCount; i++)
            {
                int randomx = random.Next(0, MaxValue);
                int randomy = random.Next(0, MaxValue);
                tmpSeries.Points.Add(new DataPoint(randomx, randomy));
            }
            return tmpSeries;
        }

        private Chart GenerateChart()
        {
            var testChart = new Chart { ImageStorageMode = ImageStorageMode.UseImageLocation };
            var tmpSeria = GenerateSeria(testChart.GetHashCode());
            var tmpChartArea = new ChartArea("test area");
            testChart.ChartAreas.Add(tmpChartArea);
            testChart.Legends.Add(new Legend("testLegend"));
            testChart.Series.Add(tmpSeria);
            return testChart;
        }

        public override Control DoGenerateChartConrol()
        {
            return GenerateChart();
        }

        public override string ChartName
        {
            get { return "Microsoft Chart Controls"; }
        }
    }
}