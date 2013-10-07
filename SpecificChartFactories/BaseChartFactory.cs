using System;
using System.IO;
using System.Web.UI;

namespace ChartTests.SpecificChartFactories
{
    public abstract class BaseChartFactory : IChartFactory
    {
        protected int MaxValue { get; set; }
        protected int DataPointsCount { get; set; }
        public abstract Control DoGenerateChartConrol();

        public Control GenerateChartConrol(int maxValue, int dataPointsCount)
        {
            MaxValue = maxValue;
            DataPointsCount = dataPointsCount;
            return DoGenerateChartConrol();
        }

        public abstract string ChartName { get; }
    }
}