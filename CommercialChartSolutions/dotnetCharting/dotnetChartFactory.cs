using ChartingCore;

namespace dotnetChartingLibrary
{
    /// <summary>
    /// Commercial
    /// </summary>
    public class DotnetChartFactory : BaseChartFactory
    {
        public override IChartAdapter DoGenerateChart(ChartParameters parameters)
        {
            return new DotnetChartAdapter(parameters);
        }

        public override string ChartTypeName
        {
            get { return "dotnetCharting"; }
        }

        public override string DownloadLink
        {
            get { return "http://www.dotnetcharting.com/download.aspx"; }
        }

        public override SolutionType SolutionType
        {
            get { return SolutionType.Commercial; }
        }

    }
}