using ChartingCore;

namespace InfragisticCharting
{
    /// <summary>
    /// Commercial
    /// http://www.infragistics.com/products/aspnet
    /// </summary>
    public class InfragisticsFactory : BaseChartFactory
    {
        public override IChartAdapter DoGenerateChart(ChartParameters parameters)
        {
            return new InfragisticsChartAdapter(parameters);
        }

        public override string ChartTypeName
        {
            get { return "Infragistics chart"; }
        }

        public override string DownloadLink
        {
            get { return "http://www.infragistics.com/products/aspnet"; }
        }

        public override SolutionType SolutionType
        {
            get { return SolutionType.Commercial; }
        }
    }
}