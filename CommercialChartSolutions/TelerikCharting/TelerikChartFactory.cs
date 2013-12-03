using ChartingCore;

namespace TelerikCharting
{
    public class TelerikChartFactory: BaseChartFactory
    {
        public override IChartAdapter DoGenerateChart(ChartParameters parameters)
        {
            return new TelerikChartAdapter(parameters);
        }

        public override string ChartTypeName
        {
            get { return "Telerik charts"; }
        }
    }
}
