using ChartingCore;

namespace ILNumericsCharting
{
    /// <summary>
    /// You can download ILNumerics sources from here: http://ilnumerics.net/download-ilnumerics.html
    /// </summary>
    public class ILNumericsChartingFactory : BaseChartFactory
    {
        public override IChartAdapter DoGenerateChart(ChartParameters parameters)
        {
            return new ILNumericsChartingAdapter(parameters);
        }

        public override string ChartTypeName
        {
            get { return "ILNumerics"; }
        }
    }
}
