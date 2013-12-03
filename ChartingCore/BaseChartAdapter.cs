using System.Drawing;

namespace ChartingCore
{
    public abstract class BaseChartAdapter: IChartAdapter
    {
        protected ChartParameters Parameters { get; private set; }
        protected BaseChartAdapter(ChartParameters parameters)
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