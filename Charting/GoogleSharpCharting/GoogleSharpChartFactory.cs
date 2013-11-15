namespace FreeChartTools.Charting.GoogleSharpCharting
{
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
    }
}