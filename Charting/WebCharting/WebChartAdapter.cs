using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using WebChart;

namespace ChartTests.Charting.WebCharting
{
    public class WebChartAdapter : BaseChartAdapter
    {
        public WebChartAdapter(ChartParameters parameters)
            : base(parameters)
        {
        }

        private ChartPointCollection GenerateChartPointCollection()
        {
            var dataArray = new List<ChartPoint>();
            foreach (var point in Parameters.SeriaData)
            {
                dataArray.Add(new ChartPoint(point.Key.ToString(CultureInfo.InvariantCulture), point.Value));
            }
            return new ChartPointCollection(dataArray.ToArray());
        }

        protected override Image DoCreateChartImage()
        {
            var webChart = new LineChart(GenerateChartPointCollection());
            webChart.Engine = new ChartEngine();
            webChart.Engine.Size = new Size(Parameters.ChartWidth, Parameters.ChartHeight);
            webChart.Engine.Charts = new ChartCollection(webChart.Engine);
            webChart.Engine.Charts.Add(webChart);
            return webChart.Engine.GetBitmap();
        }
    }
}