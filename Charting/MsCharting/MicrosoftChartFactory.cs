namespace ChartTests.Charting.MsCharting
{
    public class MicrosoftChartFactory : BaseChartFactory 
    {        
        public override IChartWrapper DoGenerateChart(ChartParameters parameters)
        {
            return new MicrosoftChartWrapper(parameters);
        }

        public override string ChartTypeName
        {
            get { return "Microsoft Chart Controls"; }
        }
    }
}