using System;
using System.Drawing;
using System.IO;

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
            try
            {
                return DoCreateChartImage();
            }
            catch (FileNotFoundException e)
            {
                var tmpImage = new Bitmap(Parameters.ChartWidth, Parameters.ChartWidth);
                return tmpImage;
            }
        }

    }
}