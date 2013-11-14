namespace ChartTests.Charting.NPlotCharting
{
    public class NPlotChartFactory: BaseChartFactory
    {
        public override IChartAdapter DoGenerateChart(ChartParameters parameters)
        {
            return new NPlotChartAdapter(parameters);
        }

        public override string ChartTypeName
        {
            get { return "NPlot"; }
        }
    }
}