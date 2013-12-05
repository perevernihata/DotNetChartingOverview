using ChartingCore;

namespace FreeChartTools.FreeCharting.NPlotCharting
{
    /// <summary>
    /// BSD License 
    /// Official link - http://sourceforge.net/projects/nplot/
    /// </summary>
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

        public override string DownloadLink
        {
            get { return "http://sourceforge.net/projects/nplot/"; }
        }
    }
}