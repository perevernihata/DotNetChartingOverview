using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ChartingCore;
using DevExpress.XtraCharts;
using System.Linq;

namespace DevExpressCharting
{
    /// <summary>
    /// You can download trial Dev Express binaries from here: https://www.devexpress.com/Home/try.xml
    /// </summary>
    public class DevExpressChartAdapter : BaseChartAdapter
    {
        public DevExpressChartAdapter(ChartParameters parameters)
            : base(parameters)
        {
        }

        protected override Image DoCreateChartImage()
        {
            using (var chart = new ChartControl())
            {
                var series1 = new Series("Series 1", ViewType.Line);
                series1.Points.AddRange(Parameters.SeriaData.Select(p => new SeriesPoint(p.Key,p.Value)).ToArray());
                chart.Series.Add(series1);
                chart.Width = Parameters.ChartWidth;
                chart.Height = Parameters.ChartHeight;
                using (var stream = new MemoryStream())
                {
                    chart.ExportToImage(stream, ImageFormat.Png);
                    return Image.FromStream(stream);
                }
            }
        }
    }
}
