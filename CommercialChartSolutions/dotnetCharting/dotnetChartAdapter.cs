using ChartingCore;
using dotnetCHARTING;
using System.Drawing;

namespace dotnetChartingLibrary
{
    /// <summary>
    /// Free for non-commercial use
    /// </summary>
    public class DotnetChartAdapter : BaseChartAdapter
    {
        public DotnetChartAdapter(ChartParameters parameters)
            : base(parameters)
        {
        }

        protected override Image DoCreateChartImage()
        {
            var chart = new Chart();
            chart.Type = ChartType.Combo;
            chart.Width = Parameters.ChartWidth;
            chart.Height = Parameters.ChartHeight;
            chart.Series.Data = Parameters.SeriaData;
            var seriesCollection = new SeriesCollection();
            var s = new Series("", SeriesType.Line);
            foreach (var pair in Parameters.SeriaData)
            {
                s.Elements.Add(new Element()
                {
                    YValue = pair.Key,
                    XValue = pair.Value
                });
            }
            seriesCollection.Add(s);
            chart.SeriesCollection.Add(seriesCollection);

            return chart.GetChartBitmap();
        }
    }
}