using System;
using System.Web.UI;
using WebChart;

namespace ChartTests.SpecificChartFactories
{
    public class WebChartControlFactory: BaseChartFactory
    {
        private ChartPointCollection GenerateChartPointCollection(int seed)
        {
            var dataArray = new ChartPoint[DataPointsCount];
            var random = new Random(seed);
            for (var i = 0; i < DataPointsCount; i++)
            {
                int randomx = random.Next(0, MaxValue);
                int randomy = random.Next(0, MaxValue);
                dataArray[i] = new ChartPoint(randomx.ToString(), randomy);
            }
            return new ChartPointCollection(dataArray);
        }


        public override Control DoGenerateChartConrol()
        {
            var chartControl = new ChartControl();
            var dataArray = new ChartPoint[DataPointsCount];
            for (int i = 0; i < dataArray.Length; i++)
            {
                dataArray[i] = new ChartPoint("10", 10);
            }
            chartControl.Charts.Add(new LineChart(GenerateChartPointCollection(chartControl.GetHashCode())));
            
            chartControl.RedrawChart();
            return chartControl;
        }

        public override string ChartName
        {
            get { return "Web Chart Control"; }
        }
    }
}