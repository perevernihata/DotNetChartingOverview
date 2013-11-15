
namespace FreeChartTools.Charting.OxyPlotCharting
{
    public class OxyPlotChartFactory: BaseChartFactory
    {
        public override IChartAdapter DoGenerateChart(ChartParameters parameters)
        {
            return new OxyPlotAdapter(parameters);
        }

        public override string ChartTypeName
        {
            get { return "Oxy Plot"; }
        }
    }
}