using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using ChartingCore;
using Telerik.Charting;
using Telerik.Web.UI;

namespace TelerikCharting
{
    /// <summary>
    /// You can download trial Telerik binaries from here: http://www.telerik.com/products/aspnet-ajax/chart.aspx
    /// </summary>
    public class TelerikChartAdapter: BaseChartAdapter
    {
        public TelerikChartAdapter(ChartParameters parameters) : base(parameters)
        {
        }

        protected override Image DoCreateChartImage()
        {
            var radChart = new RadChart {Width = Parameters.ChartWidth, Height = Parameters.ChartHeight};
            var tmpSeries = new ChartSeries() { Type = ChartSeriesType.Line };
            foreach (var point in Parameters.SeriaData)
                tmpSeries.Items.Add(new ChartSeriesItem(point.Key, point.Value));
            radChart.AddChartSeries(tmpSeries);
            return radChart.GetBitmap();
        }
    }
}
