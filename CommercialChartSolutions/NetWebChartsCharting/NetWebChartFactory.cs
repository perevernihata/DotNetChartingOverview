using ChartingCore;

namespace NetWebChartsCharting
{
    /// <summary>
    /// You can download trial NetWebChart binaries from here: http://www.advsofteng.com/download.html
    /// </summary>
    public class NetWebChartFactory : BaseChartFactory
    {
        public override IChartAdapter DoGenerateChart(ChartParameters parameters)
        {
            return new NetWebChartAdapter(parameters);
        }

        public override string ChartTypeName
        {
            get { return "ChartDirector"; }
        }

        public override string DownloadLink
        {
            get { return "http://www.advsofteng.com/download.html"; }
        }
    }
}
