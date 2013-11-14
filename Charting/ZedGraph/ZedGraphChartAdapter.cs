using System.Drawing;
using System.Linq;
using ZedGraph;

namespace ChartTests.Charting.ZedGraph
{
    public class ZedGraphChartAdapter : BaseChartAdapter
    {
        public ZedGraphChartAdapter(ChartParameters parameters)
            : base(parameters)
        {
        }

        protected override Image DoCreateChartImage()
        {
            var pg = new GraphPane();
            var seria = new PointPairList();
            foreach (var pointPair in Parameters.SeriaData.Select(p => new PointPair(p.Key, p.Value)))
            {
                seria.Add(pointPair);
            }
            pg.AddCurve("Test", seria, Color.Red, SymbolType.Diamond);
            pg.AxisChange();
            Image tmpImage = new Bitmap(Parameters.ChartWidth, Parameters.ChartHeight);
            var g = Graphics.FromImage(tmpImage);
            pg.ReSize(g, new RectangleF(0, 0, Parameters.ChartWidth, Parameters.ChartHeight));
            pg.Draw(g);
            return tmpImage;
        }
    }
}