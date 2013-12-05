using ChartingCore;

namespace TeeChartCharting
{
    /// <summary>
    /// You can download trial Tee chart binaries from here: https://www.steema.com/download/net
    /// </summary>
    public class TeeChartFactory: BaseChartFactory
    {
        public override IChartAdapter DoGenerateChart(ChartParameters parameters)
        {
            return new TeeChartAdapter(parameters);
        }

        public override string ChartTypeName
        {
            get { return "Tee charts"; }
        }

        public override string DownloadLink
        {
            get { return "https://www.steema.com/download/net"; }
        }
    }
}
