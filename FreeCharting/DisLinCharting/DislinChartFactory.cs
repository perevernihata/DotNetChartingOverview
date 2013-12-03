using ChartingCore;

namespace FreeChartTools.FreeCharting.DisLinCharting
{
    /// <summary>
    /// Free for non-commercial use
    /// </summary>
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