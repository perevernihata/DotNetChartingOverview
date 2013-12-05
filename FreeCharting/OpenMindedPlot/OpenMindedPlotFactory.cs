using ChartingCore;

namespace FreeChartTools.FreeCharting.OpenMindedPlot
{
    /// <summary>
    /// Official link - https://bitbucket.org/openminded/plot
    /// </summary>
    public class OpenMindedPlotFactory: BaseChartFactory
    {
        public override IChartAdapter DoGenerateChart(ChartParameters parameters)
        {
            return new OpenMindedPlotAdapter(parameters);
        }

        public override string ChartTypeName
        {
            get { return "Open minded plot"; }
        }

        public override string DownloadLink
        {
            get { return "https://bitbucket.org/openminded/plot"; }
        }
    }
}