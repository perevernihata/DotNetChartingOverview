using ChartingCore;

namespace FreeChartTools.FreeCharting.OxyPlotCharting
{
    /// <summary>
    /// The MIT License (MIT)
    /// Official link - http://oxyplot.codeplex.com/
    /// </summary>
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

        public override string DownloadLink
        {
            get { return "http://oxyplot.codeplex.com/releases/view/76035"; }
        }

        public override SolutionType SolutionType
        {
            get { return SolutionType.Free; }
        }
    }
}