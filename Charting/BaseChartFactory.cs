using System;

namespace ChartTests.Charting
{
    public abstract class BaseChartFactory : IChartFactory
    {
        public abstract IChartWrapper DoGenerateChart(ChartParameters parameters);

        public Guid Id
        {
            get { return GetType().GUID; }
        }

        public IChartWrapper GenerateChart(ChartParameters parameters)
        {
            return DoGenerateChart(parameters);
        }

        public abstract string ChartTypeName { get; }
    }
}