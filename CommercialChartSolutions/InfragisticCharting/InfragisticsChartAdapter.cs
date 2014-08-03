using System.Drawing;
using System.Drawing.Imaging;
using ChartingCore;
using Infragistics.UltraChart.Resources.Appearance;
using Infragistics.UltraChart.Shared.Styles;
using Infragistics.WebUI.UltraWebChart;
using System.IO;

namespace InfragisticCharting
{
    /// <summary>
    /// Commercial
    /// http://www.infragistics.com/products/aspnet
    /// </summary>
    public class InfragisticsChartAdapter : BaseChartAdapter
    {
        public InfragisticsChartAdapter(ChartParameters parameters)
            : base(parameters)
        {
        }

        protected override Image DoCreateChartImage()
        {
            var chart = new UltraChart {ChartType = ChartType.LineChart};
            var sc1 = new NumericSeries();
            foreach (var valuePair in Parameters.SeriaData)
            {
                sc1.Points.Add(new NumericDataPoint(valuePair.Key, valuePair.Value.ToString(), false));
            }
            chart.Series.Add(sc1);
            chart.Height = Parameters.ChartHeight;
            chart.Width = Parameters.ChartWidth;
            using (var stream = new MemoryStream())
            {
                chart.SaveTo(stream, ImageFormat.Png);
                return new Bitmap(stream);
            }
        }
    }
}