using System.Drawing;
using System.Linq;
using NPlot;
using PlotSurface2D = NPlot.Bitmap.PlotSurface2D;

namespace FreeChartTools.Charting.NPlotCharting
{
    public class NPlotChartAdapter: BaseChartAdapter
    {
        public NPlotChartAdapter(ChartParameters parameters) : base(parameters)
        {
        }

        protected override Image DoCreateChartImage()
        {
            var surface = new PlotSurface2D(Parameters.ChartWidth, Parameters.ChartHeight);
            var plot = new LinePlot
                {
                    OrdinateData = Parameters.SeriaData.Select(t => t.Key).ToArray(),
                    AbscissaData = Parameters.SeriaData.Select(t => t.Value).ToArray()
                };
            surface.Add(plot);
            surface.Refresh();
            return surface.Bitmap;
        }
    }
}