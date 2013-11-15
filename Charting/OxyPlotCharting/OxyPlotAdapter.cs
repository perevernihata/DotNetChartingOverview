using System.Drawing;
using System.Linq;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;
using LineSeries = OxyPlot.Series.LineSeries;
using LinearAxis = OxyPlot.Axes.LinearAxis;

namespace FreeChartTools.Charting.OxyPlotCharting
{
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
            plotModel.Axes.Add(new LinearAxis(AxisPosition.Left, -4, 4));
            plotModel.Axes.Add(new LinearAxis(AxisPosition.Bottom));
            var bitmap = new Bitmap(Parameters.ChartWidth, Parameters.ChartHeight);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                var graphicsRenderContext1 = new GraphicsRenderContext();
                graphicsRenderContext1.RendersToScreen = false;
                var graphicsRenderContext2 = graphicsRenderContext1;
                graphicsRenderContext2.SetGraphicsTarget(graphics);
                plotModel.Update();
                plotModel.Render(graphicsRenderContext2, Parameters.ChartWidth, Parameters.ChartHeight);
                return bitmap;
            }
        }
    }
}