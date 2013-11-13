namespace ChartTests.Charting.WebCharting
{
    public class WebChartControlFactory: BaseChartFactory
    {
        public override IChartWrapper DoGenerateChart(ChartParameters parameters)
        {
            return new WebChartWrapper(parameters);
        }

        public override string ChartTypeName
        {
            get { return "Web Chart Control"; }
        }
    }
}