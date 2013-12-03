using System;

namespace ChartingCore
{
    public abstract class BaseChartFactory : IChartFactory
    {
        public abstract IChartAdapter DoGenerateChart(ChartParameters parameters);

        public Guid Id
        {
            get { return GetType().GUID; }
        }

        public IChartAdapter GenerateChart(ChartParameters parameters)
        {
            return DoGenerateChart(parameters);
        }

        public abstract string ChartTypeName { get; }
    }
}