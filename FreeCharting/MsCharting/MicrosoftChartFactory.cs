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
    }
}