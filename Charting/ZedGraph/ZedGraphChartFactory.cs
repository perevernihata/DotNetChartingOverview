
namespace FreeChartTools.Charting.ZedGraph
{
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