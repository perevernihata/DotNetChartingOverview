using System;

namespace ChartTests.Charting
{
    public interface IChartFactory
    {
        IChartAdapter GenerateChart(ChartParameters parameters);
        string ChartTypeName { get; }
        Guid Id { get; }
    }
}