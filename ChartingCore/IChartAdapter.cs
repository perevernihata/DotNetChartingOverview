using System.Drawing;

namespace ChartingCore
{
    public interface IChartAdapter
    {
        Image CreateChartImage();
        IChartFactory Owner { get; set; }
    }
}