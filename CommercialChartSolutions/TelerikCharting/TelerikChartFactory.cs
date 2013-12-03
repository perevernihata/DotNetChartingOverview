using ChartingCore;

namespace TelerikCharting
{
    /// <summary>
    /// You can download trial Telerik binaries from here: http://www.telerik.com/products/aspnet-ajax/chart.aspx
    /// </summary>
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
