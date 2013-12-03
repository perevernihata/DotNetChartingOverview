using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using Plot;
using Color = Plot.Entities.Color;
using Image = System.Drawing.Image;

namespace FreeChartTools.Charting.OpenMindedPlot
{
    /// <summary>
    /// Official link - https://bitbucket.org/openminded/plot
    /// </summary>
    public class OpenMindedPlotAdapter : BaseChartAdapter
    {
        public OpenMindedPlotAdapter(ChartParameters parameters)
            : base(parameters)
        {
        }

        protected override Image DoCreateChartImage()
        {
            var plotter = new Plotter {Width = Parameters.ChartWidth, Height = Parameters.ChartHeight};
            plotter.Grid.Padding.Top = 20;
            plotter.Grid.Padding.Right = 20;
            plotter.Grid.Padding.Left = 40;
            plotter.Grid.Padding.Bottom = 40;
            plotter.Grid.MinDistance = 40;
            plotter.Graph.PointStyle.Radius = 3;
            plotter.Graph.PointTextStyle.Enabled = false;
            plotter.Title.TextStyle.Foreground = Color.DimGray;
            plotter.VerticalAxis.TextFormatter = v => ((int)v / 1000000).ToString(CultureInfo.InvariantCulture);
            plotter.OutputPath = HttpContext.Current.Server.MapPath("~/tmpImage.png");
            if (File.Exists(plotter.OutputPath))
                File.Delete(plotter.OutputPath);
            plotter.Print(Parameters.SeriaData.Select(d => (float)d.Key).ToArray(), Parameters.SeriaData.Select(d => (float)d.Value).ToArray());

            using (var fs = new FileStream(plotter.OutputPath, FileMode.Open, FileAccess.Read))
            {
                return Image.FromStream(fs);
            }
        }
    }
}