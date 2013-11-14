using System.Drawing;

namespace ChartTests.Charting
{
    public abstract class BaseChartWrapper: IChartWrapper
    {
        protected ChartParameters Parameters { get; private set; }
        protected BaseChartWrapper(ChartParameters parameters)
        {
            Parameters = parameters;
        }

        protected abstract Image DoCreateChartImage();
        public Image CreateChartImage()
        {
                return DoCreateChartImage();
        }

    }
}