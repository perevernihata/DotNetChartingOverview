using ChartingCore;

namespace DevExpressCharting
{
    /// <summary>
    /// You can download trial Dev Express binaries from here: https://www.devexpress.com/Home/try.xml
    /// </summary>
    public class DevExpressChartFactory: BaseChartFactory
    {
        public override IChartAdapter DoGenerateChart(ChartParameters parameters)
        {
            return new DevExpressChartAdapter(parameters);
        }

        public override string ChartTypeName
        {
            get { return "DevExpress"; }
        }

        public override string DownloadLink
        {
            get { return "https://www.devexpress.com/Home/try.xml"; }
        }
    }
}
