using System.Drawing;
using System.Linq;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;
using LineSeries = OxyPlot.Series.LineSeries;
using LinearAxis = OxyPlot.Axes.LinearAxis;

namespace FreeChartTools.Charting.OxyPlotCharting
{
    /// <summary>
    /// The MIT License (MIT)
    /// Official link - http://oxyplot.codeplex.com/
    /// </summary>
    public class OxyPlotAdapter : BaseChartAdapter
    {
        public OxyPlotAdapter(ChartParameters parameters)
            : base(parameters)
        {

        }

        protected override Image DoCreateChartImage()
        {
            var plotModel = new PlotModel("");
            var ls = new LineSeries("")
                {
                    Points = Parameters.SeriaData.Select(t => new DataPoint(t.Key, t.Value) as IDataPoint).ToList()
                };
            plotModel.Series.Add(ls);
            plotModel.Axes.Add(new LinearAxis(AxisPosition.Left));
            plotModel.Axes.Add(new LinearAxis(AxisPosition.Bottom));
            var bitmap = new Bitmap(Parameters.ChartWidth, Parameters.ChartHeight);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                var graphicsRenderContext = new GraphicsRenderContext { RendersToScreen = false };
                graphicsRenderContext.SetGraphicsTarget(graphics);
                plotModel.Update();
                plotModel.Render(graphicsRenderContext, Parameters.ChartWidth, Parameters.ChartHeight);
                return bitmap;
            }
        }
    }
}