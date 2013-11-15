
namespace FreeChartTools.Charting.ChartFXCharting
{
    public class ChartFxFactory: BaseChartFactory
    {
        public override IChartAdapter DoGenerateChart(ChartParameters parameters)
        {
            return new ChartFxAdapter(parameters);
        }

        public override string ChartTypeName
        {
            get { return "Chart FX"; }
        }
    }
}