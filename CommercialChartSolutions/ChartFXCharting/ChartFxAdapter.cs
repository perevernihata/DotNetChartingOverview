using System.Data;
using System.Drawing;
using ChartingCore;

namespace ChartFXCharting
{
    /// <summary>
    /// You can download trial Chart FX binaries from here: http://www.softwarefx.com/sfxnetproducts/cfxlitefornet/
    /// </summary>
    public class ChartFxAdapter : BaseChartAdapter
    {
        public ChartFxAdapter(ChartParameters parameters)
            : base(parameters)
        {
        }

        protected override Image DoCreateChartImage()
        {
            var chart = new SoftwareFX.ChartFX.Lite.Chart
                {
                    Width = Parameters.ChartWidth,
                    Height = Parameters.ChartHeight
                };
            chart.Gallery = SoftwareFX.ChartFX.Lite.Gallery.Lines;            
            var ts = new DataTable();
            ts.Columns.Add(new DataColumn("x", typeof(int)));
            foreach (var pair in Parameters.SeriaData)
            {
                var row = ts.NewRow();
                row[0] = pair.Value;
                ts.Rows.Add(row);
            }
            chart.DataSource = ts;
            chart.RecalcScale();
            var result = new Bitmap(Parameters.ChartWidth, Parameters.ChartHeight);
            chart.DrawToBitmap(result, new Rectangle(0, 0, Parameters.ChartWidth, Parameters.ChartHeight));
            return result;
        }
    }
}