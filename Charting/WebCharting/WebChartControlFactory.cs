namespace FreeChartTools.Charting.WebCharting
{
    public class WebChartControlFactory: BaseChartFactory
    {
        public override IChartAdapter DoGenerateChart(ChartParameters parameters)
        {
            return new WebChartAdapter(parameters);
        }

        public override string ChartTypeName
        {
            get { return "Web Chart Control"; }
        }
    }
}