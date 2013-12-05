using ChartingCore;

namespace FreeChartTools.FreeCharting.MsCharting
{
    public class MicrosoftChartFactory : BaseChartFactory 
    {        
        public override IChartAdapter DoGenerateChart(ChartParameters parameters)
        {
            return new MicrosoftChartAdapter(parameters);
        }

        public override string ChartTypeName
        {
            get { return "Microsoft Chart Controls"; }
        }

        public override string DownloadLink
        {
            get { return "http://www.microsoft.com/ru-ru/download/details.aspx?id=14422"; }
        }

        public override SolutionType SolutionType
        {
            get { return SolutionType.Free; }
        }
    }
}