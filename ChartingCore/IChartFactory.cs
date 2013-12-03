using System;

namespace ChartingCore
{
    public interface IChartFactory
    {
        IChartAdapter GenerateChart(ChartParameters parameters);
        string ChartTypeName { get; }
        Guid Id { get; }
    }
}