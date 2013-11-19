
namespace FreeChartTools.Charting.DisLinCharting
{
    public class DislinChartFactory: BaseChartFactory
    {
        public override IChartAdapter DoGenerateChart(ChartParameters parameters)
        {
            return new DislinChartAdapter(parameters);
        }

        public override string ChartTypeName
        {
            get { return "Dislin charts"; }
        }
    }
}