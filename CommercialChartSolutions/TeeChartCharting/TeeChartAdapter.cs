using System.Drawing;
using ChartingCore;
using Steema.TeeChart;
using Steema.TeeChart.Styles;

namespace TeeChartCharting
{
    /// <summary>
    /// You can download trial Tee chart binaries from here: https://www.steema.com/download/net
    /// </summary>
    public class TeeChartAdapter: BaseChartAdapter
    {
        public TeeChartAdapter(ChartParameters parameters) : base(parameters)
        {
        }

        protected override Image DoCreateChartImage()
        {
            var chart = new Chart();
            var seria = new Line(chart);
            foreach (var point in Parameters.SeriaData)
                seria.Add(point.Key, point.Value);
            chart.Series.Add(seria);
            return chart.Bitmap(Parameters.ChartWidth, Parameters.ChartHeight);
        }
    }
}
