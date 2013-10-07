
using System.Web.UI;

namespace ChartTests
{
    public interface IChartFactory
    {
        Control GenerateChartConrol(int maxValue, int dataPointsCount);
        string ChartName { get; }
    }
}