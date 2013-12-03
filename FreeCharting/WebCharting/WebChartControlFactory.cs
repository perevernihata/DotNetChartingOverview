using ChartingCore;

namespace FreeChartTools.FreeCharting.WebCharting
{
    /// <summary>
    /// BSD License 
    /// Official link - http://www.carlosag.net/tools/webchart/
    /// </summary>
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