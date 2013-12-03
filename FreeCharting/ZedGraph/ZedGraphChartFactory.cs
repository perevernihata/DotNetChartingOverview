
using ChartingCore;

namespace FreeChartTools.FreeCharting.ZedGraph
{
    /// <summary>
    /// GNU Lesser General Public License
    /// Official link - http://sourceforge.net/projects/zedgraph/
    /// </summary>
    public class ZedGraphChartFactory: BaseChartFactory
    {
        public override IChartAdapter DoGenerateChart(ChartParameters parameters)
        {
            return new ZedGraphChartAdapter(parameters);
        }

        public override string ChartTypeName
        {
            get { return "Zed Graph"; }
        }
    }
}