using System;
using System.Drawing;
using System.IO;
using System.Web;
using ChartingCore;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraCharts.Web;
using ScaleType = DevExpress.XtraCharts.ScaleType;
using Series = DevExpress.XtraCharts.Series;
using SeriesPoint = DevExpress.XtraCharts.SeriesPoint;

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
            WebChartControl WebChartControl1 = new WebChartControl();

            // Add the chart to the form. 
            // Note that a chart isn't initialized until it's added to the form's collection of controls. 

            // Create a line series and add points to it. 
            Series series1 = new Series("My Series", ViewType.Line);
            series1.Points.Add(new SeriesPoint("A", new double[] { 2 }));
            series1.Points.Add(new SeriesPoint("B", new double[] { 7 }));
            series1.Points.Add(new SeriesPoint("C", new double[] { 5 }));
            series1.Points.Add(new SeriesPoint("D", new double[] { 9 }));
            WebChartControl1.Series.Add(series1);
            var tmpFileName = HttpContext.Current.Server.MapPath("~/tmpImage.png");
            if (File.Exists(tmpFileName))
                File.Delete(tmpFileName);
            // Add the series to the chart. 
            ((IChartContainer)WebChartControl1).Chart.ExportToImage(tmpFileName, System.Drawing.Imaging.ImageFormat.Png);

            using (var fs = new FileStream(tmpFileName, FileMode.Open, FileAccess.Read))
            {
                return Image.FromStream(fs);
            }
        }
    }
}
