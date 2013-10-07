using System;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Charting;
using Telerik.Web.UI;

namespace ChartTests.SpecificChartFactories
{
    public class RadChartWrapper : Image
    {
        protected int DataPointsCount
        {
            get;
            set;
        }

        protected int MaxValue
        {
            get;
            set;
        }

        
        private ChartSeries GenerateSeria(int seed)
        {
            var tmpSeries = new ChartSeries() { Type = ChartSeriesType.Line };
            var random = new Random(seed);
            for (var i = 0; i < DataPointsCount; i++)
            {
                int randomx = random.Next(0, MaxValue);
                int randomy = random.Next(0, MaxValue);
                tmpSeries.Items.Add(new ChartSeriesItem(randomx, randomy));
            }
            return tmpSeries;
        }


        public RadChartWrapper(int maxValue, int dataPointsCount)
        {
            DataPointsCount = dataPointsCount;
            MaxValue = maxValue;
            var radChart = new RadChart();
            radChart.ChartTitle.TextBlock.Text = "Test Telerik Chart";
            radChart.AddChartSeries(GenerateSeria(radChart.GetHashCode()));
            var r = new Random(radChart.GetHashCode());
            var name = "tmp_radChart_" + r.Next(100000).ToString() + ".png";
            var junkfolder = HttpContext.Current.Server.MapPath(ChartUtils.JunkFolder);
            var path = Path.Combine(junkfolder, name);
            radChart.GetBitmap().Save(path, ImageFormat.Png);
            ImageUrl = string.Format("~/{0}/{1}",Path.GetFileName( Path.GetDirectoryName(path)), name);
        }
    }
}