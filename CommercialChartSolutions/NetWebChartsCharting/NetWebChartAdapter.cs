using System;
using System.Linq;
using System.Drawing;
using ChartDirector;
using ChartingCore;

namespace NetWebChartsCharting
{
    /// <summary>
    /// You can download trial NetWebChart binaries from here: http://www.advsofteng.com/download.html
    /// </summary>
    public class NetWebChartAdapter: BaseChartAdapter
    {
        public NetWebChartAdapter(ChartParameters parameters) : base(parameters)
        {
        }

        protected override Image DoCreateChartImage()
        {
            var chart = new XYChart(Parameters.ChartWidth, Parameters.ChartHeight);
            chart.setPlotArea(30, 20, (int)Math.Round(Parameters.ChartWidth - (Parameters.ChartWidth * 0.2)), (int)Math.Round(Parameters.ChartHeight - (Parameters.ChartHeight * 0.2)));
            chart.addLineLayer(Parameters.SeriaData.Select(p => (double)p.Key).ToArray());
            chart.xAxis().setLabelStep(3);
            return chart.makeImage();
        }
    }
}
