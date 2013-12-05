using ChartingCore;

namespace FreeChartTools.FreeCharting.GoogleSharpCharting
{
    /// <summary>
    /// Open Source https://code.google.com/p/googlechartsharp/
    /// </summary>
    public class GoogleSharpChartFactory: BaseChartFactory
    {
        public override IChartAdapter DoGenerateChart(ChartParameters parameters)
        {
            return new GoogleSharpAdapter(parameters);
        }

        public override string ChartTypeName
        {
            get { return "Google Sharp charting"; }
        }

        public override string DownloadLink
        {
            get { return "https://code.google.com/p/googlechartsharp/"; }
        }
    }
}